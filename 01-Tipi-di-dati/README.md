# Esercitazioni

## 01 Tipi di Dati


<details>
<summary>

### Visualizza il codice 
 </summary>

```c#

int num;  //dichiaro una variabile di tipo intero.

string name; //dichiaro una variabile di tipo string.

bool flag; //dichiaro una variabile di tipo booleano.

num =1;

name = "serghej";

flag = false;

const double PI = 3.14;
 Console.WriteLine(PI);

 var altezza = 1.80;
 Console.WriteLine($"qecco i tuoi valori! \n {num} {name} {flag} {PI} {altezza}.");
```
</details>


## 02 Operatori


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#

//Operatori aritmetici
int a = 10;

int b = 20;

int somma = a+b;

int sottrazione = a-b;

int divisione = a/b;

int modulo = a%b;

int prodotto = a*b;


//Operatori logici 
int c = 30;

int c == a;             // false

int c != a;             // true

int c < a;             // true

int c > a;              // false

int c <= a;             // true

int c >= a;             // false


//Operatori di considizionamento
bool x = true

bool y = false
//and
bool z = x && y;
//or
bool z = x || y;
//not
bool v = !x;


// Esempio di utilizzo di operatori di incremento e decremento
int d = 10;

 d++;
 d-- ;

// Esempio di utilizzo di operatori di incremento e decremento
int e=10

e +=5;
e -=5;

```
</details>


## 03 Esercitazioni-su-tipi-dati-ed-operatori


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#

//pulire il terminale 
Console.Clear();

//stampa il valore di una variabile
int num = 10;

Console.WriteLine($"ecco i tuoi valore | \n                   V\n                   {num}");

Console.WriteLine("");

int eta = 20;
eta ++;
Console.WriteLine($"ecco la tua eta    | \n                   V\n                   {eta}");

Console.WriteLine("");

int eta2 = 20;
eta2 --;
Console.WriteLine($"ecco la tua eta    | \n                   V\n                   {eta2}");

Console.WriteLine("");

int eta3 = 20;
eta3 += 10;
Console.WriteLine($"ecco la tua eta    | \n                   V\n                   {eta3}");

Console.WriteLine("");

int eta4 = 20;
eta4 -= 10;
Console.WriteLine($"ecco la tua eta    | \n                   V\n                   {eta4}");
```
</details>


## 04 Assignment


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#

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

```
</details>


## 05 Condizioni


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#

//un blocco di codice è composto da parentesi {} e puo contenere uno p piu statement 

/* Le condizioni sono utilizzate per eseguire un blocco di codice solo se una condizione è vera */

/*Le condizioni possono essere

if
if-else
if-else if-else
switch
*/

//if - se il  numero è uguale a 10 stampa il numero

Console.Clear();

//Primo esercizio
int numero = 10;

int verifica = 10;

if (numero == verifica)
{
    Console.WriteLine($"hai indovinato il numero era proprio: {numero}");
}
else
{
    Console.WriteLine("no, non è ugualeeee! riprovaci, sarai più fortunato");
}

Console.WriteLine("secondo te che numero era? ti darò un'indizio");
//Secondo esercizio
int numero2 =15;

if (numero2 == 10)
{
    Console.WriteLine($"il numero è uguale a {numero2}");
}
else if (numero2 < 10)
{
    Console.WriteLine($"il numero è minore di 10");
}
else
{
    Console.WriteLine($"il numero è maggiore di 10");
}


//Switch
int giorno = 1;

switch (giorno)
{
    case 1:
        Console.WriteLine("Lunedì");
        break;

    case 2:
        Console.WriteLine("Martedì");
        break;

    case 3:
        Console.WriteLine("Mercoledi");
        break;

    case 4:
        Console.WriteLine("Giovedì");
        break;

    case 5:
        Console.WriteLine("Venerdì");
        break;

    case 6:
        Console.WriteLine("Sabato");
        break;

    case 7:
        Console.WriteLine("Domenica");
        break;

    default:
        Console.WriteLine("Il numero non corrisponde a nessungiorno della settimana");
        break;
}
```
</details>


