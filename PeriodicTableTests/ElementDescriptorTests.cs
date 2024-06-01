using PeriodicTableTutor.Enmus;
using PeriodicTableTutor.Models;

namespace PeriodicTableTests
{
    public class ElementDescriptorTests
    {
        [Xunit.Theory]
        [Xunit.InlineData(EElementType.Actinide, "AC")]
        [Xunit.InlineData(EElementType.AlkaliMetal, "AM")]
        [Xunit.InlineData(EElementType.AlkalineEarthMetal, "AE")]
        [Xunit.InlineData(EElementType.Metalloid, "MT")]
        [Xunit.InlineData(EElementType.Metal, "ME")]
        [Xunit.InlineData(EElementType.Nonmetal, "NO")]
        [Xunit.InlineData(EElementType.Halogen, "HA")]
        [Xunit.InlineData(EElementType.NobleGas, "NG")]
        [Xunit.InlineData(EElementType.Transactinide, "TA")]
        [Xunit.InlineData(EElementType.TransitionMetal, "TM")]
        [Xunit.InlineData(EElementType.Lanthanide, "LN")]
        public void Test1(EElementType type, string expectedShortName)
        {
            var descriptor = new ElementDescriptor(type, 0);
            Xunit.Assert.Equal(expectedShortName, descriptor.ShortName);
        }
    }
}