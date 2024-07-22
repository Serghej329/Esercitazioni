using Newtonsoft.Json;
using Spectre.Console;

class Program
{
    static void Main(string[] args)
    {
        DateTime data = DateTime.Now;
        string prodotto = "";
        decimal importo = 0;
        string categoria = "";
        string descrizione = "";

        // Definizione dell'oggetto del prodotto con valori vuoti
        dynamic ProdottoBase = new
        {
            Data = DateTime.Now,
            Importo = 0m,
            Prodotto = "",
            Categoria = "",
            Descrizione = ""
        };

        // Stampa il titolo dell'applicazione
        AnsiConsole.MarkupLine("[bold green]Gestionale delle Prodotti Aziendali[/]");

        string pathProdotti = @"GestioneProdotti.json";
        string pathCategorie = @"Categorie.json";

        // Carica i dati dei prodotti
        List<dynamic> Prodotti;
        if (File.Exists(pathProdotti))
        {
            string jsonProdotti = File.ReadAllText(pathProdotti);
            Prodotti = JsonConvert.DeserializeObject<List<dynamic>>(jsonProdotti) ?? new List<dynamic>();
        }
        else
        {
            Prodotti = new List<dynamic>();
        }

        // Carica le categorie
        List<string> Categorie;
        if (File.Exists(pathCategorie))
        {
            string jsonCategorie = File.ReadAllText(pathCategorie);
            Categorie = JsonConvert.DeserializeObject<List<string>>(jsonCategorie) ?? new List<string>();
        }
        else
        {
            Categorie = new List<string>();
        }

        while (true)
        {
            // Crea un menù con le opzioni principali
            var menu = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Scegli un'opzione:")
                    .AddChoices("Gestione Prodotti", "Categorie di Prodotto", "Report e Analisi", "Esci"));

            switch (menu)
            {
                case "Gestione Prodotti":
                    while (true)
                    {
                        // Crea un menù per la gestione dei Prodotti
                        var sottoMenu = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .Title("Scegli un'azione:")
                                .AddChoices("Aggiungi Prodotto", "Visualizza Prodotti", "Modifica Prodotto", "Elimina Prodotto", "Torna al Menù Principale"));

                        switch (sottoMenu)
                        {
                            case "Aggiungi Prodotto":
                                {
                                    data = DateTime.Now;
                                    prodotto = AnsiConsole.Prompt(new TextPrompt<string>("Inserisci il nome del prodotto:"));
                                    importo = AnsiConsole.Prompt(new TextPrompt<decimal>("Inserisci l'importo del prodotto:"));
                                    categoria = AnsiConsole.Prompt(new TextPrompt<string>("Inserisci la categoria:"));
                                    descrizione = AnsiConsole.Prompt(new TextPrompt<string>("Inserisci una descrizione per il prodotto:"));

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
                                        // Salva le categorie aggiornate nel file
                                        string jsonCategorie = JsonConvert.SerializeObject(Categorie, Formatting.Indented);
                                        File.WriteAllText(pathCategorie, jsonCategorie);
                                    }

                                    // Salva i prodotti aggiornati nel file
                                    string jsonProdotti = JsonConvert.SerializeObject(Prodotti, Formatting.Indented);
                                    File.WriteAllText(pathProdotti, jsonProdotti);

                                    AnsiConsole.MarkupLine("[green]Prodotto aggiunto con successo![/]");
                                }
                                break;

                            case "Visualizza Prodotti":
                                {
                                    if (Prodotti.Count == 0)
                                    {
                                        AnsiConsole.MarkupLine("[yellow]Nessun prodotto registrato.[/]");
                                    }
                                    else
                                    {
                                        var criterio = AnsiConsole.Prompt(
                                            new SelectionPrompt<string>()
                                                .Title("Scegli l'ordine di visualizzazione:")
                                                .AddChoices("Alfabetico", "Di inserimento", "Di data", "Di categoria", "Di prezzo (alto a basso)", "Di prezzo (basso ad alto)"));

                                        // Crea una copia della lista per l'ordinamento
                                        List<dynamic> prodottiOrdinati = Prodotti.ToList();

                                        switch (criterio)
                                        {
                                            case "Alfabetico":
                                                {
                                                    string ordine = AnsiConsole.Prompt(
                                                        new SelectionPrompt<string>()
                                                            .Title("Scegli l'ordine di visualizzazione:")
                                                            .AddChoices("Crescente", "Decrescente"));

                                                    if (ordine == "Crescente")
                                                    {
                                                        prodottiOrdinati = Prodotti.OrderBy(p => (string)p.Prodotto).ToList();
                                                    }
                                                    else
                                                    {
                                                        prodottiOrdinati = Prodotti.OrderByDescending(p => (string)p.Prodotto).ToList();
                                                    }
                                                }
                                                break;
                                            case "Di inserimento":
                                                prodottiOrdinati = Prodotti.ToList();
                                                break;
                                            case "Di data":
                                                prodottiOrdinati = Prodotti.OrderBy(p => (DateTime)p.Data).ToList();
                                                break;
                                            case "Di categoria":
                                                prodottiOrdinati = Prodotti.OrderBy(p => (string)p.Categoria).ToList();
                                                break;
                                            case "Di prezzo (alto a basso)":
                                                prodottiOrdinati = Prodotti.OrderByDescending(p => (decimal)p.Importo).ToList();
                                                break;
                                            case "Di prezzo (basso ad alto)":
                                                prodottiOrdinati = Prodotti.OrderBy(p => (decimal)p.Importo).ToList();
                                                break;
                                        }

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
                                }
                                break;

                            case "Modifica Prodotto":
                                {
                                    if (Prodotti.Count == 0)
                                    {
                                        AnsiConsole.MarkupLine("[yellow]Nessun prodotto registrato.[/]");
                                    }
                                    else
                                    {
                                        var tabella = new Table();
                                        tabella.AddColumn("Indice");
                                        tabella.AddColumn("Data");
                                        tabella.AddColumn("Orario");
                                        tabella.AddColumn("Importo");
                                        tabella.AddColumn("Prodotto");
                                        tabella.AddColumn("Categoria");
                                        tabella.AddColumn("Descrizione");

                                        for (int i = 0; i < Prodotti.Count; i++)
                                        {
                                            var prodottoItem = Prodotti[i];
                                            string orario = ((DateTime)prodottoItem.Data).ToString("HH:mm");
                                            tabella.AddRow(i.ToString(), ((DateTime)prodottoItem.Data).ToShortDateString(), orario, ((decimal)prodottoItem.Importo).ToString("C"), (string)prodottoItem.Prodotto, (string)prodottoItem.Categoria, (string)prodottoItem.Descrizione);
                                        }

                                        AnsiConsole.Write(tabella);

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
                                }
                                break;

                            case "Elimina Prodotto":
                                {
                                    if (Prodotti.Count == 0)
                                    {
                                        AnsiConsole.MarkupLine("[yellow]Nessun prodotto registrato.[/]");
                                    }
                                    else
                                    {
                                        var tabella = new Table();
                                        tabella.AddColumn("Indice");
                                        tabella.AddColumn("Data");
                                        tabella.AddColumn("Orario");
                                        tabella.AddColumn("Importo");
                                        tabella.AddColumn("Prodotto");
                                        tabella.AddColumn("Categoria");
                                        tabella.AddColumn("Descrizione");

                                        for (int i = 0; i < Prodotti.Count; i++)
                                        {
                                            var prodottoItem = Prodotti[i];
                                            string orario = ((DateTime)prodottoItem.Data).ToString("HH:mm");
                                            tabella.AddRow(i.ToString(), ((DateTime)prodottoItem.Data).ToShortDateString(), orario, ((decimal)prodottoItem.Importo).ToString("C"), (string)prodottoItem.Prodotto, (string)prodottoItem.Categoria, (string)prodottoItem.Descrizione);
                                        }

                                        AnsiConsole.Write(tabella);

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
                                }
                                break;

                            case "Torna al Menù Principale":
                                return;
                        }
                    }
                    break;

                case "Categorie di Prodotto":
                    {
                        if (Categorie.Count == 0)
                        {
                            AnsiConsole.MarkupLine("[yellow]Nessuna categoria registrata.[/]");
                        }
                        else
                        {
                            var categoriaSelezionata = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                    .Title("Categorie disponibili:")
                                    .AddChoices(Categorie));

                            var prodottiFiltrati = Prodotti.Where(p => (string)p.Categoria == categoriaSelezionata).ToList();

                            if (prodottiFiltrati.Count == 0)
                            {
                                AnsiConsole.MarkupLine("[yellow]Nessun prodotto trovato per la categoria selezionata.[/]");
                            }
                            else
                            {
                                var tabella = new Table();
                                tabella.AddColumn("Indice");
                                tabella.AddColumn("Data");
                                tabella.AddColumn("Orario");
                                tabella.AddColumn("Importo");
                                tabella.AddColumn("Prodotto");
                                tabella.AddColumn("Categoria");
                                tabella.AddColumn("Descrizione");

                                for (int i = 0; i < prodottiFiltrati.Count; i++)
                                {
                                    var prodottoItem = prodottiFiltrati[i];
                                    string orario = ((DateTime)prodottoItem.Data).ToString("HH:mm");
                                    tabella.AddRow(i.ToString(), ((DateTime)prodottoItem.Data).ToShortDateString(), orario, ((decimal)prodottoItem.Importo).ToString("C"), (string)prodottoItem.Prodotto, (string)prodottoItem.Categoria, (string)prodottoItem.Descrizione);
                                }

                                AnsiConsole.Write(tabella);
                            }
                        }
                    }
                    break;

                case "Report e Analisi":
                    {
                        AnsiConsole.MarkupLine("[yellow]Questa sezione è ancora in fase di sviluppo.[/]");
                    }
                    break;

                case "Esci":
                    return;
            }
        }
    }
}
