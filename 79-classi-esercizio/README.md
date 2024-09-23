# **Gioco di Indovina Numero**

## **Obiettivo**

Il progetto consiste nello sviluppo di un semplice gioco "Indovina il numero" in C# .NET con interfaccia a console. L'utente dovrà indovinare un numero casuale generato dal sistema all'interno di un intervallo prestabilito. Il gioco include un sistema di gestione dei giocatori, la possibilità di salvare lo storico delle partite in un file JSON e la fornitura di aiuti dopo un certo numero di tentativi falliti.

## **Funzionalità principali**

1. **Interfaccia a Menu:**

   - Il gioco presenterà un menu con varie opzioni:
     - Nuovo gioco
     - Continuare una partita esistente
     - Creare un nuovo giocatore o selezionare uno già esistente
     - Salvare il gioco
     - Visualizzare lo storico delle partite

2. **Gestione Giocatori:**

   - Il sistema permetterà di creare un nuovo giocatore o di selezionarne uno esistente.
   - Lo storico delle partite per ogni giocatore verrà salvato e potrà essere caricato in seguito.

3. **Salvataggio e Caricamento dello Storico:**

   - Lo stato del gioco, compresi i tentativi fatti e i numeri scelti, verrà salvato in un file JSON.
   - Sarà possibile visualizzare lo storico dei numeri tentati da un giocatore e il numero di tentativi effettuati in una determinata partita.

4. **Gioco di Indovina Numero:**

   - L'utente dovrà indovinare un numero casuale generato dal sistema.
   - Dopo un certo numero di tentativi falliti, verranno forniti suggerimenti per aiutare il giocatore (es. "Il numero è più alto" o "Il numero è più basso").
   - Il gioco continuerà fino a quando il giocatore indovina il numero o decide di interrompere.

5. **Persistenza dei Dati:**

   - Ogni partita e giocatore verrà salvato in un file JSON per poter recuperare lo stato del gioco successivamente.

6. **Sistema di Punteggio:**
   - Il gioco terrà traccia del numero di tentativi e dei tempi impiegati per indovinare il numero.

## **Struttura del progetto**

### **Classi principali**

- `Giocatore`: rappresenta un giocatore con nome, ID e storico delle partite.
- `Partita`: contiene lo stato attuale della partita, come il numero da indovinare, i tentativi fatti, e il giocatore associato.
- `GestioneGioco`: gestisce la logica principale del gioco, incluse le interazioni con l'utente e il menu.
- `SalvataggioStorico`: classe responsabile di salvare e caricare i dati in formato JSON.

## **Obiettivi secondari**

- Migliorare l'esperienza utente fornendo aiuti progressivi durante il gioco.
- Offrire un'interfaccia a console intuitiva e facile da navigare.

## **Tecnologie utilizzate**

- C# .NET
- JSON per la persistenza dei dati
- Console per l'interfaccia utente
