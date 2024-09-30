//Database.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class Database : DbContext
{
    // Definizione delle proprietà DbSet per le tabelle del database
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Auth> Auth { get; set; }

    // Configura la connessione al database SQLite
    // Passi:
    // 1. Specifica la stringa di connessione per il database SQLite
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=database.db");
    }

    // Costruttore: Inizializza il database
    // Passi:
    // 1. Assicura che il database sia creato
    // 2. Inizializza il database con dati di base se necessario
    public Database()
    {
        //Fondamentale per gestire la creazione del DB 
        //in caso di corruzione del file gestisce automaticamente la sua ricreazione
        Database.EnsureCreated();
        InitializeDatabase();
    }

    // Inizializza il database con un utente amministratore se non esiste già
    // Passi:
    // 1. Controlla se esiste già un utente 'admin' nella tabella Auth
    // 2. Se non esiste, crea un nuovo utente 'admin' in Auth
    // 3. Controlla se esiste già un utente 'admin' nella tabella Users
    // 4. Se non esiste, crea un nuovo utente 'admin' in Users
    private void InitializeDatabase()
    {
        bool adminExists = false;

        // Controllo se esiste l'utente 'admin' nella tabella Auth
        foreach (var auth in Auth)
        {
            if (auth.Username == "admin")
            {
                adminExists = true;
                break;
            }
        }

        if (!adminExists)
        {
            Auth.Add(new Auth
            {
                Username = "admin",
                Password = "password"
            });
            SaveChanges();
        }

        adminExists = false;

        // Controllo se esiste l'utente 'admin' nella tabella Users
        foreach (var user in Users)
        {
            if (user.Username == "admin")
            {
                adminExists = true;
                break;
            }
        }

        if (!adminExists)
        {
            Users.Add(new User
            {
                Name = "Admin User",
                Username = "admin",
                Role = "CEOo",
                Salary = 0
            });
            SaveChanges();
        }
    }

    // Verifica le credenziali di un utente
    // Passi:
    // 1. Cerca le credenziali nella tabella Auth
    // 2. Se trovate, cerca l'utente corrispondente nella tabella Users
    // 3. Restituisce l'utente se trovato, altrimenti null
    public User CheckCredenziali(string username, string password)
    {
        foreach (var auth in Auth)
        {
            if (auth.Username == username && auth.Password == password)
            {
                foreach (var user in Users)
                {
                    if (user.Username == username)
                    {
                        return user;
                    }
                }
            }
        }
        return null;
    }

    // Aggiunge un nuovo utente al database
    // Passi:
    // 1. Aggiunge l'utente alla tabella Users
    // 2. Aggiunge le credenziali alla tabella Auth
    // 3. Salva le modifiche nel database
    public void AddUser(User user, Auth auth)
    {
        Users.Add(user);
        Auth.Add(auth);
        SaveChanges();
    }

    // Recupera tutti gli utenti dal database
    // Passi:
    // 1. Crea una nuova lista di utenti
    // 2. Aggiunge tutti gli utenti dalla tabella Users alla lista
    // 3. Restituisce la lista completa
    public List<User> GetUsers()
    {
        var usersList = new List<User>();
        foreach (var user in Users)
        {
            usersList.Add(user);
        }
        return usersList;
    }

    // Aggiorna il nome di un utente esistente
    // Passi:
    // 1. Cerca l'utente con l'ID specificato
    // 2. Se trovato, aggiorna il nome
    // 3. Salva le modifiche nel database
    public void UpdateUser(int id, string newName)
    {
        foreach (var user in Users)
        {
            if (user.Id == id)
            {
                user.Name = newName;
                SaveChanges();
                break;
            }
        }
    }

    // Aggiorna il ruolo di un utente esistente
    // Passi:
    // 1. Cerca l'utente con l'ID specificato
    // 2. Se trovato, aggiorna il ruolo
    // 3. Salva le modifiche nel database
    public void UpdateUserRole(int id, string newRole)
    {
        foreach (var user in Users)
        {
            if (user.Id == id)
            {
                user.Role = newRole;
                SaveChanges();
                break;
            }
        }
    }

    // Aggiorna lo stipendio di un utente esistente
    // Passi:
    // 1. Cerca l'utente con l'ID specificato
    // 2. Se trovato, aggiorna lo stipendio
    // 3. Salva le modifiche nel database
    public void UpdateUserSalary(int id, decimal newSalary)
    {
        foreach (var user in Users)
        {
            if (user.Id == id)
            {
                user.Salary = newSalary;
                SaveChanges();
                break;
            }
        }
    }

    // Elimina un utente dal database
    // Passi:
    // 1. Cerca l'utente con l'ID specificato
    // 2. Se trovato, rimuove l'utente dalla tabella Users
    // 3. Rimuove le credenziali corrispondenti dalla tabella Auth
    // 4. Salva le modifiche nel database
    public void DeleteUser(int id)
    {
        foreach (var user in Users)
        {
            if (user.Id == id)
            {
                Users.Remove(user);
                foreach (var auth in Auth)
                {
                    if (auth.Username == user.Username)
                    {
                        Auth.Remove(auth);
                        break;
                    }
                }
                SaveChanges();
                break;
            }
        }
    }

    public void AddProduct(Product product)
    {
        // Verifica se la categoria esiste già
        var category = Categories.FirstOrDefault(c => c.Name == product.Category);
        if (category == null)
        {
            // Se la categoria non esiste, crea una nuova categoria
            category = new Category { Name = product.Category, Quantity = 0 };
            Categories.Add(category);
        }

        // Aggiorna la quantità della categoria
        category.Quantity += product.Quantity;

        // Aggiungi il prodotto
        Products.Add(product);
        SaveChanges();
    }


    public List<Product> GetProducts()
    {
        var productList = new List<Product>();
        foreach (var product in Products)
        {
            productList.Add(product);
        }
        return productList;
    }

    public void UpdateProduct(int id, string name, string category, string description, int quantity, decimal unitCost, DateTime date)
    {
        foreach (var product in Products)
        {
            if (product.Id == id)
            {
                product.Name = name;
                product.Category = category;
                product.Description = description;
                product.Quantity = quantity;
                product.UnitCost = unitCost;
                product.Date = date;
                SaveChanges();
                break;
            }
        }
    }

    public void DeleteProduct(int id)
    {
        foreach (var product in Products)
        {
            if (product.Id == id)
            {
                Products.Remove(product);
                SaveChanges();
                break;
            }
        }
    }

    public List<Product> SearchProducts(string name)
    {
        var productList = new List<Product>();
        foreach (var product in Products)
        {
            if (product.Name.Contains(name))
            {
                productList.Add(product);
            }
        }
        return productList;
    }
}
