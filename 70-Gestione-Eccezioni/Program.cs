/*StackOverflow*/
class Program
{
    static void Main(string[] args)
    {
        try
        {
            StackOverflow();
        }
        catch
        {
            Console.WriteLine("StackOverflow");
            Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}")
            return;
        }
    }
    static void stackOverflow(){
        StackOverflow();
    }
}

/*ArgumentException*/
class Program
{
    static void Main(string[] args)
    {
        try
        {
            int numero= int.Parse("ciao"); // il metodo int.Parse() genera un'eccezione perche "ciao" non è un numero
        }
        catch
        {
            Console.WriteLine("StackOverflow");
            Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}")
            return;
        }
    }
    static void stackOverflow(){
        StackOverflow();
    }
}