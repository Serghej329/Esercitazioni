/*Program.cs */
using Microsoft.EntityFrameworkCore;
class Program{
    static void Main(string[] args){
        var db = new Database();
        var view = new View(db);
        var controller = new Controllerr(db, view);
        controller.MainMenu();
    }
}