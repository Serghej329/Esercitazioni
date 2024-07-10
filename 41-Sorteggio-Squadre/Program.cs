using Spectre.Console;

// Liste delle squadre e delle persone disponibili
List<string> squadra1 = new List<string>();
List<string> squadra2 = new List<string>();
List<string> persone = new List<string> { "Mario", "Luigi", "Francesca", "Giovanni", "Paola", "Simone" };
Random rand = new Random();

// Inserisci persone casualmente nelle due squadre
while (persone.Count > 0)
{
    int indice = rand.Next(persone.Count);
    string persona = persone[indice];
    persone.RemoveAt(indice);

    if (squadra1.Count <= squadra2.Count)
    {
        squadra1.Add(persona);
    }
    else
    {
        squadra2.Add(persona);
    }
}

bool start = true;

while (start)
{
    // Pulisce la console ad ogni ciclo per una visualizzazione pulita
    AnsiConsole.Clear();

    // Mostra il menu con le opzioni
    AnsiConsole.Markup("[bold underline green]Menu:[/]\n");
    AnsiConsole.Markup("[bold green]1.[/] Visualizza squadre\n");
    AnsiConsole.Markup("[bold green]2.[/] Aggiungi persona a una squadra\n");
    AnsiConsole.Markup("[bold green]3.[/] Rimuovi persona da una squadra\n");
    AnsiConsole.Markup("[bold green]4.[/] Sposta persona tra squadre\n");
    AnsiConsole.Markup("[bold green]5.[/] Esci\n");
    AnsiConsole.Markup("[bold yellow]Scegli un'opzione: [/]");
    string scelta = Console.ReadLine();

    switch (scelta)
    {
        case "1":
            // Visualizza le persone in squadra 1
            AnsiConsole.Markup("\n[bold green]Squadra 1:[/]\n");
            var table1 = new Table();
            table1.AddColumn(new TableColumn("[bold underline red]MEMBRI[/]"));
            foreach (string persona in squadra1)
            {
                table1.AddRow(persona);
            }
            AnsiConsole.Render(table1);


            // Visualizza le persone in squadra 2
            AnsiConsole.Markup("\n[bold green]Squadra 2:[/]\n");
            var table2 = new Table();
            table2.AddColumn(new TableColumn("[bold underline red]MEMBRI[/]"));
            foreach (string persona in squadra2)
            {
                table2.AddRow(persona);
            }
            AnsiConsole.Render(table2);
            break;

        case "2":
            // Aggiunge una persona a una squadra specificata
            AnsiConsole.Markup("Inserisci il nome della persona da aggiungere: ");
            string nuovaPersona = Console.ReadLine();
            AnsiConsole.Markup("Inserisci in squadra (1 o 2): ");
            int squadraScelta = int.Parse(Console.ReadLine());

            
            if (squadraScelta == 1)
            {
                squadra1.Add(nuovaPersona);
            }
            else if (squadraScelta == 2)
            {
                squadra2.Add(nuovaPersona);
            }
            else
            {
                AnsiConsole.Markup("[bold red]Scelta non valida.[/]");
            }
            break;

        case "3":
            // Rimuove una persona da una squadra specificata
            AnsiConsole.Markup("Inserisci il nome della persona da rimuovere: ");
            string personaDaRimuovere = Console.ReadLine();
            AnsiConsole.Markup("Inserisci la squadra (1 o 2): ");
            squadraScelta = int.Parse(Console.ReadLine());

            bool personaRimossa = false;
            if (squadraScelta == 1)
            {
                for (int i = 0; i < squadra1.Count; i++)
                {
                    if (squadra1[i] == personaDaRimuovere)
                    {
                        squadra1.RemoveAt(i);
                        personaRimossa = true;
                        break;
                    }
                }
                if (personaRimossa)
                {
                    AnsiConsole.Markup($"[bold yellow]{personaDaRimuovere} è stato rimosso da squadra 1.[/]");
                }
                else
                {
                    AnsiConsole.Markup($"[bold red]{personaDaRimuovere} non è presente in squadra 1.[/]");
                }
            }
            else if (squadraScelta == 2)
            {
                for (int i = 0; i < squadra2.Count; i++)
                {
                    if (squadra2[i] == personaDaRimuovere)
                    {
                        squadra2.RemoveAt(i);
                        personaRimossa = true;
                        break;
                    }
                }
                if (personaRimossa)
                {
                    AnsiConsole.Markup($"[bold yellow]{personaDaRimuovere} è stato rimosso da squadra 2.[/]");
                }
                else
                {
                    AnsiConsole.Markup($"[bold red]{personaDaRimuovere} non è presente in squadra 2.[/]");
                }
            }
            else
            {
                AnsiConsole.Markup("[bold red]Scelta non valida.[/]");
            }
            break;

        case "4":
            // Sposta una persona da una squadra all'altra
            AnsiConsole.Markup("Inserisci il nome della persona da spostare: ");
            string personaDaSpostare = Console.ReadLine();
            AnsiConsole.Markup("Inserisci la squadra di partenza (1 o 2): ");
            int squadraPartenza = int.Parse(Console.ReadLine());
            AnsiConsole.Markup("Inserisci la squadra di destinazione (1 o 2): ");
            int squadraDestinazione = int.Parse(Console.ReadLine());

            bool personaSpostata = false;
            if (squadraPartenza == 1 && squadraDestinazione == 2)
            {
                for (int i = 0; i < squadra1.Count; i++)
                {
                    if (squadra1[i] == personaDaSpostare)
                    {
                        squadra1.RemoveAt(i);
                        squadra2.Add(personaDaSpostare);
                        personaSpostata = true;
                        break;
                    }
                }
                if (personaSpostata)
                {
                    AnsiConsole.Markup($"[bold yellow]{personaDaSpostare} è stato spostato da squadra 1 a squadra 2.[/]");
                }
                else
                {
                    AnsiConsole.Markup($"[bold red]{personaDaSpostare} non è presente in squadra 1.[/]");
                }
            }
            else if (squadraPartenza == 2 && squadraDestinazione == 1)
            {
                for (int i = 0; i < squadra2.Count; i++)
                {
                    if (squadra2[i] == personaDaSpostare)
                    {
                        squadra2.RemoveAt(i);
                        squadra1.Add(personaDaSpostare);
                        personaSpostata = true;
                        break;
                    }
                }
                if (personaSpostata)
                {
                    AnsiConsole.Markup($"[bold yellow]{personaDaSpostare} è stato spostato da squadra 2 a squadra 1.[/]");
                }
                else
                {
                    AnsiConsole.Markup($"[bold red]{personaDaSpostare} non è presente in squadra 2.[/]");
                }
            }
            else
            {
                AnsiConsole.Markup("[bold red]Scelte non valide.[/]");
            }
            break;

        case "5":
            // Esce dal programma
            start = false;
            break;

        default:
            // Gestisce l'input non valido
            AnsiConsole.Markup("[bold red]Scelta non valida.[/]");
            break;
    }

    // Pausa per consentire all'utente di vedere il messaggio prima di continuare
    if (start)
    {
        AnsiConsole.Markup("\n[bold yellow]Premi un tasto per continuare...[/]");
        Console.ReadKey();
    }
}
