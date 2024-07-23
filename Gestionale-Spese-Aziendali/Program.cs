using Newtonsoft.Json;
using Spectre.Console;
using System.Diagnostics;

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
                    /*ReportAnalisi();*/
                    break;

                case "Esci":
                    return;
            }
        }
    }

    static List<dynamic> CaricaProdotti(string path)
    {
        if (File.Exists(path)) // Viene mantenuto il controllo per verificare se il file esiste.
        {
            //si tenta di leggere il contenuto e deserializzarlo.
            try
            {
                string json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<List<dynamic>>(json)!;
            }
            catch (Exception ex) // In caso di eccezione durante la deserializzazione, viene stampato un messaggio di errore e viene restituita una lista vuota.
            {
                // Gestione dell'errore
                Console.WriteLine($"Errore durante il caricamento dei prodotti: {ex.Message}");
                return new List<dynamic>();
            }
        }
        else
        {
            return new List<dynamic>();
        }
    }

    static List<string> CaricaCategorie(string path)
    {
        if (File.Exists(path)) // Viene mantenuto il controllo per verificare se il file esiste.
        {
            //si tenta di leggere il contenuto e deserializzarlo.
            try
            {
                string json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<List<string>>(json)!;
            }
            catch (Exception ex) // In caso di eccezione durante la deserializzazione, viene stampato un messaggio di errore e viene restituita una lista vuota.
            {
                // Gestione dell'errore
                Console.WriteLine($"Errore durante il caricamento delle categorie: {ex.Message}");
                return new List<string>();
            }
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
                prodottiOrdinati = new List<dynamic>(Prodotti);
                break;
            case "Di categoria":
                prodottiOrdinati = new List<dynamic>(Prodotti);
                break;
            case "Di prezzo (alto a basso)":
                prodottiOrdinati = new List<dynamic>(Prodotti);
                break;
            case "Di prezzo (basso ad alto)":
                prodottiOrdinati = new List<dynamic>(Prodotti);
                break;
        }

        VisualizzaProdottiInTabella(prodottiOrdinati);

         var esporta = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Vuoi esportare in csv? (excel)")
                .AddChoices("si", "no"));

        if (esporta == "si")
        {
           EsportaCSV(Prodotti);
        }

        
    }

    static void OrdinaAlfabetico(List<dynamic> prodottiOrdinati)
    {
        var ordine = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Scegli l'ordine di visualizzazione:")
                .AddChoices("Crescente", "Decrescente"));

        if (ordine == "Crescente")
        {
            prodottiOrdinati.Sort(/*OrdinaPerNomeCrescente*/);
        }
        else
        {
            prodottiOrdinati.Sort(/*OrdinaPerNomeDecrescente*/);
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

        var prodottiFiltrati = new List<dynamic>();
        foreach (var prodotto in Prodotti)
        {
            if ((string)prodotto.Categoria == categoriaSelezionata)
            {
                prodottiFiltrati.Add(prodotto);
            }
        }

        if (prodottiFiltrati.Count == 0)
        {
            AnsiConsole.MarkupLine("[yellow]Nessun prodotto trovato per la categoria selezionata.[/]");
        }
        else
        {
            VisualizzaProdottiInTabella(prodottiFiltrati);
        }
    }

    static void EsportaCSV(List<dynamic> Prodotti)
    {
        if (Prodotti.Count == 0)
        {
            AnsiConsole.MarkupLine("[yellow]Nessun prodotto registrato.[/]");
            return;
        }

        // Percorso del file CSV
        string pathCSV = "Prodotti.csv";


        using (var writer = new StreamWriter(pathCSV))
        {
            // Scrivi l'intestazione del file CSV
            writer.WriteLine("Indice,Data,Orario,Importo,Prodotto,Categoria,Descrizione");

            // Scrivi i dati dei prodotti
            for (int i = 0; i < Prodotti.Count; i++)
            {
                var prodottoItem = Prodotti[i];
                string data = ((DateTime)prodottoItem.Data).ToShortDateString();
                string orario = ((DateTime)prodottoItem.Data).ToString("HH:mm");
                string importo = ((decimal)prodottoItem.Importo).ToString("F2");
                string prodotto = (string)prodottoItem.Prodotto;
                string categoria = (string)prodottoItem.Categoria;
                string descrizione = (string)prodottoItem.Descrizione;

                writer.WriteLine($"{i},{data},{orario},{importo},{prodotto},{categoria},{descrizione}");
            }
        }

        var apriFile = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Vuoi aprire il file :")
                .AddChoices("si", "no"));

        if (apriFile == "si")
        {
            Process.Start("excel.exe", "Prodotti.csv");
        }

    }



    // Funzioni di ordinamento esplicite
}