## 06 Assignment


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#

Console.WriteLine("|scegli la data| \n 1)Lunedì \n 2)Martedì \n 3)Mercoledì \n 4)Giovedì \n 5)Venerdì \n 6)Sabato \n 7)Domenica \n Scrivimi il numero");
/*
int giorno = Convert.ToInt32(Console.ReadLine());
*/
int giorno = int.Parse(Console.ReadLine()!);

switch (giorno)
{
    case 1:
        Console.WriteLine("Lunedì");
        break;

    case 2:
        Console.WriteLine("Martedì");
        break;

    case 3:
        Console.WriteLine("Mercoledi");
        break;

    case 4:
        Console.WriteLine("Giovedì");
        break;

    case 5:
        Console.WriteLine("Venerdì");
        break;

    case 6:
        Console.WriteLine("Sabato");
        break;

    case 7:
        Console.WriteLine("Domenica");
        break;

    default:
        Console.WriteLine("Il numero non corrisponde a nessungiorno della settimana");
        break;
}

```
</details>


## 07 Calcolatrice


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#

//Pulisce il terminale
Console.Clear();

//MENU'
Console.WriteLine("\t |CALCOLATRICE (2 numeri)| \n\n    MENU' \n 1)ADDIZIONE \n 2)SOTTRAZIONE \n 3)MOLTIPLICAZIONE \n 4)DIVISIONE \n 5)RADICE \n 6)ESPONENZIALE \n Digita il numero dell'operazione che vuoi fare: ");

//Richiesta del tipo di operazione
int operazione = int.Parse(Console.ReadLine()!); // Converte l'input dell'utente in un numero intero

//Rieschiesta dei 2 numeri
Console.WriteLine("Scrivimi il primo numero ");
int n1 = int.Parse(Console.ReadLine()!); // Converte l'input dell'utente in un numero intero

Console.WriteLine("Scrivimi il secondo numero");
int n2 = int.Parse(Console.ReadLine()!); // Converte l'input dell'utente in un numero intero

//Controlli operazioni
switch (operazione) // Esegue un'operazione diversa in base al valore di "operazione"
{
    case 1: // Somma
        int somma = n1 + n2;
        Console.WriteLine($"IL RISUALTO E': {n1} + {n2} = {somma}"); // Stampa il risultato
        break;

    case 2: // Sottrazione
        int sottrazione = n1 - n2;
        Console.WriteLine($"IL RISUALTO E': {n1} - {n2} = {sottrazione}"); // Stampa il risultato
        break;

    case 3: // Moltiplicazione
        int moltiplicazione = n1 * n2;
        Console.WriteLine($"IL RISUALTO E': {n1} x {n2} = {moltiplicazione}"); // Stampa il risultato
        break;

    case 4: // Divisione
        if (n2 != 0) // Controlla se il divisore è diverso da zero
        {
            double divisione = n1 / n2;
            Console.WriteLine($"IL RISUALTO E': {n1} / {n2} = {divisione}"); // Stampa il risultato
        }
        else
        {
            Console.WriteLine("Indefinita"); // Stampa un messaggio di errore
        }
        break;

    case 5: // Radice quadrata
        double radice1 = Math.Sqrt(n1); // Calcola la radice quadrata di n1
        double radice2 = Math.Sqrt(n2); // Calcola la radice quadrata di n2
        Console.WriteLine($"IL RISUALTI SONO: \n PRIMO NUMERO √{n1} = {radice1} \n SECONDO NUMERO √{n2} = {radice2}"); // Stampa i risultati
        break;

    case 6: // Potenza
        double esponenziale = Math.Pow(n1, n2); // Calcola n1 elevato alla potenza n2
        Console.WriteLine($"IL RISUALTO E': {n1}^{n2} = {esponenziale}"); // Stampa il risultato
        break;

    default: // Se l'operazione non è valida
        Console.WriteLine("Il numero non corrisponde a nessun delle operazioni "); // Stampa un messaggio di errore
        break;
}

```
</details>


