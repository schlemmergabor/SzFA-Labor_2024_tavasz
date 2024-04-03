using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L08_ProgTetelekGyakorlasa
{
    internal class Személy
    {
        // mezők
        string nev;
        bool nem;
        int progjegy;

        // ctor
        public Személy(string nev, bool nem, int progjegy)
        {
            this.nev = nev;
            this.nem = nem;
            this.progjegy = progjegy;
        }
        
        // Propertyk, kívülről csak get
        public string Nev { get => nev;  }
        public bool Nem { get => nem;  }
        public int Progjegy { get => progjegy;  }


    }
}
