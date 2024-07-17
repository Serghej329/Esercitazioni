class Program
{
    static void Main(String[] args)
    {
        string path = @"test.csv";
        File.Create(path).Close();

        while (true)
        {
            //Acquisizione dati
            Console.WriteLine("Inserisci nome, cognome ed età");
            string nome = Console.ReadLine()!;
            string cognome = Console.ReadLine()!;
            string eta = Console.ReadLine()!;
            string risposta;

            bool nomeEsistente = false;
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line.ToLower().Contains(nome.ToLower()))
                    {
                        nomeEsistente = true;
                        break;
                    }
                }
            }

            if (nomeEsistente)
            {
                Console.WriteLine("Nome già presente. Inserire un altro nome? (s/n)");
                risposta = Console.ReadLine()!;
                if (risposta == "n")
                {
                    break;
                }
                continue;
            }

            // Se ill file non è stato trovato allora salva nel gile CSV i dati
            File.AppendAllText(path, nome + "," + cognome + "," + eta + "\n");

            Console.WriteLine("Vuoi inserire un altro nome? (s/n)");
            risposta = Console.ReadLine()!;
            if (risposta == "n")
            {
                break;
            }
        }
    }
}
