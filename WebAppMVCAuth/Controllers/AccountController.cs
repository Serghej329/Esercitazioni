using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;

    public AccountController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    // GET: /Account/AddToRole
    public async Task<IActionResult> AddToRoleAdmin()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name); // trovare l'utente attuale
        await _userManager.AddToRoleAsync(user, "Admin"); // aggiungere l'utente al ruolo Admin
        return RedirectToAction("Index", "Home"); // reindirizzare l'utente alla pagina principale
    }
    // GET: /Account/GetRole
    public async Task<IActionResult> GetRole()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name); // trovare l'utente attuale
        var roles = await _userManager.GetRolesAsync(user); // trovare i ruoli dell'utente
        return Content(string.Join(", ", roles)); // stampare il ruolo dell'utente
    }
    // GET: /Account/RemoveFromRole
    public async Task<IActionResult> RemoveFromRoleAdmin()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name); // trovare l'utente attuale
        await _userManager.RemoveFromRoleAsync(user, "Admin"); // rimuovere l'utente dal ruolo Admin
        return RedirectToAction("Index", "Home"); // reindirizzare l'utente alla pagina principale
    }
    // GET: /Account/AddToRoleUser
    public async Task<IActionResult> AddToRoleUser()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name); // trovare l'utente attuale
        await _userManager.AddToRoleAsync(user, "User"); // aggiungere l'utente al ruolo User
        return RedirectToAction("Index", "Home"); // reindirizzare l'utente alla pagina principale
    }
    // GET: /Account/RemoveFromRoleUser
    public async Task<IActionResult> RemoveFromRoleUser()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        await _userManager.RemoveFromRoleAsync(user, "User");
        return RedirectToAction("Index", "Home");
    }
}