 ```Mermaid
flowchart TD
    A[Gioco dei Dadi] --> B[Carica i punteggi da punteggi.txt]
    B -->|File esiste| C[Leggi punteggi dal file]
    B -->|File non esiste| D[Inizializza punteggi a 100]
    C --> E[Mostra i punteggi iniziali]
    D --> E
    E --> F{Punteggi > 0?}
    F -->|Sì| G[Premi un tasto per lanciare i dadi]
    G --> H[Lancia i dadi]
    H --> I[Calcola i punteggi]
    I --> J[Mostra i risultati dei dadi]
    J --> K{Chi ha vinto il round?}
    K -->|Giocatore| L[Decrementa punteggio computer]
    K -->|Computer| M[Decrementa punteggio giocatore]
    L --> N[Mostra i nuovi punteggi]
    M --> N
    N --> O[Salva i punteggi nel file]
    O --> F
    F -->|No, giocatore punteggio <= 0| P[Mi dispiace, ho vinto io!]
    F -->|No, computer punteggio <= 0| Q[Congratulazioni!! Hai vinto!]
    P --> R[Resetta i punteggi a 100]
    Q --> R
    R --> S[Fine]



```
