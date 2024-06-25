int Min = 1;
int Max = 100;
int Tent = 5; // Numero massimo di tentativi
int segreto, num, tentativiFatti = 0; // Aggiunta della variabile tentativiFatti
bool indovinato = false;
Random rnd = new Random(); // Dichiarazione e inizializzazione dell'oggetto Random

Console.WriteLine($"Indovina un numero casuale tra {Min} e {Max}...");
segreto = rnd.Next(Min, Max); // Genera un numero casuale tra 1 e 100

Console.WriteLine($"GAME OVER  \n Numero segreto è {segreto}");
if (Tent != 0)
{
    do
    {
        Console.Write("Fornisci il tuo numero: ");
        num = int.Parse(Console.ReadLine()!);

        if (num < Min || num > Max)
        {
            Console.WriteLine("Numero fuori dal range previsto.");
        }
        else
        {
            tentativiFatti++; // Incremento dei tentativi ogni volta che viene fornito un numero valido

            if (num == segreto)
            {
                Console.WriteLine("Bravo, hai indovinato!");
                indovinato = true;
            }
            else if (num > segreto)
            {
                Console.WriteLine("No, il tuo numero è troppo alto!");
            }
            else
            {
                Console.WriteLine("No, il tuo numero è troppo basso!");
            }

            Tent--; // Decremento dei tentativi rimanenti
            Console.WriteLine($"Tentativi rimanenti: {Tent}");

            // Aggiungo un suggerimento se siamo al terzo tentativo rimanente
            if (Tent == 3)
            {
                Console.WriteLine("vuoi un suggerimento? (si/no)");
                string Suggerimento = Console.ReadLine()!;
                if (Suggerimento == "si")
                {
                    if (segreto % 2 == 0)
                    {
                        Console.WriteLine("Suggerimento: Il numero segreto è pari.");
                    }
                    else
                    {
                        Console.WriteLine("Suggerimento: Il numero segreto è dispari.");
                    }
                }
            }
        }

    } while (!indovinato && Tent > 0);
}
else
{
    Console.WriteLine("Hai finito i tentativi disponibili.");
}

Console.WriteLine($"GAME OVER  \n Numero segreto era: {segreto}");
Console.WriteLine($"Tentativi fatti: {tentativiFatti}");
Console.WriteLine("Premi un tasto per uscire...");
Console.ReadKey();
