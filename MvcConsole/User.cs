class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public decimal Salary { get; set; }

    public User(int id, string name, string role, decimal salary)
    {
        Id = id;
        Name = name;
        Role = role;
        Salary = salary;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Role: {Role}, Salary: {Salary:C}";
    }
}
