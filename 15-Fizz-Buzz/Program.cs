/*
//Primo metodo
Random random = new Random();

for (int n1 = random.Next(100); n1 < 100; n1++)
{
    if (n1 % 5 == 0 && n1 % 3 == 0) // n1 % 15 == 0
    {
        Console.WriteLine($"FizzBuzz {n1}");
    }
    else if (n1 % 5 == 0)
    {
        Console.WriteLine($"Buzz {n1}");
    }
    else if (n1 % 3 == 0)
    {
        Console.WriteLine($"Fizz {n1}");
    }
}

*/

/*
//Secondo metodo
while (true)
{
Console.WriteLine("scrivimi un numero");
int n1 = int.Parse(Console.ReadLine()!);

    if (n1 % 15 == 0)
    {
        Console.WriteLine($"|FizzBuzz| {n1}");
    }
    else if (n1 % 5 == 0)
    {
        Console.WriteLine($"|Buzz| {n1}");
    }
    else if (n1 % 3 == 0)
    {
        Console.WriteLine($"|Fizz| {n1}");
    }
}
*/

/*
//Terzo metodo
for(int i = 0; i < 100; i++){
    Console.Write($"Numero |{i}| \t");
    Thread.Sleep(200);
    if(i % 3 == 0) Console.Write($"Fizz");
    if(i % 5 == 0) Console.Write($"Buzz");
    Console.Write("\n");
} 
*/

/*
//Quarto metodo
//Ricreare il FizzBuzz usando le liste
List<string> fizzBuzzList = new List<string>();


for (int i = 1; i <= 100; i++)
{
    if (i % 15 == 0)
    {
        fizzBuzzList.Add("FizzBuzz");
    }
    else if (i % 5 == 0)
    {
        fizzBuzzList.Add("Buzz");
    }
    else if (i % 3 == 0)
    {
        fizzBuzzList.Add("Fizz");
    }
    else
    {
        fizzBuzzList.Add($"{i}");
    }
}

foreach (string c in fizzBuzzList)
{
    Console.WriteLine(c);
}
*/

//Quinto metodo Da sistemare (Comprensione/Logica errata )
Random random = new Random();
List<int> numeri = new List<int>();

// Generare la lista dei numeri
for (int i = 0; i < 100; i++)
{
     numeri.Add(random.Next(100));
     numeri = numeri.Distinct().ToList();
}

// Scorrere l'elenco e applicare la logica di FizzBuzz direttamente all'Output
foreach (int numero in numeri)
{
    if (numero % 15 == 0)
    {
        Console.WriteLine($"{numero} FizzBuzz");
    }
    else if (numero % 5 == 0)
    {
        Console.WriteLine($"{numero} Buzz ");
    }
    else if (numero % 3 == 0)
    {
        Console.WriteLine($"{numero} Fizz");
    }
}