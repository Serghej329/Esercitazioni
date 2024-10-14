using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MvcApp.Controllers;
public class ReservedController : Controller
    {
        // GET: /Reserved/Index
        [Authorize] // richiede all utente di essere autenticato
        public IActionResult Index()
        {
            return View(); // restituisce la vista solo se l utente è autenticato
        }
        // GET: /Reserved/Admin
        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }
        // GET: /Reserved/User
        [Authorize(Roles = "User")]
        public IActionResult User()
        {
            return View();
        }
    }