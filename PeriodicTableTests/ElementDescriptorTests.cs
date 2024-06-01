using PeriodicTableTutor.Enmus;
using PeriodicTableTutor.Models;

namespace PeriodicTableTests
{
    public class ElementDescriptorTests
    {
        [Theory]
        [InlineData(EElementType.Actinide, "AC")]
        [InlineData(EElementType.AlkaliMetal, "AM")]
        [InlineData(EElementType.AlkalineEarthMetal, "AE")]
        [InlineData(EElementType.Metalloid, "MT")]
        [InlineData(EElementType.Metal, "ME")]
        [InlineData(EElementType.Nonmetal, "NO")]
        [InlineData(EElementType.Halogen, "HA")]
        [InlineData(EElementType.NobleGas, "NG")]
        [InlineData(EElementType.Transactinide, "TA")]
        [InlineData(EElementType.TransitionMetal, "TM")]
        [InlineData(EElementType.Lanthanide, "LN")]
        public void Test1(EElementType type, string expectedShortName)
        {
            var descriptor = new ElementDescriptor(type, 0);
            Assert.Equal(expectedShortName, descriptor.ShortName);
        }
    }
}