namespace L09_TrainingCosts
{
    // Ez az osztály nem kapcsolódik szorosan a feladathoz
    // hanem inkább a feladatok megoldásához szükséges
    // hátteret, elméletet, technikát akarja bemutatni

    internal class Program
    {

        // Metódus, ami eldönti a paraméterül kapott számról,
        // hogy páros-e
        // Ezt fogjuk Predicate<int> típusként használni
        // A Predicate<int> -nek mindig bool a visszatérési értéke 
        // paramétere pedig mindig int lesz
        // (Predicate<string> -nek bool a visszatérési értéke
        // és string a paramétere
        static bool PárosE(int szam)
        {
            // ha kettővel osztva a maradéka 0
            if (szam % 2 == 0) return true;
            return false;
        }

        // Összegzés prog.tétel, paramétere a tömb
        // és a predicate is paramétere
        // predicate -> delegate -> metódus referencia
        // átadjuk paraméterül azt a metódust amit majd használni akarunk
        // a feltétel teljesülés ellenőrzésére (lásd if -nél!!!)
        // Predicate<int> mindig bool a visszatérési értéke, a paramétere
        // pedig attól függ, hogy mit írtál a < > közé
        static int ÖsszegTétel(int[] t, Predicate<int> pre)
        {
            int összeg = 0;
            for (int i = 0; i < t.Length; i++)
            {
                // itt hívjuk meg, a paraméter metódust
                if (pre(t[i]))
                    összeg += t[i];
            }
            return összeg;
        }


        static void Main(string[] args)
        {
            // Kezdeti tömb, ezzel dolgozunk
            // ebben lévő ps számokat akarjuk összeadni
            int[] t = new int[] { 1, 2, 3, 4, 5, 6 };

            // Predicate példányt készítünk
            // itt állítjuk be, hogy melyik metódust hívjuk majd meg
            Predicate<int> ps = PárosE;

            // tesztelés
            int psÖsszeg = ÖsszegTétel(t, ps);
            Console.WriteLine(psÖsszeg);

            // működik úgy is, hogy nem kell Predicate<> példányt csinálni
            psÖsszeg = ÖsszegTétel(t, PárosE);
            Console.WriteLine(psÖsszeg);

            // nem is kell metódust készíteni neki, hanem
            // névtelen metódusokkal, lambdákkal is megtudjuk adni
            // figyelj arra, hogy bool legyen a visszatérési értéke

            psÖsszeg = ÖsszegTétel(t, a => a % 2 == 0);
            Console.WriteLine(psÖsszeg);

            // pár példa még a lambda kifejezésekre

            // 5-nél nagyobb és párosak öszege
            int psÖsszeg2 = ÖsszegTétel(t, b => b > 5 && b % 2 == 0);
            Console.WriteLine(psÖsszeg2); // 6

            // 3-al osztható vagy kettőnél kisebbek összege
            int csudaÖsszeg = ÖsszegTétel(t, x => x % 3 == 0 || x < 2);
            Console.WriteLine(csudaÖsszeg); // 10

        }
    }
}