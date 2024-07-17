
int[] dadi = new int[5]; // Array per contenere i dadi
Random random = new Random(); // Oggetto Random per generare i lanci

// Lancio iniziale dei dadi e visualizzazione
Console.WriteLine("Benvenuto a Yahtzee semplificato!");
Console.WriteLine("Lancio iniziale dei dadi:");

for (int i = 0; i < dadi.Length; i++)
{
    dadi[i] = random.Next(1, 7); // Numeri casuali da 1 a 6 per ogni dado
    Console.Write(dadi[i] + " ");
}

Console.WriteLine(); // Andare a capo dopo i dadi iniziali

// Chiede all'utente quali dadi vuole cambiare
Console.WriteLine("Quale dado vuoi cambiare? (1-5, separati da spazio. 0 per nessuno)");
string input = Console.ReadLine()!;
int[] inputSplit =  Array.ConvertAll(input.Split(' '), int.Parse);


/*
int[] dadiDaCambiare = new int[inputSplit.Length];

for (int i = 0; i < inputSplit.Length; i++)
{
    dadiDaCambiare[i] = int.Parse(inputSplit[i]);
}*/

// Tira nuovamente i dadi selezionati
Console.WriteLine("Lancio dei dadi selezionati:");

for (int i = 0; i < inputSplit.Length; i++)
{
    dadi[inputSplit[i] - 1] = random.Next(1, 7); // Genera un numero casuale per il dado selezionato
}

// Visualizza i dadi dopo il cambio
for (int i = 0; i < dadi.Length; i++)
{
    Console.Write(dadi[i] + " ");
}

Console.WriteLine(); // Andare a capo dopo i dadi selezionati


// PROVA PUNTEGGI
// Calcola il punteggio basato sul numero di dadi uguali
int[] frequenze = new int[6]; // Array per contare le frequenze di ogni dado (da 1 a 6)

// Aggiorna le frequenze dei dadi attuali
foreach (var dado in dadi)
{
    frequenze[dado - 1]++; // Incrementa il contatore per il valore del dado corrente
}

// Trova il valore del dado con la frequenza più alta
int valoreDado = 0;
int maxFrequenza = 0;

for (int i = 0; i < frequenze.Length; i++)
{
    if (frequenze[i] > maxFrequenza)
    {
        maxFrequenza = frequenze[i];
        valoreDado = i + 1; // Il valore del dado è l'indice + 1
    }
}

// Calcola il punteggio come il massimo numero di dadi identici moltiplicato per il valore del dado
/*int punteggio = maxFrequenza * valoreDado;*/

// Visualizza il punteggio
Console.WriteLine($"Il tuo punteggio è: {valoreDado}");

