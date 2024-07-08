Console.WriteLine("Premi 'n' per terminare");

while (true){
    ConsoleKeyInfo keyInfo = Console.ReadKey();
    if(keyInfo.Key == ConsoleKey.N){ //se premo N
        break;
    }
}

Console.BackgroundColor = ConsoleColor.Red;
Console.ForegroundColor = ConsoleColor.Black;

Console.WriteLine("questo è un testo di colore nero su uno sfondo bianco");