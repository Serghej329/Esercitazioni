//Pulisci il terminale
Console.Clear();

//MENU'
Console.WriteLine("\t |CALCOLATRICE (2 numeri)| \n\n    MENU' \n 1)ADDIZIONE \n 2)SOTTRAZIONE \n 3)MOLTIPLICAZIONE \n 4)DIVISIONE \n 5)RADICE \n 6)ESPONENZIALE \n Digita il numero dell'operazione che vuoi fare: ");

/*
int giorno = Convert.ToInt32(Console.ReadLine());
*/
//Richiesta del tipo di operzione
int operazione = int.Parse(Console.ReadLine()!);

//Rieschiesta dei 2 numeri
Console.WriteLine("Scrivimi il primo numero ");
int n1 = int.Parse(Console.ReadLine()!);
Console.WriteLine("Scrivimi il secondo numero");
int n2 = int.Parse(Console.ReadLine()!);

//Controlli operazioni
switch (operazione)
{
    case 1:
        int somma = n1 + n2;
        Console.WriteLine($"IL RISUALTO E' = {somma}");
        break;

    case 2:
        int sottrazione = n1 - n2;
        Console.WriteLine($"IL RISUALTO E' = {sottrazione}");
        break;

    case 3:
        int moltiplicazione = n1 * n2;
        Console.WriteLine($"IL RISUALTO E' = {moltiplicazione}");
        break;

    case 4:
        if (n2 !=0)
        {
            int divisione = n1 / n2;
            Console.WriteLine($"IL RISUALTO E' = {divisione}");
        }else{
            Console.WriteLine("Indefinita");
        }
        break;

    case 5:
        double radice1 = Math.Sqrt(n1);
        double radice2 = Math.Sqrt(n2);
        Console.WriteLine($"IL RISUALTI SONO: \n PRIMO NUMERO = {radice1} \n SECONDO NUMERO = {radice2}");
        break;

    case 6:
        double esponenziale = Math.Pow(n1, n2);
        Console.WriteLine($"IL RISUALTO E' = {esponenziale}");
        break;

    default:
        Console.WriteLine("Il numero non corrisponde a nessun delle operazioni ");
        break;
}
