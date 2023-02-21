using Microsoft.AspNetCore.Mvc;

namespace AV22YRGO.web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
