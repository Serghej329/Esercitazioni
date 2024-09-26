class View
{
    private Database _db;

    public View(Database db)
    {
        _db = db;
    }

    //  Menu Principale
    public void ShowMainMenu()
    {
        Console.WriteLine("1. Aggiungi user");
        Console.WriteLine("2. Leggi user");
        Console.WriteLine("3. Modifica user");
        Console.WriteLine("4. Elimina user");
        Console.WriteLine("5. Gestisci abbonamenti");
        Console.WriteLine("6. Gestisci transizioni");
        Console.WriteLine("7. Esci");
    }

    //  Mostra Utenti
    public void ShowUsers(List<User> users)
    {
        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
    }

    //  Menu Abbonamenti
    public void ShowSubscriptionMenu()
    {
        Console.WriteLine("1. Aggiungi abbonamento");
        Console.WriteLine("2. Leggi abbonamenti");
        Console.WriteLine("3. Modifica abbonamento");
        Console.WriteLine("4. Elimina abbonamento");
        Console.WriteLine("5. Torna al menu principale");
    }

    //  Mostra abbonamenti

    public void ShowSubscriptions(List<Subscription> subscriptions)
    {
        foreach (var subscription in subscriptions)
        {
            Console.WriteLine(subscription.ToString());
        }
    }
    

    // Menu Transazioni
    public void ShowTransitionMenu()
    {
        Console.WriteLine("1. Aggiungi transizione");
        Console.WriteLine("2. Leggi transizioni");
        Console.WriteLine("3. Mostra utenti con abbonamenti");
        Console.WriteLine("4. Torna al menu principale");
    }


    // Mostra Transazioni
    public void ShowTransitions(List<Transition> transitions)
    {
        foreach (var transition in transitions)
        {
            Console.WriteLine(transition.ToString());
        }
    }

    public string GeInput()
    {
        return Console.ReadLine()!;
    }
}
