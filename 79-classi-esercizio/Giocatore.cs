public class Giocatore
{
    public string Nome { get; set; }
    public int ID { get; set; }
    public List<Partita> StoricoPartite { get; set; }

    public Giocatore(string nome, int id)
    {
        Nome = nome;
        ID = id;
        StoricoPartite = new List<Partita>();
    }

    public void AggiungiPartita(Partita partita)
    {
        StoricoPartite.Add(partita);
    }
}
