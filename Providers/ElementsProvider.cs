using PeriodicTableTutor.Enmus;
using PeriodicTableTutor.Interfaces;
using PeriodicTableTutor.Models.Entities;
using System.Globalization;
using System.Net;
using System.Text;

namespace PeriodicTableTutor.Providers
{ 
    public class ElementsProvider : IElementsProvider
    {
        /// <summary>
        /// Elements data url
        /// </summary>
        private const string ElementsRepositoryFallbackAddress = "https://gist.githubusercontent.com/GoodmanSciences/c2dd862cd38f21b0ad36b8f96b4bf1ee/raw/1d92663004489a5b6926e944c1b3d9ec5c40900e/Periodic%2520Table%2520of%2520Elements.csv";

        private readonly ICollection<ElementModel> _elements = [];

        /// <summary>
        /// Get elements
        /// </summary>
        /// <returns>Elements read from remote database</returns>
        public ICollection<ElementModel> GetElements()
        {
            ReadBytesToElements(DownloadFile());
            return _elements;
        }

        /// <summary>
        /// Parse byte data elements
        /// </summary>
        /// <param name="data"></param>
        public void ReadBytesToElements(byte[] data)
        {
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
                _elements.Add(CreateNewElement(shortName, latinName, latinName,
                    elementProtons, elementNeutrons, elementElectrons,
                    elementAtomicMass, elementDensity,
                    elementPhase, elementType,
                    elementYear, discoverer));
            }
        }

        /// <summary>
        /// Downlad file from url
        /// </summary>
        /// <returns>Downloaded bytes data</returns>
        private static byte[] DownloadFile()
        {
            var client = new WebClient();
            return client.DownloadData(ElementsRepositoryFallbackAddress);
        }

        /// <summary>
        /// Create new element
        /// </summary>
        /// <param name="shortName"></param>
        /// <param name="name"></param>
        /// <param name="latinName"></param>
        /// <param name="protons"></param>
        /// <param name="neutrons"></param>
        /// <param name="electrons"></param>
        /// <param name="atomicMass"></param>
        /// <param name="density"></param>
        /// <param name="phase"></param>
        /// <param name="type"></param>
        /// <param name="year"></param>
        /// <param name="discoverer"></param>
        /// <returns>New element</returns>
        private static ElementModel CreateNewElement(
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

    }
}
