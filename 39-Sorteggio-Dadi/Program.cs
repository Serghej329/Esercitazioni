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
/*
// Chiede all'utente quanti dadi vuole lanciare
Console.WriteLine("Quanti dadi vuoi lanciare? (scrivi un numero):");
int numDadi = int.Parse(Console.ReadLine()!);


// Crea un array per memorizzare i risultati di ogni dado
int[] risultatiDado = new int[numDadi];

// Crea una lista per memorizzare il totale dei numeri ottenuti ad ogni turno
List<int> totNumeri = new List<int>();

/*
// Crea una lista per memorizzare il risultato totale di ogni turno
List<int> risultatiTotaliTurni = new List<int>();
*//*
int[] freqNum = new int[6];

int turni = 0;
Random random = new Random();


while (true)
{
    turni++;
    Console.WriteLine($"\nTurno:  {turni}");

    // Svuotare array freqNum
    freqNum = new int[freqNum.Length];
    // 

    // Lancia i dadi e memorizza i risultati nell'array
    for (int i = 0; i < numDadi; i++)
    {
        risultatiDado[i] = random.Next(1, 7);
        Console.Write($" |{risultatiDado[i]}|"); // Visualizza il risultato del dado

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
                Console.WriteLine($"ERRORE! Come avresti fatto... Spiegami!");
                break;
        }
    }

    // Calcolo il totale dei risultati dei dadi
    int totNumero = 0;
    for (int i = 0; i < numDadi; i++)
    {
        totNumero += risultatiDado[i];
    }

    // Visualizz il totale dei numeri ottenuti in questo turno
    Console.WriteLine($"\nTotale: {totNumero}");

    // Aggiunge il totale del turno alla lista dei totali
    totNumeri.Add(totNumero);

    // Stampa la frequenza di ogni numero alla fine del turno
    for (int i = 0; i < 6; i++)
    {
        Console.WriteLine($"Frequenza numero {i + 1}: {freqNum[i]} volte uscito");
    }

    /*
        // Aggiunge il risultato totale del turno alla lista apposita
        risultatiTotaliTurni.Add(turni);
    */
/*
    Console.WriteLine("\nVuoi lanciare di nuovo? (s/n):");
    string risposta = Console.ReadLine()!.ToLower();
    if (risposta != "s")
    {
        break;
    }
}

// Esempio di visualizzazione dei risultati totali di ogni turno
Console.WriteLine("\nRisultati totali di ogni turno:");
for (int i = 0; i < totNumeri.Count; i++)
{
    Console.WriteLine($"Turno {i + 1}: {totNumeri[i]}");
}
*/

        // Chiede all'utente quanti dadi vuole lanciare
        Console.WriteLine("Quanti dadi vuoi lanciare? (scrivi un numero):");
        int numDadi = int.Parse(Console.ReadLine()!);

        // Verifica che il numero di dadi sia valido
        if (numDadi <= 0)
        {
            Console.WriteLine("Il numero di dadi deve essere maggiore di zero.");
            return;
        }

        // Crea un array per memorizzare i risultati di ogni dado
        int[] risultatiDado = new int[numDadi];

        // Crea una lista per memorizzare il totale dei numeri ottenuti ad ogni turno
        List<int> totNumeri = new List<int>();

        // Crea un array per la frequenza di ogni numero
        int[] freqNum = new int[6];

        int turni = 0;
        Random random = new Random();

        while (true)
        {
            turni++;
            Console.WriteLine($"\nTurno:  {turni}");

            // Svuotare array freqNum
            Array.Clear(freqNum, 0, freqNum.Length);

            // Lancia i dadi e memorizza i risultati nell'array
            for (int i = 0; i < numDadi; i++)
            {
                risultatiDado[i] = random.Next(1, 7);
                Console.Write($" |{risultatiDado[i]}|"); // Visualizza il risultato del dado

                // Incrementa la frequenza del risultato corrente
                freqNum[risultatiDado[i] - 1]++;
            }

            // Calcolo il totale dei risultati dei dadi
            int totNumero = 0;
            for (int i = 0; i < numDadi; i++)
            {
                totNumero += risultatiDado[i];
            }

            // Visualizza il totale dei numeri ottenuti in questo turno
            Console.WriteLine($"\nTotale: {totNumero}");

            // Aggiunge il totale del turno alla lista dei totali
            totNumeri.Add(totNumero);

            // Stampa la frequenza di ogni numero alla fine del turno
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"Frequenza numero {i + 1}: {freqNum[i]} volte uscito");
            }

            // Chiede all'utente se vuole lanciare di nuovo
            Console.WriteLine("\nVuoi lanciare di nuovo? (s/n):");
            string risposta = Console.ReadLine()!.ToLower();
            if (risposta != "n")
            {
                continue;
            }
            else
            {
                break;
            }
        }

        // Esempio di visualizzazione dei risultati totali di ogni turno
        Console.WriteLine("\nRisultati totali di ogni turno:");
        for (int i = 0; i < totNumeri.Count; i++)
        {
            Console.WriteLine($"Turno {i + 1}: {totNumeri[i]}");
        }

        // Calcolo statistiche finali
        if (totNumeri.Count > 0)
        {
            // Media dei punteggi totali
            int somma = 0;
            foreach (int numero in totNumeri)
            {
                somma += numero;
            }
            double media = (double)somma / totNumeri.Count;
            Console.WriteLine($"\nMedia dei punteggi totali: {media:F2}");

            // Punteggio più frequente
            Dictionary<int, int> frequenze = new Dictionary<int, int>();
            foreach (int numero in totNumeri)
            {
                if (frequenze.ContainsKey(numero))
                {
                    frequenze[numero]++;
                }
                else
                {
                    frequenze[numero] = 1;
                }
            }

            int punteggioFrequente = 0;
            int maxFrequenza = 0;

            foreach (KeyValuePair<int, int> entry in frequenze)
            {
                if (entry.Value > maxFrequenza)
                {
                    maxFrequenza = entry.Value;
                    punteggioFrequente = entry.Key;
                }
            }

            Console.WriteLine($"Punteggio più frequente: {punteggioFrequente}");
        }

