namespace PeriodicTableTutor.Models
{
    public class ElementModel
    { 
        public string ShortName { get; init; }
        
        public string Name { get; init; }
        
        public string LatinName { get; init; }

        public int AtomicNumber { get; init; }

        public int MassNumber { get; init; }
        
        public string YearOfDiscover { get; init; }
        
        public int Protons { get; init; }
        
        public int Neutrons { get; init; }
        
        public double Density { get; init; }
        
        public string Type { get; init; }

        public ElementModel(string shortName, string name, string latinName, int atomicNumber, int massNumber,
            string yearOfDiscover, double density, string type)
        {
            ShortName = shortName;
            Name = name;
            LatinName = latinName;
            AtomicNumber = atomicNumber;
            MassNumber = massNumber;
            YearOfDiscover = yearOfDiscover;
            Protons = atomicNumber; 
            Neutrons = MassNumber - Protons;
            Density = density;
            Type = type;
        } 

        public ElementModel()
        {
            
        }    
    }
}