// See https://aka.ms/new-console-template for more information
Console.Write("il tuo nome: ");
Console.WriteLine("Sergej");
Console.WriteLine("weeee \n");
Console.Write("tutto beneee? \t wewewewewe ");
Console.WriteLine("Scrivimi il tuo nome!");
/*
ConsoleKeyInfo cki;
do{
    cki = Console.ReadKey();
    Console.Write("BLA BLA BLA ORA \n Premi esc per uscire \n");
} while(cki.Key != ConsoleKey.Escape);
*/
string nome2 = "Luigi";
string nome = Console.ReadLine()!;
Console.WriteLine("ciao " + nome + " è un piacere conoscerti!");

Console.WriteLine("Scrivimi il tuo cognome!");
string cognome = Console.ReadLine()!;
Console.WriteLine($"ahhh, {cognome}! che bel cognome");
Console.WriteLine($"quindni ti chiami {nome} {nome2} {cognome}.");