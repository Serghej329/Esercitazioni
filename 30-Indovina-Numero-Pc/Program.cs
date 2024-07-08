//in C#
//il proogramma chiede di pensare un numero 
//il pc prova ad indovinare il numero in maniera casuale all'interno dell'intervallo (1 e 100) 
//il programma chiede di inserire un aiuto che puo essere +(IL NUMERO è PIU GRANDE), -(IL NUMERO è PIU PICCOLO), o Corretto(NUMERO INDOVINATO)
//il programma sceglie i numeri successivi fino ad un massimo di 5 tentativi con la seguente logica: ad ogni numPc il pc sorteggia un numero compreso fra il numero scelto in precedenza (+1 o -1) ed un numero casuale 
//se dopo i primi 4 tentativi il pc non riesce ad indovinare fà un'ultimo numPc casuale nel range dei numeri filtrati fino al numPc il programma stampa lo stato del vincitore (se il pc ha indovinato e il numero è corretto entro i tentativi ha vinto altrimenti ha perso)

/*

Random random = new Random();
int min = 1;
int max = 100;
int tentativi = 5;
bool indovinato = false;

Console.WriteLine("Pensa ad un numero tra 1 e 100 e non dirlo a nessuno.");
Console.WriteLine("Il PC cercherà di indovinare il numero.");

for (int numPc = 1; numPc <= tentativi; numPc++)
{
    int numPc = random.Next(min, max + 1);
    Console.WriteLine($"numPc {numPc}: Il PC indovina {numPc}");
    Console.Write("Inserisci aiuto: + (più grande) - (più piccolo), c (Numero corretto) ");
    string risposta = Console.ReadLine().ToUpper();

    if (risposta == "C")
    {
        indovinato = true;
        Console.WriteLine($"Il PC ha indovinato il numero {numPc} in {numPc} tentativi. Ha vinto!");
        break;
    }
    else if (risposta == "+")
        min = numPc + 1;
    else if (risposta == "-")
        max = numPc - 1;
}

if (!indovinato)
{
    int numPcFinale = random.Next(min, max + 1);
    Console.WriteLine($"numPc finale: Il PC sceglie {numPcFinale}");
    Console.Write("Inserisci aiuto (+, -, c): ");
    string rispostaFinale = Console.ReadLine().ToUpper();

    if (rispostaFinale == "C")
        Console.WriteLine($"Il PC ha indovinato il numero {numPcFinale}. Ha vinto!");
    else
        Console.WriteLine("Il PC non è riuscito ad indovinare il numero. Ha perso!");
}
*/

//Codice migliorato di quello sopra
Random random = new Random();
int min = 1;
int max = 100;
int tentativi = 0;
bool indovinato = false;

// SCELTA DEL NOME
Console.Write("Scegli Nickname: ");
string nome = Console.ReadLine();

Console.WriteLine($"Ciao {nome}, pensa ad un numero tra 1 e 100 e non dirlo a nessuno.");
Console.WriteLine("Il PC cercherà di indovinare il numero.");
Console.WriteLine("");
Console.WriteLine("Premi un tasto qualsiasi per iniziare");
Console.ReadKey();
Console.WriteLine("");
while (!indovinato && tentativi < 10)
{
    int numPc = random.Next(min, max + 1);
    /*if (numPc >= 1 && numPc <= 100)
    {*/
    Console.WriteLine($"Tentativo {tentativi + 1}: Il PC Sceglie {numPc} (tra {min} e {max})");
    Console.Write("Inserisci aiuto (+, -, c): ");

    string risposta;
    //Controllo che la risposta dell'utente sia corretta (+, -, c) altrimenti richiedilo
    //Considera la "c" anche se maiuscola o minuscola
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
        Console.WriteLine($"\nIl PC ha indovinato il numero {numPc} in {tentativi + 1} tentativi. COMPLIMENTI!");
        break;

    }
    else if (risposta == "+")
    {
        Console.WriteLine("\nIl numero è più grande!");
        min = numPc + 1;
        Console.WriteLine($"max: {max} min: {min}");
    }
    else if (risposta == "-")
    {
        Console.WriteLine("\nIl numero è più piccolo!");
        max = numPc - 1;
        Console.WriteLine($"max: {max} min: {min}");
    }

    tentativi++;
}
/* else
 {
     indovinato = true;
     Console.WriteLine($"Il numero che hai pensato non puo andare sopra a {max} o sotto a {min}");
     Console.WriteLine($"Il PC ha indovinato il numero {numPc} in {tentativi + 1} tentativi. COMPLIMENTI!");
 }
}*/
if (!indovinato)
{
    Console.WriteLine("Tentativi esauriti. Il PC ha perso!");
}
