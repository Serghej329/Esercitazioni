using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

public class ProdottiController : Controller
{
    private readonly string prodottiFilePath = "wwwroot/json/prodotti.json"; // Path del file prodotti
    private readonly string categorieFilePath = "wwwroot/json/categorie.json"; // Path del file categorie

    // Logger per registrare informazioni, avvisi ed errori
    private readonly ILogger<ProdottiController> _logger;

    // Costruttore che riceve il logger
    public ProdottiController(ILogger<ProdottiController> logger)
    {
        _logger = logger;
    }

    // Metodo per leggere i prodotti dal file JSON
    private List<Prodotto> LeggiProdottiDaJson()
    {
        var jsonData = System.IO.File.ReadAllText(prodottiFilePath);
        return JsonConvert.DeserializeObject<List<Prodotto>>(jsonData) ?? new List<Prodotto>();
    }

    // Metodo per salvare i prodotti nel file JSON
    private void SalvaProdottiSuJson(List<Prodotto> prodotti)
    {
        try
        {
            var jsonData = JsonConvert.SerializeObject(prodotti, Formatting.Indented);
            System.IO.File.WriteAllText(prodottiFilePath, jsonData);
            _logger.LogInformation("Product list successfully written to JSON.");
        }
        catch (Exception ex)
        {
            _logger.LogError("Error writing to JSON file: {Message}", ex.Message);
        }
    }

    // Metodo per leggere le categorie dal file JSON
    private List<string> LeggiCategorieDaJson()
    {
        try
        {
            var jsonData = System.IO.File.ReadAllText(categorieFilePath);
            _logger.LogInformation("Categorie JSON loaded: " + jsonData); // Log per il JSON data
            return JsonConvert.DeserializeObject<List<string>>(jsonData) ?? new List<string>();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error reading categorie.json: " + ex.Message);
            return new List<string>(); // Ritorna una lista vuota se c'è un errore
        }
    }

    // Action per visualizzare la lista dei prodotti con filtro prezzo e paginazione
    public IActionResult Index(int? minPrezzo, int? maxPrezzo, int pageIndex = 1)
    {
        var prodotti = LeggiProdottiDaJson();
        var prodottiFiltrati = FiltraProdottiPerPrezzo(prodotti, minPrezzo, maxPrezzo);
        var prodottiPaginati = PaginaProdotti(prodottiFiltrati, pageIndex);

        var viewModel = new ProdottiViewModel
        {
            Prodotti = prodottiPaginati,
            MinPrezzo = minPrezzo ?? 0,
            MaxPrezzo = maxPrezzo ?? prodotti.Max(p => p.Prezzo),
            NumeroPagine = (int)Math.Ceiling((double)prodottiFiltrati.Count() / 6),
            PaginaCorrente = pageIndex
        };

        return View("Prodotti", viewModel);
    }

    // Metodo per filtrare i prodotti per prezzo
    private List<Prodotto> FiltraProdottiPerPrezzo(List<Prodotto> prodotti, int? minPrezzo, int? maxPrezzo)
    {
        if (minPrezzo.HasValue)
        {
            prodotti = prodotti.Where(p => p.Prezzo >= minPrezzo.Value).ToList();
        }
        if (maxPrezzo.HasValue)
        {
            prodotti = prodotti.Where(p => p.Prezzo <= maxPrezzo.Value).ToList();
        }
        return prodotti;
    }

    // Metodo per paginare i prodotti
    private List<Prodotto> PaginaProdotti(List<Prodotto> prodotti, int pageIndex)
    {
        int numeroProdottiPerPagina = 6;
        return prodotti.Skip((pageIndex - 1) * numeroProdottiPerPagina).Take(numeroProdottiPerPagina).ToList();
    }

    // Action per visualizzare i dettagli di un singolo prodotto
    public IActionResult ProdottoDettaglio(int id)
    {
        var prodotti = LeggiProdottiDaJson();
        var prodotto = prodotti.Find(p => p.Id == id);

        if (prodotto == null)
        {
            return NotFound();
        }

        return View(prodotto);
    }

