using Newtonsoft.Json;
using Spectre.Console;
class Program
{
    static void Main(string[] args)
    {
        // Stampa il titolo dell'applicazione
        AnsiConsole.MarkupLine("[bold green]Gestionale delle Prodotti Aziendali[/]");

        string pathProdotti = @"GestioneProdotti.json";
        string pathCategorie = @"Categorie.json";

        // Carica i dati dei prodotti e delle categorie
        List<dynamic> Prodotti = CaricaProdotti(pathProdotti);
        List<string> Categorie = CaricaCategorie(pathCategorie);

        while (true)
        {
            var menu = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Scegli un'opzione:")
                    .AddChoices("Gestione Prodotti", "Categorie di Prodotto", "Report e Analisi", "Esci"));

            switch (menu)
            {
                case "Gestione Prodotti":
                    GestioneProdotti(Prodotti, Categorie, pathProdotti, pathCategorie);
                    break;

                case "Categorie di Prodotto":
                    VisualizzaCategorie(Prodotti, Categorie);
                    break;

                case "Report e Analisi":
                    AnsiConsole.MarkupLine("[yellow]Questa sezione è ancora in fase di sviluppo.[/]");
                    break;

                case "Esci":
                    return;
            }
        }
    }

    static List<dynamic> CaricaProdotti(string path)
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<dynamic>>(json) ?? new List<dynamic>();
        }
        else
        {
            return new List<dynamic>();
        }
    }

    static List<string> CaricaCategorie(string path)
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<string>>(json) ?? new List<string>();
        }
        else
        {
            return new List<string>();
        }
    }

    static void GestioneProdotti(List<dynamic> Prodotti, List<string> Categorie, string pathProdotti, string pathCategorie)
    {
        while (true)
        {
            var sottoMenu = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Scegli un'azione:")
                    .AddChoices("Aggiungi Prodotto", "Visualizza Prodotti", "Modifica Prodotto", "Elimina Prodotto", "Torna al Menù Principale"));

            switch (sottoMenu)
            {
                case "Aggiungi Prodotto":
                    AggiungiProdotto(Prodotti, Categorie, pathProdotti, pathCategorie);
                    break;

                case "Visualizza Prodotti":
                    VisualizzaProdotti(Prodotti);
                    break;

                case "Modifica Prodotto":
                    ModificaProdotto(Prodotti, Categorie, pathProdotti, pathCategorie);
                    break;

                case "Elimina Prodotto":
                    EliminaProdotto(Prodotti, pathProdotti);
                    break;

                case "Torna al Menù Principale":
                    return;
            }
        }
    }

    static void AggiungiProdotto(List<dynamic> Prodotti, List<string> Categorie, string pathProdotti, string pathCategorie)
    {
        DateTime data = DateTime.Now;
        string prodotto = AnsiConsole.Prompt(new TextPrompt<string>("Inserisci il nome del prodotto:"));
        decimal importo = AnsiConsole.Prompt(new TextPrompt<decimal>("Inserisci l'importo del prodotto:"));
        string categoria = AnsiConsole.Prompt(new TextPrompt<string>("Inserisci la categoria:"));
        string descrizione = AnsiConsole.Prompt(new TextPrompt<string>("Inserisci una descrizione per il prodotto:"));

        var nuovoProdotto = new
        {
            Data = data,
            Importo = importo,
            Prodotto = prodotto,
            Categoria = categoria,
            Descrizione = descrizione
        };

        Prodotti.Add(nuovoProdotto);

        // Verifica e aggiungi la categoria se non esiste già
        if (!Categorie.Contains(categoria))
        {
            Categorie.Add(categoria);
            string jsonCategorie = JsonConvert.SerializeObject(Categorie, Formatting.Indented);
            File.WriteAllText(pathCategorie, jsonCategorie);
        }

        string jsonProdotti = JsonConvert.SerializeObject(Prodotti, Formatting.Indented);
        File.WriteAllText(pathProdotti, jsonProdotti);

        AnsiConsole.MarkupLine("[green]Prodotto aggiunto con successo![/]");
    }

    static void VisualizzaProdotti(List<dynamic> Prodotti)
    {
        if (Prodotti.Count == 0)
        {
            AnsiConsole.MarkupLine("[yellow]Nessun prodotto registrato.[/]");
            return;
        }

        var criterio = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Scegli l'ordine di visualizzazione:")
                .AddChoices("Alfabetico", "Di inserimento", "Di data", "Di categoria", "Di prezzo (alto a basso)", "Di prezzo (basso ad alto)"));

        List<dynamic> prodottiOrdinati = new List<dynamic>(Prodotti);

        switch (criterio)
        {
            case "Alfabetico":
                OrdinaAlfabetico(prodottiOrdinati);
                break;
            case "Di inserimento":
                prodottiOrdinati = new List<dynamic>(Prodotti);
                break;
            case "Di data":
               /* prodottiOrdinati.Sort((a, b) => ((DateTime)a.Data).CompareTo((DateTime)b.Data));*/
                break;
            case "Di categoria":
               /* prodottiOrdinati.Sort((a, b) => ((string)a.Categoria).CompareTo((string)b.Categoria));*/
                break;
            case "Di prezzo (alto a basso)":
                /*prodottiOrdinati.Sort((a, b) => ((decimal)b.Importo).CompareTo((decimal)a.Importo));*/
                break;
            case "Di prezzo (basso ad alto)":
                /*prodottiOrdinati.Sort((a, b) => ((decimal)a.Importo).CompareTo((decimal)b.Importo));*/
                break;
        }

        VisualizzaProdottiInTabella(prodottiOrdinati);
    }

    static void OrdinaAlfabetico(List<dynamic> prodottiOrdinati)
    {
        var ordine = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Scegli l'ordine di visualizzazione:")
                .AddChoices("Crescente", "Decrescente"));

        if (ordine == "Crescente")
        {
            /*prodottiOrdinati.Sort((a, b) => ((string)a.Prodotto).CompareTo((string)b.Prodotto));*/
        }
        else
        {
           /* prodottiOrdinati.Sort((a, b) => ((string)b.Prodotto).CompareTo((string)a.Prodotto));*/
        }
    }

    static void VisualizzaProdottiInTabella(List<dynamic> prodottiOrdinati)
    {
        var tabella = new Table();
        tabella.AddColumn("Indice");
        tabella.AddColumn("Data");
        tabella.AddColumn("Orario");
        tabella.AddColumn("Importo");
        tabella.AddColumn("Prodotto");
        tabella.AddColumn("Categoria");
        tabella.AddColumn("Descrizione");

        for (int i = 0; i < prodottiOrdinati.Count; i++)
        {
            var prodottoItem = prodottiOrdinati[i];
            string orario = ((DateTime)prodottoItem.Data).ToString("HH:mm");
            tabella.AddRow(i.ToString(), ((DateTime)prodottoItem.Data).ToShortDateString(), orario, ((decimal)prodottoItem.Importo).ToString("C"), (string)prodottoItem.Prodotto, (string)prodottoItem.Categoria, (string)prodottoItem.Descrizione);
        }

        AnsiConsole.Write(tabella);
    }

    static void ModificaProdotto(List<dynamic> Prodotti, List<string> Categorie, string pathProdotti, string pathCategorie)
    {
        if (Prodotti.Count == 0)
        {
            AnsiConsole.MarkupLine("[yellow]Nessun prodotto registrato.[/]");
            return;
        }

        VisualizzaProdottiInTabella(Prodotti);

        int index;
        while (true)
        {
            index = AnsiConsole.Prompt(new TextPrompt<int>("Inserisci l'indice del prodotto da modificare:"));
            if (index >= 0 && index < Prodotti.Count)
            {
                break;
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Indice non valido. Riprovare.[/]");
            }
        }

        var prodottoDaModificare = Prodotti[index];

        var campoDaModificare = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Scegli il campo da modificare:")
                .AddChoices("Data", "Importo", "Prodotto", "Categoria", "Descrizione"));

        switch (campoDaModificare)
        {
            case "Data":
                prodottoDaModificare.Data = AnsiConsole.Prompt(new TextPrompt<DateTime>("Inserisci la nuova data (YYYY-MM-DD):"));
                break;
            case "Importo":
                prodottoDaModificare.Importo = AnsiConsole.Prompt(new TextPrompt<decimal>("Inserisci il nuovo importo:"));
                break;
            case "Prodotto":
                prodottoDaModificare.Prodotto = AnsiConsole.Prompt(new TextPrompt<string>("Inserisci il nuovo nome del prodotto:"));
                break;
            case "Categoria":
                prodottoDaModificare.Categoria = AnsiConsole.Prompt(new TextPrompt<string>("Inserisci la nuova categoria:"));

                // Verifica e aggiungi la categoria se non esiste già
                if (!Categorie.Contains((string)prodottoDaModificare.Categoria))
                {
                    Categorie.Add((string)prodottoDaModificare.Categoria);
                    // Salva le categorie aggiornate nel file
                    string jsonCategorie = JsonConvert.SerializeObject(Categorie, Formatting.Indented);
                    File.WriteAllText(pathCategorie, jsonCategorie);
                }
                break;
            case "Descrizione":
                prodottoDaModificare.Descrizione = AnsiConsole.Prompt(new TextPrompt<string>("Inserisci una nuova descrizione:"));
                break;
        }

        // Salva i prodotti aggiornati nel file
        string jsonProdotti = JsonConvert.SerializeObject(Prodotti, Formatting.Indented);
        File.WriteAllText(pathProdotti, jsonProdotti);

        AnsiConsole.MarkupLine("[green]Prodotto modificato con successo![/]");
    }

    static void EliminaProdotto(List<dynamic> Prodotti, string pathProdotti)
    {
        if (Prodotti.Count == 0)
        {
            AnsiConsole.MarkupLine("[yellow]Nessun prodotto registrato.[/]");
            return;
        }

        VisualizzaProdottiInTabella(Prodotti);

        int index;
        while (true)
        {
            index = AnsiConsole.Prompt(new TextPrompt<int>("Inserisci l'indice del prodotto da eliminare:"));
            if (index >= 0 && index < Prodotti.Count)
            {
                break;
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Indice non valido. Riprovare.[/]");
            }
        }

        Prodotti.RemoveAt(index);

        // Salva i prodotti aggiornati nel file
        string jsonProdotti = JsonConvert.SerializeObject(Prodotti, Formatting.Indented);
        File.WriteAllText(pathProdotti, jsonProdotti);

        AnsiConsole.MarkupLine("[red]Prodotto eliminato con successo![/]");
    }

    static void VisualizzaCategorie(List<dynamic> Prodotti, List<string> Categorie)
    {
        if (Categorie.Count == 0)
        {
            AnsiConsole.MarkupLine("[yellow]Nessuna categoria registrata.[/]");
            return;
        }

        var categoriaSelezionata = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Categorie disponibili:")
                .AddChoices(Categorie));

       /* var prodottiFiltrati = Prodotti.Where(p => (string)p.Categoria == categoriaSelezionata).ToList();*/

        if (prodottiFiltrati.Count == 0)
        {
            AnsiConsole.MarkupLine("[yellow]Nessun prodotto trovato per la categoria selezionata.[/]");
        }
        else
        {
            VisualizzaProdottiInTabella(prodottiFiltrati);
        }
    }
}
