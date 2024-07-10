```Mermaid
graph TD

    A[Start] --> B{Mostra Menu}
    B --> C1[1. Visualizza squadre]
    B --> C2[2. Aggiungi persona a una squadra]
    B --> C3[3. Rimuovi persona da una squadra]
    B --> C4[4. Sposta persona tra squadre]
    B ---> C5[5. Esci]

    C1 --> D1[Visualizza Squadra 1]
    D1 --> D2[Visualizza Squadra 2]
    D2 --> B

    C2 --> E1[Inserisci nome della persona]
    E1 --> E2[Inserisci numero squadra 1 o 2]
    E2 --> F1{Squadra scelta valida?}
    F1 --> |Sì| G1[Aggiungi persona alla squadra]
    F1 --> |No| G2[Mostra errore]
    G1 --> B
    G2 --> B

    C3 --> H1[Inserisci nome della persona da rimuovere]
    H1 --> H2[Inserisci numero squadra 1 o 2]
    H2 --> I1{Squadra scelta valida?}
    I1 --> |Sì| J1[Verifica se persona è presente]
    J1 --> |Presente| K1[Rimuovi persona]
    J1 --> |Non presente| K2[Mostra errore]
    I1 --> |No| K2
    K1 --> B
    K2 --> B

    C4 --> L1[Inserisci nome della persona da spostare]
    L1 --> L2[Inserisci numero squadra di partenza 1 o 2]
    L2 --> L3[Inserisci numero squadra di destinazione 1 o 2]
    L3 --> M1{Scelte valide?}
    M1 --> |Sì| N1[Verifica se persona è presente nella squadra di partenza]
    N1 --> |Presente| O1[Sposta persona]
    N1 --> |Non presente| O2[Mostra errore]
    M1 --> |No| O2
    O1 --> B
    O2 --> B

    C5 --> P[Esci dal programma]

```