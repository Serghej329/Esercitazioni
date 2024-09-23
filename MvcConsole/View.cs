class View
{
    private Database _db;

    public View(Database db)
    {
        _db = db;
    }

    public void ShowMainMenu()
    {
        Console.WriteLine("1. Aggiungi un utente");
        Console.WriteLine("2. Leggi tutti gli utenti");
        Console.WriteLine("3. Modifica un utente");
        Console.WriteLine("4. Elimina un utente");
        Console.WriteLine("5. Ricerca utente per nome");
        Console.WriteLine("6. Esci");
    }

    public void ShowUsers(List<User> users)
    {
        foreach (var user in users)
        {
            Console.WriteLine(user.ToString()); // stampa ovveride ID e Name della classe user
        }
    }

    public string GetInput()
    {
        return Console.ReadLine()!;
    }

    public void SearchResults(List<User> users)
    {
        if (users.Count == 0)
        {
            Console.WriteLine("Nessun utente trovato.");
        }
        else
        {
            ShowUsers(users);
        }
    }
}
