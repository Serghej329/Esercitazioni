using System.Data.SQLite;

class Database
{
    private SQLiteConnection _connection;

    public Database()
    {
        _connection = new SQLiteConnection("Data Source=database.db");
        _connection.Open();
        var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT, role TEXT, salary REAL)", _connection);
        command.ExecuteNonQuery();
    }

    public void AddUser(string name, string role, decimal salary)
    {
        var command = new SQLiteCommand("INSERT INTO users (name, role, salary) VALUES (@name, @role, @salary)", _connection);
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@role", role);
        command.Parameters.AddWithValue("@salary", salary);
        command.ExecuteNonQuery();
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
