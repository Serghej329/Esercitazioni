//Controller.cs
using System;
using System.Linq;

public class Controller
{
    private Database _db;
    private View _view;

    private string _currentUserRole;
    private bool _isLogged;

    // Costruttore: Inizializza il controller con le dipendenze necessarie
    public Controller(Database db, View view)
    {
        _db = db;
        _view = view;
        _isLogged = false;
        _currentUserRole = "";
    }

    // Gestisce il processo di login
    // Passi:
    // 1. Verifica se l'utente è già loggato
    // 2. Richiede username e password
    // 3. Verifica le credenziali nel database
    // 4. Se valide, imposta lo stato di login e il ruolo dell'utente
    public bool Login()
    {
        if (_isLogged) return true;

        Console.WriteLine("Username:");
        var username = Console.ReadLine();

        Console.WriteLine("Password:");
        var password = Console.ReadLine();

        var user = _db.CheckCredenziali(username, password);

        if (user != null)
        {
            Console.WriteLine("Login avvenuto con successo!");
            _currentUserRole = user.Role;
            _isLogged = true;
            return true;
        }
        else
        {
            Console.WriteLine("Username o password errati.");
            return false;
        }
    }

    // Gestisce il menu principale e il flusso dell'applicazione
    // Passi:
    // 1. Verifica il login dell'utente
    // 2. Mostra il menu appropriato in base al ruolo
    // 3. Elabora l'input dell'utente
    // 4. Esegue l'azione corrispondente alla scelta dell'utente
    // 5. Ripete finché l'utente non sceglie di uscire
    public void MainMenu()
    {
        while (true)
        {
            if (!Login())
            {
                continue;
            }

            ShowCustomMenu();
            var input = _view.GetInput();

            if (int.TryParse(input, out int scelta))
            {
                switch (scelta)
                {
                    case 1:
                        if (_currentUserRole == "CEO" || _currentUserRole == "Manager")
                        {
                            AddUser();
                        }
                        else
                        {
                            Console.WriteLine("Accesso negato.");
                        }
                        break;
                    case 2:
                        ShowUsers();
                        break;
                    case 3:
                        if (_currentUserRole == "CEO" || _currentUserRole == "Manager")
                        {
                            UpdateUser();
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
                        SearchUser();
                        break;
                    case 6:
                        _isLogged = false;
                        return;
                    case 7:
                        _isLogged = false;
                        Console.WriteLine("Logout effettuato. Puoi ora accedere con un altro account.");
                        break;
                    case 8:
                        if (_currentUserRole == "CEO" || _currentUserRole == "Manager")
                        {
                            AddProduct();
                        }
                        else
                        {
                            Console.WriteLine("Accesso negato.");
                        }
                        break;
                    case 9:
                        ShowProducts();
                        break;
                    case 10:
                        if (_currentUserRole == "CEO" || _currentUserRole == "Manager")
                        {
                            UpdateProduct();
                        }
                        else
                        {
                            Console.WriteLine("Accesso negato.");
                        }
                        break;
                    case 11:
                        if (_currentUserRole == "CEO" || _currentUserRole == "Manager")
                        {
                            ShowProducts();
                            DeleteProduct();
                        }
                        else
                        {
                            Console.WriteLine("Accesso negato.");
                        }
                        break;
                    case 12:
                        SearchProduct();
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

    // Mostra il menu appropriato in base al ruolo dell'utente
    // Passi:
    // 1. Verifica il ruolo dell'utente corrente
    // 2. Chiama il metodo appropriato della vista per mostrare il menu
    private void ShowCustomMenu()
    {
        if (_currentUserRole == "CEO" || _currentUserRole == "Manager")
        {
            _view.ShowMainMenu(_currentUserRole);
        }
        else
        {
            _view.ShowLimitedMenu();
        }
    }

    // Aggiunge un nuovo utente al sistema
    // Passi:
    // 1. Verifica il login
    // 2. Richiede i dati del nuovo utente
    // 3. Crea un nuovo oggetto User e Auth
    // 4. Aggiunge l'utente al database
    private void AddUser()
    {
        if (!Login()) return;

        Console.WriteLine("Inserisci il nuovo nome:");
        var name = _view.GetInput();

        Console.WriteLine("Inserisci il nuovo ruolo:");
        var role = _view.GetInput();

        Console.WriteLine("Inserisci il nuovo salario:");
        if (decimal.TryParse(_view.GetInput(), out decimal salary))
        {
            Console.WriteLine("Inserisci il nuovo username:");
            var username = _view.GetInput();

            Console.WriteLine("Inserisci la nuova password:");
            var password = _view.GetInput();

            var user = new User
            {
                Name = name,
                Role = role,
                Salary = salary,
                Username = username
            };

            var auth = new Auth
            {
                Username = username,
                Password = password
            };

            _db.AddUser(user, auth);
            Console.WriteLine("Utente aggiunto correttamente.");
        }
        else
        {
            Console.WriteLine("Modifica Utente errata.");
        }
    }

    // Mostra tutti gli utenti nel sistema
    // Passi:
    // 1. Verifica il login
    // 2. Recupera tutti gli utenti dal database
    // 3. Utilizza la vista per mostrare gli utenti
    private void ShowUsers()
    {
        if (!Login()) return;

        var users = _db.GetUsers();
        _view.ShowUsers(users);
    }

    // Aggiorna i dati di un utente esistente
    // Passi:
    // 1. Verifica il login
    // 2. Chiede all'utente se vuole cercare per ID o per nome
    // 3. Esegue la ricerca appropriata
    // 4. Se l'utente è trovato, permette di modificare i suoi dati
    private void UpdateUser()
    {
        if (!Login()) return;

        while (true)
        {
            ShowUsers();
            Console.WriteLine("Vuoi modificare l'utente tramite (1) ID o (2) Nome? (0 per tornare al menu principale)");
            var option = _view.GetInput();

            if (option == "0") return;

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

    // Aggiorna un utente cercando per ID
    // Passi:
    // 1. Richiede l'ID dell'utente
    // 2. Cerca l'utente nel database
    // 3. Se trovato, chiama ModificaScelta per aggiornare i dati
    private void UpdateUserById()
    {
        if (!Login()) return;

        while (true)
        {
            Console.WriteLine("Inserisci l'ID dell'utente da modificare (0 per tornare alla scelta precedente):");
            var idInput = _view.GetInput();

            if (idInput == "0") break;

            if (int.TryParse(idInput, out int id))
            {
                var user = _db.GetUsers().FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    ModificaScelta(user.Id);
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

    // Aggiorna un utente cercando per nome
    // Passi:
    // 1. Richiede il nome dell'utente
    // 2. Cerca gli utenti con quel nome nel database
    // 3. Se trova un solo utente, chiama ModificaScelta
    // 4. Se trova più utenti, mostra la lista e chiede di selezionare per ID
    private void UpdateUserByName()
    {
        if (!Login()) return;

        while (true)
        {
            Console.WriteLine("Inserisci il nome dell'utente da modificare (0 per tornare alla scelta precedente):");
            var nameInput = _view.GetInput();

            if (nameInput == "0") break;

            var users = _db.GetUsers().Where(u => u.Name.Contains(nameInput)).ToList();
            if (users.Count == 1)
            {
                ModificaScelta(users[0].Id);
                return;
            }
            else if (users.Count > 1)
            {
                Console.WriteLine("Più utenti trovati con lo stesso nome. Inserisci l'ID corrispondente:");
                _view.ShowUsers(users);
                SelectUserFromList(users);
                return;
            }
            else
            {
                Console.WriteLine("Nessun utente trovato con questo nome. Riprova.");
            }
        }
    }

    // Gestisce la modifica dei dati di un utente specifico
    // Passi:
    // 1. Mostra le opzioni di modifica (nome, ruolo, stipendio)
    // 2. Elabora la scelta dell'utente
    // 3. Chiama il metodo appropriato per la modifica
    private void ModificaScelta(int id)
    {
        if (!Login()) return;

        while (true)
        {
            ShowUsers();
            Console.WriteLine("Cosa vuoi modificare? (1) Nome, (2) Ruolo, (3) Stipendio, (0) Indietro");
            var scelta = _view.GetInput();

            if (scelta == "0") return;

            switch (scelta)
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

    // Seleziona un utente da una lista di utenti
    // Passi:
    // 1. Richiede l'ID dell'utente da selezionare
    // 2. Verifica che l'ID sia presente nella lista
    // 3. Se presente, chiama ModificaScelta per quell'utente
    private void SelectUserFromList(List<User> users)
    {
        if (!Login()) return;

        while (true)
        {
            var idInput = _view.GetInput();

            if (int.TryParse(idInput, out int id))
            {
                foreach (var user in users)
                {
                    if (user.Id == id)
                    {
                        ModificaScelta(id);
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

    // Aggiorna il nome di un utente
    // Passi:
    // 1. Richiede il nuovo nome
    // 2. Verifica che il nome non sia vuoto
    // 3. Aggiorna il nome nel database
    private void UpdateUserName(int id)
    {
        if (!Login()) return;

        Console.WriteLine("Inserisci il nuovo nome:");
        var newName = _view.GetInput();

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

    // Aggiorna il ruolo di un utente
    // Passi:
    // 1. Richiede il nuovo ruolo
    // 2. Verifica che il ruolo non sia vuoto
    // 3. Aggiorna il ruolo nel database
    private void UpdateUserRole(int id)
    {
        if (!Login()) return;

        Console.WriteLine("Inserisci il nuovo ruolo:");
        var newRole = _view.GetInput();

        if (!string.IsNullOrWhiteSpace(newRole))
        {
            var user = _db.GetUsers().FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.Role = newRole;
                _db.SaveChanges();
                Console.WriteLine("Ruolo aggiornato con successo.");
            }
            else
            {
                Console.WriteLine("Utente non trovato.");
            }
        }
        else
        {
            Console.WriteLine("Ruolo non valido.");
        }
    }

    // Aggiorna lo stipendio di un utente
    // Passi:
    // 1. Richiede il nuovo stipendio
    // 2. Verifica che lo stipendio sia un valore decimale valido
    // 3. Aggiorna lo stipendio nel database
    private void UpdateUserSalary(int id)
    {
        if (!Login()) return;

        Console.WriteLine("Inserisci il nuovo stipendio:");
        if (decimal.TryParse(_view.GetInput(), out decimal newSalary))
        {
            var user = _db.GetUsers().FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.Salary = newSalary;
                _db.SaveChanges();
                Console.WriteLine("Stipendio aggiornato con successo.");
            }
            else
            {
                Console.WriteLine("Utente non trovato.");
            }
        }
        else
        {
            Console.WriteLine("Stipendio non valido.");
        }
    }

    // Elimina un utente dal sistema
    // Passi:
    // 1. Verifica il login
    // 2. Richiede l'ID dell'utente da eliminare
    // 3. Elimina l'utente dal database
    private void DeleteUser()
    {
        if (!Login()) return;

        Console.WriteLine("Inserisci l'ID dell'utente da eliminare:");
        var idInput = _view.GetInput();

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

    // Cerca un utente per nome
    // Passi:
    // 1. Verifica il login
    // 2. Richiede il nome da cercare
    // 3. Cerca gli utenti nel database
    // 4. Mostra i risultati della ricerca
    private void SearchUser()
    {
        if (!Login()) return;

        Console.WriteLine("Inserisci il nome da cercare:");
        var name = _view.GetInput();

        if (!string.IsNullOrWhiteSpace(name))
        {
            var users = _db.GetUsers().Where(u => u.Name.Contains(name)).ToList();
            _view.SearchResults(users);
        }
        else
        {
            Console.WriteLine("Nome non valido. Riprova.");
        }
    }

    // Aggiunge un nuovo prodotto al sistema
    // Passi:
    // 1. Verifica il login
    // 2. Richiede i dati del nuovo prodotto
    // 3. Crea un nuovo oggetto Product
    // 4. Aggiunge il prodotto al database
    private void AddProduct()
    {
        if (!Login()) return;

        Console.WriteLine("Inserisci il nome del prodotto:");
        var name = _view.GetInput();

        Console.WriteLine("Inserisci la categoria del prodotto:");
        var category = _view.GetInput();

        Console.WriteLine("Inserisci la descrizione del prodotto:");
        var description = _view.GetInput();

        Console.WriteLine("Inserisci la quantità del prodotto:");
        if (int.TryParse(_view.GetInput(), out int quantity))
        {
            Console.WriteLine("Inserisci il costo unitario del prodotto:");
            if (decimal.TryParse(_view.GetInput(), out decimal unitCost))
            {
                Console.WriteLine("Inserisci la data del prodotto (YYYY-MM-DD):");
                if (DateTime.TryParse(_view.GetInput(), out DateTime date))
                {
                    var product = new Product
                    {
                        Name = name,
                        Category = category,
                        Description = description,
                        Quantity = quantity,
                        UnitCost = unitCost,
                        Date = date
                    };

                    _db.AddProduct(product);
                    Console.WriteLine("Prodotto aggiunto con successo.");
                }
                else
                {
                    Console.WriteLine("Data non valida.");
                }
            }
            else
            {
                Console.WriteLine("Costo unitario non valido.");
            }
        }
        else
        {
            Console.WriteLine("Quantità non valida.");
        }
    }



    // Mostra tutti i prodotti nel sistema
    // Passi:
    // 1. Verifica il login
    // 2. Recupera tutti i prodotti dal database
    // 3. Utilizza la vista per mostrare i prodotti
    private void ShowProducts()
    {
        if (!Login()) return;

        var products = _db.GetProducts();
        _view.ShowProducts(products);
    }

    // Aggiorna i dati di un prodotto esistente
    // Passi:
    // 1. Verifica il login
    // 2. Mostra la lista dei prodotti
    // 3. Richiede l'ID del prodotto da aggiornare
    // 4. Richiede i nuovi dati del prodotto
    // 5. Aggiorna il prodotto nel database
    private void UpdateProduct()
    {
        if (!Login()) return;

        ShowProducts();
        Console.WriteLine("Inserisci l'ID del prodotto da aggiornare:");
        if (int.TryParse(_view.GetInput(), out int id))
        {
            var product = ChoiceProductById(id);
            if (product != null)
            {
                Console.WriteLine("Inserisci il nuovo nome del prodotto:");
                var name = _view.GetInput();

                Console.WriteLine("Inserisci la nuova categoria del prodotto:");
                var category = _view.GetInput();

                Console.WriteLine("Inserisci la nuova descrizione del prodotto:");
                var description = _view.GetInput();

                Console.WriteLine("Inserisci la nuova quantità del prodotto:");
                if (int.TryParse(_view.GetInput(), out int quantity))
                {
                    Console.WriteLine("Inserisci il nuovo costo unitario del prodotto:");
                    if (decimal.TryParse(_view.GetInput(), out decimal unitCost))
                    {
                        Console.WriteLine("Inserisci la nuova data del prodotto (YYYY-MM-DD):");
                        string quantityString = product.Quantity.ToString();
                        if (DateTime.TryParse(_view.GetInput(), out DateTime date))
                        {
                            _db.UpdateProduct(id, name, category, description, quantity, unitCost, date);
                            Console.WriteLine("Prodotto aggiornato con successo.");
                        }

                        else
                        {
                            Console.WriteLine("Data non valida.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Costo unitario non valido.");
                    }
                }
                else
                {
                    Console.WriteLine("Quantità non valida.");
                }
            }
            else
            {
                Console.WriteLine("Prodotto non trovato.");
            }
        }
        else
        {
            Console.WriteLine("ID non valido.");
        }
    }

    private Product ChoiceProductById(int id)
    {
        foreach (var product in _db.GetProducts())
        {
            if (product.Id == id)
            {
                return product;
            }
        }
        return null;
    }

    // Elimina un prodotto dal sistema
    // Passi:
    // 1. Verifica il login
    // 2. Richiede l'ID del prodotto da eliminare
    // 3. Elimina il prodotto dal database
    private void DeleteProduct()
    {
        if (!Login()) return;

        Console.WriteLine("Inserisci l'ID del prodotto da eliminare:");
        if (int.TryParse(_view.GetInput(), out int id))
        {
            _db.DeleteProduct(id);
            Console.WriteLine("Prodotto eliminato con successo.");
        }
        else
        {
            Console.WriteLine("ID non valido.");
        }
    }

    // Cerca un prodotto per nome
    // Passi:
    // 1. Verifica il login
    // 2. Richiede il nome del prodotto da cercare
    // 3. Cerca i prodotti nel database
    // 4. Mostra i risultati della ricerca
    private void SearchProduct()
    {
        if (!Login()) return;

        Console.WriteLine("Inserisci il nome del prodotto da cercare:");
        var name = _view.GetInput();

        if (!string.IsNullOrWhiteSpace(name))
        {
            var products = _db.SearchProducts(name);
            _view.SearchResults(products);
        }
        else
        {
            Console.WriteLine("Nome non valido. Riprova.");
        }
    }
}