using PeriodicTableTutor.Models.Entities;

namespace PeriodicTableTutor.Interfaces
{
    public interface IElementsProvider
    {
        ICollection<ElementModel> GetElements();
    }
}
