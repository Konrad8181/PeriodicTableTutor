using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using PeriodicTableTutor.Enmus;
using PeriodicTableTutor.Interfaces;
using PeriodicTableTutor.Models;
using PeriodicTableTutor.Services;
using System.Diagnostics;
using System.Globalization;

namespace PeriodicTableTutor.Controllers;

public class HomeController : Controller
{
    private readonly IPeriodicTableDataProvider _periodicTableDataProvider;

    private readonly IStringLocalizer<HomeController> _localizer;

    private readonly ElementsController _elementsController;

    private readonly ILogger<HomeController> _logger;

    public List<ElementDescriptor> Descriptors { get; set; }

    public HomeController(
        IPeriodicTableDataProvider periodicTableDataProvider,
        ILogger<HomeController> logger,
        ElementsController elementsController,
        IStringLocalizer<HomeController> localizer)
    {
        _periodicTableDataProvider = periodicTableDataProvider;
        _elementsController = elementsController;
        _logger = logger;
        _localizer = localizer;
        Descriptors = [];
        CreateDescriptors();
    }

    /// <summary>
    /// Sets current language by language code
    /// </summary>
    /// <param name="language"></param>
    /// <param name="returnUrl"></param>
    /// <returns>Local redirection for given url</returns>
    public IActionResult SetLanguage(string language, string returnUrl)
    {
        var cultureInfo = new CultureInfo(language);
        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        return LocalRedirect(returnUrl);
    }

    /// <summary>
    /// Get home view
    /// </summary>
    /// <returns>View with descriptors</returns>
    public IActionResult Index()
    {
        return View(Descriptors);
    }

    /// <summary>
    /// DEfault error view
    /// </summary>
    /// <returns>Default error view</returns>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    /// <summary>
    /// Creates descriptors based on enum (EElementType)
    /// </summary>
    private void CreateDescriptors()
    {
        foreach (var item in Enum.GetValues(typeof(EElementType)).Cast<EElementType>().Select((type, i) => new { i, type }))
        {
            Descriptors.Add(new ElementDescriptor(item.type, item.i));
        }
    }
}