## 08 While


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#

int n1 = 10;
while (n1 > 0){
    Console.WriteLine($"ciao il numero ora è il seguente: {n1} \n");
    n1--;
}

```
</details>


## 09 Do-While


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#

int n1 = 10;

do{
    Console.WriteLine(n1);
    n1--;
} while(n1 > 0);
```
</details>


## 10 For


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#

//Metodo 1
for(int n1 = 10; n1 > 0; n1--){
    Console.WriteLine(n1);
}

//Metodo 2
int[] numeri = new int[10];

for (int i = 0; i < numeri.Length; i++)
{
    numeri[i] = i;
}

foreach (int numero in numeri)
{
    Console.WriteLine(numero);
}
```
</details>


## 11 foreach


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#

string s = "ciao";
foreach (char c in s){
    Console.WriteLine(c);
}
```
</details>


## 12 Metodo Random


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#

//Utilizzo di random

Random random = new Random();
int n1 = random.Next(-10, 10);
Console.WriteLine($"il numero casuale è {n1}");
```
</details>


## 13 Assignment-indovina-numero


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#

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

//bool isPari = somma % 2 == 0 

```
</details>


## 14 Pari Dispari


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#

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

```
</details>


## 15 Fizz-Buzz


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#
/*
//Primo metodo
Random random = new Random();

for (int n1 = random.Next(100); n1 < 100; n1++)
{
    if (n1 % 5 == 0 && n1 % 3 == 0) // n1 % 15 == 0
    {
        Console.WriteLine($"FizzBuzz {n1}");
    }
    else if (n1 % 5 == 0)
    {
        Console.WriteLine($"Buzz {n1}");
    }
    else if (n1 % 3 == 0)
    {
        Console.WriteLine($"Fizz {n1}");
    }
}

*/

/*
//Secondo metodo
while (true)
{
Console.WriteLine("scrivimi un numero");
int n1 = int.Parse(Console.ReadLine()!);

    if (n1 % 15 == 0)
    {
        Console.WriteLine($"|FizzBuzz| {n1}");
    }
    else if (n1 % 5 == 0)
    {
        Console.WriteLine($"|Buzz| {n1}");
    }
    else if (n1 % 3 == 0)
    {
        Console.WriteLine($"|Fizz| {n1}");
    }
}
*/

//Terzo metodo
for(int i = 0; i < 100; i++){
    Console.Write($"Numero |{i}| \t");
    Thread.Sleep(200);
    if(i % 3 == 0) Console.Write($"Fizz");
    if(i % 5 == 0) Console.Write($"Buzz");
    Console.Write("\n");
} 

```
</details>


## 16 String-Array


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#
int Max = 3;
string [] nomi = new string[Max];
nomi[0] = "Mario";
nomi[1] = 5;
nomi[2] = "Giovanni";
foreach (string s in nomi) Console.WriteLine(s);

```
</details>


## 17 Int-Array


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#
int Max = 4;
int [] num = new int[Max];
num[0] = 5;
num[1] = 10;
num[2] = 20;
num[3] = 20;
foreach (int s in num) Console.WriteLine(s);
```
</details>


