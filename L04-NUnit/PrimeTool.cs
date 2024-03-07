using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L04_NUnit
{
    // a tesztelés miatt az internal láthatóságot public-ra tesszük
    public class PrimeTool
    {
        // mező -> ebben tároljuk a számot amit tesztelünk majd
        int szam;

        // ctor
        public PrimeTool(int a)
        {
            this.szam = a;
        }

        // eldönti, hogy prím-e a szám
        public bool IsPrime()
        {
            // Prím teszt algoritmus - jegyzet - 28. oldal
            // https://users.nik.uni-obuda.hu/sergyan/Programozas1Jegyzet.pdf

            int i = 2;
            while ((i <= Math.Sqrt(this.szam)) && !(this.szam % i == 0))
            {
                i = i + 1; 
            }

            bool prim = i > Math.Sqrt(this.szam);
            return prim;

        }
    }

}
