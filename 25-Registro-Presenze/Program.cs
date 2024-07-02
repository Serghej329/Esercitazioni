Dictionary<string, bool> presenze = new Dictionary<string, bool>();
presenze["Mario Rossi"] = true;
presenze["Luca Bianchi"] = false;

while (true)
{
    Console.WriteLine("\nElenco dei dipendenti e il loro stato:");
    foreach (KeyValuePair<string, bool> studenti in presenze)
    {
        string stato;
        if (studenti.Value)
        {
            stato = "Presente";
        }
        else
        {
            stato = "Assente";
        }
        Console.WriteLine("Dipendente: " + studenti.Key + ", Stato: " + stato);
    }

    Console.WriteLine("\nInserisci il nome del dipendente per modificare il suo stato (o 'esci' per terminare):");
    string input = Console.ReadLine();

    // Converti input in minuscolo
    input = input.ToLower();

    // Controlla se l'input è "esci"
    if (input == "esci")
    {
        break;
    }

    bool found = false;
    foreach (var key in presenze.Keys)
    {
        // Converti la chiave in minuscolo per confronto case-insensitive
        if (key.ToLower() == input)
        {
            presenze[key] = !presenze[key];
            Console.WriteLine("Stato di " + key + " modificato con successo!");
            found = true;
            break;
        }
    }

    if (!found)
    {
        Console.WriteLine("Dipendente non trovato. Riprova.");
    }
}

Console.WriteLine("Programma terminato.");