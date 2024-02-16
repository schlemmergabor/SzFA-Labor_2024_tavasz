using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01_OOPalapok
{
    internal class Ketrec
    {
        // mezők
        // belső tömb, ebben tároljuk majd az állatokat
        // tömb definiálása
        Allat[] allatok;

        // éppen aktuális állatok száma
        int allatokSzama = 0;

        // feladatban korlátozás az állatok számára
        int maxAllat = 10;


        public Ketrec(int meret)
        {
            // nem engedjük maxAllat méreténél nagyobb ketrec-et
            if (meret > maxAllat) meret = maxAllat;

            // tömb létrehozása
            allatok = new Allat[meret];

            // utána "húzzuk" a belső változót, hogy "szép" legyen
            // azaz megegyezik a maxAllat a kapacitással
            maxAllat = meret;
        }

        public bool Felvétel(Allat a)
        {
            // Early Exit programozási technika
            // -> Metódusból, Ciklusból, stb. a kód elején
            // kiugrunk a "nem kedvező" feltételek esetén
            // majd utána a "kedvező" esetnek megfelelően
            // folytatjuk a kódolást

            // kedvezőtlen eset -> tele van a ketrec
            // tehát ez lesz most az Early Exit
            // visszajelezzük, hogy nem volt sikeres a felvétel (false)
            if (allatokSzama == allatok.Length) return false;

            // ide csak akkor jut a kód, ha nem volt EE
            // új indexre elhelyezzük az állatot
            allatok[allatokSzama] = a;

            // megnöveljük az állatok számát
            allatokSzama++;

            // jelezzük a felvétel sikerességét
            return true;
        }

        public bool Töröl(Allat a)
        {
            // az állatokat tároló tömb úgy néz ki, hogy
            // a tömb elején (kisebb indexeken) vannak
            // az állatok, majd utána vannak az üres részek
            // amik a tömb esetében null referenciák

            // végig nézzük a tömböt, addig amíg van benen állat
            for (int i = 0; i < allatokSzama; i++)
            {
                // most nincs Early Exit
                // ha a ciklus az allatok.Length-ig menne, akkor
                // lehetnének null ref. elemek, így akkor kellene
                // Early Exit és akkor ez a kód lenne:

                // A tömb bejárása során eljutottunk a null ref-ig
                // így eddig nem találtuk meg, utána se lehet
                // if (allatok[i] == null) return false;


                if (allatok[i].Név == a.Név)
                {
                    // megvan az állat -> i. -> őt kell kitörölni
                    // a tömb végéről az i.-be pakoljuk az állatot
                    allatok[i] = allatok[allatokSzama - 1];

                    // a tömb végét töröljük -> null
                    allatok[allatokSzama - 1] = null;

                    allatokSzama--;
                    return true;
                }
            }
            // Ha tele van a tömb és nem találtuk meg, akkor fog
            // ez a kódrészlet lefutni...
            return false;
        }

        public int FajDb(Faj f)
        {
            // megszámlálás tétel -> lásd jegyzet !!!
            // adott tulajdonsági elemek száma
            int db = 0;

            // a tömb minden elemét megnézzük
            for (int i = 0; i < allatokSzama; i++)
            {
                // ha a faj megegyezik -> db ++
                if (allatok[i].Faj == f) db++;
            }

            return db;

            // Early Exit technikával a kód az alábbi lenne:
            // for (int i = 0; i < allatok.Length; i++)
            // {
            //    // itt van az Early Exit
            //    if (allatok[i] == null) return db;
            //    if (allatok[i].Faj == f) db++;
            // }
            // return db;
        }

        public bool VanE(Faj f, bool nem)
        {
            // eldöntés tétel -> lásd jegyzet

            for (int i = 0; i < allatokSzama; i++)
            {
                // Early Exit
                // első egyezésnél return true;
                if (allatok[i].Faj == f
                    && allatok[i].Nem == nem) return true;
            }
            // végig jártuk a tömb azon részét ahol vannak állatok
            // de nem találtunk egyezést
            return false;
        }

        public Allat[] AdottFajuAllatok(Faj f)
        {
            // ennyi db adott fajú állat van
            int db = FajDb(f); 

            // nincs ilyen állat -> null ref. vissza
            if (db == 0) return null;

            // átmeneti tömb
            Allat[] temp = new Allat[db];
            // temp melyik indexébe kerül az állat
            int index = 0;

            for (int i = 0; i < allatokSzama; i++)
            {
                if (allatok[i].Faj == f)
                {
                    // temp jó indexébe & index léptetése
                    temp[index] = allatok[i];
                    index++;
                }
            }

            return temp;

        }

        public double Atlag(Faj f)
        {
            // !!! Figyelj a 0-val osztásra !!!

            // db -> lásd AdottFajuAllatok(f)
            int db = FajDb(f);
            if (db == 0) return 0.0;

            // kigyűjtjük egy tömbbe
            Allat[] temp = AdottFajuAllatok(f);

            // összegváltozó
            int sum = 0;
            
            // kigyűjtött tömböt járjuk végig
            for (int i = 0; i < temp.Length; i++)
            {
                sum += temp[i].Súly;
            }

            return (double)sum / db;
        }

        public bool ParE()
        {
            // végig megyek a tömbön ameddig állatokat tartalmaz
            // elég 1-től menni, mert ha 1 állat van benne, akkor 
            // nem lehet "párja"
            for (int i = 1; i < allatokSzama; i++)
            {
                // megnézem az előző állatokat, hogy
                // ellentétes nemű, de ugyanaz a faj
             
                // a mostani állatom amit nézek -> allatok[i]
                for (int j = 0; j < i; j++)
                {
                    // előző állatok -> allatok[j] -> j < i !

                    if (allatok[i].Faj == allatok[j].Faj
                        && allatok[i].Nem != allatok[j].Nem)

                        // azaz az előzőekben volt ilyen állat
                        return true; 
                }
            }
            // nem volt ilyen állat
            return false; 
        }

        // az osztály ToString() metódusának felülírása
        // ez jelenik meg, ha cw-be teszed az objektumot
        // Object ősosztálytól öröklődik -> ezért az override
        public override string? ToString()
        {
            string temp = "A ketrec tartalma: \n";

            // végig járjuk az állatokat
            for (int i = 0; i < allatokSzama; i++)
            {
                // hozzáfűzzük a temp végére az adatokat
                temp += $"{allatok[i].Név} - {allatok[i].Faj} - {allatok[i].Súly} - {(allatok[i].Nem ? "hím" : "nőstény")}\n";
            }

            return temp;
        }
    }

}
