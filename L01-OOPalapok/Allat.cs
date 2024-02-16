using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01_OOPalapok
{
    internal class Allat
    {
        // Adattagok, belső változók, mezők
        string név; // alapértéke null
        bool nem; // alapértéke false
        int súly; // alapértéke 0
        Faj faj; // alapértéke a 0. Faj Enum értéke (most Kutya)

        // Property-k
        // kézzel
        public string Név
        {
            // belső mező lekérdezése
            get { return this.név; }
            // beállítani nem kell, így ez most komment
            // set { this.név = value; }
        }

        // VS-ből legenerált Property-k
        public bool Nem { get => this.nem; }
        public int Súly { get => súly; }
        internal Faj Faj { get => faj; }


        // Konstruktorok - ctor
        public Allat(string név, bool nem, int súly, Faj faj)
        {
            this.név = név;
            this.nem = nem;
            this.súly = súly;
            this.faj = faj;
        }


        // Metódusok
        // Ennek az osztálynak nincs metódusa
    }

}
