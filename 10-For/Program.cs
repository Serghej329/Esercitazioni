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