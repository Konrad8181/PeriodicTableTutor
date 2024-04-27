using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using PeriodicTableTutor.Enmus;
using PeriodicTableTutor.Models;
using PeriodicTableTutor.Services;
using System.Diagnostics;
using System.Globalization;

namespace PeriodicTableTutor.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ElementsController _elementsController;

    public List<ElementDescriptor> Descriptors { get; set; }

    private readonly IStringLocalizer<HomeController> _localizer;

    public HomeController(ILogger<HomeController> logger,
        ElementsController elementsController,
        IStringLocalizer<HomeController> localizer)
    {
        _elementsController = elementsController;
        _logger = logger;
        _localizer = localizer;
        Descriptors = [];
        CreateDescriptors();
    }

    public IActionResult SetLanguage(string language, string returnUrl)
    {
        var cultureInfo = new CultureInfo(language);
        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        return LocalRedirect(returnUrl);
    }

    public IActionResult Index()
    {
        return View(Descriptors);
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

    private void CreateDescriptors()
    {
        foreach (var item in Enum.GetValues(typeof(EElementType)).Cast<EElementType>().Select((type, i) => new { i, type }))
        {
            Descriptors.Add(new ElementDescriptor(item.type, item.i));
        }
    }
}
