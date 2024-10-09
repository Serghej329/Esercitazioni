using System.Collections.Generic; // Per lavorare con liste
using Microsoft.AspNetCore.Mvc; // Per gestire le richieste HTTP
using Microsoft.AspNetCore.Mvc.RazorPages; // Razor Pages
using Microsoft.Extensions.Logging; // Per gestire il logging
using Newtonsoft.Json; // Per lavorare con file JSON
using System.IO; // Per lavorare con file

public class ModificaProdottoModel : PageModel
{
    private readonly ILogger<ModificaProdottoModel> _logger;

    public Prodotto Prodotto { get; set; }
    public List<string> CategorieEsistenti { get; set; }

    private const string JsonProdottiPath = "wwwroot/json/prodotti.json";
    private const string JsonCategoriePath = "wwwroot/json/categorie.json";

    public ModificaProdottoModel(ILogger<ModificaProdottoModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(int id)
    {
        try
        {
            // Leggi il contenuto del file prodotti
            var json = System.IO.File.ReadAllText(JsonProdottiPath);
            var tuttiProdotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);

            // Leggi il contenuto del file categorie
            CategorieEsistenti = JsonConvert.DeserializeObject<List<string>>(System.IO.File.ReadAllText(JsonCategoriePath));

            // Trova il prodotto con l'ID specificato
            Prodotto = tuttiProdotti.FirstOrDefault(p => p.Id == id);
        }
        catch (FileNotFoundException ex)
        {
            _logger.LogError(ex, "Il file non è stato trovato: {FileName}", ex.FileName);
            // Gestisci il caso in cui il file non è trovato
            CategorieEsistenti = new List<string>(); // Imposta una lista vuota per evitare errori nella vista
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Errore nella deserializzazione del file JSON: {Message}", ex.Message);
            // Gestisci il caso di errore nella deserializzazione
            CategorieEsistenti = new List<string>(); // Imposta una lista vuota per evitare errori nella vista
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Si è verificato un errore imprevisto.");
            // Gestisci qualsiasi altro errore
            CategorieEsistenti = new List<string>(); // Imposta una lista vuota per evitare errori nella vista
        }
    }


    public IActionResult OnPost(int id, string nome, decimal prezzo, string dettaglio, string immagine, int quantita, string categoria)
    {
        var json = System.IO.File.ReadAllText(JsonProdottiPath);
        var tuttiProdotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);

        Prodotto prodotto = null; // Inizializza la variabile prodotto come null

        // Scorri tutti i prodotti per trovare quello con l'ID corrispondente
        foreach (var p in tuttiProdotti)
        {
            if (p.Id == id)
            {
                prodotto = p; // Assegna il prodotto trovato
                break; // Esci dal ciclo una volta trovato
            }
        }
        if (prodotto != null)
        {
            prodotto.Nome = nome;
            prodotto.Prezzo = prezzo;
            prodotto.Dettaglio = dettaglio;
            prodotto.Immagine = immagine;
            prodotto.Quantita = quantita;
            prodotto.Categoria = categoria;
        }

        System.IO.File.WriteAllText(JsonProdottiPath, JsonConvert.SerializeObject(tuttiProdotti, Formatting.Indented));

        return RedirectToPage("/Prodotti");
    }
}
