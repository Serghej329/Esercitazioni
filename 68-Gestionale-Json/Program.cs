using Newtonsoft.Json;
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            string path = @"test.Json";


            Console.WriteLine("Inserisci nome:");
            string nome = Console.ReadLine().Trim();

            Console.WriteLine("Inserisci il prezzo:");
        }
        if (decimal.TryParse(Console.ReadLine(), out decimal prezzo))
        {
            File.AppendAllText(path, JsonConvert.SerializeObject(new {nome, prezzo = prezzo.ToString() })+ ".\n");

            Conosole.WriteAllText("vuoi inserire un'altro prodotto (s/n)");
            if (Console.ReadLine().Trim().ToLower() == "s")
        }
        {
            File.Create(path).Close();
            File.AppendAllText(path, "[\n");
        }
    }
}