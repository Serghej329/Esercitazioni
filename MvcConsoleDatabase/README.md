# Sistema di Gestione Utenti

Questo progetto è un semplice Sistema di Gestione Utenti basato su console implementato in C#. Permette operazioni CRUD (Creazione, Lettura, Aggiornamento, Eliminazione) di base su utenti e abbonamenti.

## Indice

1. [Struttura del Progetto](#struttura-del-progetto)
2. [Classi](#classi)
3. [Funzionalità](#funzionalità)
4. [Database](#database)
5. [Come Eseguire](#come-eseguire)

## Struttura del Progetto

Il progetto è composto da diversi file C#:

- `Program.cs`: Il punto di ingresso dell'applicazione
- `Database.cs`: Gestisce le operazioni del database usando Entity Framework Core
- `View.cs`: Gestisce l'interfaccia utente e le operazioni di input/output
- `Controller.cs`: Contiene la logica principale per la gestione di utenti e abbonamenti
- `User.cs`: Definisce il modello Utente
- `Subscription.cs`: Definisce il modello Abbonamento

## Classi

### Database

Questa classe estende `DbContext` e configura la connessione al database usando SQLite. Include:

- `Users`: Un `DbSet` per le entità Utente
- `Subscriptions`: Una lista di oggetti Abbonamento
- `GetSubscriptions()`: Un metodo per recuperare tutti gli abbonamenti

### View

Responsabile della visualizzazione dei menu e delle informazioni utente. I metodi principali includono:

- `ShowMainMenu()`: Mostra le opzioni del menu principale
- `ShowUsers()`: Visualizza una lista di utenti
- `ShowSubscriptionMenu()`: Mostra il menu di gestione degli abbonamenti
- `ShowSubscriptions()`: Visualizza una lista di abbonamenti
- `GeInput()`: Ottiene l'input dell'utente (Nota: C'è un errore di battitura nel nome del metodo, dovrebbe essere `GetInput()`)

### Controller

Gestisce la logica principale dell'applicazione. Include metodi per:

- Gestione utenti: Aggiungere, Mostrare, Aggiornare ed Eliminare utenti
- Gestione abbonamenti: Aggiungere, Mostrare, Aggiornare ed Eliminare abbonamenti

### User

Rappresenta un utente nel sistema con le proprietà:

- `Id`: Identificatore unico
- `Name`: Nome dell'utente
- `isActive`: Booleano che indica se l'utente è attivo

### Subscription

Rappresenta un abbonamento con le proprietà:

- `Id`: Identificatore unico
- `Name`: Nome dell'abbonamento
- `Price`: Prezzo dell'abbonamento

## Funzionalità

Il sistema offre le seguenti funzionalità:

1. Gestione Utenti:
   - Aggiungere nuovi utenti
   - Visualizzare utenti attivi
   - Aggiornare informazioni utente
   - Eliminare utenti

2. Gestione Abbonamenti:
   - Aggiungere nuovi abbonamenti
   - Visualizzare tutti gli abbonamenti
   - Aggiornare dettagli degli abbonamenti
   - Eliminare abbonamenti

## Database

Il progetto utilizza SQLite come database, configurato con Entity Framework Core. Il file del database si chiama `db.db`.

## Come Eseguire

1. Assicurati di avere il .NET SDK installato sul tuo sistema.
2. Clona il repository sulla tua macchina locale.
3. Naviga nella directory del progetto nel tuo terminale.
4. Esegui i seguenti comandi:

   ```
   dotnet restore
   dotnet run
   ```

5. Segui le istruzioni a schermo per interagire con il Sistema di Gestione Utenti.

Nota: Assicurati di avere installati i pacchetti NuGet necessari, in particolare Microsoft.EntityFrameworkCore e Microsoft.EntityFrameworkCore.Sqlite.

## Problemi Noti

- C'è un errore di battitura nella classe `View`: `GeInput()` dovrebbe essere rinominato in `GetInput()` per chiarezza.
- Il nome della classe `Controllerr` ha un errore di battitura e dovrebbe essere rinominato in `Controller`.

## Miglioramenti Futuri

- Implementare la gestione degli errori e la validazione degli input in tutta l'applicazione.
- Aggiungere test unitari per garantire l'affidabilità del codice.
- Implementare uno schema di database più robusto con relazioni tra Utenti e Abbonamenti.
- Migliorare l'interfaccia utente per una migliore esperienza utente.


aggiungo la teballa transizione