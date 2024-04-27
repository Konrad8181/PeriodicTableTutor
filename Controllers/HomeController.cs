using Microsoft.AspNetCore.Mvc;
using PeriodicTableTutor.Enmus;
using PeriodicTableTutor.Models;
using PeriodicTableTutor.Services;
using System.Diagnostics;

namespace PeriodicTableTutor.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ElementsController _elementsController;

    public List<ElementDescriptor> Descriptors { get; set; }

    public HomeController(ILogger<HomeController> logger, ElementsController elementsController)
    {
        _elementsController = elementsController;
        _logger = logger;
        Descriptors = [];
        CreateDescriptors();
    }

    public IActionResult Index()
    {
        return View(Descriptors);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Test(string SearchString)
    {
        ViewData["CurrentFilter"] = SearchString;
        return View(Descriptors);

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private void CreateDescriptors()
    {
        foreach (var item in Enum.GetValues(typeof(EElementType)).Cast<EElementType>().Select((type, i) => new { i, type }))
        {
            Descriptors.Add(new ElementDescriptor(item.type, item.i));
        }
    }
}
