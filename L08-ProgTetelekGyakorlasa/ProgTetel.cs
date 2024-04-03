using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L08_ProgTetelekGyakorlasa
{
    internal class ProgTetel
    {
        // Másolás programozási tétel - 37.oldal
        // https://users.nik.uni-obuda.hu/sergyan/Programozas1Jegyzet.pdf 
        // f - művelet itt most *2
        public static int[] TombDuplazo(int[] x)
        {
            int[] y = new int[x.Length];

            for (int i = 0; i < x.Length; i++)
            {
                y[i] = 2 * x[i];
            }

            return y;
        }

        // Kiválogatás programozási tétel - 39. oldal
        // https://users.nik.uni-obuda.hu/sergyan/Programozas1Jegyzet.pdf
        // mivel csak 1 visszatérési érték lehet
        // ez legyen most a tömb és 
        // ezért feltöltjük -1-el, ami mutatni fogja, hogy
        // onnantól csak nem páros elemek vannak benne
        public static int[] ParostKivalogat(int[] x)
        {
            int[] y = new int[x.Length];
            // -1 -el feltöltés, mert az int kezdőértéke 0
            // és ha ez nem lenne, akkor nem tudjuk, hogy 0 
            // az a kezdőérték vagy a leválogatás előtti tömbből jön-e
            for (int i = 0; i < y.Length; i++)
            {
                y[i] = -1;
            }

            int db = 0;

            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] % 2 == 0)
                {
                    db = db + 1;
                    // indexelés miatti korrekció a -1
                    y[db - 1] = x[i];
                }
            }

            return y;
        }
        // Kiválogatás programozási tétel ver 2.0
        // itt már referenciaként átadásra kerül a db érték
        // így amit módosítunk rajta az a metóduson kívül is
        // "végrahajtódik"
        public static int[] ParostKivalogat(int[] x, ref int db)
        {
            int[] y = new int[x.Length];

            db = 0;

            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] % 2 == 0)
                {
                    db = db + 1;
                    y[db - 1] = x[i];
                }
            }
            // y-t returnoljuk, de mivel a db-t refként adtuk át
            // így az itt végrehajtott módosítások is belekerülnek a db-be.
            return y;
        }

        // kiválogatás helyben programozási tétel - 41. oldal
        // https://users.nik.uni-obuda.hu/sergyan/Programozas1Jegyzet.pdf
        public static int ParostHelybenKivalogat(ref int[] x)
        {
            int db = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] % 2 == 0)
                {
                    db = db + 1;
                    x[db - 1] = x[i];
                }
            }
            return db;
        }

        // Szétválogatás programozási tétel - 44. oldal
        // https://users.nik.uni-obuda.hu/sergyan/Programozas1Jegyzet.pdf
        public static void SzamokatSzetValogat(int[] tomb,
            ref int[] paros, ref int[] paratlan,
            ref int db1, ref int db2)
        {
            paros = new int[tomb.Length];
            paratlan = new int[tomb.Length];
            db1 = 0;
            db2 = 0;

            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] % 2 == 0)
                {
                    db1++;
                    paros[db1 - 1] = tomb[i];
                }
                else
                {
                    db2++;
                    paratlan[db2 - 1] = tomb[i];
                }
            }

        }




    }
}
