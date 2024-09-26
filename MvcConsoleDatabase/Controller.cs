//Controller.cs
class Controllerr
{
    private Database _db;
    private View _view;

    public Controllerr(Database db, View view)
    {
        _db = db;
        _view = view;
    }

    //  Menu principale
    public void MainMenu()
    {
        while (true)
        {
            _view.ShowMainMenu();
            var input = _view.GeInput();
            if (input == "1")
            {
                AddUser();
            }
            else if (input == "2")
            {
                ShowUser();
            }
            else if (input == "3")
            {
                UpdateUser();
            }
            else if (input == "4")
            {
                DeleteUser();
            }
            else if (input == "5")
            {
                ManageSubscriptions();
            }
            else if (input == "6")
            {
                ManageTransitions(); // Add transition management
            }
            else if (input == "7") // Update menu option for exit
            {
                break;
            }
        }
    }

    // Metodi per gestire gli Utenti
    private void AddUser()
    {
        Console.WriteLine("Inserisci il nome utente");
        var name = _view.GeInput();
        Console.WriteLine("L'utente è attivo? (y/n)");
        var isActiveInput = _view.GeInput();
        bool isActive = isActiveInput.ToLower() == "y";

        _db.Users.Add(new User { Name = name, isActive = isActive });
        _db.SaveChanges();
    }

    private void ShowUser()
    {
        var users = new List<User>();
        foreach (var user in _db.Users)
        {
            if (user.isActive)
            {
                users.Add(user);
            }
        }
        _view.ShowUsers(users);
    }

    private void UpdateUser()
    {
        Console.WriteLine("Inserisci il nome che vuoi modificare");
        var oldName = _view.GeInput();

        User user = null;
        foreach (var u in _db.Users)
        {
            if (u.Name == oldName)
            {
                user = u;
                break;
            }
        }

        if (user != null)
        {
            Console.WriteLine("Inserisci il nuovo nome");
            var newName = _view.GeInput();
            Console.WriteLine("è un'utente attivo? (y/n)");
            var isActiveInput = _view.GeInput();
            bool newisActive = isActiveInput.ToLower() == "y";

            user.Name = newName;
            user.isActive = newisActive;
            _db.SaveChanges();
        }
        else
        {
            Console.WriteLine("utente non trovato");
        }
    }

    private void DeleteUser()
    {
        Console.WriteLine("Inserisci il nome utente");
        var name = _view.GeInput();
        User userToDelete = null;
        foreach (var user in _db.Users)
        {
            if (user.Name == name)
            {
                userToDelete = user;
                break;
            }
        }
        if (userToDelete != null)
        {
            _db.Users.Remove(userToDelete);
            _db.SaveChanges();
        }
        else
        {
            Console.WriteLine("utente non trovato");
        }
    }

    // Metodi per gestire gli Abbonamenti
    private void ManageSubscriptions()
    {
        while (true)
        {
            _view.ShowSubscriptionMenu();
            var input = _view.GeInput();
            if (input == "1")
            {
                AddSubscription();
            }
            else if (input == "2")
            {
                ShowSubscriptions();
            }
            else if (input == "3")
            {
                UpdateSubscription();
            }
            else if (input == "4")
            {
                DeleteSubscription();
            }
            else if (input == "5") // Return to main menu
            {
                break;
            }
        }
    }

    private void AddSubscription()
    {
        Console.WriteLine("Inserisci il nome dell'abbonamento");
        var name = _view.GeInput();
        Console.WriteLine("Inserisci il prezzo dell'abbonamento");
        var priceInput = _view.GeInput();
        decimal price;

        // Try to parse the price input
        while (!decimal.TryParse(priceInput, out price) || price < 0)
        {
            Console.WriteLine("Prezzo non valido. Inserisci un prezzo valido.");
            priceInput = _view.GeInput();
        }

        _db.Subscriptions.Add(new Subscription { Name = name, Price = price });
        _db.SaveChanges();
        Console.WriteLine("Abbonamento aggiunto con successo.");
    }

    private void ShowSubscriptions()
    {
        var subscriptions = _db.Subscriptions.ToList(); ;
        _view.ShowSubscriptions(subscriptions);
    }

