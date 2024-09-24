# MvcConsole

MvcConsole è una semplice applicazione console in C# progettata per gestire informazioni sugli utenti utilizzando il pattern architetturale MVC (Model-View-Controller). Il progetto si concentra su funzionalità di gestione utenti come l'aggiunta, l'aggiornamento, l'eliminazione e la ricerca di utenti, consentendo una facile integrazione di analisi dati e statistiche nelle versioni future.

## Funzionalità

- Aggiungi nuovi utenti con nome, ruolo e stipendio.
- Aggiorna utenti esistenti (nome, ruolo o stipendio).
- Elimina utenti tramite ID.
- Cerca utenti per nome.
- Visualizza tutti gli utenti.
- Implementato in C# utilizzando SQLite come database per la memorizzazione persistente dei dati.

## Tecnologie Utilizzate

- **C# .NET**: Linguaggio di programmazione principale del progetto.
- **Pattern MVC**: Usato per separare le responsabilità tra il Model, View e Controller.
- **SQLite**: Database incorporato per la memorizzazione dei dati degli utenti, consentendo uno storage persistente senza bisogno di un server di database separato.
- **Interfaccia Console**: Interfaccia testuale semplice per l'interazione con l'utente.

## Struttura del Progetto

- **Controller**: Gestisce la logica di business dell'applicazione. Comunica tra la View e il Model.
- **Model (Database)**: Si occupa della gestione dei dati e della loro persistenza. Interagisce con il database SQLite per la gestione dei dati degli utenti.
- **View**: Responsabile della visualizzazione dei dati all'utente e della raccolta degli input dalla console.

## Miglioramenti Futuri

- Implementazione di funzionalità di autenticazione e autorizzazione per utenti.

passaggi...
crea le 2 tabelle.
quella users conterrà NOME, USERNAME, RUOLO, SALARIO  avra anche un ruolo che permetterà di settare se ceo o manager come admin mentre se il ruolo non corrisponde ad esso allora sarà un dipendente e rimuovera alcune ozioni dal menu.
la nuova tabella è quella che gestisce l'autenticazione con username e password.
considerare che la tabella che gestisce l'autenticazione deve avere invece già un utente di default chiamato admin con password "password" e con ruolo da CEO e quindi da admin per poter inserire i primi utenti.

la prima cosa che viene visualizzata una volta create le 2 tabelle è la richiesta del nome utente (motivo per il quale devo creare la tabella con 1 utente gia settato ad admin), la password(password) e avendo accesso come admin ho accesso al menù di aggiunta dipendenti ecc per intero.. se inserisco il primo utente inserisco nome, ruolo, salario. la seconda tabella controlla il ruolo e se "ceo" o "manager" allora ha accesso come ruolo di admin al contrario sei un dipendente, limiti l'accesso a quando si effettua il login di determinate possibili scelte del menu in questo caso rimuovi la possibilita di aggiungere, eliminare, modificare un'utente ma rimane solo la visualizzazione e la ricerca.

il sistema richiederà il login solo all'inizio e non ogni volta che si esegue un'operazione che richiede autenticazione. Il flag \_isLoggedIn viene utilizzato per tenere traccia dello stato di login dell'utente e viene impostato a false quando si esce dal menu principale.
