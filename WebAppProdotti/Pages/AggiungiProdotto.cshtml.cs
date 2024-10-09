using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace WebAppProdotti.Pages
{
    public class AggiungiProdottoModel : PageModel
    {
        private readonly ILogger<AggiungiProdottoModel> _logger; // Logger per registrare messaggi di errore o informativi

        // Costruttore della classe
        public AggiungiProdottoModel(ILogger<AggiungiProdottoModel> logger)
        {
            _logger = logger; // Inizializza il logger
        }

        // Prodotto da aggiungere, bindato automaticamente dal form
        [BindProperty]
        public Prodotto Prodotto { get; set; }

        // Codice di sicurezza per l'aggiunta del prodotto
        [BindProperty]
        [Required(ErrorMessage = "required field!.")] // Validazione del campo Codice
        public string Codice { get; set; }

        // Lista delle categorie di prodotto
        public List<string> Categorie { get; set; }

        // Metodo chiamato quando la pagina viene caricata
        public void OnGet()
        {
            // Percorso del file JSON che contiene i prodotti
            var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/json/prodotti.json");

            // Verifica se il file esiste
            if (System.IO.File.Exists(jsonFilePath))
            {
                try
                {
                    // Legge il contenuto del file JSON
                    var json = System.IO.File.ReadAllText(jsonFilePath);
                    // Deserializza il JSON in una lista di prodotti
                    var tuttiProdotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
                    // Estrae le categorie uniche dai prodotti
                    Categorie = tuttiProdotti?.Select(p => p.Categoria).Distinct().ToList() ?? new List<string>();
                }
                catch (JsonReaderException jsonEx) // Gestione delle eccezioni per errori nella lettura del JSON
                {
                    _logger.LogError("Errore nella lettura del file JSON: " + jsonEx.Message);
                    Categorie = new List<string>(); // Imposta la lista vuota in caso di errore
                }
                catch (Exception ex) // Gestione di altre eccezioni generali
                {
                    _logger.LogError("Errore imprevisto: " + ex.Message);
                    Categorie = new List<string>();
                }
            }
            else
            {
                // Messaggio di errore se il file non viene trovato
                _logger.LogError("File prodotti.json non trovato.");
                Categorie = new List<string>(); // Imposta la lista vuota se il file non esiste
            }
        }

        // Metodo chiamato quando il form viene inviato
        public IActionResult OnPost()
        {
            try
            {
                // Verifica se il codice di sicurezza è corretto
                if (Codice != "1234") // Cambia "1234" con il tuo codice di sicurezza
                {
                    return RedirectToPage("Error", new { message = "Codice di sicurezza non valido." }); // Reindirizza in caso di codice errato
                }

                // Percorso del file JSON
                var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/json/prodotti.json");
                List<Prodotto> prodotti;

                // Legge i prodotti dal file JSON
                var json = System.IO.File.ReadAllText(jsonFilePath);
                prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json) ?? new List<Prodotto>(); // Se il file è vuoto, inizializza una lista vuota

                // Aggiungi il nuovo prodotto
                int id = 1; // Inizializza l'ID del prodotto
                if (prodotti.Count > 0) // Se ci sono già prodotti
                {
                    id = prodotti[prodotti.Count - 1].Id + 1; // Imposta l'ID del nuovo prodotto come l'ID dell'ultimo prodotto + 1
                }
                Prodotto.Id = id; // Assegna l'ID al prodotto da aggiungere

                // Imposta un'immagine di default se non fornita
                if (string.IsNullOrEmpty(Prodotto.Immagine))
                {
                    Prodotto.Immagine = "img/default.jpg"; // Immagine predefinita
                }

                // Aggiungi il nuovo prodotto alla lista esistente
                prodotti.Add(Prodotto);

                // Salva la lista aggiornata di prodotti nel file JSON
                var jsonSalvato = JsonConvert.SerializeObject(prodotti, Formatting.Indented);
                System.IO.File.WriteAllText(jsonFilePath, jsonSalvato);

                // Reindirizza alla pagina Prodotti dopo aver aggiunto il prodotto
                return RedirectToPage("/Prodotti");
            }
            catch (Exception ex)
            {
                _logger.LogError("Errore durante l'aggiunta del prodotto: " + ex.Message);
                return RedirectToPage("Error", new { message = "Si è verificato un errore durante l'aggiunta del prodotto." });
            }
        }

    }
}
