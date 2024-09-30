# Documentazione del progetto C#

## Sommario
1. [Controller.cs](#controllercs)
2. [Database.cs](#databasecs)
3. [View.cs](#viewcs)

## Controller.cs

### Descrizione generale
Il file `Controller.cs` contiene la classe `Controller` che gestisce la logica di controllo dell'applicazione, inclusi l'autenticazione degli utenti, la gestione del menu principale e le varie operazioni CRUD (Create, Read, Update, Delete) per utenti e prodotti.

### Membri della classe

#### Campi privati
- `_db`: Istanza di `Database` per l'accesso ai dati.
- `_view`: Istanza di `View` per la gestione dell'interfaccia utente.
- `_currentUserRole`: Stringa che memorizza il ruolo dell'utente attualmente autenticato.
- `_isLogged`: Booleano che indica se un utente è attualmente autenticato.

#### Costruttore
```csharp
public Controller(Database db, View view)
```
Inizializza una nuova istanza della classe `Controller` con le dipendenze necessarie.

#### Metodi pubblici

##### `Login()`
Gestisce il processo di autenticazione dell'utente.

##### `MainMenu()`
Implementa il loop principale del programma, gestendo le scelte dell'utente e chiamando i metodi appropriati.

#### Metodi privati

##### `ShowCustomMenu()`
Mostra il menu appropriato in base al ruolo dell'utente.

##### Operazioni sugli utenti
- `AddUser()`: Aggiunge un nuovo utente.
- `ShowUsers()`: Mostra tutti gli utenti.
- `UpdateUser()`: Aggiorna le informazioni di un utente esistente.
- `DeleteUser()`: Elimina un utente.
- `SearchUser()`: Cerca un utente per nome.

##### Operazioni sui prodotti
- `AddProduct()`: Aggiunge un nuovo prodotto.
- `ShowProducts()`: Mostra tutti i prodotti.
- `UpdateProduct()`: Aggiorna le informazioni di un prodotto esistente.
- `DeleteProduct()`: Elimina un prodotto.
- `SearchProduct()`: Cerca un prodotto per nome.

### Flusso di controllo
Il metodo `MainMenu()` implementa un loop infinito che continua fino a quando l'utente non sceglie di uscire. All'interno del loop, il controller verifica l'autenticazione dell'utente, mostra il menu appropriato, e gestisce le scelte dell'utente chiamando i metodi corrispondenti.

### Gestione dei permessi
Il controller implementa un sistema di controllo degli accessi basato sui ruoli. Alcune operazioni (come l'aggiunta o l'eliminazione di utenti) sono consentite solo agli utenti con ruolo "CEO" o "Manager".

## Database.cs

### Descrizione generale
Il file `Database.cs` contiene la classe `Database` che eredita da `DbContext` di Entity Framework Core. Questa classe gestisce la connessione al database e fornisce metodi per le operazioni CRUD su utenti e prodotti.

### Membri della classe

#### Proprietà DbSet
- `Users`: Rappresenta la tabella degli utenti nel database.
- `Products`: Rappresenta la tabella dei prodotti nel database.
- `Categories`: Rappresenta la tabella delle categorie nel database.
- `Auth`: Rappresenta la tabella delle credenziali di autenticazione nel database.

#### Metodi

##### `OnConfiguring(DbContextOptionsBuilder optionsBuilder)`
Configura la connessione al database SQLite.

##### `InitializeDatabase()`
Inizializza il database con un utente amministratore se non esiste già.

##### `CheckCredenziali(string username, string password)`
Verifica le credenziali di un utente.

##### Operazioni sugli utenti
- `AddUser(User user, Auth auth)`: Aggiunge un nuovo utente e le relative credenziali.
- `GetUsers()`: Restituisce tutti gli utenti.
- `UpdateUser(int id, string newName)`: Aggiorna il nome di un utente.
- `UpdateUserRole(int id, string newRole)`: Aggiorna il ruolo di un utente.
- `UpdateUserSalary(int id, decimal newSalary)`: Aggiorna il salario di un utente.
- `DeleteUser(int id)`: Elimina un utente e le relative credenziali.
- `SearchUsers(string name)`: Cerca utenti per nome.
- `SearchUsersById(int id)`: Cerca un utente per ID.

##### Operazioni sui prodotti
- `AddProduct(Product product)`: Aggiunge un nuovo prodotto.
- `GetProducts()`: Restituisce tutti i prodotti.
- `UpdateProduct(...)`: Aggiorna le informazioni di un prodotto.
- `DeleteProduct(int id)`: Elimina un prodotto.
- `SearchProducts(string name)`: Cerca prodotti per nome.

### Gestione del database
La classe utilizza Entity Framework Core con SQLite come database. Il metodo `OnConfiguring` specifica la stringa di connessione per il database SQLite.

## View.cs

### Descrizione generale
Il file `View.cs` contiene la classe `View` che gestisce l'interfaccia utente dell'applicazione, fornendo metodi per visualizzare menu e dati all'utente.

### Membri della classe

#### Metodi pubblici

##### `ShowMainMenu(string role)`
Mostra il menu principale completo, disponibile per utenti con ruoli "CEO" o "Manager".

##### `ShowLimitedMenu()`
Mostra un menu limitato per utenti con ruoli diversi da "CEO" o "Manager".

##### `ShowUsers(List<User> users)`
Visualizza una lista di utenti.

##### `ShowProducts(List<Product> products)`
Visualizza una lista di prodotti.

##### `GetInput()`
Legge l'input dell'utente dalla console.

##### `SearchResults(List<User> users)`
Visualizza i risultati della ricerca per gli utenti.

##### `SearchResults(List<Product> products)`
Visualizza i risultati della ricerca per i prodotti.

### Interazione con l'utente
La classe `View` si occupa di presentare le informazioni all'utente in un formato leggibile e di raccogliere l'input dell'utente. Non contiene logica di business, ma si limita a gestire l'input/output della console.

## Conclusione

Questo progetto implementa un'applicazione console per la gestione di utenti e prodotti con un sistema di autenticazione e controllo degli accessi basato sui ruoli. L'architettura segue il pattern MVC (Model-View-Controller), con:

- `Database.cs` che agisce come Model, gestendo l'accesso ai dati.
- `View.cs` che gestisce la presentazione dei dati all'utente.
- `Controller.cs` che coordina le interazioni tra Model e View, implementando la logica di business dell'applicazione.