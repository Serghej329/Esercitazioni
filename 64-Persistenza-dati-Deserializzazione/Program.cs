using Newtonsoft.Json;
class Program
{
    static void Main(string[] args)
    {
        string path = @"test.json";
        string json = File.ReadAllText(path);
        dynamic obj = JsonConvert.DeserializeObject(json)!;
        Console.WriteLine($"nome:{obj.nome}\n Cognome: {obj.cognome}\n Eta: {obj.eta}");
        Console.WriteLine($"Via:{obj.indirizzo.via}\n Citta: {obj.indirizzo.citta}");
    }
}

