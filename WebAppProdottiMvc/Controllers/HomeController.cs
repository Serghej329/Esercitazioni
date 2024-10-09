using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly string prodottiFilePath = "wwwroot/json/prodotti.json"; // Path del file prodotti

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var prodotti = LeggiProdottiDaJson();
        var randomProdotti = prodotti.OrderBy(x => Guid.NewGuid()).Take(5).ToList(); // Prendi 5 prodotti casuali

        var viewModel = new IndexViewModel
        {
            RandomProdotti = randomProdotti
        };

        return View(viewModel);
    }

    private List<Prodotto> LeggiProdottiDaJson()
    {
        var jsonData = System.IO.File.ReadAllText(prodottiFilePath);
        return JsonConvert.DeserializeObject<List<Prodotto>>(jsonData) ?? new List<Prodotto>();
    }
}