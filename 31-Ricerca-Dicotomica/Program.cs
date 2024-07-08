bool playAgain = true;
List<int> tentativiPartita = new List<int>();

while (playAgain)
{
    Random random = new Random();
    int min = 1;
    int max = 100;
    int tentativi = 0;
    int tentativiMax;
    bool indovinato = false;

    // SCELTA DEL NOME
    Console.Write("Scegli Nickname: ");
    string nome = Console.ReadLine();

    Console.WriteLine($"Ciao {nome}, pensa ad un numero tra 1 e 100 e non dirlo a nessuno.");
    Console.WriteLine("Il PC cercherà di indovinare il numero usando la ricerca dicotomica.");
    Console.WriteLine("");
    Console.Write("Inserisci il numero massimo di tentativi (massimo 100): ");
    tentativiMax = int.Parse(Console.ReadLine());

    if (tentativiMax <= 0 || tentativiMax > 100)
    {
        Console.WriteLine("Errore: il numero di tentativi deve essere compreso tra 1 e 100.");
        return;
    }

    Console.WriteLine("Premi un tasto qualsiasi per iniziare");
    Console.ReadKey();
    Console.WriteLine("");

    while (!indovinato && tentativi < tentativiMax)
    {
        int mid = min + (max - min) / 2; // Calcolo del punto medio

        Console.WriteLine($"Tentativo {tentativi + 1}/{tentativiMax}: Il PC prova {mid}");
        Console.Write("Inserisci aiuto (+, -, c): ");

        string risposta;
        do
        {
            risposta = Console.ReadLine().ToUpper();
            if (risposta != "+" && risposta != "-" && risposta != "C")
            {
                Console.WriteLine("INSERIMENTO ERRATO");
                Console.WriteLine("Scegli tra queste 3 opzioni: \n '+' se il numero che hai pensato è MAGGIORE del numero scelto dal Pc \n '-' se il numero che hai pensato è MINORE del numero scelto dal Pc \n 'c/C' se il numero che hai pensato è stato INDOVINATO dal Pc");
            }
        } while (risposta != "+" && risposta != "-" && risposta != "C");

        if (risposta == "C")
        {
            indovinato = true;
            Console.WriteLine($"\nIl PC ha indovinato il numero {mid} in {tentativi + 1} tentativi. COMPLIMENTI!");
            break;
        }
        else if (risposta == "+")
        {
            min = mid + 1;
        }
        else if (risposta == "-")
        {
            max = mid - 1;
        }

        tentativi++; // Incrementa il contatore dei tentativi
    }

    if (!indovinato)
    {
        Console.WriteLine("Tentativi esauriti. Il PC ha perso!");
    }

    // Aggiungi i tentativi di questa partita alla lista
    tentativiPartita.Add(tentativi + 1);

    Console.WriteLine("Vuoi riprovare? (s/n): ");
    string playAgainResponse = Console.ReadLine().ToLower();
    playAgain = (playAgainResponse == "s");
}

// Calcola e visualizza la media dei tentativi per trovare il numero 
double mediaTentativi = tentativiPartita.Average();
Console.WriteLine($"La media dei tentativi per trovare il numero è: {mediaTentativi}");

