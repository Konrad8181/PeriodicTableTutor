using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeriodicTableTutor.Data;
using PeriodicTableTutor.Models;

namespace PeriodicTableTutor.Services
{
    public class ElementsController : Controller
    {
        private readonly ElementModelContext _dbContext;

        public ICollection<ElementModel> Elements { get; private set; }

        public ElementsController(ElementModelContext elementModelContext)
        {
            _dbContext = elementModelContext;
            Elements = new List<ElementModel>(_dbContext.Elements);
            _dbContext.SavedChanges += OnSavedChanges;
            _dbContext.SaveChangesFailed += OnSaveChangesFailed;
        }

        public void AddElement(ElementModel element)
        {
            _dbContext.Elements.Add(element);
            _dbContext.SaveChanges();
        }

        public IActionResult ElementsTable()
        {
            return View();
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