# MvcConsole

**MvcConsole** è un'applicazione console scritta in C# che adotta il pattern architetturale **MVC** (Model-View-Controller) per la gestione delle informazioni sugli utenti. Il progetto si focalizza su operazioni di base quali l'aggiunta, l'aggiornamento, l'eliminazione e la ricerca di utenti, con l'obiettivo di facilitare l'eventuale integrazione di analisi dati e statistiche in future versioni.

Nella versione attuale, l'applicazione include anche una funzionalità di **login** per gestire i permessi delle varie operazioni, a seconda del ruolo assegnato a ciascun utente:

- **Admin** (ruoli: CEO e Manager): può eseguire tutte le operazioni disponibili.
- **Dipendente** (altri ruoli): ha accesso limitato a operazioni di sola visualizzazione.

## Funzionalità Principali

- **Aggiungi Utente**: Permette di inserire un nuovo utente con nome, ruolo e salario.
- **Aggiorna Utente**: Consente di modificare i dati di un utente esistente (nome, ruolo o salario).
- **Elimina Utente**: Consente di rimuovere un utente dal sistema tramite il suo ID.
- **Cerca Utente**: Permette di cercare utenti per nome.
- **Visualizza Tutti gli Utenti**: Mostra l'elenco completo degli utenti registrati.
- **Persistenza dei Dati**: Utilizzo di SQLite come database per mantenere i dati in modo persistente.
- **Login e Gestione Permessi**: Accesso controllato tramite login, con funzionalità differenziate in base al ruolo.

## Funzionalità di Login

Il sistema di autenticazione richiede il login all'avvio dell'applicazione. I dati per l'autenticazione sono memorizzati in una tabella dedicata, con un utente predefinito già presente per il primo accesso:

- **Username**: admin
- **Password**: password

Una volta effettuato l'accesso come admin, sarà possibile gestire i dati degli utenti e assegnare i rispettivi ruoli. L'applicazione verifica il ruolo assegnato e limita le operazioni disponibili a seconda di esso.

## Tecnologie Utilizzate

- **C# .NET**: Linguaggio principale di sviluppo dell'applicazione.
- **Pattern MVC**: Utilizzato per separare la logica del programma (Controller), la gestione dei dati (Model) e l'interfaccia utente (View).
- **SQLite**: Database leggero e integrato per la memorizzazione persistente degli utenti.
- **Console**: Interfaccia testuale semplice e immediata per interagire con l'applicazione.

## Struttura del Progetto

- **Controller**: Gestisce la logica di business dell'applicazione, fungendo da intermediario tra la View e il Model.
- **Model**: Si occupa della gestione e persistenza dei dati. Interagisce con SQLite per operazioni come l'inserimento, la modifica e la cancellazione di utenti.
- **View**: Responsabile della visualizzazione dei dati e della gestione degli input provenienti dalla console.

## Dettagli Tecnici per la Gestione dei Ruoli

### Tabella **"users"**
Questa tabella contiene i seguenti campi:
- **Nome**
- **Username**
- **Ruolo**
- **Salario**

Il campo "Ruolo" determina i permessi dell'utente. Se il ruolo è "CEO" o "Manager", l'utente ha i permessi di admin; altrimenti, l'utente sarà considerato un dipendente con permessi limitati.

### Tabella **"auth"**
Questa tabella gestisce l'autenticazione degli utenti con:
- **Username**
- **Password**

Al primo avvio dell'applicazione, esiste già un utente predefinito con username **admin** e password **password**, e ruolo **CEO** (quindi admin).

### Flusso di Login
Dopo aver creato le tabelle, al primo avvio verrà richiesto il login, con username e password. Una volta effettuato l'accesso come admin, si avrà accesso completo al menu, che permetterà l'inserimento di nuovi utenti (nome, ruolo, salario). Il sistema verificherà il ruolo degli utenti e, in base a esso, modificherà dinamicamente le opzioni disponibili nel menu.

Gli utenti con ruoli **CEO** o **Manager** avranno accesso a tutte le funzionalità (aggiunta, modifica, eliminazione, visualizzazione), mentre gli altri ruoli potranno solo visualizzare e cercare utenti.

### Stato di Login Persistente
Il sistema richiederà il login solo all'avvio e manterrà lo stato dell'utente loggato per tutta la sessione. Il flag **_isLoggedIn** viene utilizzato per tracciare se l'utente è autenticato e verrà reimpostato su `false` solo al momento della disconnessione o dell'uscita dal menu principale.

## Miglioramenti Futuri

- **Statistiche**: Prevedere l'integrazione di strumenti di analisi e statistiche, ad esempio utilizzando la libreria **Spectre.Console**.
- **Cambio Account**: Implementare la possibilità di cambiare utente senza uscire dall'applicazione.

---

In questa versione, l'applicazione è pronta per gestire utenti con login e permessi, personalizzando il menu in base ai ruoli.


# Passaggi

- crea le 2 tabelle.
- La tabella **"users"** conterrà NOME, USERNAME, RUOLO, SALARIO e il ruolo permetterà di settare se "ceo" o "manager" come ADMIN mentre se il ruolo non corrisponde ad esso allora sarà un dipendente e rimuovera alcune ozioni dal menu.
- la nuova tabella "Auth" è quella che gestisce l'autenticazione con username e password. (X ADMIN:possibile join tra le 2 tabelle per avere affianco al nome le credenziali)
  considerare che le tabelle all'inizio l'autenticazione deve avere già un utente di default chiamato admin con password "password" e con ruolo da CEO e quindi da admin per poter inserire i primi utenti.

la prima cosa che viene visualizzata una volta create le 2 tabelle è la richiesta del nome utente (motivo per il quale devo creare la tabella con 1 utente gia settato ad admin), la password(password) e avendo accesso come admin ho accesso al menù di aggiunta dipendenti ecc per intero.. se inserisco il primo utente inserisco nome, ruolo, salario. la seconda tabella controlla il ruolo e se "ceo" o "manager" allora ha accesso come ruolo di admin al contrario sei un dipendente, limiti l'accesso a quando si effettua il login di determinate possibili scelte del menu in questo caso rimuovi la possibilita di aggiungere, eliminare, modificare un'utente ma rimane solo la visualizzazione e la ricerca.

il sistema richiederà il login solo all'inizio e non ogni volta che si esegue un'operazione che richiede autenticazione. Il flag \_isLoggedIn viene utilizzato per tenere traccia dello stato di login dell'utente e viene impostato a false quando si esce dal menu principale.

[x] _Personalizzare il menu principale_ in base al ruolo dell'utente.
[x] _Implementare_ un meccanismo per cambiare account senza uscire definitivamente dal programma.
