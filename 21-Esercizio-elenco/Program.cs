
List<string> nomi = new List<string>();
List<string> selezionati = new List<string>();
int sorteggio;
nomi.Add("Alison");
nomi.Add("Ginevra");
nomi.Add("Matteo");
nomi.Add("Mattia");
nomi.Add("Salvatore");
nomi.Add("Serghej");
nomi.Add("Daniele");
nomi.Add("Sharon");

/*
foreach (string s in nomi)  Console.WriteLine(s);
*/

Random rnd = new Random();
while (nomi.Count != 0)
{

    sorteggio = rnd.Next(nomi.Count); // Genera un numero casuale tra 0 e numero massimo di partecipanti
    //Lista PRIMA
    Console.WriteLine($"\n|PRIMA|");
    Thread.Sleep(500);
    foreach (string nomeLista in nomi) Console.WriteLine(nomeLista);
    Thread.Sleep(500);
    //Output sorteggio
    Console.WriteLine($"\nè uscito il numero {sorteggio}, '{nomi[sorteggio]}' verrà rimosso");
    //aggiunge il nome uscito (random) dentro la lista di "selezionati"
    selezionati.Add(nomi[sorteggio]);
    //Rimozione del nome uscito
    nomi.Remove(nomi[sorteggio]);
    //Lista DOPO
    Thread.Sleep(500);
    Console.WriteLine($"\n|DOPO|\n");
    Thread.Sleep(500);
    foreach (string nomeLista in nomi) Console.WriteLine(nomeLista);
    
    // Il nome della lista che viene rimosso verrà insrito in un'altra lista "Selezionati"
    Thread.Sleep(500);
    Console.WriteLine($"\n|LISTA DI SELEZIONATI|\n");
    foreach (string nomeSelezionato in selezionati) Console.WriteLine(nomeSelezionato);
    Thread.Sleep(2000);
    //Console.Clear();
    
}if (sorteggio < 0) Console.Clear(); Console.WriteLine($"La lista è VUOTA!\n");

