using System.Data.SQLite;
class Program
{
    static void Main(string[] args)
    {
        string path = @"database.db";

        if (!File.Exists(path))
        {
            SQLiteConnection.CreateFile(path);
            SQLiteConnection connection = new SQLiteConnection($"Data Source={path}; Version=3;");
            connection.Open();
            string sql = @"
                CREATE TABLE categorie (id INTEGER PRIMARY KEY AUTOINCREMENT, categoria TEXT UNIQUE);
                CREATE TABLE prodotti (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    nome TEXT UNIQUE,
                    prezzo REAL,
                    quantita INTEGER CHECK (quantita >= 0),
                    id_categoria INTEGER,
                    FOREIGN KEY (id_categoria) REFERENCES categorie(id)
                );
                INSERT INTO categorie (categoria) VALUES ('frutta&verdura');
                INSERT INTO categorie (categoria) VALUES ('carni bianche');
                INSERT INTO categorie (categoria) VALUES ('carni rosse');
                INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('p1', 1, 10, 1);
                INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('p2', 2, 20, 2);
            ";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        while (true)
        {
            Console.WriteLine("1 - Inserisci prodotto");
            Console.WriteLine("2 - Visualizza prodotti");
            Console.WriteLine("3 - Elimina prodotto");
            Console.WriteLine("4 - Modifica prodotto");
            Console.WriteLine("5 - Inserisci categoria");
            Console.WriteLine("6 - Visualizza categorie");
            Console.WriteLine("7 - Elimina categoria");
            Console.WriteLine("8 - Modifica categoria");
            Console.WriteLine("9 - Exit");
            Console.Write("Scegli un'opzione: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    InserisciProdotto();
                    break;
                case "2":
                    VisualizzaProdotti();
                    break;
                case "3":
                    EliminaProdotto();
                    break;
                case "4":
                    ModificaProdotto();
                    break;
                case "5":
                    InserisciCategoria();
                    break;
                case "6":
                    VisualizzaCategorie();
                    break;
                case "7":
                    EliminaCategoria();
                    break;
                case "8":
                    ModificaCategoria();
                    break;
                case "9":
                    return; // Exit the program
                default:
                    Console.WriteLine("Opzione non valida. Riprova.");
                    break;
            }
        }
    }

    static void InserisciProdotto()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db; Version=3;");
        connection.Open();
        Console.Write("Nome del prodotto: ");
        string nome = Console.ReadLine();
        Console.Write("Prezzo del prodotto: ");
        double prezzo = Convert.ToDouble(Console.ReadLine());
        Console.Write("Quantità del prodotto: ");
        int quantita = Convert.ToInt32(Console.ReadLine());
        Console.Write("ID della categoria: ");
        int idCategoria = Convert.ToInt32(Console.ReadLine());

        string sql = $"INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('{nome}', {prezzo}, {quantita}, {idCategoria})";
        SQLiteCommand command = new SQLiteCommand(sql, connection);

        command.ExecuteNonQuery();
        Console.WriteLine("Prodotto inserito con successo.");

        connection.Close();
    }

    static void VisualizzaProdotti()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db; Version=3;");
        connection.Open();
        string sql = "SELECT * FROM prodotti INNER JOIN categorie ON prodotti.id_categorie == categorie.id";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        Console.WriteLine("Prodotti disponibili:");
        while (reader.Read())
        {
            Console.WriteLine($"ID: {reader["id"]}, Nome: {reader["nome"]}, Prezzo: {reader["prezzo"]}, Quantità: {reader["quantita"]}, ID Categoria: {reader["categoria"]}");
        }
        connection.Close();
    }

    static void ModificaProdotto()
    {
        SQLiteConnection connection = new SQLiteConnection("Data Source=database.db; Version=3;");
        connection.Open();

        Console.Write("Inserisci l'ID del prodotto da modificare: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Nuovo nome: ");
        string nuovoNome = Console.ReadLine();
        Console.Write("Nuovo prezzo: ");
        double nuovoPrezzo = double.Parse(Console.ReadLine());
        Console.Write("Nuova quantità: ");
        int nuovaQuantita = int.Parse(Console.ReadLine());
        Console.Write("Nuovo ID categoria: ");
        int nuovoIdCategoria = int.Parse(Console.ReadLine());

        string sql = $"UPDATE prodotti SET nome = '{nuovoNome}', prezzo = {nuovoPrezzo}, quantita = {nuovaQuantita}, id_categoria = {nuovoIdCategoria} WHERE id = {id}";
        SQLiteCommand cmd = new SQLiteCommand(sql, connection);
        cmd.ExecuteNonQuery();

        Console.WriteLine("Prodotto modificato con successo!");
        connection.Close();
    }

    static void EliminaProdotto()
    {
        SQLiteConnection connection = new SQLiteConnection("Data Source=database.db; Version=3;");
        connection.Open();

        Console.Write("Inserisci l'ID del prodotto da ELIMINARE: ");
        int id = int.Parse(Console.ReadLine());
        string sql = $"DELETE FROM prodotti WHERE id = {id}";
        SQLiteCommand cmd = new SQLiteCommand(sql, connection);
        cmd.ExecuteNonQuery();

        Console.WriteLine("Prodotto ELIMINATO con successo!");
        connection.Close();
    }

    static void InserisciCategoria()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db; Version=3;");
        connection.Open();
        Console.Write("Nome della categoria: ");
        string nome = Console.ReadLine();

        string sql = $"INSERT INTO categorie (nome) VALUES ('{nome}')";
        SQLiteCommand command = new SQLiteCommand(sql, connection);

        try
        {
            command.ExecuteNonQuery();
            Console.WriteLine("Categoria inserita con successo.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore durante l'inserimento della categoria: {ex.Message}");
        }

        connection.Close();
    }

    static void VisualizzaCategorie()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db; Version=3;");
        connection.Open();
        string sql = "SELECT * FROM categorie";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        Console.WriteLine("Categorie disponibili:");
        while (reader.Read())
        {
            Console.WriteLine($"ID: {reader["id"]}, Nome: {reader["nome"]}");
        }
        connection.Close();
    }

    static void ModificaCategoria()
    {
        SQLiteConnection connection = new SQLiteConnection("Data Source=database.db; Version=3;");
        connection.Open();

        Console.Write("Inserisci l'ID della categoria da modificare: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Nuovo nome: ");
        string nuovoNome = Console.ReadLine();

        string sql = $"UPDATE categorie SET nome = '{nuovoNome}' WHERE id = {id}";
        SQLiteCommand cmd = new SQLiteCommand(sql, connection);
        cmd.ExecuteNonQuery();

        Console.WriteLine("Categoria modificata con successo!");
        connection.Close();
    }

    static void EliminaCategoria()
    {
        SQLiteConnection connection = new SQLiteConnection("Data Source=database.db; Version=3;");
        connection.Open();

        Console.Write("Inserisci l'ID della categoria da ELIMINARE: ");
        int id = int.Parse(Console.ReadLine());
        string sql = $"DELETE FROM categorie WHERE id = {id}";
        SQLiteCommand cmd = new SQLiteCommand(sql, connection);
        cmd.ExecuteNonQuery();

        Console.WriteLine("Categoria ELIMINATA con successo!");
        connection.Close();
    }
}
