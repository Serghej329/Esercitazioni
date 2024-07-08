/*
Obbiettivo:
Simula il lancio di più dadi e registra i risultati per calcolare statistiche.
*/

/*
Descrizione:
- Il giocatore può decidere quanti dadi lanciare .
- Ogni dado ha 6 facce numerate da 1 a 6.
- Dopo il lancio, il programma deve mostrare il risultato di ogni dado e il totale dei punteggi.
- Gli esiti di ogni turno vengono salvati in un array per calcolare statistiche come la media dei punteggi totali, il punteggio più frequente, ecc.
*/

/*
Passaggi per l'implementazione:
- Chiedi all'utente quanti dadi vuole lanciare.
- Verifica che il numero di dadi sia valido.
- Simula il lancio dei dadi usando un generatore di numeri casuali.
- Salva i risultati di ogni dado in un array.
- Mostra il risultato di ogni dado e il totale.
- Conserva il risultato totale di ogni turno in un'altra lista.
*/
using Spectre.Console;


// Chiede all'utente quanti dadi vuole lanciare
AnsiConsole.Markup("[bold]Quanti dadi vuoi lanciare? (scrivi un numero):[/] ");
int numDadi = int.Parse(Console.ReadLine()!);

// Crea un array per memorizzare i risultati di ogni dado
int[] risultatiDado = new int[numDadi];

// Crea una lista per memorizzare il totale dei numeri ottenuti ad ogni turno
List<int> totNumeri = new List<int>();

int[] freqNum = new int[6];

int turni = 0;
Random random = new Random();

while (true)
{
    turni++;
    AnsiConsole.Markup($"\n[bold yellow]Turno: {turni}[/]\n");

    // Svuotare array freqNum
    freqNum = new int[freqNum.Length];

    /*Animazione 1.0
        // Simula l'animazione del lancio dei dadi
        AnsiConsole.Markup("[italic]Lanciando i dadi[/]");
        for (int i = 0; i < 3; i++)
        {
            AnsiConsole.Markup(".");
            Thread.Sleep(500);  // Aspetta mezzo secondo per simulare l'animazione
        }
        AnsiConsole.MarkupLine("");
    */

    //Animazione 2.0
    for (int i = 0; i < numDadi; i++)
    {
        Console.Write("\r");
        Console.Write("🎲");
        Thread.Sleep(200);
        Console.Write("\r");
        Thread.Sleep(200);    
    }
    Console.Write("\r "); // Canncella il carattere di rotazione
    // Lancia i dadi e memorizza i risultati nell'array
    var diceTable = new Table();
    diceTable.AddColumn("[bold]Dado[/]");
    diceTable.AddColumn("[bold]Risultato[/]");

    for (int i = 0; i < numDadi; i++)
    {
        risultatiDado[i] = random.Next(1, 7);
        diceTable.AddRow((i + 1).ToString(), risultatiDado[i].ToString());

        int risultatoDadoCorrente = risultatiDado[i];

        switch (risultatoDadoCorrente)
        {
            case 1:
                freqNum[0]++;
                break;
            case 2:
                freqNum[1]++;
                break;
            case 3:
                freqNum[2]++;
                break;
            case 4:
                freqNum[3]++;
                break;
            case 5:
                freqNum[4]++;
                break;
            case 6:
                freqNum[5]++;
                break;
            default:
                // Gestione errore, ma in teoria non dovrebbe mai accadere con risultatiDado[i] = random.Next(1, 7);
                AnsiConsole.MarkupLine($"[bold red]ERRORE! Come avresti fatto... Spiegami![/]");
                break;
        }
    }

    // Visualizza la tabella dei risultati dei dadi
    AnsiConsole.Write(diceTable);

    // Calcolo il totale dei risultati dei dadi
    int totNumero = 0;
    for (int i = 0; i < numDadi; i++)
    {
        totNumero += risultatiDado[i];
    }

    // Visualizza il totale dei numeri ottenuti in questo turno
    AnsiConsole.MarkupLine($"\n[bold green]Totale: {totNumero}[/]");

    // Aggiunge il totale del turno alla lista dei totali
    totNumeri.Add(totNumero);

    // Stampa la frequenza di ogni numero alla fine del turno
    var freqTable = new Table();
    freqTable.AddColumn("Numero");
    freqTable.AddColumn("Frequenza");

    for (int i = 0; i < 6; i++)
    {
        // Aggiunge una riga alla tabella delle frequenze.
        // La prima colonna è il numero del dado (da 1 a 6), la seconda colonna è quante volte è uscito quel numero.
        freqTable.AddRow((i + 1).ToString(), freqNum[i].ToString());
    }

    // Visualizza la tabella delle frequenze
    AnsiConsole.Write(freqTable);

    AnsiConsole.MarkupLine("\n[bold]Vuoi lanciare di nuovo? (s/n):[/]");
    string risposta = Console.ReadLine()!.ToLower();
    if (risposta != "s")
    {
        break;
    }
}

// Esempio di visualizzazione dei risultati totali di ogni turno
AnsiConsole.MarkupLine("\n[bold]Risultati totali di ogni turno:[/]");
for (int i = 0; i < totNumeri.Count; i++)
{
    AnsiConsole.MarkupLine($"[bold yellow]Turno {i + 1}[/]: [green]{totNumeri[i]}[/]");
}