    // Action per visualizzare il form di aggiunta prodotto (GET)
    public IActionResult AggiungiProdotto()
    {
        var viewModel = new AggiungiProdottoViewModel
        {
            Prodotto = new Prodotto(),
            Categorie = LeggiCategorieDaJson() // Carica le categorie dal file JSON 
        };

        return View(viewModel);
    }

    // Action per processare l'aggiunta di un nuovo prodotto (POST)
    [HttpPost]
    public IActionResult AggiungiProdotto(AggiungiProdottoViewModel viewModel)
    {
        _logger.LogInformation("Valore della categoria: " + viewModel.Prodotto.Categoria);

        if (!ModelState.IsValid)
        {
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    _logger.LogError(error.ErrorMessage);
                }
            }

            var prodotti = LeggiProdottiDaJson();
            viewModel.Prodotto.Id = prodotti.Count > 0 ? prodotti.Max(p => p.Id) + 1 : 1;

            prodotti.Add(viewModel.Prodotto);
            SalvaProdottiSuJson(prodotti);

            return RedirectToAction("Index");
        }

        viewModel.Categorie = LeggiCategorieDaJson();
        return View(viewModel);
    }

    // Azione GET per visualizzare il form di modifica del prodotto
    public IActionResult ModificaProdotto(int id)
    {
        var prodotti = LeggiProdottiDaJson();
        var prodotto = prodotti.FirstOrDefault(p => p.Id == id); // trova il prodotto per ID

        if (prodotto == null)
        {
            return NotFound(); // Restituisce un errore se il prodotto non esiste
        }

        var viewModel = new ModificaProdottoViewModel
        {
            Prodotto = prodotto,
            Categorie = LeggiCategorieDaJson() // Carica le categorie dal file JSON
        };

        return View(viewModel);
    }

    // azione POST per inviare dati al server del metodo modificaprodotto
    [HttpPost]
    public IActionResult ModificaProdotto(ModificaProdottoViewModel viewModel)
    {
        _logger.LogInformation("Categoria selezionata: " + viewModel.Prodotto.Categoria);

        if (!ModelState.IsValid)
        {
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    _logger.LogError(error.ErrorMessage);
                }
            }

            viewModel.Categorie = LeggiCategorieDaJson();
            return View(viewModel);
        }

        var prodotti = LeggiProdottiDaJson();
        var prodottoDaModificare = prodotti.FirstOrDefault(p => p.Id == viewModel.Prodotto.Id);

        if (prodottoDaModificare != null)
        {
            _logger.LogInformation("Modifica del prodotto con ID: {Id}", viewModel.Prodotto.Id);

            prodottoDaModificare.Nome = viewModel.Prodotto.Nome;
            prodottoDaModificare.Prezzo = viewModel.Prodotto.Prezzo;
            prodottoDaModificare.Dettaglio = viewModel.Prodotto.Dettaglio;
            prodottoDaModificare.Immagine = viewModel.Prodotto.Immagine;
            prodottoDaModificare.Quantita = viewModel.Prodotto.Quantita;
            prodottoDaModificare.Categoria = viewModel.Prodotto.Categoria;

            SalvaProdottiSuJson(prodotti);

            _logger.LogInformation("Prodotto con ID: {Id} modificato con successo.", viewModel.Prodotto.Id);

            return RedirectToAction("Index");
        }

        _logger.LogWarning("Prodotto con ID: {Id} non trovato.", viewModel.Prodotto.Id);
        return NotFound();
    }

    // Azione GET per visualizzare la conferma della cancellazione di un prodotto
    public IActionResult CancellaProdotto(int id)
    {
        var prodotti = LeggiProdottiDaJson();
        var prodotto = prodotti.Find(p => p.Id == id);

        if (prodotto == null)
        {
            return NotFound();
        }

        return View(prodotto);
    }

    // Azione POST per confermare la cancellazione del prodotto
    [HttpPost, ActionName("CancellaProdotto")]
    public IActionResult ConfermaCancellazione(int id)
    {
        var prodotti = LeggiProdottiDaJson();
        var prodotto = prodotti.Find(p => p.Id == id);

        if (prodotto != null)
        {
            prodotti.Remove(prodotto);
            SalvaProdottiSuJson(prodotti);
        }

        return RedirectToAction("Index");
    }
}