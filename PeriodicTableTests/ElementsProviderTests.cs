using Moq;
using PeriodicTableTutor.Enmus;
using PeriodicTableTutor.Providers;
using System.Text;

namespace PeriodicTableTests
{
    public class ElementsProviderTests
    {
        [Fact]
        public void ReadBytesToElements_ParsesDataCorrectly()
        {
            // Arrange
            var mockProvider = new Mock<ElementsProvider>
            {
                CallBase = true
            };
            var provider = mockProvider.Object;
            var data = Encoding.UTF8.GetBytes(MockData);

            // Act
            provider.ReadBytesToElements(data);
            var elements = provider.GetElements();

            // Assert
            var firstElement = elements.FirstOrDefault();
            Assert.NotNull(firstElement);
            Assert.Equal("H", firstElement.ShortName);
            Assert.Equal("Hydrogen", firstElement.Name);
            Assert.Equal(1, firstElement.Protons);
            Assert.Equal(0, firstElement.Neutrons);
            Assert.Equal(1, firstElement.Electrons);
            Assert.Equal(1.007, firstElement.AtomicMass);
            Assert.Equal(8.99E-05, firstElement.Density);
            Assert.Equal(EElementPhase.gas, firstElement.Phase);
            Assert.Equal(EElementType.Nonmetal, firstElement.Type);
            Assert.Equal("Cavendish", firstElement.Discoverer);
        }

        private const string MockData = @"AtomicNumber,Element,Symbol,AtomicMass,NumberofNeutrons,NumberofProtons,NumberofElectrons,Period,Group,Phase,Radioactive,Natural,Metal,Nonmetal,Metalloid,Type,AtomicRadius,Electronegativity,FirstIonization,Density,MeltingPoint,BoilingPoint,NumberOfIsotopes,Discoverer,Year,SpecificHeat,NumberofShells,NumberofValence
1,Hydrogen,H,1.007,0,1,1,1,1,gas,,yes,,yes,,Nonmetal,0.79,2.2,13.5984,8.99E-05,14.175,20.28,3,Cavendish,1766,14.304,1,1
";
    }
}
