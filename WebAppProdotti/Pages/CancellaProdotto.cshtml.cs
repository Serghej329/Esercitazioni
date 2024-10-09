using System.Collections.Generic; // Necessario per lavorare con le liste
using Microsoft.AspNetCore.Mvc; // Libreria MVC per gestire le richieste e risposte HTTP
using Microsoft.AspNetCore.Mvc.RazorPages; // Libreria specifica per le Razor Pages
using Microsoft.Extensions.Logging; // Per il logging
using Newtonsoft.Json; // Per la gestione dei file JSON

public class CancellaProdottoModel : PageModel
{
    private readonly ILogger<CancellaProdottoModel> _logger;

    // Prodotto da cancellare, che viene mostrato prima della cancellazione
    public Prodotto Prodotto { get; set; }

    // Costruttore che prende un logger
    public CancellaProdottoModel(ILogger<CancellaProdottoModel> logger)
    {
        _logger = logger;
    }

    // Metodo OnGet per recuperare un prodotto da cancellare in base all'ID
    public void OnGet(int id)
    {
        // Leggi il file prodotti.json
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");

        // Converte il JSON in una lista di prodotti
        var tuttiProdotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);

        // Cerca il prodotto con l'ID corrispondente
        foreach (var prodotto in tuttiProdotti)
        {
            if (prodotto.Id == id)
            {
                Prodotto = prodotto; // Assegna il prodotto da cancellare
                break;
            }
        }
    }

    // Metodo OnPost per gestire la cancellazione del prodotto
    public IActionResult OnPost(int id)
    {
        // Leggi il file prodotti.json
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");

        // Converte il JSON in una lista di prodotti
        var tuttiProdotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);

        // Trova il prodotto da rimuovere con l'ID corrispondente
        for (int i = 0; i < tuttiProdotti.Count; i++)
        {
            if (tuttiProdotti[i].Id == id)
            {
                tuttiProdotti.RemoveAt(i); // Rimuovi il prodotto
                break;
            }
        }

        // Salva la lista aggiornata di prodotti nel file prodotti.json
        System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(tuttiProdotti, Formatting.Indented));

        // Reindirizza alla pagina Prodotti
        return RedirectToPage("/Prodotti");
    }
}
