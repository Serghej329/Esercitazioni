 ```Mermaid
 
flowchart TD
    A[Avvio] --> B{Carica dati squadre da file}
    B -->|File squadra1.txt esiste| C[Carica dati in squadra1]
    B -->|File squadra2.txt esiste| D[Carica dati in squadra2]
    B -->|File non esiste| E[Continua]
    E --> F{Persone rimanenti}
    F -->|Sì| G[Seleziona persona casuale]
    G --> H{Squadra con meno membri}
    H -->|Squadra1| I[Aggiungi a squadra1]
    H -->|Squadra2| J[Aggiungi a squadra2]
    J --> K[Remove persona da lista persone]
    I --> K
    K --> F
    F -->|No| L[Avvio del Menu]
    L --> M{Scelta dell'utente}
    M -->|1. Visualizza squadre| N[Visualizza Squadra1]
    N --> O[Visualizza Squadra2]
    O --> P[Mostra menu]
    M -->|2. Aggiungi persona| Q[Inserisci nome e squadra]
    Q --> R{Squadra scelta}
    R -->|Squadra1| S[Aggiungi a squadra1 e salva]
    R -->|Squadra2| T[Aggiungi a squadra2 e salva]
    T --> P
    S --> P
    M -->|3. Rimuovi persona| U[Inserisci nome e squadra]
    U --> V{Squadra scelta}
    V -->|Squadra1| W[Rimuovi da squadra1 e salva]
    V -->|Squadra2| X[Rimuovi da squadra2 e salva]
    W --> P
    X --> P
    M -->|4. Sposta persona| Y[Inserisci nome, squadra partenza e destinazione]
    Y --> Z{Squadra partenza e destinazione}
    Z -->|Squadra1 a Squadra2| AA[Rimuovi da squadra1, aggiungi a squadra2 e salva]
    Z -->|Squadra2 a Squadra1| AB[Rimuovi da squadra2, aggiungi a squadra1 e salva]
    AA --> P
    AB --> P
    M -->|5. Esci| AC[Termina]
    AC --> AD[Fine]
    P --> L

 ```
