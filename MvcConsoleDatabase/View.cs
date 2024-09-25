class View
{
    private Database _db;
    public View(Database db)
    {
        _db=db;
    }
    public void ShowMainMenu()
    {
        Console.WriteLine("1. Aggiungi user");
        Console.WriteLine("2. Leggi user");
        Console.WriteLine("3. Modifica user");
        Console.WriteLine("4. Elimina user");
        Console.WriteLine("5. Esci");
    }

    public void ShowUsers(List<User> users)
    {
        foreach(var user in users)
            Console.WriteLine(user.Name);
    }
    public string GeInput()
    {
        return Console.ReadLine()!;
    }
}