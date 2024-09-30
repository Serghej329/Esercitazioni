public class View
{

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
        Console.WriteLine("8. Aggiungi Prodotto");
        Console.WriteLine("9. Mostra Prodotti");
        Console.WriteLine("10. Aggiorna Prodotto");
        Console.WriteLine("11. Elimina Prodotto");
        Console.WriteLine("12. Cerca Prodotto");
    }

    public void ShowLimitedMenu()
    {
        Console.WriteLine("Menu Principale:");
        Console.WriteLine("2. Mostra Utenti");
        Console.WriteLine("5. Cerca Utente");
        Console.WriteLine("6. Esci");
        Console.WriteLine("7. Cambia Account");
        Console.WriteLine("9. Mostra Prodotti");
        Console.WriteLine("12. Cerca Prodotto");
    }

    public void ShowUsers(List<User> users)
    {
        if (users.Count == 0)
        {
            Console.WriteLine("Nessun utente trovato.");
        }
        else
        {
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Nome: {user.Name}, Ruolo: {user.Role}, Salario: {user.Salary:C}, Username: {user.Username}");
            }
        }
    }

    public void ShowProducts(List<Product> products)
    {
        if (products.Count == 0)
        {
            Console.WriteLine("Nessun prodotto trovato.");
        }
        else
        {
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, Nome: {product.Name}, Categoria: {product.Category}, Descrizione: {product.Description}, Quantità: {product.Quantity}, Costo Unitario: {product.UnitCost:C}, Data: {product.Date.ToShortDateString()}");
            }
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

    public void SearchResults(List<Product> products)
    {
        if (products.Count == 0)
        {
            Console.WriteLine("Nessun prodotto trovato.");
        }
        else
        {
            ShowProducts(products);
        }
    }
}