/*
Random rnd = new Random(); // Dichiarazione e inizializzazione dell'oggetto Random
int n1 = rnd.Next(100);
Console.WriteLine($"è un numero pari o dispari?");
string risposta = Console.ReadLine();

// Controllo numero random se è PARI
bool isPari = n1 % 2 == 0;

bool indovinato = false;
while (!indovinato)
{
    if (isPari)
    {
        if (risposta == "pari")
        {
            Console.WriteLine($"CORRETTO è un numero PARI |{n1}|");
            indovinato = true;
        }
        else if (risposta == "dispari")
        {
            Console.WriteLine($"SBAGLIATO è un numero PARI |{n1}|");
            indovinato = true;
        }
    }
    else
    {
        if (risposta == "pari")
        {
            Console.WriteLine($"SBAGLIATO è un numero DISPARI |{n1}|");
            indovinato = true;
        }
        else if (risposta == "dispari")
        {
            Console.WriteLine($"CORRETTO è un numero DISPARI |{n1}|");
            indovinato = true;
        }
    }
}*/

/*
Random random = new Random();
int numeroComputer = random.Next(1, 11);

Console.WriteLine("scegli pari o dispari (p/d)");
string scelta = Console.ReadLine().toLower();

if((numeroComputer % 2 == 0 && scelta == "p") || (numeroComputer % 2 == 1 && scelta == "d")){

    Console.WriteLine($"il computer ha scelto {numeroComputer}. HAI VINTO");
}
else{
    Console.WriteLine($"Il computer ha scelto {numeroComputer}. HAI PERSO!");
}*/
//scelta se essere pari o dispari
Console.WriteLine("Scegli PARI o DISPARI (p/d)");
string scelta = Console.ReadLine().ToLower();
Console.WriteLine(" |BIM BUM BAM|\n SCEGLI UN NUMERO: ");
int sceltaNumero = int.Parse(Console.ReadLine()!);

//scelta numero PC
Random random = new Random();
int numeroComputer = random.Next(1, 5);

int risultato = sceltaNumero + numeroComputer;
if (sceltaNumero < 6 || sceltaNumero > 0){
if((risultato % 2 == 0 && scelta == "p") || (risultato % 2 == 1 && scelta == "d")){
    Console.WriteLine($" {numeroComputer} + {sceltaNumero} = {risultato} . HAI VINTO");
}
else{
    Console.WriteLine($"{sceltaNumero} + {numeroComputer} = {risultato} HAI PERSO!");
}
}else{
    Console.WriteLine("scegli tra 1 e 5");
}
