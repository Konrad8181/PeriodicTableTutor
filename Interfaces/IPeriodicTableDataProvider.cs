namespace PeriodicTableTutor.Interfaces
{
    public interface IPeriodicTableDataProvider
    {
        (int column, int row) GetElementLocalizationByShortName(string shortName);
    }
}