   private void ShowUserSubscriptions()
{
    var transitions = _db.Transitions.ToList();
    var users = _db.Users.ToList();
    var subscriptions = _db.Subscriptions.ToList();

    foreach (var transition in transitions)
    {
        User user = null;
        Subscription subscription = null;

        // Trova l'utente corrispondente
        foreach (var u in users)
        {
            if (u.Id == transition.UserId)
            {
                user = u;
                break; // Esci dal ciclo una volta trovato
            }
        }

        // Trova l'abbonamento corrispondente
        foreach (var s in subscriptions)
        {
            if (s.Id == transition.SubscriptionId)
            {
                subscription = s;
                break; // Esci dal ciclo una volta trovato
            }
        }

        // Stampa le informazioni se entrambi sono stati trovati
        if (user != null && subscription != null)
        {
            Console.WriteLine($"User: {user.Name}, Subscription: {subscription.Name}, Date: {transition.Data}");
        }
    }
}



    private void UpdateSubscription()
    {
        Console.WriteLine("Inserisci il nome dell'abbonamento che vuoi modificare");
        var oldName = _view.GeInput();

        Subscription subscription = null;
        foreach (var sub in _db.Subscriptions)
        {
            if (sub.Name == oldName)
            {
                subscription = sub;
                break;
            }
        }

        if (subscription != null)
        {
            Console.WriteLine("Inserisci il nuovo nome dell'abbonamento");
            var newName = _view.GeInput();
            Console.WriteLine("Inserisci il nuovo prezzo dell'abbonamento");
            var priceInput = _view.GeInput();
            decimal newPrice;

            while (!decimal.TryParse(priceInput, out newPrice) || newPrice < 0)
            {
                Console.WriteLine("Prezzo non valido. Inserisci un prezzo valido.");
                priceInput = _view.GeInput();
            }

            subscription.Name = newName;
            subscription.Price = newPrice;
            _db.SaveChanges();
            Console.WriteLine("Abbonamento aggiornato con successo.");
        }
        else
        {
            Console.WriteLine("Abbonamento non trovato.");
        }
    }

    private void DeleteSubscription()
    {
        Console.WriteLine("Inserisci il nome dell'abbonamento da eliminare");
        var name = _view.GeInput();
        Subscription subscriptionToDelete = null;
        foreach (var subscription in _db.Subscriptions)
        {
            if (subscription.Name == name)
            {
                subscriptionToDelete = subscription;
                break;
            }
        }
        if (subscriptionToDelete != null)
        {
            _db.Subscriptions.Remove(subscriptionToDelete);
            _db.SaveChanges();
            Console.WriteLine("Abbonamento eliminato con successo.");
        }
        else
        {
            Console.WriteLine("Abbonamento non trovato.");
        }
    }

    // Metodi per gestire le Transazioni
    private void ManageTransitions()
    {
        while (true)
        {
            _view.ShowTransitionMenu();
            var input = _view.GeInput();
            if (input == "1")
            {
                AddTransition();
            }
            else if (input == "2")
            {
                ShowTransitions();
            }
            else if (input == "3") 
            {
                ShowUserSubscriptions();
            }
            else if (input == "4") 
            {
                break;
            }
        }
    }


    private void AddTransition()
    {
        Console.WriteLine("Inserisci l'ID utente:");
        var userIdInput = _view.GeInput();
        int userId;
        while (!int.TryParse(userIdInput, out userId))
        {
            Console.WriteLine("ID non valido. Riprova.");
            userIdInput = _view.GeInput();
        }

        Console.WriteLine("Inserisci l'ID abbonamento:");
        var subscriptionIdInput = _view.GeInput();
        int subscriptionId;
        while (!int.TryParse(subscriptionIdInput, out subscriptionId))
        {
            Console.WriteLine("ID non valido. Riprova.");
            subscriptionIdInput = _view.GeInput();
        }

        Console.WriteLine("Inserisci la data della transizione (YYYY-MM-DD):");
        var dateInput = _view.GeInput();
        DateOnly date;
        while (!DateOnly.TryParse(dateInput, out date))
        {
            Console.WriteLine("Data non valida. Riprova.");
            dateInput = _view.GeInput();
        }

        var transition = new Transition
        {
            UserId = userId,
            SubscriptionId = subscriptionId,
            Data = date
        };

        _db.Transitions.Add(transition);
        _db.SaveChanges();
        Console.WriteLine("Transizione aggiunta con successo.");
    }

    private void ShowTransitions()
    {
        var transitions = _db.Transitions.ToList();
        _view.ShowTransitions(transitions);
    }



}
