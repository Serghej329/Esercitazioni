class Controller
{
    private Database _db; // Istanza della classe Database per la gestione dei dati
    private View _view; // Istanza della classe View per l'interazione con l'utente

    // Costruttore per inizializzare il Controller con istanze di Database e View
    public Controller(Database db, View view)
    {
        _db = db;
        _view = view;
    }

    // Ciclo del menu principale per l'interazione con l'utente
    public void MainMenu()
    {
        while (true)
        {
            _view.ShowMainMenu(); // Mostra il menu principale
            var input = _view.GetInput(); // Ottieni l'input dell'utente

            // Valida l'input e esegui azioni in base alla scelta
            if (int.TryParse(input, out int scelta) && scelta >= 1 && scelta <= 6)
            {
                switch (scelta)
                {
                    case 1:
                        AddUser(); // Aggiungi un nuovo utente
                        break;
                    case 2:
                        ShowUsers(); // Mostra la lista degli utenti
                        break;
                    case 3:
                        UpdateUser(); // Aggiorna un utente esistente
                        break;
                    case 4:
                        ShowUsers(); // Mostra gli utenti prima della cancellazione
                        DeleteUser(); // Elimina un utente
                        break;
                    case 5:
                        SearchUser(); // Cerca un utente per nome
                        break;
                    case 6:
                        return; // Esci dal menu
                }
            }
            else
            {
                Console.WriteLine("Scelta non valida, riprova."); // Messaggio di scelta non valida
            }
        }
    }

    // Metodo per aggiungere un nuovo utente
    private void AddUser()
    {
        Console.WriteLine("inserisci il nuovo nome:"); // Richiesta per il nome
        var name = _view.GetInput();

        Console.WriteLine("inserisci il nuovo ruolo:"); // Richiesta per il ruolo
        var role = _view.GetInput();

        Console.WriteLine("inserisci il nuovo salario:"); // Richiesta per il salario
        if (decimal.TryParse(_view.GetInput(), out decimal salary))
        {
            _db.AddUser(name, role, salary); // Aggiungi l'utente al database
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
        var users = _db.GetUsers(); // Recupera gli utenti dal database
        _view.ShowUsers(users); // Mostra gli utenti nella vista
    }

    // Metodo per aggiornare un utente esistente
    private void UpdateUser()
    {
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
                Console.WriteLine("Scelta non valida. Riprova."); // Messaggio di scelta non valida
            }
        }
    }

    // Metodo per aggiornare un utente tramite ID
    private void UpdateUserById()
    {
        while (true)
        {
            Console.WriteLine("Inserisci l'ID dell'utente da modificare (0 per tornare alla scelta precedente):");
            var idInput = _view.GetInput();

            if (idInput == "0") break; // Esci dal ciclo se viene inserito 0

            // Valida l'ID e recupera l'utente
            if (int.TryParse(idInput, out int id))
            {
                var user = _db.SearchUsersById(id);
                if (user != null)
                {
                    ModifyUserChoice(user.Id); // Modifica l'utente se trovato
                    return;
                }
                else
                {
                    Console.WriteLine("Nessun utente trovato con questo ID. Riprova."); // Messaggio di errore se non trovato
                }
            }
            else
            {
                Console.WriteLine("ID non valido. Riprova."); // Messaggio di errore per ID non valido
            }
        }
    }

    // Metodo per aggiornare un utente tramite Nome
    private void UpdateUserByName()
    {
        while (true)
        {
            Console.WriteLine("Inserisci il nome dell'utente da modificare (0 per tornare alla scelta precedente):");
            var nameInput = _view.GetInput();

            if (nameInput == "0") break; // Esci dal ciclo se viene inserito 0

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
                Console.WriteLine("Nessun utente trovato con questo nome. Riprova."); // Messaggio di errore se non trovato
            }
        }
    }

    // Metodo per modificare i dettagli di un utente in base alla scelta dell'utente
    private void ModifyUserChoice(int id)
    {
        while (true)
        {
            ShowUsers(); // Mostra gli utenti
            Console.WriteLine("Cosa vuoi modificare? (1) Nome, (2) Ruolo, (3) Stipendio, (0) Indietro");
            var choice = _view.GetInput(); // Ottieni la scelta dell'utente

            if (choice == "0") return; // Torna indietro se viene selezionato 0

            // Chiama il metodo corrispondente in base alla scelta
            switch (choice)
            {
                case "1":
                    UpdateUserName(id); // Aggiorna il nome
                    break;
                case "2":
                    UpdateUserRole(id); // Aggiorna il ruolo
                    break;
                case "3":
                    UpdateUserSalary(id); // Aggiorna il salario
                    break;
                default:
                    Console.WriteLine("Scelta non valida. Riprova."); // Messaggio di scelta non valida
                    break;
            }
        }
    }

    // Metodo per selezionare un utente da una lista di utenti
    private void SelectUserFromList(List<User> users)
    {
        while (true)
        {
            var idInput = _view.GetInput(); // Ottieni l'input dell'utente

            if (int.TryParse(idInput, out int id)) // Valida l'ID
            {
                // Controlla se l'ID esiste nella lista degli utenti
                foreach (var user in users)
                {
                    if (user.Id == id)
                    {
                        ModifyUserChoice(id); // Modifica l'utente se trovato
                        return;
                    }
                }

                Console.WriteLine("ID non presente nella lista. Riprova."); // Messaggio di errore se l'ID non è trovato
            }
            else
            {
                Console.WriteLine("ID non valido. Riprova."); // Messaggio di errore per ID non valido
            }
        }
    }

    // Metodo per aggiornare il nome dell'utente
    private void UpdateUserName(int id)
    {
        Console.WriteLine("Inserisci il nuovo nome:"); // Richiesta per il nuovo nome
        var newName = _view.GetInput();

        // Valida il nuovo nome e aggiorna
        if (!string.IsNullOrWhiteSpace(newName))
        {
            _db.UpdateUser(id, newName); // Aggiorna il nome dell'utente nel database
            Console.WriteLine("Nome dell'Utente aggiornato con successo."); // Messaggio di successo
        }
        else
        {
            Console.WriteLine("Nome non valido. Riprova."); // Messaggio di errore per nome non valido
        }
    }

    // Metodo per aggiornare il ruolo dell'utente
    private void UpdateUserRole(int id)
    {
        Console.WriteLine("Inserisci il nuovo ruolo:"); // Richiesta per il nuovo ruolo
        var newRole = _view.GetInput();

        // Valida il nuovo ruolo e aggiorna
        if (!string.IsNullOrWhiteSpace(newRole))
        {
            _db.UpdateUserRole(id, newRole); // Aggiorna il ruolo dell'utente nel database
            Console.WriteLine("Ruolo aggiornato con successo."); // Messaggio di successo
        }
        else
        {
            Console.WriteLine("Ruolo non valido."); // Messaggio di errore per ruolo non valido
        }
    }

    // Metodo per aggiornare il salario dell'utente
    private void UpdateUserSalary(int id)
    {
        Console.WriteLine("Inserisci il nuovo stipendio:"); // Richiesta per il nuovo stipendio
        if (decimal.TryParse(_view.GetInput(), out decimal newSalary))
        {
            _db.UpdateUserSalary(id, newSalary); // Aggiorna il salario dell'utente nel database
            Console.WriteLine("Stipendio aggiornato con successo."); // Messaggio di successo
        }
        else
        {
            Console.WriteLine("Stipendio non valido."); // Messaggio di errore per stipendio non valido
        }
    }

    // Metodo per eliminare un utente
    private void DeleteUser()
    {
        Console.WriteLine("Inserisci l'ID dell'utente da eliminare:"); // Richiesta per l'ID dell'utente da eliminare
        var idInput = _view.GetInput();

        // Valida l'ID e cancella l'utente
        if (int.TryParse(idInput, out int id))
        {
            _db.DeleteUser(id); // Cancella l'utente dal database
            Console.WriteLine("Utente eliminato con successo."); // Messaggio di successo
        }
        else
        {
            Console.WriteLine("ID non valido. Riprova."); // Messaggio di errore per ID non valido
        }
    }
    private void SearchUser()
    {
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