## 18 Int-Array


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#
int[] num = new int[4];
num[0] = 5;
num[1] = 10;
num[2] = 20;
num[3] = 20;
foreach (int s in num) Console.WriteLine(s);
Console.WriteLine($"il numero di elementi è {num.Length}");
```
</details>


## 19 String-List


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#

List<string> nomi = new List<string>();
List<string> selezionati = new List<string>();
int sorteggio;
nomi.Add("Alison");
nomi.Add("Ginevra");
nomi.Add("Matteo");
nomi.Add("Mattia");
nomi.Add("Salvatore");
nomi.Add("Serghej");
nomi.Add("Daniele");
nomi.Add("Sharon");

/*
foreach (string s in nomi)  Console.WriteLine(s);
*/

Random rnd = new Random();
while (nomi.Count != 0)
{

    sorteggio = rnd.Next(nomi.Count); // Genera un numero casuale tra 0 e numero massimo di partecipanti
    //Lista PRIMA
    Console.WriteLine($"\n|PRIMA|");
    Thread.Sleep(500);
    foreach (string nomeLista in nomi) Console.WriteLine(nomeLista);
    Thread.Sleep(500);
    //Output sorteggio
    Console.WriteLine($"\nè uscito il numero {sorteggio}, '{nomi[sorteggio]}' verrà rimosso");
    //aggiunge il nome uscito (random) dentro la lista di "selezionati"
    selezionati.Add(nomi[sorteggio]);
    //Rimozione del nome uscito
    nomi.Remove(nomi[sorteggio]);
    //Lista DOPO
    Thread.Sleep(500);
    Console.WriteLine($"\n|DOPO|\n");
    Thread.Sleep(500);
    foreach (string nomeLista in nomi) Console.WriteLine(nomeLista);
    
    // Il nome della lista che viene rimosso verrà insrito in un'altra lista "Selezionati"
    Thread.Sleep(500);
    Console.WriteLine($"\n|LISTA DI SELEZIONATI|\n");
    foreach (string nomeSelezionato in selezionati) Console.WriteLine(nomeSelezionato);
    Thread.Sleep(2000);
    //Console.Clear();
    
}if (sorteggio < 0) Console.Clear(); Console.WriteLine($"La lista è VUOTA!\n");


```
</details>


## 20 List-Int


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#
List<int> num = new List<int>();

num.Add(1);
num.Add(2);
num.Add(3);
foreach (int s in num) Console.WriteLine(s);
Console.WriteLine($"il numero di elementi è {num.Count}");


```
</details>


## 21 Esercizio Elenco


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#

List<string> nomi = new List<string>();
List<string> selezionati = new List<string>();
int sorteggio;
nomi.Add("Alison");
nomi.Add("Ginevra");
nomi.Add("Matteo");
nomi.Add("Mattia");
nomi.Add("Salvatore");
nomi.Add("Serghej");
nomi.Add("Daniele");
nomi.Add("Sharon");

/*
foreach (string s in nomi)  Console.WriteLine(s);
*/

Random rnd = new Random();
while (nomi.Count != 0)
{

    sorteggio = rnd.Next(nomi.Count); // Genera un numero casuale tra 0 e numero massimo di partecipanti
    //Lista PRIMA
    Console.WriteLine($"\n|PRIMA|");
    Thread.Sleep(500);
    foreach (string nomeLista in nomi) Console.WriteLine(nomeLista);
    Thread.Sleep(500);
    //Output sorteggio
    Console.WriteLine($"\nè uscito il numero {sorteggio}, '{nomi[sorteggio]}' verrà rimosso");
    //aggiunge il nome uscito (random) dentro la lista di "selezionati"
    selezionati.Add(nomi[sorteggio]);
    //Rimozione del nome uscito
    nomi.Remove(nomi[sorteggio]);
    //Lista DOPO
    Thread.Sleep(500);
    Console.WriteLine($"\n|DOPO|\n");
    Thread.Sleep(500);
    foreach (string nomeLista in nomi) Console.WriteLine(nomeLista);
    
    // Il nome della lista che viene rimosso verrà insrito in un'altra lista "Selezionati"
    Thread.Sleep(500);
    Console.WriteLine($"\n|LISTA DI SELEZIONATI|\n");
    foreach (string nomeSelezionato in selezionati) Console.WriteLine(nomeSelezionato);
    Thread.Sleep(2000);
    //Console.Clear();
    
}if (sorteggio < 0) Console.Clear(); Console.WriteLine($"La lista è VUOTA!\n");


```
</details>


## 22 Menù Lista fissa


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#

