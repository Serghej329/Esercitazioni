Random random = new Random();
int mioPunteggio = 100;
int punteggioComputer = 100;

Console.WriteLine("Gioco dei Dadi");
Console.WriteLine("Benvenuto al gioco dei dadi, giocherai contro di me!");

// Carica i punteggi
string percorso = @"punteggi.txt";
if (File.Exists(percorso))
{
    string[] punteggi = File.ReadAllLines(percorso); // Se il file esiste, legge i punteggi dal file.
    mioPunteggio = Convert.ToInt32(punteggi[0]); // Carica il punteggio del giocatore dal file.
    punteggioComputer = Convert.ToInt32(punteggi[1]); // Carica il punteggio del computer dal file.

}

// Mostra i punteggi iniziali
Console.WriteLine("Ecco i punteggi:");
Console.WriteLine($"Tu: {mioPunteggio}");
Console.WriteLine($"Io: {punteggioComputer}");

while (mioPunteggio > 0 && punteggioComputer > 0)
{
    Console.WriteLine("Premi un tasto per lanciare i dadi");
    Console.ReadKey(true);
    Console.WriteLine("");

    int mioLancio1 = random.Next(1, 7);
    int mioLancio2 = random.Next(1, 7);
    int lancioComputer1 = random.Next(1, 7);
    int lancioComputer2 = random.Next(1, 7);

    Console.Clear();
    Console.WriteLine("Il tuo lancio:");
    Console.WriteLine($"I tuoi dadi: {mioLancio1}, {mioLancio2}");
    Console.WriteLine("Il mio lancio:");
    Console.WriteLine($"I miei dadi: {lancioComputer1}, {lancioComputer2}");

    int mieiPunti = mioLancio1 + mioLancio2;
    int puntiComputer = lancioComputer1 + lancioComputer2;
    int differenzaPunti = Math.Abs(mieiPunti - puntiComputer); // Calcola la differenza assoluta di punti tra i due giocatori.

    if (mieiPunti > puntiComputer)
    {
        punteggioComputer -= differenzaPunti; // Se il giocatore ha vinto il round: sottrai al punteggio del pc la differenza dei punti
    }
    else if (mieiPunti < puntiComputer)
    {
        mioPunteggio -= differenzaPunti; // Se il computer ha vinto il round: sottrai al punteggio del giocatpre la differenza dei punti
    }

    // Mostra i nuovi punteggi
    Console.WriteLine("Ecco i nuovi punteggi:");
    Console.WriteLine($"Tu: {mioPunteggio}");
    Console.WriteLine($"Io: {punteggioComputer}");

    // Salva i punteggi
    File.WriteAllLines(percorso, new string[]
    {
            mioPunteggio.ToString(), punteggioComputer.ToString()
    });


    //primo metodo con storico del salvataggio
    // Salva i punteggi
    /*
    string punti = $"Tu: {mioPunteggio} - Io: {punteggioComputer}"; // Crea una stringa con i punteggi formattati
    File.AppendAllText(percorso, punti + "\n"); // Aggiungi la stringa al file
*/

}

if (mioPunteggio <= 0)
{
    Console.WriteLine("Mi dispiace, ho vinto io!");

/*    File.WriteAllLines(percorso, ) { mioPunteggio, punteggioComputer, }*/
}

else if (punteggioComputer <= 0)
{
    Console.WriteLine("Congratulazioni!! Hai vinto!");
}
File.WriteAllLines(percorso, new string[] { "100", "100" });
