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

        string path = @"GestioneProdotti.json";
        var Prodotti = new List<dynamic>();

        if (File.Exists(path))
        {
            // Leggi il contenuto del file JSON
            string json = File.ReadAllText(path);

            // Deserializza il contenuto del file JSON
            var deserializedProdotti = JsonConvert.DeserializeObject<List<dynamic>>(json);
            if (deserializedProdotti != null)
            {
                Prodotti = deserializedProdotti;
            }
        }
        else
        {
            // Se il file non esiste, inizializza una lista vuota e crea un file JSON vuoto
            Prodotti = new List<dynamic>();
            File.WriteAllText(path, "[]");
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

                                    // Serializza la lista di Prodotti in JSON e scrivilo nel file
                                    string json = JsonConvert.SerializeObject(Prodotti, Formatting.Indented);
                                    File.WriteAllText(path, json);

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
                                        var prodottiOrdinati = Prodotti.ToList();

                                        switch (criterio)
                                        {
                                            case "Alfabetico":
                                                {
                                                    var ordine = AnsiConsole.Prompt(
                                                        new SelectionPrompt<string>()
                                                            .Title("Scegli l'ordine di visualizzazione:")
                                                            .AddChoices("Crescente", "Decrescente"));

                                                    if (ordine == "Crescente")
                                                    {
                                                        prodottiOrdinati = Prodotti.ToList();
                                                        prodottiOrdinati.OrderBy(Prodotti.Prodotto);
                                                    }
                                                    else
                                                    {

                                                    }
                                                }
                                                break;
                                            case "Di inserimento":
                                                prodottiOrdinati = Prodotti.ToList();
                                                break;
                                            case "Di data":

                                                break;
                                            case "Di categoria":

                                                break;
                                            case "Di prezzo (alto a basso)":

                                                break;
                                            case "Di prezzo (basso ad alto)":

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
                                            var Prodotto = prodottiOrdinati[i];
                                            string orario = ((DateTime)Prodotto.Data).ToString("HH:mm");
                                            tabella.AddRow(i.ToString(), ((DateTime)Prodotto.Data).ToShortDateString(), orario, ((decimal)Prodotto.Importo).ToString("C"), (string)Prodotto.Prodotto, (string)Prodotto.Categoria, (string)Prodotto.Descrizione);
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
                                            var Prodotto = Prodotti[i];
                                            string orario = ((DateTime)Prodotto.Data).ToString("HH:mm");
                                            tabella.AddRow(i.ToString(), ((DateTime)Prodotto.Data).ToShortDateString(), orario, ((decimal)Prodotto.Importo).ToString("C"), (string)Prodotto.Prodotto, (string)Prodotto.Categoria, (string)Prodotto.Descrizione);
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

                                        var ProdottoDaModificare = Prodotti[index];

                                        var campoDaModificare = AnsiConsole.Prompt(
                                            new SelectionPrompt<string>()
                                                .Title("Scegli il campo da modificare:")
                                                .AddChoices("Data", "Importo", "Prodotto", "Categoria", "Descrizione"));

                                        switch (campoDaModificare)
                                        {
                                            case "Data":
                                                ProdottoDaModificare.Data = AnsiConsole.Prompt(new TextPrompt<DateTime>("Inserisci la nuova data (YYYY-MM-DD):"));
                                                break;
                                            case "Importo":
                                                ProdottoDaModificare.Importo = AnsiConsole.Prompt(new TextPrompt<decimal>("Inserisci il nuovo importo:"));
                                                break;
                                            case "Prodotto":
                                                ProdottoDaModificare.Prodotto = AnsiConsole.Prompt(new TextPrompt<string>("Inserisci il nuovo nome del prodotto:"));
                                                break;
                                            case "Categoria":
                                                ProdottoDaModificare.Categoria = AnsiConsole.Prompt(new TextPrompt<string>("Inserisci la nuova categoria:"));
                                                break;
                                            case "Descrizione":
                                                ProdottoDaModificare.Descrizione = AnsiConsole.Prompt(new TextPrompt<string>("Inserisci la nuova descrizione:"));
                                                break;
                                        }

                                        // Serializza la lista di Prodotti in JSON e scrivilo nel file
                                        string json = JsonConvert.SerializeObject(Prodotti, Formatting.Indented);
                                        File.WriteAllText(path, json);

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
                                            var Prodotto = Prodotti[i];
                                            string orario = ((DateTime)Prodotto.Data).ToString("HH:mm");
                                            tabella.AddRow(i.ToString(), ((DateTime)Prodotto.Data).ToShortDateString(), orario, ((decimal)Prodotto.Importo).ToString("C"), (string)Prodotto.Prodotto, (string)Prodotto.Categoria, (string)Prodotto.Descrizione);
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

                                        // Serializza la lista di Prodotti in JSON e scrivilo nel file
                                        string json = JsonConvert.SerializeObject(Prodotti, Formatting.Indented);
                                        File.WriteAllText(path, json);

                                        AnsiConsole.MarkupLine("[green]Prodotto eliminato con successo![/]");
                                    }
                                }
                                break;

                            case "Torna al Menù Principale":
                                break;
                        }

                        if (sottoMenu == "Torna al Menù Principale")
                        {
                            break;
                        }
                    }
                    break;

                case "Categorie di Prodotto":
                    AnsiConsole.MarkupLine("[yellow]Categorie di Prodotto - Funzionalità non implementata.[/]");
                    break;

                case "Report e Analisi":
                    AnsiConsole.MarkupLine("[yellow]Report e Analisi - Funzionalità non implementata.[/]");
                    break;

                case "Esci":
                    return; // Esci dall'applicazione
            }
        }
    }
}
