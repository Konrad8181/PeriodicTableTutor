﻿using PeriodicTableTutor.Interfaces;

namespace PeriodicTableTutor.Providers
{
    public class PeriodicTableDataProvider : IPeriodicTableDataProvider
    {
        private Dictionary<string, (int column, int row)> _periodicTablePositionsByShortName;

        public PeriodicTableDataProvider()
        {
            _periodicTablePositionsByShortName = [];
            InitializePositions();
        }

        /// <summary>
        /// Get element coordinates by short name
        /// </summary>
        /// <param name="shortName"></param>
        /// <returns>Column and row assigned for given element by its short name</returns>
        public (int column, int row) GetElementLocalizationByShortName(string shortName)
        {
            return _periodicTablePositionsByShortName.TryGetValue(shortName, out (int column, int row) value) ? value : default;
        }


        /// <summary>
        /// Assign elements positions dictionary
        /// </summary>
        private void InitializePositions()
        {
            _periodicTablePositionsByShortName = new Dictionary<string, (int column, int row)>()
                {
                { "H", (1, 1) },
                { "He", (18, 1) },

                { "Li", (1, 2) },
                { "Be", (2, 2) },
                { "B", (13, 2) },
                { "C", (14, 2) },
                { "N", (15, 2) },
                { "O", (16, 2) },
                { "F", (17, 2) },
                { "Ne", (18, 2) },

                { "Na", (1, 3) },
                { "Mg", (2, 3) },
                { "Al", (13, 3) },
                { "Si", (14, 3) },
                { "P", (15, 3) },
                { "S", (16, 3) },
                { "Cl", (17, 3) },
                { "Ar", (18, 3) },

                { "K", (1, 4) },
                { "Ca", (2, 4) },
                { "Sc", (3, 4) },
                { "Ti", (4, 4) },
                { "V", (5, 4) },
                { "Cr", (6, 4) },
                { "Mn", (7, 4) },
                { "Fe", (8, 4) },
                { "Co", (9, 4) },
                { "Ni", (10, 4) },
                { "Cu", (11, 4) },
                { "Zn", (12, 4) },
                { "Ga", (13, 4) },
                { "Ge", (14, 4) },
                { "As", (15, 4) },
                { "Se", (16, 4) },
                { "Br", (17, 4) },
                { "Kr", (18, 4) },

                { "Rb", (1, 5) },
                { "Sr", (2, 5) },
                { "Y", (3, 5) },
                { "Zr", (4, 5) },
                { "Nb", (5, 5) },
                { "Mo", (6, 5) },
                { "Tc", (7, 5) },
                { "Ru", (8, 5) },
                { "Rh", (9, 5) },
                { "Pd", (10, 5) },
                { "Ag", (11, 5) },
                { "Cd", (12, 5) },
                { "In", (13, 5) },
                { "Sn", (14, 5) },
                { "Sb", (15, 5) },
                { "Te", (16, 5) },
                { "I", (17, 5) },
                { "Xe", (18, 5) },

                { "Cs", (1, 6) },
                { "Ba", (2, 6) },
                { "La", (4, 9) },

                { "Hf", (4, 6) },
                { "Ta", (5, 6) },
                { "W", (6, 6) },
                { "Re", (7, 6) },
                { "Os", (8, 6) },
                { "Ir", (9, 6) },
                { "Pt", (10, 6) },
                { "Au", (11, 6) },
                { "Hg", (12, 6) },
                { "Tl", (13, 6) },
                { "Pb", (14, 6) },
                { "Bi", (15, 6) },
                { "Po", (16, 6) },
                { "At", (17, 6) },
                { "Rn", (18, 6) },

                { "Fr", (1, 7) },
                { "Ra", (2, 7) },
                { "Ac", (4, 10) },

                { "Rf", (4, 7) },
                { "Db", (5, 7) },
                { "Sg", (6, 7) },
                { "Bh", (7, 7) },
                { "Hs", (8, 7) },
                { "Mt", (9, 7) },
                { "Ds", (10, 7) },
                { "Rg", (11, 7) },
                { "Cn", (12, 7) },
                { "Nh", (13, 7) },
                { "Fl", (14, 7) },
                { "Mc", (15, 7) },
                { "Lv", (16, 7) },
                { "Ts", (17, 7) },
                { "Og", (18, 7) },


                { "Ce", (5, 9) },
                { "Pr", (6, 9) },
                { "Nd", (7, 9) },
                { "Pm", (8, 9) },
                { "Sm", (9, 9) },
                { "Eu", (10, 9) },
                { "Gd", (11, 9) },
                { "Tb", (12, 9) },
                { "Dy", (13, 9) },
                { "Ho", (14, 9) },
                { "Er", (15, 9) },
                { "Tm", (16, 9) },
                { "Yb", (17, 9) },
                { "Lu", (18, 9) },


                { "Th", (5, 10) },
                { "Pa", (6, 10) },
                { "U", (7, 10) },
                { "Np", (8, 10) },
                { "Pu", (9, 10) },
                { "Am", (10, 10) },
                { "Cm", (11, 10) },
                { "Bk", (12, 10) },
                { "Cf", (13, 10) },
                { "Es", (14, 10) },
                { "Fm", (15, 10) },
                { "Md", (16, 10) },
                { "No", (17, 10) },
                { "Lr", (18, 10) }
            };
        }
    }
}
