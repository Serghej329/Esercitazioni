using Newtonsoft.Json;
class Program
{
    static void Main(string[] args)
    {
        string path = @"test.Json";

        File.Create(path).Close();
        File.AppendAllText(path, "[\n");

        while (true)
        {
            Console.WriteLine("Scrivi il nome e prezzo:");
            string nome = Console.ReadLine()!;
            string prezzo = Console.ReadLine()!;

            string jsonString = JsonConvert.SerializeObject(new { nome, prezzo }, Formatting.Indented);
            File.AppendAllText(path,jsonString + ",\n");

            Console.WriteLine("Vuoi inserire un'altro prodotto? (s/n)");
            string risposta = Console.ReadLine()!;
            if (risposta == "n")
            {
                break;
            }
        }
        string file = File.ReadAllText(path);
        file = file.Remove(file.Length - 2, 1);
        File.WriteAllText(path, file);
        File.AppendAllText(path, "]");
    }
}

