using Newtonsoft.Json;
using Spectre.Console;

class Program
{
    static void Main(string[] args)
    {
        // Stampa il titolo dell'applicazione
        AnsiConsole.MarkupLine("[bold green]Gestionale delle Spese Aziendali[/]");

        string path = @"GestioneSpese.json";
        var spese = new List<dynamic>();

        if (File.Exists(path))
        {
            // Leggi il contenuto del file JSON
            string json = File.ReadAllText(path);

            // Deserializza il contenuto del file JSON
            spese = JsonConvert.DeserializeObject<List<dynamic>>(json) ?? new List<dynamic>();
        }
        else
        {
            // Se il file non esiste, inizializza una lista vuota e crea un file JSON vuoto
            spese = new List<dynamic>();
            File.WriteAllText(path, "[]");
        }

        while (true)
        {
            // Crea un menù con le opzioni principali
            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Scegli un'opzione:")
                    .AddChoices("Gestione Spese", "Categorie di Spesa", "Report e Analisi", "Esci"));

            switch (selection)
            {
                case "Gestione Spese":
                    while (true)
                    {
                        // Crea un menù per la gestione delle spese
                        var sceltaGestione = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .Title("Scegli un'azione:")
                                .AddChoices("Aggiungi Spesa", "Visualizza Spese", "Modifica Spesa", "Elimina Spesa", "Torna al Menù Principale"));

                        switch (sceltaGestione)
                        {
                            case "Aggiungi Spesa":
                                {
                                    DateTime data = DateTime.Now;
                                    string prodotto = AnsiConsole.Prompt(new TextPrompt<string>("Inserisci il nome del prodotto:"));
                                    decimal importo = AnsiConsole.Prompt(new TextPrompt<decimal>("Inserisci l'importo della spesa:"));
                                    string categoria = AnsiConsole.Prompt(new TextPrompt<string>("Inserisci la categoria:"));
                                    string descrizione = AnsiConsole.Prompt(new TextPrompt<string>("Inserisci una descrizione per il prodotto:"));

                                    var spesa = new
                                    {
                                        Data = data,
                                        Importo = importo,
                                        Prodotto = prodotto,
                                        Categoria = categoria,
                                        Descrizione = descrizione
                                    };

                                    spese.Add(spesa);

                                    // Serializza la lista di spese in JSON e scrivilo nel file
                                    string json = JsonConvert.SerializeObject(spese, Formatting.Indented);
                                    File.WriteAllText(path, json);

                                    AnsiConsole.MarkupLine("[green]Spesa aggiunta con successo![/]");
                                }
                                break;

                            case "Visualizza Spese":
                                {
                                    if (spese.Count == 0)
                                    {
                                        AnsiConsole.MarkupLine("[yellow]Nessuna spesa registrata.[/]");
                                    }
                                    else
                                    {
                                        var tabella = new Table();
                                        tabella.AddColumn("Data");
                                        tabella.AddColumn("Orario");
                                        tabella.AddColumn("Importo");
                                        tabella.AddColumn("Prodotto");
                                        tabella.AddColumn("Categoria");
                                        tabella.AddColumn("Descrizione");

                                        foreach (var spesa in spese)
                                        {
                                            string orario = ((DateTime)spesa.Data).ToString("HH:mm");
                                            tabella.AddRow(((DateTime)spesa.Data).ToShortDateString(), orario, ((decimal)spesa.Importo).ToString("C"), (string)spesa.Prodotto, (string)spesa.Categoria, (string)spesa.Descrizione);
                                        }

                                        AnsiConsole.Write(tabella);
                                    }
                                }
                                break;

                            case "Modifica Spesa":
                                {
                                    AnsiConsole.MarkupLine("[yellow]Funzionalità di modifica non implementata.[/]");
                                }
                                break;

                            case "Elimina Spesa":
                                {
                                    AnsiConsole.MarkupLine("[yellow]Funzionalità di eliminazione non implementata.[/]");
                                }
                                break;

                            case "Torna al Menù Principale":
                                break;
                        }

                        if (sceltaGestione == "Torna al Menù Principale")
                        {
                            break;
                        }
                    }
                    break;

                case "Categorie di Spesa":
                    AnsiConsole.MarkupLine("[yellow]Categorie di Spesa - Funzionalità non implementata.[/]");
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
