public class Partita
{
    public Giocatore Giocatore { get; set; }
    public int NumeroDaIndovinare { get; private set; }
    public List<int> Tentativi { get; private set; }
    public bool Completata { get; set; }
    public DateTime InizioPartita { get; private set; }
    public DateTime FinePartita { get; private set; }

    private Random random = new Random();

    public Partita(Giocatore giocatore)
    {
        Giocatore = giocatore;
        NumeroDaIndovinare = random.Next(1, 101); // Numero casuale tra 1 e 100
        Tentativi = new List<int>();
        InizioPartita = DateTime.Now;
        Completata = false;
    }

    public void AggiungiTentativo(int numero)
    {
        Tentativi.Add(numero);
        if (numero == NumeroDaIndovinare)
        {
            Completata = true;
            FinePartita = DateTime.Now;
        }
    }

    public string FornisciSuggerimento(int numero)
    {
        if (numero < NumeroDaIndovinare)
            return "Il numero è più alto.";
        else if (numero > NumeroDaIndovinare)
            return "Il numero è più basso.";
        else
            return "Hai indovinato!";
    }
}