List<string> nomi = new List<string>();
bool t = true;
while (t)
{
    //MENU'
    Console.WriteLine("\t|MENU' LISTA| \n\n    Fai la tua scelta' \n 1)visualizza lista \n 2)Aggiungi partecipante \n 3)Esci \n ");
    int scelta = int.Parse(Console.ReadLine()!);

    switch (scelta)
    {
        case 1: // Visualizzazione Partecipanti in lista
            Console.WriteLine($"\n|Lista|");
            foreach (string nomeLista in nomi) Console.WriteLine(nomeLista);
            break;
        case 2: // Aggiunta Partecipanti in lista
            Console.WriteLine("Scrivi il nome del partecipante: \n");
            string partecipante = Console.ReadLine()!;
            nomi.Add(partecipante);
            break;

        case 3: // TODO DA SISTERMARE
            Console.ReadKey();
            t = false;
            break;

        default:// Se l'operazione non è valida
            Console.WriteLine("Il numero non corrisponde a nessun delle operazioni "); // Stampa un messaggio di errore
            break;

    }
}


```
</details>


## 24 Spesa


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#
Dictionary <string, int> listaSpesa = new Dictionary<string, int>();
listaSpesa.Add("pane", 1);
listaSpesa.Add("latte", 2);

//Aggiungere un nuovo articolo 
listaSpesa["uova"] = 12;

//Incrementa la quantita di un articolo già presente
listaSpesa["pane"] = listaSpesa["pane"] + 1;

foreach (KeyValuePair<string, int> articolo in listaSpesa)
{
    Console.WriteLine($"Articolo {articolo.Key}, Quantità: {articolo.Value}");
}
```
</details>


## 25 Registro Presenze


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#
int Max = 4;
int [] num = new int[Max];
num[0] = 5;
num[1] = 10;
num[2] = 20;
num[3] = 20;
foreach (int s in num) Console.WriteLine(s);
```
</details>


## 26 Registro Voti


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#
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

```
</details>


## 27 Var-List


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#
var numeri = new List<int> { 1, 2, 3, 4, 5 };

foreach (var numero in numeri)
{
    Console.WriteLine(numero);
}

//utilizzare un ciclo do while finchè l'utente non decide di uscire però il focus è mantenere il menù sempre visualizato
```
</details>


## 28 Assignment Random


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#

Random rand = new Random();
int somma = 0;

Console.WriteLine("Numeri casuali generati: ");
for (int i = 0; i < 10; ++i)
{
    int numero = rand.Next(10); // Genera un numero casuale tra 0 e 9
    Console.Write(numero + " ");
    somma += numero;
}

Console.WriteLine("\nSomma totale: " + somma);

```
</details>


## 29 Assignment-Menu


<details>
<summary>

### Visualizza il codice 
 </summary>
 
```c#

List<string> nomi = new List<string>();
bool t = true;
do
{
    //MENU'
    Console.WriteLine("\t|MENU' LISTA| \n\n    Fai la tua scelta' \n 1)visualizza lista \n 2)Aggiungi partecipante \n 3)Esci \n ");
    int scelta = int.Parse(Console.ReadLine()!);

    switch (scelta)
    {
        case 1: // Visualizzazione Partecipanti in lista
            Console.WriteLine($"\n|Lista|");
            foreach (string nomeLista in nomi) Console.WriteLine(nomeLista);
            //Console.Beep(32766, 1000);
            Console.WriteLine($"\n|PREMI UN TASTO QUALSIASI PER TORNARE AL MENU'|");
            Console.ReadKey();
            break;
        case 2: // Aggiunta Partecipanti in lista
            Console.WriteLine("Scrivi il nome del partecipante: \n");
            string partecipante = Console.ReadLine()!;
            nomi.Add(partecipante);
            Console.WriteLine($"\n|PREMI UN TASTO QUALSIASI PER TORNARE AL MENU'|");
            Console.ReadKey();
            break;

        case 3: // TODO DA SISTERMARE
            t = false;
            break;

        default:// Se l'operazione non è valida
            Console.WriteLine("Il numero non corrisponde a nessun delle operazioni "); // Stampa un messaggio di errore
            Console.WriteLine($"\n|PREMI UN TASTO QUALSIASI PER TORNARE AL MENU'|");
            Console.ReadKey();
            break;
    }
    Console.Clear();

} while (t);


```
</details>

