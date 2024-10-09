using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace WebAppProdotti.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    public List<Prodotto> RandomProdotti { get; set; } = new List<Prodotto>();
    public void OnGet()
    {
        try
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
            var tuttiProdotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);

            if (tuttiProdotti != null && tuttiProdotti.Count > 0)
            {
                Random random = new Random();
                RandomProdotti = tuttiProdotti.OrderBy(x => random.Next()).Take(3).ToList();
            }
            else
            {
                _logger.LogWarning("Nessun prodotto trovato nel file JSON.");
                RandomProdotti = new List<Prodotto>();
            }
        }
        catch (FileNotFoundException)
        {
            _logger.LogError("File JSON non trovato.");
            RandomProdotti = new List<Prodotto>();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Errore durante il caricamento dei prodotti: {ex.Message}");
            RandomProdotti = new List<Prodotto>();
        }
    }
}