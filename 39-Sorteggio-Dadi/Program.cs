/*
Obbiettivo:
Simula il lancio di più dadi e registra i risultati per calcolare statistiche.
*/

/*
Descrizione:
- Il giocatore può decidere quanti dadi lanciare (ad esempio, da 1 a 6).
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

// Chiede all'utente quanti dadi vuole lanciare
Console.WriteLine("Quanti dadi vuoi lanciare? (scrivi un numero):");
int numeroDadi = int.Parse(Console.ReadLine());


// Crea un array per memorizzare i risultati di ogni dado
int[] risultatiDado = new int[numeroDadi];

// Crea una lista per memorizzare il totale dei numeri ottenuti ad ogni turno
List<int> totaleNumeri = new List<int>();

/*
// Crea una lista per memorizzare il risultato totale di ogni turno
List<int> risultatiTotaliTurni = new List<int>();
*/
int[] frequenzaNumeri = new int[6];

int turni = 0;
Random random = new Random();


while (true)
{
    turni++;
    Console.WriteLine($"\nTurno:  {turni}");

    //TODO Svuotare array frequenzaNumeri

    // Lancia i dadi e memorizza i risultati nell'array
    for (int i = 0; i < numeroDadi; i++)
    {
        risultatiDado[i] = random.Next(1, 7);
        Console.Write($" |{risultatiDado[i]}|"); // Visualizza il risultato del dado

        int risultatoDadoCorrente = risultatiDado[i];

        switch (risultatoDadoCorrente)
        {
            case 1:
                frequenzaNumeri[0]++;
                break;
            case 2:
                frequenzaNumeri[1]++;
                break;
            case 3:
                frequenzaNumeri[2]++;
                break;
            case 4:
                frequenzaNumeri[3]++;
                break;
            case 5:
                frequenzaNumeri[4]++;
                break;
            case 6:
                frequenzaNumeri[5]++;
                break;
            default:
                // Gestione errore, ma in teoria non dovrebbe mai accadere con Next(1, 7)
                Console.WriteLine($"ERRORE! COMEEE");
                break;
        }
    }

    // Calcola il totale dei risultati dei dadi
    int totaleNumero = 0;
    for (int i = 0; i < numeroDadi; i++)
    {
        totaleNumero += risultatiDado[i];
    }

    // Visualizza il totale dei numeri ottenuti in questo turno
    Console.WriteLine($"\nTotale: {totaleNumero}");

    // Aggiunge il totale del turno alla lista dei totali
    totaleNumeri.Add(totaleNumero);

    // Stampa la frequenza di ogni numero alla fine del turno
    for (int i = 0; i < 6; i++)
    {
        Console.WriteLine($"Frequenza numero {i + 1}: {frequenzaNumeri[i]} volte uscito");
    }

    /*
        // Aggiunge il risultato totale del turno alla lista apposita
        risultatiTotaliTurni.Add(turni);
    */


    Console.WriteLine("\nVuoi lanciare di nuovo? (s/n):");
    string risposta = Console.ReadLine().ToLower();
    if (risposta != "s")
    {
        break;
    }
}

// Esempio di visualizzazione dei risultati totali di ogni turno
Console.WriteLine("\nRisultati totali di ogni turno:");
for (int i = 0; i < totaleNumeri.Count; i++)
{
    Console.WriteLine($"Turno {i + 1}: {totaleNumeri[i]}");
}
