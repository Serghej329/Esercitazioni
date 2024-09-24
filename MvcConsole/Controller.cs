class Controller
{
    private Database _db; 
    private View _view; 

    private string _currentUserRole;
    private bool _isLogged; // Flag per indicare se l'utente è loggato

    // Costruttore per inizializzare il Controller con istanze di Database e View
    public Controller(Database db, View view)
    {
        _db = db;
        _view = view;
        _isLogged = false; // Inizialmente l'utente non è loggato
    }

    public bool Login()
    {
        if (_isLogged) return true; 

        Console.WriteLine("Username:");
        var username = Console.ReadLine();

        Console.WriteLine("Password:");
        var password = Console.ReadLine();

        // Convalida nome utente e password rispetto alla tabella Auth
        var user = _db.ValidateCredentials(username, password);

        if (user != null)
        {
            Console.WriteLine("Login avvenuto con successo!");
            _currentUserRole = user.Role; // Imposta il ruolo corrente
            _isLogged = true; // Imposta il flag di login a true
            return true;
        }
        else
        {
            Console.WriteLine("Username o password errati.");
            return false;
        }
    }

    // Ciclo del menu principale per l'interazione con l'utente
    public void MainMenu()
    {
        while (true)
        {
            if (!Login()) // Controllo dello stato del login
            {
                continue;
            }

            ShowCustomMenu(); // Mostra il menu personalizzato in base al ruolo
            var input = _view.GetInput(); // Ottieni l'input dell'utente

            // Valida l'input e esegui azioni in base alla scelta
            if (int.TryParse(input, out int scelta))
            {
                switch (scelta)
                {
                    case 1:
                        if (_currentUserRole == "CEO" || _currentUserRole == "Manager")
                        {
                            AddUser(); // Aggiungi un nuovo utente
                        }
                        else
                        {
                            Console.WriteLine("Accesso negato.");
                        }
                        break;
                    case 2:
                        ShowUsers(); // Mostra la lista degli utenti
                        break;
                    case 3:
                        if (_currentUserRole == "CEO" || _currentUserRole == "Manager")
                        {
                            UpdateUser(); // Aggiorna un utente esistente
                        }
                        else
                        {
                            Console.WriteLine("Accesso negato.");
                        }
                        break;
                    case 4:
                        if (_currentUserRole == "CEO" || _currentUserRole == "Manager")
                        {
                            ShowUsers(); 
                            DeleteUser();
                        }
                        else
                        {
                            Console.WriteLine("Accesso negato.");
                        }
                        break;
                    case 5:
                        SearchUser(); // Cerca un utente per nome
                        break;
                    case 6:
                        _isLogged = false; 
                        return; // Esci da tutto
                    case 7:
                        _isLogged = false; 
                        Console.WriteLine("Logout effettuato. Puoi ora accedere con un altro account.");
                        break;
                    default:
                        Console.WriteLine("Scelta non valida, riprova.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Scelta non valida, riprova.");
            }
        }
    }

    // Metodo per mostrare il menu personalizzato in base al ruolo
    private void ShowCustomMenu()
    {
        if (_currentUserRole == "CEO" || _currentUserRole == "Manager")
        {
            _view.ShowMainMenu(_currentUserRole); // Mostra il menu completo per CEO e Manager
        }
        else
        {
            _view.ShowLimitedMenu(); // Mostra un menu limitato per altri ruoli
        }
    }

    // Metodo per aggiungere un nuovo utente
    private void AddUser()
    {
        if (!Login()) return; // Richiedi il login se non è già stato fatto

        Console.WriteLine("inserisci il nuovo nome:"); // Richiesta per il nome
        var name = _view.GetInput();

        Console.WriteLine("inserisci il nuovo ruolo:"); // Richiesta per il ruolo
        var role = _view.GetInput();

        Console.WriteLine("inserisci il nuovo salario:"); // Richiesta per il salario
        if (decimal.TryParse(_view.GetInput(), out decimal salary))
        {
            Console.WriteLine("inserisci il nuovo username:"); // Richiesta per l'username
            var username = _view.GetInput();

            Console.WriteLine("inserisci la nuova password:"); // Richiesta per la password
            var password = _view.GetInput();

            // Aggiungi l'utente al database con username e password
            _db.AddUser(name, role, salary, username, password);
            Console.WriteLine("Utente aggiornato correttamente."); // Messaggio di successo
        }
        else
        {
            Console.WriteLine("Modifica Utente errata."); // Messaggio di errore per salario non valido
        }
    }

    // Metodo per visualizzare la lista degli utenti
    private void ShowUsers()
    {
        if (!Login()) return;

        var users = _db.GetUsers(); // Recupera gli utenti dal database
        _view.ShowUsers(users); // Mostra gli utenti nella vista
    }

    // Metodo per aggiornare un utente esistente
    private void UpdateUser()
    {
        if (!Login()) return; 

        while (true)
        {
            ShowUsers(); // Mostra gli utenti per la selezione
            Console.WriteLine("Vuoi modificare l'utente tramite (1) ID o (2) Nome? (0 per tornare al menu principale)");
            var option = _view.GetInput(); // Ottieni la scelta dell'utente

            if (option == "0") return; // Torna al menu principale se viene selezionato 0

            // Aggiorna l'utente in base a ID o Nome
            if (option == "1")
            {
                UpdateUserById();
            }
            else if (option == "2")
            {
                UpdateUserByName();
            }
            else
            {
                Console.WriteLine("Scelta non valida. Riprova.");
            }
        }
    }

    // Metodo per aggiornare un utente tramite ID
    private void UpdateUserById()
    {
        if (!Login()) return; 

        while (true)
        {
            Console.WriteLine("Inserisci l'ID dell'utente da modificare (0 per tornare alla scelta precedente):");
            var idInput = _view.GetInput();

            if (idInput == "0") break;

            // Valida l'ID e recupera l'utente
            if (int.TryParse(idInput, out int id))
            {
                var user = _db.SearchUsersById(id);
                if (user != null)
                {
                    ModifyUserChoice(user.Id);
                    return;
                }
                else
                {
                    Console.WriteLine("Nessun utente trovato con questo ID. Riprova.");
                }
            }
            else
            {
                Console.WriteLine("ID non valido. Riprova.");
            }
        }
    }

    // Metodo per aggiornare un utente tramite Nome
    private void UpdateUserByName()
    {
        if (!Login()) return;

        while (true)
        {
            Console.WriteLine("Inserisci il nome dell'utente da modificare (0 per tornare alla scelta precedente):");
            var nameInput = _view.GetInput();

            if (nameInput == "0") break;

            var users = _db.SearchUsers(nameInput); // Cerca utenti per nome
            if (users.Count == 1)
            {
                ModifyUserChoice(users[0].Id); // Modifica se trovato esattamente un utente
                return;
            }
            else if (users.Count > 1)
            {
                Console.WriteLine("Più utenti trovati con lo stesso nome. Inserisci l'ID corrispondente:"); // Informazioni su utenti multipli
                _view.ShowUsers(users); // Mostra gli utenti
                SelectUserFromList(users); // Seleziona l'utente dalla lista
                return;
            }
            else
            {
                Console.WriteLine("Nessun utente trovato con questo nome. Riprova.");
            }
        }
    }

    // Metodo per modificare i dettagli di un utente in base alla scelta dell'utente
    private void ModifyUserChoice(int id)
    {
        if (!Login()) return;

        while (true)
        {
            ShowUsers();
            Console.WriteLine("Cosa vuoi modificare? (1) Nome, (2) Ruolo, (3) Stipendio, (0) Indietro");
            var choice = _view.GetInput();

            if (choice == "0") return;

            // Chiama il metodo corrispondente in base alla scelta
            switch (choice)
            {
                case "1":
                    UpdateUserName(id);
                    break;
                case "2":
                    UpdateUserRole(id);
                    break;
                case "3":
                    UpdateUserSalary(id);
                    break;
                default:
                    Console.WriteLine("Scelta non valida. Riprova.");
                    break;
            }
        }
    }

    // Metodo per selezionare un utente da una lista di utenti
    private void SelectUserFromList(List<User> users)
    {
        if (!Login()) return; 

        while (true)
        {
            var idInput = _view.GetInput();

            if (int.TryParse(idInput, out int id))
            {
                // Controlla se l'ID esiste nella lista degli utenti
                foreach (var user in users)
                {
                    if (user.Id == id)
                    {
                        ModifyUserChoice(id);
                        return;
                    }
                }

                Console.WriteLine("ID non presente nella lista. Riprova.");
            }
            else
            {
                Console.WriteLine("ID non valido. Riprova.");
            }
        }
    }

    // Metodo per aggiornare il nome dell'utente
    private void UpdateUserName(int id)
    {
        if (!Login()) return; 

        Console.WriteLine("Inserisci il nuovo nome:");
        var newName = _view.GetInput();

        // Controlla il nuovo nome e aggiorna
        if (!string.IsNullOrWhiteSpace(newName))
        {
            _db.UpdateUser(id, newName);
            Console.WriteLine("Nome dell'Utente aggiornato con successo.");
        }
        else
        {
            Console.WriteLine("Nome non valido. Riprova.");
        }
    }

    // Metodo per aggiornare il ruolo dell'utente
    private void UpdateUserRole(int id)
    {
        if (!Login()) return; 

        Console.WriteLine("Inserisci il nuovo ruolo:");
        var newRole = _view.GetInput();

        // Valida il nuovo ruolo e aggiorna
        if (!string.IsNullOrWhiteSpace(newRole))
        {
            _db.UpdateUserRole(id, newRole);
            Console.WriteLine("Ruolo aggiornato con successo.");
        }
        else
        {
            Console.WriteLine("Ruolo non valido.");
        }
    }

    // Metodo per aggiornare il salario dell'utente
    private void UpdateUserSalary(int id)
    {
        if (!Login()) return; 

        Console.WriteLine("Inserisci il nuovo stipendio:");
        if (decimal.TryParse(_view.GetInput(), out decimal newSalary))
        {
            _db.UpdateUserSalary(id, newSalary);
            Console.WriteLine("Stipendio aggiornato con successo.");
        }
        else
        {
            Console.WriteLine("Stipendio non valido.");
        }
    }

    // Metodo per eliminare un utente
    private void DeleteUser()
    {
        if (!Login()) return; 

        Console.WriteLine("Inserisci l'ID dell'utente da eliminare:");
        var idInput = _view.GetInput();

        // Valida l'ID e cancella l'utente
        if (int.TryParse(idInput, out int id))
        {
            _db.DeleteUser(id);
            Console.WriteLine("Utente eliminato con successo.");
        }
        else
        {
            Console.WriteLine("ID non valido. Riprova.");
        }
    }

    private void SearchUser()
    {
        if (!Login()) return; // Richiedi il login se non è già stato fatto

        Console.WriteLine("Inserisci il nome da cercare:");
        var name = _view.GetInput();

        if (!string.IsNullOrWhiteSpace(name))
        {
            var users = _db.SearchUsers(name);
            _view.SearchResults(users);
        }
        else
        {
            Console.WriteLine("Nome non valido. Riprova.");
        }
    }
}