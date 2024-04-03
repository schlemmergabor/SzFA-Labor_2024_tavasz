namespace L08_ProgTetelekGyakorlasa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] N = new int[] { 1, 2, 3 };

            int[] dupla = ProgTetel.TombDuplazo(N);

            int[] parosak = ProgTetel.ParostKivalogat(N);

            int parosakSzama = 0;
            int[] parosak2 = ProgTetel.ParostKivalogat(N, ref parosakSzama);


            int pSz = ProgTetel.ParostHelybenKivalogat(ref N);

            int[] M = new int[] { 13, 6, 5, 8, 3, 22, 1 };

            int[] ps = new int[0];
            int[] ptln = new int[0];
            int psdb = 0;
            int ptlndb = 0;

            ProgTetel.SzamokatSzetValogat(M, ref ps, ref ptln, ref psdb, ref ptlndb);

            Kurzus prog = new Kurzus(24);
            Személy sz1 = new Személy("Minden Áron", true, 3);
            Személy sz2 = new Személy("Winch Eszter", false, 5);
            Személy sz3 = new Személy("Bármi Áron", true, 5);
            Személy sz4 = new Személy("Mekk Elek", true, 4);
            Személy sz5 = new Személy("Ameri Katalin", false, 4);

            prog.Felvétel(sz1);
            prog.Felvétel(sz2);
            prog.Felvétel(sz3);
            prog.Felvétel(sz4);
            prog.Felvétel(sz5);

            int girls = prog.GirlsNumber();
            bool couple = prog.GeekCouple();
            Személy[] proprogs = prog.ProProgrammers();
            prog.OrderbyGender();


            ;


        }
    }
}