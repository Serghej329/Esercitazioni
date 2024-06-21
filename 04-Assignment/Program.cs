Console.Clear();
//La variabile "c" servirà da contatore
int c = 0;

//Chiedo il nome all'utente
Console.WriteLine("scrivimi il tuo nome:");
string nome = Console.ReadLine()!;

//incremento di 1 la la Variabile contatore
c++;    //TODO ciclo while per poter richiedere ogni volta il nome e aumentare di uno la posizione + creare un tasto di uscita con un boolean

//Dare in output il risultato 
Console.WriteLine($"Il nome è : {nome} - {c}");
