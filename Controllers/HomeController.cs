using Microsoft.AspNetCore.Mvc;
using PeriodicTableTutor.Models;
using PeriodicTableTutor.Services;
using System.Diagnostics;

namespace PeriodicTableTutor.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ElementsController _elementsController;

    public HomeController(ILogger<HomeController> logger, ElementsController elementsController)
    {
        _elementsController = elementsController;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
