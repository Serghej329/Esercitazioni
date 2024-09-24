using System.Data.SQLite;

class Database
{
    private SQLiteConnection _connection;

    public Database()
    {
        _connection = new SQLiteConnection("Data Source=database.db");
        _connection.Open();

        // Creazione della tabella Users (se non esiste già)
        var createUsersTable = new SQLiteCommand("CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT, username TEXT UNIQUE, role TEXT, salary REAL)", _connection);
        createUsersTable.ExecuteNonQuery();

        // Creazione della tabella Auth (se non esiste già)
        var createAuthTable = new SQLiteCommand("CREATE TABLE IF NOT EXISTS auth (id INTEGER PRIMARY KEY AUTOINCREMENT, username TEXT UNIQUE, password TEXT)", _connection);
        createAuthTable.ExecuteNonQuery();

        // Inserimento dell'utente predefinito
        var insertDefaultUser = new SQLiteCommand("INSERT OR IGNORE INTO auth (username, password) VALUES ('admin', 'password')", _connection);
        insertDefaultUser.ExecuteNonQuery();

        // Inserimento dell'utente predefinito nella tabella users
        var insertDefaultUserInUsers = new SQLiteCommand("INSERT OR IGNORE INTO users (name, username, role, salary) VALUES ('Admin User', 'admin', 'CEO', 0)", _connection);
        insertDefaultUserInUsers.ExecuteNonQuery();
    }

    public User ValidateCredentials(string username, string password)
    {
        // Prepare the SQL command to check for matching credentials
        var command = new SQLiteCommand("SELECT * FROM auth WHERE username = @username AND password = @password", _connection);
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@password", password);

        using (var reader = command.ExecuteReader())
        {
            if (reader.Read())
            {
                int authId = reader.GetInt32(0);

                // Query the users table to get the Name and Salary
                var userCommand = new SQLiteCommand("SELECT id, name, role, salary FROM users WHERE id = @id", _connection);
                userCommand.Parameters.AddWithValue("@id", authId);

                using (var userReader = userCommand.ExecuteReader())
                {
                    if (userReader.Read())
                    {
                        return new User(
                            userReader.GetInt32(0),
                            userReader.GetString(1),
                            userReader.GetString(2),
                            userReader.GetDecimal(3)
                        );
                    }
                }
            }
        }

        return null; // Nessun utente trovato
    }

    public void AddUser(string name, string role, decimal salary, string username, string password)
    {
        // Insert user information into the users table
        var userCommand = new SQLiteCommand("INSERT INTO users (name, username, role, salary) VALUES (@name, @username, @role, @salary)", _connection);
        userCommand.Parameters.AddWithValue("@name", name);
        userCommand.Parameters.AddWithValue("@username", username);
        userCommand.Parameters.AddWithValue("@role", role);
        userCommand.Parameters.AddWithValue("@salary", salary);
        userCommand.ExecuteNonQuery();

        // Insert login information into the auth table
        var authCommand = new SQLiteCommand("INSERT INTO auth (username, password) VALUES (@username, @password)", _connection);
        authCommand.Parameters.AddWithValue("@username", username);
        authCommand.Parameters.AddWithValue("@password", password);
        authCommand.ExecuteNonQuery();
    }

    public List<User> GetUsers()
    {
        var command = new SQLiteCommand("SELECT id, name, role, salary FROM users", _connection);
        var reader = command.ExecuteReader();
        var users = new List<User>();

        while (reader.Read())
        {
            users.Add(new User(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetDecimal(3)));
        }

        return users;
    }

    public void UpdateUser(int id, string newName)
    {
        var command = new SQLiteCommand("UPDATE users SET name = @name WHERE id = @id", _connection);
        command.Parameters.AddWithValue("@name", newName);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
    }

    public void UpdateUserRole(int id, string newRole)
    {
        var command = new SQLiteCommand("UPDATE users SET role = @role WHERE id = @id", _connection);
        command.Parameters.AddWithValue("@role", newRole);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
    }

    public void UpdateUserSalary(int id, decimal newSalary)
    {
        var command = new SQLiteCommand("UPDATE users SET salary = @salary WHERE id = @id", _connection);
        command.Parameters.AddWithValue("@salary", newSalary);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
    }

    public void DeleteUser(int id)
    {
        var command = new SQLiteCommand("DELETE FROM users WHERE id = @id", _connection);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
    }

    public List<User> SearchUsers(string name)
    {
        var command = new SQLiteCommand("SELECT id, name, role, salary FROM users WHERE name LIKE @name", _connection);
        command.Parameters.AddWithValue("@name", "%" + name + "%");
        var reader = command.ExecuteReader();
        var users = new List<User>();

        while (reader.Read())
        {
            users.Add(new User(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetDecimal(3)));
        }

        return users;
    }

    public User SearchUsersById(int id)
    {
        var command = new SQLiteCommand("SELECT id, name, role, salary FROM users WHERE id = @id", _connection);
        command.Parameters.AddWithValue("@id", id);
        var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return new User(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetDecimal(3));
        }

        return null; // Nessun utente trovato
    }
}