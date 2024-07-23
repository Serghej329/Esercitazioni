# Gestionale delle Spese Aziendali

## Descrizione

Il **Gestionale delle Spese Aziendali** è un'applicazione console sviluppata in C# progettata per aiutare le aziende a tracciare, gestire e analizzare le spese aziendali. L'applicazione consente di registrare le spese, gestire le categorie e generare report in formato CSV per facilitare l'analisi finanziaria e la contabilità.

## Target

- I **contabili** e i **professionisti della contabilità** sono il target che probabilmente trarrà il massimo vantaggio dal _Gestionale delle Spese Aziendali_ grazie alla sua capacità di gestire e analizzare le spese in modo dettagliato.
- **Manager e Responsabili Finanziari**: Anche se il loro utilizzo potrebbe essere più orientato verso la visualizzazione e l'analisi dei dati piuttosto che la gestione quotidiana. Tuttavia, l'analisi dei report generati dal software sarà comunque utile per loro.

## Funzionalità

### Gestione Spese

- [x] **Aggiungi Nuove Spese**: Registra nuove spese con dettagli come data, importo, categoria e descrizione.
- [x] **Modifica e Elimina Spese**: Aggiorna o rimuovi spese esistenti.
- [x] **Visualizza Riepilogo**: Consulta un riepilogo dettagliato delle spese registrate.
- [ ] **Ordinamento Visualizzazione**: Ordinamento della visualizzazione delle spese registrate in ordine alfabetico, di data, di inserimento, di categoria, di prezzo (alto - basso / basso - alto).

### Categorie di Spesa

- [ ] **Gestione Categorie**: Crea e gestisci categorie di spesa personalizzate.
- [ ] **Assegna Categorie**: Collega i prodotti alle categorie appropriate per una gestione più organizzata.

### Report e Analisi

- [ ] **Esporta in CSV**: Genera file CSV contenenti i dettagli delle spese per analisi finanziaria e contabilità.
- [ ] **Creazione di Grafici**: Analizza le spese attraverso grafici incorporati nel file CSV (in fase di valutazione).

### Funzionalità Future

- [ ] **Gestione degli Utenti**: Implementa registrazione e login degli utenti con ruoli e permessi.
- [ ] **Gestione Spese Carte di Credito Aziendali**: Monitoraggio delle spese effettuate tramite carte di credito aziendali.
- [ ] **Monitoraggio Spese Viaggi e Vitto**: Gestisci le spese relative a viaggi e vitto.
- [ ] **Gestione Spese per Progetti**: Assegna e monitorizza spese specifiche per progetti.
- [ ] **Analisi Finanziaria**: Analisi complessiva del fatturato, utili e perdite.
- [ ] **Budget e Avvisi**: Imposta e monitora budget per categorie con notifiche sui superamenti.
- [ ] **Gestione Multi-Valuta**: Gestisci spese in diverse valute e esegui conversioni tra valute.
- [ ] **Persistenza dei Dati**: Implementazione della persistenza dei dati usando JSON e supporto per database.

## Architettura del Progetto

```mermaid
graph TD
    A[Inizio] --> B[Definizione dei Requisiti]
    B --> C[Progettazione dell'Architettura]
    C --> D[Configurazione dell'Ambiente di Sviluppo]
    D --> E[Sviluppo delle Funzionalità]
    E --> F[Implementazione Gestione Spese]
    E --> G[Implementazione Gestione Categorie]
    E --> H[Implementazione Report e Analisi]
    F --> I[Test delle Funzionalità di Spesa]
    G --> J[Test delle Funzionalità di Categoria]
    H --> K[Test di Report e Analisi]
    I --> L[Debug e Correzione Errori]
    J --> L
    K --> L
    L --> M[Documentazione]
    M --> N[Esportazione e Versionamento]
    N --> O[Deployment e Rilascio]
    O --> P[Feedback e Iterazioni]
    P --> Q[Fine]

    classDef startend fill:Green,stroke:#333,stroke-width:2px;
    class A,Q startend;
```

```mermaid
flowchart TD
    Main[Main]
    Main -->|Scegli un'opzione| Menu[Menu Principale]
    Menu -->|Gestione Prodotti| GestioneProdotti[Gestione Prodotti]
    Menu -->|Categorie di Prodotto| VisualizzaCategorie[Visualizza Categorie]
    Menu -->|Report e Analisi| ReportAnalisi[Report e Analisi]
    Menu -->|Esci| Esci[Esci]

    GestioneProdotti -->|Aggiungi Prodotto| AggiungiProdotto[Aggiungi Prodotto]
    GestioneProdotti -->|Visualizza Prodotti| VisualizzaProdotti[Visualizza Prodotti]
    GestioneProdotti -->|Modifica Prodotto| ModificaProdotto[Modifica Prodotto]
    GestioneProdotti -->|Elimina Prodotto| EliminaProdotto[Elimina Prodotto]
    GestioneProdotti -->|Torna al Menù Principale| Menu

    VisualizzaProdotti -->|Ordina Alfabetico| OrdinaAlfabetico[Ordina Alfabetico]
    VisualizzaProdotti -->|Ordina di Inserimento| OrdinaInserimento[Ordina di Inserimento]
    VisualizzaProdotti -->|Ordina di Data| OrdinaData[Ordina di Data]
    VisualizzaProdotti -->|Ordina di Categoria| OrdinaCategoria[Ordina di Categoria]
    VisualizzaProdotti -->|Ordina di Prezzo| OrdinaPrezzo[Ordina di Prezzo]

    AggiungiProdotto -->|Salva e Aggiorna| GestioneProdotti
    ModificaProdotto -->|Salva e Aggiorna| GestioneProdotti
    EliminaProdotto -->|Salva e Aggiorna| GestioneProdotti
    VisualizzaCategorie -->|Seleziona Categoria| FiltraProdotti[Filtra Prodotti per Categoria]

    FiltraProdotti -->|Visualizza| VisualizzaProdottiInTabella[Visualizza Prodotti in Tabella]
    VisualizzaProdottiInTabella -->|Ritorna| VisualizzaCategorie

    subgraph Funzioni di Ordinamento
        OrdinaAlfabetico
        OrdinaInserimento
        OrdinaData
        OrdinaCategoria
        OrdinaPrezzo
    end

    subgraph Funzioni di Gestione Prodotti
        AggiungiProdotto
        ModificaProdotto
        EliminaProdotto
        VisualizzaProdotti
    end
```