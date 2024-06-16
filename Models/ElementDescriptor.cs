using PeriodicTableTutor.Enmus;
using PeriodicTableTutor.Extensions;

namespace PeriodicTableTutor.Models
{
    /// <summary>
    /// Element descriptor definition
    /// </summary>
    public struct ElementDescriptor
    {
        public EElementType Type { get; set; }

        public string Description { get; set; }

        public string ShortName { get; set; }

        public int Index { get; set; }

        public ElementDescriptor(EElementType type, int index)
        {
            Type = type;
            Description = type.ToString().ToSentenceCase();
            ShortName = GetShortName();
            Index = index;
        }

        /// <summary>
        /// Creates short name by Type
        /// </summary>
        /// <returns></returns>
        private readonly string GetShortName()
        {
            var type = Type.ToString();
            if (type.Length >= 2)
            {
                var result = string.Concat(type.Where(c => c >= 'A' && c <= 'Z'));
                if (result.Length == 1)
                {
                    result += type[new Random(420).Next(1, type.Length - 1)];
                }
                if (result.Length > 2)
                {
                    result = result[..2];
                }
                return result.ToUpperInvariant();
            }
            return "";
        }
    }
}
