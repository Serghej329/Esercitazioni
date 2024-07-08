List<int> numeri = new List<int>() { 10, 20, 30 };

Random random = new Random();
int indice = random.Next(0, numeri.Count);
int numeroSorteggiato = numeri[indice];

int numeroInserito;

do
{
    Console.WriteLine("Indovina il numero sorteggiato:");
    numeroInserito = int.Parse(Console.ReadLine()!);

    if (numeroInserito > numeroSorteggiato)
    {
        Console.WriteLine("Il numero che hai inserito è troppo alto. Prova con un numero più piccolo.");
    }
    else if (numeroInserito < numeroSorteggiato)
    {
        Console.WriteLine("Il numero che hai inserito è troppo basso. Prova con un numero più grande.");
    }
} while (numeroInserito != numeroSorteggiato);

Console.WriteLine($"Hai indovinato! Il numero era {numeroSorteggiato}");
