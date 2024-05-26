using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using PeriodicTableTutor.Data;
using PeriodicTableTutor.Enmus;
using PeriodicTableTutor.Interfaces;
using PeriodicTableTutor.Models.Entities;

namespace PeriodicTableTutor.Services
{
    public class ElementsController : Controller
    {
        private readonly ElementModelContext _dbContext;

        private readonly IElementsProvider _elementsProvider;

        private readonly IPeriodicTableDataProvider _periodicTableDataProvider;

        public ICollection<ElementModel> Elements { get; private set; }

        public ElementsController(
            IPeriodicTableDataProvider periodicTableDataProvider,
            IElementsProvider elementsProvider,
            ElementModelContext elementModelContext,
            IStringLocalizer<ElementsController> localizer)
        {
            _periodicTableDataProvider = periodicTableDataProvider;
            _elementsProvider = elementsProvider;
            _dbContext = elementModelContext;
            Elements = new List<ElementModel>(_dbContext.Elements);
            _dbContext.SavedChanges += OnSavedChanges;
            _dbContext.SaveChangesFailed += OnSaveChangesFailed;
            DatabaseSanityCheck();
            AssignTablePositions();
        }

        public IActionResult ElementsTable() => View(Elements);

        public IActionResult SpecificElements(string type) => View(GetElements(type).ToList());

        public IActionResult SpecificElement(string name) => View(Elements.First(x => x.ShortName == name));

        public IActionResult SearchElements(string searchString)
        {
            return View(Elements.Where(x => x.LatinName.Contains(searchString, StringComparison.InvariantCultureIgnoreCase)).ToList());
        }

        private IEnumerable<ElementModel> GetElements(string type)
        {
            if (Enum.TryParse(type, out EElementType elementType))
            {
                return Elements.Where(x => x.Type == elementType);
            }
            else
            {
                return Elements;
            }
        }

        private void DatabaseSanityCheck()
        {
            if (Elements.Count == 0)
            {
                _dbContext.Elements.AddRange(_elementsProvider.GetElements());
                _dbContext.SaveChanges();
            }
        }

        private void AssignTablePositions()
        {
            foreach (var element in Elements)
            {
                var (column, row) = _periodicTableDataProvider.GetElementLocalizationByShortName(element.ShortName);
                element.Column = column;
                element.Row = row;
            }
        }


        private void OnSaveChangesFailed(object? sender, SaveChangesFailedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnSavedChanges(object? sender, SavedChangesEventArgs e)
        {
            Elements = new List<ElementModel>(_dbContext.Elements);
        }
    }
}