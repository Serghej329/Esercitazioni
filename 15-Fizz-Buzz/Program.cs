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

//Terzo metodo
for(int i = 0; i < 100; i++){
    Console.Write($"Numero |{i}| \t");
    Thread.Sleep(200);
    if(i % 3 == 0) Console.Write($"Fizz");
    if(i % 5 == 0) Console.Write($"Buzz");
    Console.Write("\n");
} 
