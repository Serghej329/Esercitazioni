//Pulisce il terminale
Console.Clear();



//MENU'
Console.WriteLine("\t |CALCOLATRICE (2 numeri)| \n\n    MENU' \n 1)ADDIZIONE \n 2)SOTTRAZIONE \n 3)MOLTIPLICAZIONE \n 4)DIVISIONE \n 5)RADICE \n 6)ESPONENZIALE \n Digita il numero dell'operazione che vuoi fare: ");

//Richiesta del tipo di operazione
int operazione = int.Parse(Console.ReadLine()!); // Converte l'input dell'utente in un numero intero

//Rieschiesta dei 2 numeri
Console.WriteLine("Scrivimi il primo numero ");
int n1 = int.Parse(Console.ReadLine()!); // Converte l'input dell'utente in un numero intero
Console.WriteLine("Scrivimi il secondo numero");

int n2 = int.Parse(Console.ReadLine()!); // Converte l'input dell'utente in un numero intero

//Controlli operazioni
switch (operazione) // Esegue un'operazione diversa in base al valore di "operazione"
{
    case 1: // Somma
        int somma = n1 + n2;
        Console.WriteLine($"IL RISUALTO E' = {somma}"); // Stampa il risultato
        break;

    case 2: // Sottrazione
        int sottrazione = n1 - n2;
        Console.WriteLine($"IL RISUALTO E' = {sottrazione}"); // Stampa il risultato
        break;

    case 3: // Moltiplicazione
        int moltiplicazione = n1 * n2;
        Console.WriteLine($"IL RISUALTO E' = {moltiplicazione}"); // Stampa il risultato
        break;

    case 4: // Divisione
        if (n2 != 0) // Controlla se il divisore è diverso da zero
        {
            int divisione = n1 / n2;
            Console.WriteLine($"IL RISUALTO E' = {divisione}"); // Stampa il risultato
        }
        else
        {
            Console.WriteLine("Indefinita"); // Stampa un messaggio di errore
        }
        break;

    case 5: // Radice quadrata
        double radice1 = Math.Sqrt(n1); // Calcola la radice quadrata di n1
        double radice2 = Math.Sqrt(n2); // Calcola la radice quadrata di n2
        Console.WriteLine($"IL RISUALTI SONO: \n PRIMO NUMERO = {radice1} \n SECONDO NUMERO = {radice2}"); // Stampa i risultati
        break;

    case 6: // Potenza
        double esponenziale = Math.Pow(n1, n2); // Calcola n1 elevato alla potenza n2
        Console.WriteLine($"IL RISUALTO E' = {esponenziale}"); // Stampa il risultato
        break;

    default: // Se l'operazione non è valida
        Console.WriteLine("Il numero non corrisponde a nessun delle operazioni "); // Stampa un messaggio di errore
        break;
}
