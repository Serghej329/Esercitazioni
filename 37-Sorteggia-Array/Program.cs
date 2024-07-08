int [] numeri = new int [3] { 10, 20, 30 };
/*
numeri[0] = 10;
numeri[1] = 20;
numeri[2] = 30;
*/
Random random = new Random ();
int indicie = random.Next(0, 3);

Console.WriteLine("Indovina il numero sorteggiato");
int numero = int.Parse (Console.ReadLine());

if (numero == numeri[indicie]){
    Console.WriteLine ("Hai indovinato");
}
else 
{
Console.WriteLine ("Non hai indovinato");
}