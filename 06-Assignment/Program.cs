Console.WriteLine("|scegli la data| \n 1)Lunedì \n 2)Martedì \n 3)Mercoledì \n 4)Giovedì \n 5)Venerdì \n 6)Sabato \n 7)Domenica \n Scrivimi il numero");
/*
int giorno = Convert.ToInt32(Console.ReadLine());
*/
int giorno = int.Parse(Console.ReadLine()!);

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
