Dictionary<string, List<int>> registroClassi = new Dictionary<string, List<int>>();
registroClassi["Marco"] = new List<int> { 7, 8, 9};
registroClassi["Laura"] = new List<int> { 6, 7, 8};

//Aggiungere a uno student un voto 

registroClassi ["Marco"].Add(10);

// stampa di tutti gli studenti e i loro voti
foreach(var studente in registroClassi)
{
    Console.WriteLine($"studente: {studente.Key}, Voti: {string.Join(",", studente.Value)}"); // string.Join Concatena gli elementi di una matrice specificata o i membri di una raccolta, usando tra gli elementi o i membri il separatore specificato.
}
