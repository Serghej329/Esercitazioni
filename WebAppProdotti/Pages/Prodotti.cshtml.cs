using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebAppProdotti.Pages
{
    public class ProdottiModel : PageModel
    {
        private readonly ILogger<ProdottiModel> _logger;

        public ProdottiModel(ILogger<ProdottiModel> logger)
        {
            _logger = logger;
        }

        public IEnumerable<Prodotto> ElencoProdotti { get; set; }

        public void OnGet()
        {
            ElencoProdotti = new List<Prodotto>
            {
                new Prodotto { Id = 1, Nome = "Prod 1", Prezzo = 100, Immagine = "./img/img1.jpg"},
                new Prodotto { Id = 2, Nome = "Prod 2", Prezzo = 200, Immagine = "./img/img2.jpg" },
                new Prodotto { Id = 3, Nome = "Prod 3", Prezzo = 300, Immagine = "./img/img3.jpg" }
            };
        }
    }
}