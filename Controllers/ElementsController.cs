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
            //Create elements list with database elements
            Elements = new List<ElementModel>(_dbContext.Elements);
            _dbContext.SavedChanges += OnSavedChanges;
            _dbContext.SaveChangesFailed += OnSaveChangesFailed;
            DatabaseSanityCheck();
            AssignTablePositions();
        }

        /// <summary>
        /// Get specific view
        /// </summary>
        /// <returns>View with all elements</returns>
        public IActionResult ElementsTable() => View(Elements);

        /// <summary>
        /// Get specific view
        /// </summary>
        /// <param name="type"></param>
        /// <returns>View with elements of given type</returns>
        public IActionResult SpecificElements(string type) => View(GetElements(type).ToList());

        /// <summary>
        /// Get specific view
        /// </summary>
        /// <param name="name"></param>
        /// <returns>View with single element by given name</returns>
        public IActionResult SpecificElement(string name) => View(Elements.First(x => x.ShortName == name));

        /// <summary>
        /// Get specific view
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns>View with found elements for given phrase</returns>
        public IActionResult SearchElements(string searchString)
        {
            ViewData["SearchString"] = searchString;
            return View(Elements.Where(x => x.LatinName.Contains(searchString, StringComparison.InvariantCultureIgnoreCase)).ToList());
        }

        /// <summary>
        /// Get elements with given type
        /// </summary>
        /// <param name="type"></param>
        /// <returns>List of elements of given type</returns>
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

        /// <summary>
        /// Checking if database elements exists. If empty sets them by elements provider
        /// </summary>
        private void DatabaseSanityCheck()
        {
            if (Elements.Count == 0)
            {
                _dbContext.Elements.AddRange(_elementsProvider.GetElements());
                _dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Assign elements table positions by IPeriodicTableDataProvider
        /// </summary>
        private void AssignTablePositions()
        {
            foreach (var element in Elements)
            {
                var (column, row) = _periodicTableDataProvider.GetElementLocalizationByShortName(element.ShortName);
                element.Column = column;
                element.Row = row;
            }
        }

        /// <summary>
        /// On database saving fail logic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void OnSaveChangesFailed(object? sender, SaveChangesFailedEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// On database saving success logic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSavedChanges(object? sender, SavedChangesEventArgs e)
        {
            Elements = new List<ElementModel>(_dbContext.Elements);
        }
    }
}