class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool isActive { get; set; }  // isActive per indicare se l'utente è attivo o inattivo 

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, isActive: {(isActive ? "Attivo" : "Inattivo")}";
    }
}

class Subscription
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Price: {Price:C}";
    }
}

class Transition
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateOnly Data { get; set; }
    public int SubscriptionId { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, UserId: {UserId}, Data: {Data}, SubscriptionId: {SubscriptionId}";
    }
}

