using Microsoft.EntityFrameworkCore;

namespace PeriodicTableTutor.Models
{
    [Keyless]
    public class ElementModel
    {
        public string ShortName { get; set; }

        public string Name { get; set; }

        public string LatinName { get; set; }

        public int AtomicNumber { get; set; }

        public int MassNumber { get; set; }

        public string YearOfDiscover { get; set; }

        public int Protons { get; set; }

        public int Neutrons { get; set; }

        public double Density { get; set; }

        public string Type { get; set; }
    }
}