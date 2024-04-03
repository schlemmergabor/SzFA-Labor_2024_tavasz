using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L08_ProgTetelekGyakorlasa
{
    internal class Kurzus
    {
        // mező, belső tömb
        Személy[] hallgatok;


        // ctor
        public Kurzus(int meret)
        {
            // kurzus max létszáma 24, afölött exception
            if (meret > 24) throw new MaxLetszamException();
            hallgatok = new Személy[meret];
        }

        public bool Felvétel(Személy sz)
        {
            for (int i = 0; i < hallgatok.Length; i++)
            {
                if (hallgatok[i]==null)
                {
                    hallgatok[i] = sz;
                    // sikerült a felvétel
                    return true;
                }
            }
            // tele volt, így nem sikerült a felvétel
            return false;
        }

        public bool Töröl(Személy sz)
        {
            for (int i = 0; i < hallgatok.Length; i++)
            {
                if (hallgatok[i]==sz)
                {
                    hallgatok[i] = null;
                    // lyukas lesz így a tömb, de nembaj
                    return true;
                }
            }
            return false;
        }

        public int GirlsNumber()
        {
            int num = 0;
            for (int i = 0; i < hallgatok.Length; i++)
            {
                if (hallgatok[i]?.Nem == false) num++;
            }
            return num;
        }

        public bool GeekCouple()
        {
          
            for (int i = 0; i < hallgatok.Length; i++)
            {
                for (int j = i; j < hallgatok.Length; j++)
                {
                    if (hallgatok[i]?.Nem != hallgatok[j]?.Nem && hallgatok[i]?.Progjegy == 5 && hallgatok[j]?.Progjegy == 5)
                        return true;
                }
            }
            return false;
        }

        public Személy[] ProProgrammers()
        {
            int num = 0;
            foreach (Személy item in hallgatok)
            {
                if (item?.Progjegy == 5) num++;
            }
            Személy[] result = new Személy[num];
            if (num>0)
            {
                
                int db = 0;
                for (int i = 0; i < hallgatok.Length; i++)
                {
                    if (hallgatok[i]?.Progjegy == 5)
                    { 
                        db++;
                    result[db - 1] = hallgatok[i];
                    }
                }
            }
            return result;
        }

        public void OrderbyGender()
        {
            // Szétválogatás programozási tétel az eredeti tömbben - 49. oldal
            // https://users.nik.uni-obuda.hu/sergyan/Programozas1Jegyzet.pdf

            int bal = 0; // index miatt -1
            int jobb = hallgatok.Length - 1; // index miatt -1
            Személy segéd = hallgatok[0]; // index miatt 0

            while (bal<jobb)
            {
                while ((bal < jobb) && !(hallgatok[jobb]?.Nem == false))
                    jobb--;
                if (bal<jobb)
                {
                    hallgatok[bal] = hallgatok[jobb];
                    bal++;
                }
                while ((bal<jobb) && (hallgatok[bal]?.Nem == false))
                    bal++;
                if (bal < jobb)
                {
                    hallgatok[jobb] = hallgatok[bal];
                    jobb--;
                }
            }
            hallgatok[bal] = segéd;
            // db ellenőrzés nem kell
            
        }


    }
}
