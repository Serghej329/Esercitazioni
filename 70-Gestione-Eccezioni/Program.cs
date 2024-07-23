/*StackOverflow*/
/*class Program
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
*/
/*ArgumentException*/
/*class Program
{
    static void Main(string[] args)
    {
        try
        {
            int numero= int.Parse("ciao"); // il metodo int.Parse() genera un'eccezione perche "ciao" non è un numero
        }
        catch
        {
            Console.WriteLine("il numero non è valido");
            Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}")
            return;
        }
    }
    static void stackOverflow(){
        StackOverflow();
    }
}
*/
/*ArgumentException*/
/*class Program
{
    static void Main(string[] args)
    {
        try
        {
            int numero = int.Parse("1000000000000"); // il metodo int.Parse() genera un'eccezione perche 1000000000000 è un numero troppo alto
        }
        catch
        {
            Console.WriteLine("il numero è troppo alto");
            Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}")
            Console.WriteLine($"CODICE ERRORE: {e.HResult}")
            return;
        }
    }
    static void stackOverflow(){
        StackOverflow();
    }
}
*/
/*ArgumentException*/
class Program
{
    static void Main(string[] args)
    {
        try
        {
            int numero = int.Parse("1000000000000"); // il metodo int.Parse() genera un'eccezione perche 1000000000000 è un numero troppo alto
        }
        catch
        {
            Console.WriteLine("il numero è troppo alto");
            Console.WriteLine($"ERRORE NON TRATTATO: {e.Data}")
            Console.WriteLine($"CODICE ERRORE: {e.HResult}")
            return;
        }
    }
    static void stackOverflow(){
        StackOverflow();
    }
}
/*
try
{
    int zero = 0;
    int numero = 1 / zero; // il programma si blocca perché non si può dividere per zero
}
catch (Exception e)
{
    Console.WriteLine("Divisione per zero");
    Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
    Console.WriteLine($"CODICE ERRORE: {e.HResult}");
    Console.WriteLine(e.Data); // stampa il dizionario di dati associato all'eccezione
    return;
}
finally
{
    Console.WriteLine("Fine del programma");
}*/