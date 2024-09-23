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
                    CREATE TABLE prodotti (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        nome TEXT UNIQUE,
                        prezzo REAL,
                        quantita INTEGER CHECK (quantita >= 0)
                    );
                    INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p1', 1, 10);
                    INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p2', 2, 20);
                    INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p3', 3, 30);
                ";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();


        }

        while (true)
        {
            Console.WriteLine("1 - Inserisci prodotto");
            Console.WriteLine("2 - Visualizza prodotti");
            Console.WriteLine("3 - Elimina prodotto");
            Console.WriteLine("4 - Modifica prodotto");
            Console.WriteLine("5 - Exit");
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

        string sql = $"INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('{nome}', {prezzo}, {quantita})";
        SQLiteCommand command = new SQLiteCommand(sql, connection);


        try
        {
            command.ExecuteNonQuery();
            Console.WriteLine("Prodotto inserito con successo.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore durante l'inserimento del prodotto: {ex.Message}");
        }

        connection.Close();

    }

    static void VisualizzaProdotti()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db; Version=3;");
        connection.Open();
        string sql = "SELECT * FROM prodotti";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        Console.WriteLine("Prodotti disponibili:");
        while (reader.Read())
        {
            Console.WriteLine($"ID: {reader["id"]}, Nome: {reader["nome"]}, Prezzo: {reader["prezzo"]}, Quantità: {reader["quantita"]}");
        }
        connection.Close();
    }

    static void ModificaProdotto()
    {
        using (SQLiteConnection conn = new SQLiteConnection("Data Source=database.db; Version=3;"))
        {
            conn.Open();

            Console.Write("Inserisci l'ID del prodotto da modificare: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nuovo nome: ");
            string nuovoNome = Console.ReadLine();
            Console.Write("Nuovo prezzo: ");
            double nuovoPrezzo = double.Parse(Console.ReadLine());
             Console.Write("Nuova quantità: ");
            double nuovaQuantità = int.Parse(Console.ReadLine());

            string sql = $"UPDATE prodotti SET nome = '{nuovoNome}', prezzo = '{nuovoPrezzo}', quantita = '{nuovaQuantità}' WHERE id = {id}";

            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Prodotto modificato con successo!");
        }
    }


    static void EliminaProdotto()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db; Version=3;");


        connection.Open();
        Console.Write("Inserisci il nome del prodotto da eliminare: ");
        string nome = Console.ReadLine();

        string sql = $"DELETE FROM prodotti WHERE nome = '{nome}'";
        SQLiteCommand command = new SQLiteCommand(sql, connection);


        /* rowsAffected = command.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Prodotto eliminato con successo.");
        }
        else
        {
            Console.WriteLine("Nessun prodotto trovato con il nome specificato.");
        }*/

        connection.Close();

    }
}
