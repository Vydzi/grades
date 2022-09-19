using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_grades
{
    public class Zak
    {
        public string Jmeno;
        public string Trida;
        public Dictionary<string, int> Znamky = new Dictionary<string, int>();

        public Zak()
        {
            foreach  (string vybranyPredmet in tridaData.jmenaPredmetu)
            {
                Znamky.Add(vybranyPredmet, 0);
            }
        }
        public void ZmenitZnamku(string zmenenyPredmet, int zmenaZnamka)
        {
            Znamky[zmenenyPredmet] = zmenaZnamka;
        }
    }
