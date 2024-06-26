# FizzBuzz

### Questo readme.md documenta tre diversi metodi per implementare il classico gioco FizzBuzz in C#. Il gioco consiste nel generare una sequenza di numeri da 1 a 100, sostituendo i numeri divisibili per 3 con "Fizz", quelli divisibili per 5 con "Buzz" e quelli divisibili per entrambi 3 e 5 con "FizzBuzz". 

```Mermaid
flowchart TD
    A(15) --> B[ FIZZBUZZ ]
    C(3) --> D[ FIZZ ]
    E(5) --> F[ BUZZ ]
```
### Esempio
Console:
```
> Numero |0| ---> FizzBuzz
> Numero |1|
> Numero |2| 
> Numero |3| ---> Fizz
> Numero |4|
> Numero |5| ---> Buzz
> Numero |6| ---> Fizz
> Numero |7|
> Numero |8| 
> Numero |9| ---> Fizz
> Numero |10| ---> Buzz
> Numero |11|
> Numero |12| ---> Fizz
> Numero |13|
> Numero |14| 
> Numero |15| ---> FizzBuzz
> Numero |16|
> Numero |17| 
> Numero |18| ---> Fizz
...Ecc
```

## Primo metodo: Ciclo casuale
 Il primo metodo utilizza un ciclo for e un oggetto Random per generare numeri casuali tra 1 e 100. All'interno del ciclo, si verificano le seguenti condizioni:
- Se il numero è divisibile sia per 3 che per 5 (equivalente a n1 % 15 == 0), viene stampato "FizzBuzz".
- Se il numero è divisibile solo per 5 (n1 % 5 == 0), viene stampato "Buzz".
- Se il numero è divisibile solo per 3 (n1 % 3 == 0), viene stampato "Fizz".

```c#
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
```
## Secondo metodo: Input utente
Il secondo metodo utilizza un ciclo while per richiedere all'utente di inserire un numero. Il numero viene quindi controllato per la divisibilità per 3, 5 e 15, e viene stampato il corrispondente output "Fizz", "Buzz" o "FizzBuzz".
```c#
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

```
## Terzo metodo: Input utente
Il terzo metodo utilizza un ciclo for per generare una sequenza di numeri da 0 a 99. Per ogni numero, viene verificata la divisibilità per 3 e 5, e vengono stampati "Fizz", "Buzz" o entrambi a seconda del risultato. La funzione Thread.Sleep(200) introduce un ritardo di 200 millisecondi tra ogni numero, creando un effetto di animazione.

```c#
//Terzo metodo
for(int i = 0; i < 100; i++){
    Console.Write($"Numero |{i}| \t");
    Thread.Sleep(200);
    if(i % 3 == 0) Console.Write($"Fizz");
    if(i % 5 == 0) Console.Write($"Buzz");
    Console.Write("\n");
}

```

## Conclusione
Tutti e tre i metodi implementano correttamente il gioco FizzBuzz in C#. La scelta del metodo da utilizzare dipende dalle esigenze specifiche e dal contesto di utilizzo. Il primo metodo è utile per generare una sequenza casuale di numeri, il secondo permette di interagire con l'utente e il terzo crea un effetto di animazione visiva.
