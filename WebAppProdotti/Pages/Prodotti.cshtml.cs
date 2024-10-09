using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace WebAppProdotti.Pages
{
    public class ProdottiModel : PageModel
    {
        private readonly ILogger<ProdottiModel> _logger;

        // Proprietà per contenere i prodotti e le categorie
        public List<Prodotto> Prodotti { get; set; }
        public List<string> Categorie { get; set; }
        public int NumeroPagine { get; set; }

        public ProdottiModel(ILogger<ProdottiModel> logger)
        {
            _logger = logger;
        }

        // Metodo OnGet per ottenere e filtrare i prodotti
        public void OnGet(decimal? minPrezzo, decimal? maxPrezzo, int? pageIndex, string selectedCategoria)
        {
            var jsonFilePath = "wwwroot/json/prodotti.json";

            // Verifica se il file esiste
            if (System.IO.File.Exists(jsonFilePath))
            {
                var json = System.IO.File.ReadAllText(jsonFilePath);
                var tuttiProdotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);

                if (tuttiProdotti != null)
                {
                    // Ottieni le categorie distinte
                    Categorie = tuttiProdotti.Select(p => p.Categoria).Distinct().ToList();

                    // Filtra i prodotti in base al prezzo e alla categoria
                    var prodottiFiltrati = tuttiProdotti.Where(p =>
                        (!minPrezzo.HasValue || p.Prezzo >= minPrezzo.Value) &&
                        (!maxPrezzo.HasValue || p.Prezzo <= maxPrezzo.Value) &&
                        (string.IsNullOrEmpty(selectedCategoria) || p.Categoria == selectedCategoria)).ToList();

                    // Calcola il numero di pagine
                    NumeroPagine = (int)System.Math.Ceiling((double)prodottiFiltrati.Count / 6);

                    // Esegui la paginazione
                    Prodotti = prodottiFiltrati.Skip(((pageIndex ?? 1) - 1) * 6).Take(6).ToList();
                }
                else
                {
                    _logger.LogWarning("Prodotti non trovati nel file.");
                    Prodotti = new List<Prodotto>();
                }
            }
            else
            {
                _logger.LogError("File prodotti.json non trovato.");
                Prodotti = new List<Prodotto>();
            }
        }
    }
}
