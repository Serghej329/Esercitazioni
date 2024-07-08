using Spectre.Console;
AnsiConsole.Clear();
AnsiConsole.Write(new Markup("[bold red]ciao[/], [green] mondo![/]"));

AnsiConsole.Markup("[28]ciao[/], [30] mondo![/]");


AnsiConsole.Markup("[underline red]testo sottolineato e rosso[/]");
//esempio di testo formattato
var continua = AnsiConsole.Confirm("vuoi continuare?");
AnsiConsole.Write("");
var table = new Table();
table.AddColumn("Nome corso");
table.AddColumn("Anno");
table.AddRow("corso di informatica", "2024");
//render è obsoleto va bene sopratutto AnsiConsole.Write = AnsiConsole.Render
AnsiConsole.Render(table);

//esempio di panel
var panel = new Panel("Esempio di Panel");
panel.Border = BoxBorder.Double;
AnsiConsole.Render(panel);


