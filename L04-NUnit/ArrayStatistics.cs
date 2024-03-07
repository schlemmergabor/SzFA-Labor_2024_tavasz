using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L04_NUnit
{
    // 2. feladat
    public class ArrayStatistics
    {
        // mező, belsőérték, adattag
        int[] tömb;

        // ctor
        public ArrayStatistics(int[] t)
        {
            this.tömb = t;
        }

        // összeg számítása
        public int Total()
        {
            // Sorozatszámítás programozási tétel - jegyzet - 23. oldal
            // https://users.nik.uni-obuda.hu/sergyan/Programozas1Jegyzet.pdf
            // érték0 -> feladattól függő kezdőérték (összegnél 0, szorzatnál 1)
            // (+) -> feladattól függő művelet -> most összeadás

            // tömbbel dolgozunk, figyelj, rá, hogy a jegyzetben i=1-től megy
            // nálunk 0-tól van a tömb indexelése így minden ami tömb balra shiftelődik
            // mérete - 1, indexe -1, stb.

            int érték = 0;
            // n: tömb mérete = tömb.Length
            // mivel az index is 0-tól (1 -1) indul, így itt is -1
            for (int i = 0; i <= tömb.Length - 1; i++)
            {
                érték = érték + this.tömb[i];
            }
            return érték;
        }

        public bool Contains(int number)
        {
            // Eldöntés programozási tétel - jegyzet - 25. oldal
            // https://users.nik.uni-obuda.hu/sergyan/Programozas1Jegyzet.pdf

            int i = 0;
            // figyelsz az indexre, figyelsz az n -re
            while ((i <= this.tömb.Length - 1) && !(this.tömb[i] == number))
            {
                i = i + 1;
            }
            bool van = i <= this.tömb.Length - 1;
            return van;
        }

        public bool Sorted()
        {
            // Növekvő rendezettség vizsgálata - jegyzet - 28. oldal
            // https://users.nik.uni-obuda.hu/sergyan/Programozas1Jegyzet.pdf

            int i = 0;
            while ((i <= (this.tömb.Length - 1) - 1) && (this.tömb[i] <= this.tömb[i + 1]))
            {
                i = i + 1;
            }
            bool rendezett = i > (this.tömb.Length - 1) - 1;
            return rendezett;
        }

        public int FirstGreater(int value)
        {
            // Lineáris keresés programozási tétel - jegyzet - 30. oldal
            // https://users.nik.uni-obuda.hu/sergyan/Programozas1Jegyzet.pdf

            int i = 0;

            while ((i <= (this.tömb.Length - 1)) && !(this.tömb[i] > value))
            {
                i = i + 1;
            }
            bool van = i <= (this.tömb.Length - 1);

            if (van) return i;
            return -1;

        }

        public int CountEvens()
        {
            // Megszámlálás programozási tétel - jegyzet - 33. oldal
            // https://users.nik.uni-obuda.hu/sergyan/Programozas1Jegyzet.pdf

            int db = 0;
            for (int i = 0; i <= (this.tömb.Length - 1); i++)
            {
                if (this.tömb[i] % 2 == 0)
                {
                    db = db + 1;
                }
            }
            return db;
        }

        // maxIndex -> MaxIndex -> Metódus neve
        public int MaxIndex()
        {
            // Maximumkiválasztás programozási tétel - jegyzet - 33. oldal
            // https://users.nik.uni-obuda.hu/sergyan/Programozas1Jegyzet.pdf

            // Figyelj rá, hogy nem max érték, hanem a max indexe
            // Úgy vesszük, hogy kezdetben a 0. index a legnagyobb
            int max = 0;

            // 1-es indextől nézzük
            for (int i = (2 - 1); i <= (tömb.Length - 1); i++)
            {
                // ha nagyobb, frissítjük az indexet !
                if (this.tömb[i] > this.tömb[max])
                {
                    max = i;
                }
            }

            return max;
        }

        public void Sort()
        {
            // Buborékrendezés (bubble sort) - jegyzet - 102. oldal
            // https://users.nik.uni-obuda.hu/sergyan/Programozas1Jegyzet.pdf
            // Példák: https://www.youtube.com/results?search_query=bubble+sort+visualization

            for (int i = (this.tömb.Length - 1); i >= (2 - 1); i--)
            {
                for (int j = (1 - 1); j <= (i - 1); j++)
                {
                    if (this.tömb[j] > this.tömb[j + 1])
                    {
                        int temp = this.tömb[j];
                        this.tömb[j] = this.tömb[j + 1];
                        this.tömb[j + 1] = temp;
                    }
                }
            }


        }
    }

}
