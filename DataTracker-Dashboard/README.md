# DataTracker Dashboard

## Descrizione del Progetto

DataTracker Dashboard è un'applicazione web progettata per monitorare e visualizzare vari tipi di dati, inclusi i clic su una griglia interattiva. Il progetto utilizza una combinazione di C#, HTML, CSS e JavaScript per fornire un'interfaccia utente intuitiva e funzionalità di backend robuste. I dati di frequenza dei clic vengono temporaneamente memorizzati in formato JSON e successivamente inviati a un database relazionale per la memorizzazione permanente.

## Requisiti

- **Linguaggio di programmazione**: C#, HTML, CSS, JavaScript
- **Gestione dati**: JSON per lo scambio e l'archiviazione temporanea dei dati.
- **Database**: SQL Server o MySQL per la memorizzazione permanente dei dati di frequenza.
- **Librerie**:
  - **Griglia**: [DataTables](https://datatables.net/) per semplificare la gestione della griglia.
  - **Grafici**: [Chart.js](https://www.chartjs.org/) o [D3.js](https://d3js.org/) per creare la dashboard con la griglia colorata (valutare se necessarie).
- **Server web**: Necessario per ospitare il sito web e l'applicazione web.

## Passi da Seguire

### 1. Progettazione della Griglia

- Definire la struttura della griglia, le dimensioni e le eventuali aree cliccabili.

### 2. Sviluppo del Frontend

- Creare il codice HTML e CSS per la griglia e la dashboard.

### 3. Gestione Eventi

- Implementare il codice JavaScript per registrare i clic sulla griglia e aggiornare i dati di frequenza.

### 4. Archiviazione Dati Temporanea

- Salvare i dati di frequenza in file JSON temporaneamente.
- Aggiornare il file sommando i dati con quelli precedenti per l'accesso successivo.

### 5. Integrazione con il Database

- Stabilire la connessione al database.
- Implementare le query per memorizzare e recuperare i dati aggregati.

### 6. Creazione della Dashboard

- Sviluppare la dashboard con la griglia colorata utilizzando librerie di grafici.

### 7. Invio Dati al Database

- Implementare il codice per inviare i dati di frequenza al database quando l'utente chiude la pagina.

### 8. Test e Ottimizzazione

- Testare accuratamente l'applicazione per garantire prestazioni e stabilità.



