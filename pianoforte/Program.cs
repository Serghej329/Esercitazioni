using System;
using System.Threading;

class PianoBeepBuzz
{
    // Array per tenere traccia dei thread di suono attivi per ogni nota
    static Thread[] soundThreads = new Thread[8];
    static bool[] isSoundPlaying = new bool[8];

    static void Main()
    {
        Console.WriteLine("Premi i tasti da A a K per suonare le note. Premi Esc per uscire.");

        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    break; // Esci dal ciclo while per terminare il programma
                }
                else
                {
                    int index = GetNoteIndex(key.KeyChar);
                    if (index != -1)
                    {
                        if (!isSoundPlaying[index])
                        {
                            // Avvia il thread per suonare la nota
                            soundThreads[index] = new Thread(() => PlaySound(index));
                            soundThreads[index].Start();
                            isSoundPlaying[index] = true;
                        }
                    }
                }
            }
            Thread.Sleep(100); // Attendi 100 millisecondi prima di controllare nuovamente
        }

        // Attendere la fine di tutti i thread prima di uscire
        foreach (Thread thread in soundThreads)
        {
            thread?.Join();
        }

        Console.WriteLine("Programma terminato.");
    }

    static void PlaySound(int index)
    {
        int frequency = GetFrequency(index);
        Console.WriteLine($"Suona nota per l'indice '{index}'");

        // Suona la nota per 500 millisecondi
        Console.Beep(frequency, 500);

        // Segna che il suono è stato interrotto
        isSoundPlaying[index] = false;
    }

    static int GetFrequency(int index)
    {
        // Array di frequenze per le note da A a K
        int[] frequencies = { 440, 494, 523, 587, 659, 698, 784, 880 };

        return frequencies[index];
    }

    static int GetNoteIndex(char key)
    {
        // Mappa i tasti da A a K agli indici dell'array di frequenze
        switch (char.ToUpper(key))
        {
            case 'A': return 0; // La nota A (La 440 Hz)
            case 'S': return 1; // La nota B (Si 494 Hz)
            case 'D': return 2; // La nota C (Do 523 Hz)
            case 'F': return 3; // La nota D (Re 587 Hz)
            case 'G': return 4; // La nota E (Mi 659 Hz)
            case 'H': return 5; // La nota F (Fa 698 Hz)
            case 'J': return 6; // La nota G (Sol 784 Hz)
            case 'K': return 7; // La nota A (La 880 Hz)
            default: return -1; // Tasto non valido
        }
    }
}
