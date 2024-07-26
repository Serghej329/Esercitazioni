public class Program
{
    public static void Main()
    {
        int[] numeri = { 3, 5, 8, 4, 2, 1, 0,};
        (int minimo, int massimo) risultato = CalcolaMinMax(numeri);
        Console.WriteLine($"Valore Minimo: {risultato.minimo}");
        Console.WriteLine($"Valore Massimo: {risultato.massimo}");
    }

    static (int, int) CalcolaMinMax(int[] numeri)
    {
        int massimo = numeri.Max();
        int minimo = numeri.Min();
        return (massimo, minimo);
    }

}

