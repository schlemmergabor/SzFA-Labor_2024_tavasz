using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L11_Halmazok
{
    public class SetOfInts
    {
        // változó, mező
        // ebben fogjuk tárolni a rendezett, nem ismétlődő számokat
        int[] tömb;

        public SetOfInts(int[] tömb)
        {
            // rendezettség vizsgálata -> ha nem Exc.
            if (!RendezettE(tömb))
                throw new ArgumentException("Nem redezett!");

            // egyediség vizsgálata -> ha nem Exc.
            if (!EgyediE(tömb))
                throw new ArgumentException("Nem egyedi!");

            this.tömb = tömb;
        }

        // private, hogy kívülről ne lehessen elérni
        // Rendezettség vizsgálata
        // használhatod a jegyzetbeli algoritmust vagy akárt ezt

        private bool RendezettE(int[] t)
        {
            // EarlyExit-el

            for (int i = 0; i < t.Length - 1; i++)
            {
                // ha az i. elem nagyobb, mint az i+1 (következő) elem
                // akkor biztos, hogy nem rendezett -> false
                if (t[i].CompareTo(t[i + 1]) > 0) return false;
            }
            // jó sorrendben van minden -> true
            return true;
        }

        // Egyenlőség (egyediséghez) vizsgálata
        // ctor-ban először rendezettség, utána ezt vizsgáljuk
        // azaz feltételezhetjük, hogy már rendezett a tömb
        private bool EgyediE(int[] t)
        {
            // Early Exit-el
            for (int i = 0; i < t.Length - 1; i++)
            {
                // ha i == i+1 , akkor nem egyedi -> false
                if (t[i].Equals(t[i + 1])) return false;
            }
            // minden elem egyedi -> true
            return true;
        }

        // Equals metódus (Object ősosztálytól kapja) felülírása
        // Eldönti a .Equals() segítségével, hogy két objektum megegyezik-e

        // Két halmaz akkor egyezik meg, ha minden eleme megegyezik
        // (és egyedi és rendezett)
        public override bool Equals(object? obj)
        {
            // ha nem SetOfInts-ekkel hasonlítjuk össze -> nem egyezhetmeg
            if (!(obj is SetOfInts)) return false;

            // obj átcastolása, hogy a temp.tömb -öt elérjük
            // (object ugyanis nem rendelkezik tömb mezőval/adattaggal)
            SetOfInts temp = (SetOfInts)obj;

            // hossz egyezés ellenörzés
            // ha a hosszuk nem egyezik meg -> false
            // itt két int Equals-a fut le
            if (!(this.tömb.Length.Equals(temp.tömb.Length)))
                return false;

            // A két halmaz tömbjének indexenkénti ellenőrzése
            for (int i = 0; i < this.tömb.Length; i++)
            {
                // ha nem egyeznek meg -> nem ugyanaz -> false
                if (!(this.tömb[i].Equals(temp.tömb[i])))
                    return false;
            }
            // megegyeztek
            return true;
        }

        // Bináris keresés - lehessen egy számot keresni
        // adjuk vissza a megtalált szám indexét
        // ügyeljünk arra, ha nincs benne -1-et adjunk vissza!
        // Algoritmusban az előadás ppt-t használd!
        public int BinKeresés(int keresett)
        {
            int bal = 0;
            int jobb = this.tömb.Length - 1;
            int center = (bal + jobb) / 2;

            while ((bal <= jobb) && !tömb[center].Equals(keresett))
            {
                if (tömb[center].CompareTo(keresett) > 0) jobb = center - 1;

                else bal = center + 1;

                center = (bal + jobb) / 2;
            }
            // center indexen van a keresett elem!
            if (bal <= jobb) return center;

            // nincs benne
            return -1;
        }

        // Részhalmaza-e?
        // Algoritmust lásd a PPT-ben
        public bool Subset(SetOfInts other)
        {
            // az algoritmus könnyebb kódolása érdekében
            // megcsinálom a segédváltozókat ugyanolyan névvel
            // mint, ahogy a PPT-ben van.
            int i = 0;
            int j = 0;

            int m = this.tömb.Length - 1;
            int n = other.tömb.Length - 1;
            int[] a = this.tömb;
            int[] b = other.tömb;

            while ((i <= m) && (j <= n) && (a[i].CompareTo(b[j]) > -1))
            {
                if (a[i] == b[j]) i++;
                j++;
            }
            return i > m;
        }

        // két halmaz metszetét előállító metódus
        // Algoritmust lásd PPT
        public SetOfInts Intersection(SetOfInts other)
        {
            // készítek egy tömböt, ami a "kisebb" halmaz méretével egyezik meg
            int[] b =
                new int[this.tömb.Length <= other.tömb.Length ? this.tömb.Length : other.tömb.Length];

            // algoritmus
            int i = 0;
            int j = 0;
            int db = 0;

            int m1 = this.tömb.Length - 1;
            int m2 = other.tömb.Length - 1;
            while ((i <= m1) && (j <= m2))
            {
                if (this.tömb[i] < other.tömb[j]) i++;
                else if (this.tömb[i] > other.tömb[j]) j++;

                else
                {
                    b[db++] = this.tömb[i];
                    i++;
                    j++;
                }
            }

            // levágjuk a b tömböt db-nyi int-re
            // e nélkül kellene a b mellett a db-t is visszaadni
            Array.Resize(ref b, db);

            // ha nem használható az Array.Resize, akkor készíts egy külön metódust
            // pl Levág(ref tömb, int db) néven és használd azt
            // lásd lejjebb
            // Levág(ref b, db);
            return new SetOfInts(b);
        }

        // ha nem lehet használni Array.Resize-t, akkor
        // ezt a metódust készítjük el
        private void Levág(ref int[] t, int db)
        {
            // létrehoz egy tömböt db-nyi mérettel
            int[] result = new int[db];

            // átmásolja az értékeket
            for (int i = 0; i < db; i++)
            {
                result[i] = t[i];
            }

            // átállítja a tömbre mutató ref-et
            t = result;
        }

        // Unio
        // Algoritmust lásd PPT-ben!
        public SetOfInts Union(SetOfInts other)
        {
            // tömb méretei
            int m1 = this.tömb.Length;
            int m2 = other.tömb.Length;

            // a1[m1] -re kell a +végtelen
            // így csinálok egy újabb tömböt, ami 1-el nagyobb
            int[] a1 = new int[this.tömb.Length + 1];
            
            // átmásolom az értékeket
            for (int ii = 0; ii < this.tömb.Length; ii++)
            {
                a1[ii] = this.tömb[ii];
            }
            // a1[m1]-re mehet a +végtelen
            a1[m1] = int.MaxValue;

            // ugyanezeket megcsinálom a2 -re is
            int[] a2 = new int[other.tömb.Length + 1];

            for (int jj = 0; jj < other.tömb.Length; jj++)
            {
                a2[jj] = other.tömb[jj];
            }
            a2[other.tömb.Length ] = int.MaxValue;

            // eu lesz az eredemény tömb
            int[] b = new int[m1 + m2];

            // "hasznos" elemek száma
            int db = 0;

            int i = 0;
            int j = 0;
            while ((i < m1) || j < m2)
            {
                // db++; -> helyett a b[db++] -t használjuk!
                if (a1[i] < a2[j])
                {
                    b[db++] = a1[i];
                    i++;
                }
                else
                {
                    if (a1[i] > a2[j])
                    {
                        b[db++] = a2[j];
                        j++;
                    }
                    else
                    {
                        b[db++] = a1[i];
                        i++;
                        j++;
                    }
                }
            }
            // szokásos tömb méretre vágása
            Array.Resize(ref b, db);
            return new SetOfInts(b);
        }


    }
}
