/*View.cs*/
class View
{
    private Database _db;

    public View(Database db)
    {
        _db = db;
    }

    // Mostra menu per CEO & Manager (Admin)
    public void ShowMainMenu(string role)
    {
        Console.WriteLine("Menu Principale:");
        Console.WriteLine("1. Aggiungi Utente");
        Console.WriteLine("2. Mostra Utenti");
        Console.WriteLine("3. Aggiorna Utente");
        Console.WriteLine("4. Elimina Utente");
        Console.WriteLine("5. Cerca Utente");
        Console.WriteLine("6. Esci");
        Console.WriteLine("7. Cambia Account");
    }

    // Mostra menu per i dipendenti (non Admin)
    public void ShowLimitedMenu()
    {
        Console.WriteLine("Menu Principale:");
        Console.WriteLine("2. Mostra Utenti");
        Console.WriteLine("5. Cerca Utente");
        Console.WriteLine("6. Esci");
        Console.WriteLine("7. Cambia Account");
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
