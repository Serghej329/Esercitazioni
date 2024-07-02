
Random rand = new Random();
int somma = 0;

Console.WriteLine("Numeri casuali generati: ");
for (int i = 0; i < 10; ++i)
{
    int numero = rand.Next(10); // Genera un numero casuale tra 0 e 9
    Console.Write(numero + " ");
    somma += numero;
}

Console.WriteLine("\nSomma totale: " + somma);
