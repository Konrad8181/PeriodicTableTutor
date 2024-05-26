using PeriodicTableTutor.Models.Entities;

namespace PeriodicTableTutor
{
    public interface IElementsProvider
    {
        ICollection<ElementModel> GetElements();
    }
}
