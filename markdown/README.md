# Titolo principale
## Sottotitolo 1
### Titolo paragrafo

>esempio di quote (citazione)

esempio di __grassetto__ o **bold**

esempio di _italic_

- primo
    - sottoelenco
- secondo
    - sottoelenco
- terzo
    - sottoelenco
- quarto
    - sottoelenco.
    
##  esempio di check
- [x] ciaoooooo
- [ ] primoooooo

|syntax|balalalsd|ciaooo|
|---------|---------|----|
|header|------|


```
ciaoooooooooooo
comde staiii
bello
yeyeye
```

```c#
Random random = new Random();
int n1 = random.Next(-10, 10);
Console.WriteLine($"il numero casuale è {n1}");

```
```html
<div>
    <p>testo</p>
</div>
<!--ahahahah-->
```

<!--Commento per far apparite anche nel markdown-->

<details>

<summary>

## Titolo 
 
 </summary>

[link a pagina 2](02_link.md)
</details>

```Mermaid
%%{init: {"flowchart": {"htmlLabels": false}} }%%
flowchart LR
    markdown["`This **is** _Markdown_`"]
    newLines["`Line1
    Line 2
    Line 3`"]
    markdown --> newLines
```
```Mermaid
flowchart TD
    A[Start] --> B{Is it?}
    B -- Yes --> C[OK]
    C --> D[Rethink]
    D --> B
    B -- No ----> E[End]
```

