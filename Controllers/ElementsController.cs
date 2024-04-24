using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeriodicTableTutor.Data;
using PeriodicTableTutor.Enmus;
using PeriodicTableTutor.Models.Entities;
using System.Globalization;
using System.Net;
using System.Text;

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
            DatabaseSanityCheck();
        }

        public IActionResult ElementsTable() => View(Elements);

        public IActionResult SpecificElements(string type) => View(GetElements(type).ToList());

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

        public void DownloadFile()
        {
            var client = new WebClient();
            var data = client.DownloadData("https://gist.githubusercontent.com/GoodmanSciences/c2dd862cd38f21b0ad36b8f96b4bf1ee/raw/1d92663004489a5b6926e944c1b3d9ec5c40900e/Periodic%2520Table%2520of%2520Elements.csv");
            var lines = Encoding.Default.GetString(data).Split('\n');
            var headers = lines[0].Split(',').ToList();
            foreach (var line in lines.Skip(1))
            {
                var attributes = line.Split(',');
                if (attributes.Length < 11)
                {
                    continue;
                }
                var shortName = attributes[headers.IndexOf("Symbol")];
                var latinName = attributes[headers.IndexOf("Element")];
                var atomicMass = attributes[headers.IndexOf("AtomicMass")];
                var neutrons = attributes[headers.IndexOf("NumberofNeutrons")];
                var protons = attributes[headers.IndexOf("NumberofProtons")];
                var electrons = attributes[headers.IndexOf("NumberofElectrons")];
                var phase = attributes[headers.IndexOf("Phase")];
                var type = attributes[headers.IndexOf("Type")];
                var density = attributes[headers.IndexOf("Density")];
                var year = attributes[headers.IndexOf("Year")];
                var discoverer = attributes[headers.IndexOf("Discoverer")];
                EElementType elementType = new();
                EElementPhase elementPhase = new();
                _ = int.TryParse(electrons, out int elementElectrons);
                _ = int.TryParse(protons, out int elementProtons);
                _ = int.TryParse(neutrons, out int elementNeutrons);
                _ = double.TryParse(atomicMass, NumberStyles.Float,
                    CultureInfo.InvariantCulture, out double elementAtomicMass);
                _ = double.TryParse(density, NumberStyles.Float,
                    CultureInfo.InvariantCulture, out double elementDensity);
                _ = int.TryParse(year, out int elementYear);
                if (Enum.TryParse(type.Replace(" ", ""), out EElementType eType))
                {
                    elementType = eType;
                }
                if (Enum.TryParse(phase, out EElementPhase ePhase))
                {
                    elementPhase = ePhase;
                }
                AddElement(CreateNewElement(shortName, latinName, latinName,
                    elementProtons, elementNeutrons, elementElectrons,
                    elementAtomicMass, elementDensity,
                    elementPhase, elementType,
                    elementYear, discoverer));
            }
        }

        private void DatabaseSanityCheck()
        {
            if (!Elements.Any())
            {
                DownloadFile();
            }
        }

        private ElementModel CreateNewElement(
            string shortName,
            string name,
            string latinName,
            int protons,
            int neutrons,
            int electrons,
            double atomicMass,
            double density,
            EElementPhase phase,
            EElementType type,
            int year,
            string discoverer)
        {
            return new ElementModel()
            {
                ShortName = shortName,
                Name = name,
                LatinName = latinName,
                AtomicMass = atomicMass,
                Year = year,
                Neutrons = neutrons,
                Protons = protons,
                Electrons = electrons,
                Density = density,
                Type = type,
                Phase = phase,
                MassNumber = neutrons + protons,
                Discoverer = discoverer
            };
        }

        public void AddElement(ElementModel element)
        {
            _dbContext.Elements.Add(element);
            _dbContext.SaveChanges();
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