class Program
{
    public static void Main(String[] args)
    {
        string path = @"test.csv";
        File.Create(path).Close();
        while (true)
        {
            Console.WriteLine("inserisci nome, cognome ed età");
            string nome = Console.ReadLine()!;
            string cognome = Console.ReadLine()!;
            string eta = Console.ReadLine()!;
            File.AppendAllText(path, nome + "," + cognome + "," + eta + "\n");
            Console.WriteLine("Vuoi inserire un'altro nome? (s/n)");
            string risposta = Console.ReadLine()!;
            if (risposta == "n")
            {
                break;
            }
        }
    }
}