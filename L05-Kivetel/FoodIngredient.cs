using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L05_Kivetel
{
    public enum Egyseg
    {
        Liter, Kilogramm, Darab, Csomag
    }
    public class FoodIngredient
    {


        string nev;
        int mennyiseg;
        Egyseg egyseg;

        public FoodIngredient(string nev, int mennyiseg, Egyseg egyseg)
        {
            this.nev = nev;
            this.mennyiseg = mennyiseg;
            this.egyseg = egyseg;
        }

        public override string? ToString()
        {
            return $"{this.nev} " +
                $"- {this.mennyiseg} " +
                $"- {this.egyseg}";
        }
    }
}
