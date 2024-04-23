using PeriodicTableTutor.Enmus;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace PeriodicTableTutor.Models.Entities
{
    public class ElementModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(2)]
        public string ShortName { get; set; }

        [NotMapped]
        public string Name { get; set; }

        [Required]
        public string LatinName { get; set; }

        [Required]
        [MaxLength(3)]
        public int Protons { get; set; }

        [Required]
        [MaxLength(3)]
        public int Neutrons { get; set; }

        [Required]
        [MaxLength(3)]
        public int Electrons { get; set; }

        [Required]
        public double AtomicMass { get; set; }

        [Required]
        public int MassNumber { get; set; }

        [Required]
        public double Density { get; set; }

        [Required]
        public EElementPhase Phase { get; set; }

        [Required]
        [MaxLength(24)]
        public EElementType Type { get; set; }

        public int Year { get; set; }

        public string Discoverer { get; set; }

        [NotMapped]
        public string TypeDescription => ToSentenceCase(Type.ToString());

        public string ToSentenceCase(string str) => Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLower(m.Value[1]));
    }
}