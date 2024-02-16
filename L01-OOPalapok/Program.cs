namespace L01_OOPalapok
{
    enum Faj
    {
        Kutya, Panda, Nyúl
    }

    internal class Program
    {

        static Ketrec Betölt(string filename)
        {
            // ha nem létezik a fájl -> null
            if (!File.Exists(filename)) return null;

            // beolvassuk egy tömbbe
            string[] sorok = File.ReadAllLines(filename);

            // átmeneti ketrec -> sorszámnyi mérettel
            Ketrec temp = new Ketrec(sorok.Length);

            // sorok feldolgozása
            for (int i = 0; i < sorok.Length; i++)
            {
                // feldarabolás , mentén
                string[] db = sorok[i].Split(",");

                // hím / nőstény -> ből true/false
                bool nem = db[1] == "hím" ? true : false;

                int kg = int.Parse(db[2]);

                // Faj Enum-má Parse-olás
                Faj faj = (Faj)Enum.Parse(typeof(Faj), db[3]);

                Allat a = new Allat(db[0], nem, kg, faj);

                temp.Felvétel(a);

            }
            return temp;
        }

        static Ketrec[] BetöltMappából(string mappa)
        {
            // lekérjük a mappában a fájlik listáját
            string[] fileok = Directory.GetFiles(mappa);
            
            // átmeneti tömb
            Ketrec[] temp = new Ketrec[fileok.Length];

            // végig megyünk a fájlokon
            for (int i = 0; i < fileok.Length; i++)
            {
                // egyesével betöltjük őket
                temp[i] = Betölt(fileok[i]);
            }
            return temp;
        }

        static Ketrec Max(Ketrec[] ketrecek, Faj f)
        {
            // maximum tétel -> lásd jegyzet !!!
            // feltételezzük, hogy a 0. indexű kezdetben a legnagyobb
            int maxIndex = 0; 

            // végig nézzük a ketreceket
            for (int i = 1; i < ketrecek.Length; i++)
            {
                // ha nagyobb, mint az eddigi index
                if (ketrecek[i].FajDb(f) > ketrecek[maxIndex].FajDb(f))
                    
                    // akkor maxIndex elmentése
                    maxIndex = i;
            }

            return ketrecek[maxIndex];
        }
        static void Main(string[] args)
        {
            // tesztelés, ketrecek készítése
            Ketrec[] kk = new Ketrec[4];
            for (int i = 0; i < kk.Length; i++)
            {
                kk[i] = new Ketrec((i+1)*3);

            }

            // Ketrecek feltöltése állatokkal
            kk[0].Felvétel(new Allat("Kutyi", true, 10, Faj.Kutya));
            kk[0].Felvétel(new Allat("Molli", false, 140, Faj.Panda));
            kk[0].Felvétel(new Allat("Tappancs", true, 11, Faj.Nyúl));
            kk[0].Felvétel(new Allat("Morzsi", false, 7, Faj.Kutya));

            kk[1].Felvétel(new Allat("Pandi", false, 189, Faj.Panda));
            kk[1].Felvétel(new Allat("Fehér", true, 7, Faj.Nyúl));
            kk[1].Felvétel(new Allat("Folti", true, 9, Faj.Kutya));

            kk[2].Felvétel(new Allat("Ugri", true, 10, Faj.Nyúl));
            kk[2].Felvétel(new Allat("Füles", false, 10, Faj.Nyúl));

            kk[3].Felvétel(new Allat("Dalmi", false, 7, Faj.Kutya));
            kk[3].Felvétel(new Allat("Bogáncs", true, 6, Faj.Kutya));
            kk[3].Felvétel(new Allat("Öreg", false, 6, Faj.Nyúl));
            kk[3].Felvétel(new Allat("Pötyi", true, 77, Faj.Panda));
            kk[3].Felvétel(new Allat("Kutyi", false, 4, Faj.Kutya));

            // 4. ketrec állatainak kiírása
            // ToString() hívása itt történik meg
            Console.WriteLine(kk[3]);


            // Legtöbb Kutya-t tartalmazó ketrec
            Ketrec sokKutyaKetrece = Max(kk, Faj.Kutya);

            // fileból betöltés tesztelése
            // ..\..\..\ azért kell mert a lefordított exe mappájából
            // három szülő mappába kell lépni és onnan a files mappa...
            Ketrec filebolKetrec1 = Betölt(@"..\..\..\files\ketrec1.txt");
            
            // mappából betöltés 
            Ketrec[] AllatKert = BetöltMappából(@"..\..\..\files");
            ;

        }
    }
}