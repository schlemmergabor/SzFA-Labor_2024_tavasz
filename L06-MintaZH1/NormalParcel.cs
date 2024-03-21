using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L06_MintaZH1
{
    // public a tesztelések miatt, 
    // : Parcel, mert az őse a Parcel osztály
    public class NormalParcel : Parcel
    {
        // ctor
        // meghívjuk az őse base () ctorját a paraméterekkel
        // majd folytatjuk a metódus törzsében a futást
        public NormalParcel(int weight, string address) : base(weight, address)
        {

            // véletlenszámot generálunk
            Random rnd = new Random();
            int vSz = rnd.Next(3); // 0, 1, 2 között

            // int-ből Enum-á castoljuk
            this.ElhelyezesiMod = (Mod)vSz;
        }

        // ár frissítése
        public override double CalculatePrice(bool fromLocker)
        {
            int dij = 500 + this.Weight;
            if (fromLocker) dij -= 250;

            return dij;
            // itt megpróbálom ugyanezt egy sorban visszadni :) */
            // return 500 + this.Weight + (fromLocker ? -250 : 0);

        }
    }

}
