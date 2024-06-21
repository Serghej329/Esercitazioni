//un blocco di codice è composto da parentesi {} e puo contenere uno p piu statement 

/* Le condizioni sono utilizzate per eseguire un blocco di codice solo se una condizione è vera */

/*Le condizioni possono essere

if
if-else
if-else if-else
switch
*/

//if - se il  numero è uguale a 10 stampa il numero

Console.Clear();

//Primo esercizio
int numero = 10;

int verifica = 10;

if (numero == verifica)
{
    Console.WriteLine($"hai indovinato il numero era proprio: {numero}");
}
else
{
    Console.WriteLine("no, non è ugualeeee! riprovaci, sarai più fortunato");
}

Console.WriteLine("secondo te che numero era? ti darò un'indizio");
//Secondo esercizio
int numero2 =15;

if (numero2 == 10)
{
    Console.WriteLine($"il numero è uguale a {numero2}");
}
else if (numero2 < 10)
{
    Console.WriteLine($"il numero è minore di 10");
}
else
{
    Console.WriteLine($"il numero è maggiore di 10");
}


//Switch
int giorno = 1;

switch (giorno)
{
    case 1:
        Console.WriteLine("Lunedì");
        break;

    case 2:
        Console.WriteLine("Martedì");
        break;

    case 3:
        Console.WriteLine("Mercoledi");
        break;

    case 4:
        Console.WriteLine("Giovedì");
        break;

    case 5:
        Console.WriteLine("Venerdì");
        break;

    case 6:
        Console.WriteLine("Sabato");
        break;

    case 7:
        Console.WriteLine("Domenica");
        break;

    default:
        Console.WriteLine("Il numero non corrisponde a nessungiorno della settimana");
        break;
}