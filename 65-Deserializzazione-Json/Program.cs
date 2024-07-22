using Newtonsoft.Json;
class Program
{
    static void Main(string[] args)
    {
        string path = @"test.json";
        string json = File.ReadAllText(path);
        dynamic obj = JsonConvert.DeserializeObject(json)!;
        string path2 = @"test.csv";
        File.Create(path2).Close();
        File.AppendAllText(path2, "nome, cognome, eta, via, citta\n");
        for (int i = 0; i < obj.Count; i++)
        {
            File.AppendAllText(path2, $"{obj[i].nome},{obj[i].cognome}, {obj[i].eta}, {obj[i].indirizzo.via},{obj[i].indirizzo.citta}\n");
        }
    }
}
/*
                            case "Visualizza Spese":
                                {
                                    if (spese.Count == 0)
                                    {
                                        AnsiConsole.MarkupLine("[yellow]Nessuna spesa registrata.[/]");
                                    }
                                    else
                                    {
                                        // Prompt per selezionare l'ordine di visualizzazione
                                        var ordine = AnsiConsole.Prompt(
                                            new SelectionPrompt<string>()
                                                .Title("Scegli l'ordine di visualizzazione:")
                                                .AddChoices("Alfabetico", "Di inserimento", "Di data", "Di categoria", "Di prezzo (alto a basso)", "Di prezzo (basso ad alto)"));

                                        // Ordina le spese in base all'opzione scelta
                                        switch (ordine)
                                        {
                                            case "Alfabetico":
                                                spese = spese.OrderBy(s => (string)s.Prodotto).ToList();
                                                break;
                                            case "Di inserimento":
                                                spese = spese.OrderBy(s => (DateTime)s.Data).ToList();
                                                break;
                                            case "Di data":
                                                spese = spese.OrderBy(s => (DateTime)s.Data).ToList();
                                                break;
                                            case "Di categoria":
                                                spese = spese.OrderBy(s => (string)s.Categoria).ToList();
                                                break;
                                            case "Di prezzo (alto a basso)":
                                                spese = spese.OrderByDescending(s => (decimal)s.Importo).ToList();
                                                break;
                                            case "Di prezzo (basso ad alto)":
                                                spese = spese.OrderBy(s => (decimal)s.Importo).ToList();
                                                break;
                                        }

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
*/