public class GestioneGioco
{
    private List<Giocatore> giocatori;
    private Giocatore giocatoreCorrente;
    private Partita partitaCorrente;

    public GestioneGioco()
    {
        giocatori = new List<Giocatore>();
        CaricaGiocatori();
    }

    public void MostraMenu()
    {
        bool esci = false;

        while (!esci)
        {
            Console.Clear();
            Console.WriteLine("Benvenuto a Indovina Numero!");
            Console.WriteLine("1. Nuovo Gioco");
            Console.WriteLine("2. Continuare Partita Esistente");
            Console.WriteLine("3. Selezionare o Creare Giocatore");
            Console.WriteLine("4. Visualizza Storico Partite");
            Console.WriteLine("5. Esci");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    IniziaNuovaPartita();
                    break;
                case "2":
                    ContinuaPartita();
                    break;
                case "3":
                    GestioneGiocatori();
                    break;
                case "4":
                    VisualizzaStoricoPartite();
                    break;
                case "5":
                    esci = true;
                    break;
            }
        }
    }

    private void IniziaNuovaPartita()
    {
        if (giocatoreCorrente == null)
        {
            Console.WriteLine("Seleziona un giocatore prima di iniziare una partita.");
            return;
        }

        partitaCorrente = new Partita(giocatoreCorrente);
        Gioca();
    }

    private void ContinuaPartita()
    {
        if (partitaCorrente == null || partitaCorrente.Completata)
        {
            Console.WriteLine("Non ci sono partite in corso da continuare.");
            return;
        }

        Gioca();
    }

    private void Gioca()
    {
        bool haIndovinato = false;
        int tentativi = 0;

        while (!haIndovinato && tentativi < 10)
        {
            Console.Write("Inserisci un numero: ");
            int numero = int.Parse(Console.ReadLine());
            partitaCorrente.AggiungiTentativo(numero);

            string suggerimento = partitaCorrente.FornisciSuggerimento(numero);
            Console.WriteLine(suggerimento);

            if (suggerimento == "Hai indovinato!")
            {
                haIndovinato = true;
                giocatoreCorrente.AggiungiPartita(partitaCorrente);
                SalvaGiocatori();
            }

            tentativi++;
        }

        if (!haIndovinato)
        {
            Console.WriteLine($"Hai finito i tentativi! Il numero corretto era {partitaCorrente.NumeroDaIndovinare}.");
        }
    }

    private void GestioneGiocatori()
    {
        Console.WriteLine("1. Crea Nuovo Giocatore");
        Console.WriteLine("2. Seleziona Giocatore Esistente");
        string scelta = Console.ReadLine();

        switch (scelta)
        {
            case "1":
                CreaNuovoGiocatore();
                break;
            case "2":
                SelezionaGiocatoreEsistente();
                break;
        }
    }

    private void CreaNuovoGiocatore()
    {
        Console.Write("Inserisci il nome del giocatore: ");
        string nome = Console.ReadLine();
        int id = giocatori.Count + 1;

        Giocatore nuovoGiocatore = new Giocatore(nome, id);
        giocatori.Add(nuovoGiocatore);
        giocatoreCorrente = nuovoGiocatore;

        SalvaGiocatori();
    }

    private void SelezionaGiocatoreEsistente()
    {
        Console.WriteLine("Seleziona un giocatore:");
        for (int i = 0; i < giocatori.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {giocatori[i].Nome}");
        }

        int scelta = int.Parse(Console.ReadLine());
        giocatoreCorrente = giocatori[scelta - 1];
    }

    private void VisualizzaStoricoPartite()
    {
        if (giocatoreCorrente == null)
        {
            Console.WriteLine("Seleziona un giocatore prima di visualizzare lo storico.");
            return;
        }

        foreach (var partita in giocatoreCorrente.StoricoPartite)
        {
            Console.WriteLine($"Partita: {partita.NumeroDaIndovinare}, Tentativi: {partita.Tentativi.Count}, Completata: {partita.Completata}");
        }
    }

    // Metodi di caricamento e salvataggio JSON

    private void CaricaGiocatori()
    {
        if (File.Exists("giocatori.json"))
        {
            string json = File.ReadAllText("giocatori.json");
           this giocatori = JsonConvert.DeserializeObject<List<Giocatore>>(json);
        }
    }

    private void SalvaGiocatori()
    {
        string json = JsonConvert.SerializeObject(giocatori, Formatting.Indented);
        File.WriteAllText("giocatori.json", json);
    }
}
