﻿
List<string> nomi = new List<string>();
bool t = true;
do
{
    //MENU'
    Console.WriteLine("\t|MENU' LISTA| \n\n    Fai la tua scelta' \n 1)visualizza lista \n 2)Aggiungi partecipante \n 3)Esci \n ");
    int scelta = int.Parse(Console.ReadLine()!);

    switch (scelta)
    {
        case 1: // Visualizzazione Partecipanti in lista
            Console.WriteLine($"\n|Lista|");
            foreach (string nomeLista in nomi) Console.WriteLine(nomeLista);
            //Console.Beep(32766, 1000);
            Console.WriteLine($"\n|PREMI UN TASTO QUALSIASI PER TORNARE AL MENU'|");
            Console.ReadKey();
            break;
        case 2: // Aggiunta Partecipanti in lista
            Console.WriteLine("Scrivi il nome del partecipante: \n");
            string partecipante = Console.ReadLine()!;
            nomi.Add(partecipante);
            Console.WriteLine($"\n|PREMI UN TASTO QUALSIASI PER TORNARE AL MENU'|");
            Console.ReadKey();
            break;

        case 3: // TODO DA SISTERMARE
            t = false;
            break;

        default:// Se l'operazione non è valida
            Console.WriteLine("Il numero non corrisponde a nessun delle operazioni "); // Stampa un messaggio di errore
            Console.WriteLine($"\n|PREMI UN TASTO QUALSIASI PER TORNARE AL MENU'|");
            Console.ReadKey();
            break;
    }
    Console.Clear();

} while (t);

