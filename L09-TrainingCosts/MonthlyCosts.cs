using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace L09_TrainingCosts
{
    public class MonthlyCosts
    {
        public TrainingCost[] TrainingCosts { get; set; }

        public static MonthlyCosts LoadFrom(string filename)
        {
            if (!File.Exists(filename)) throw new FileNotFoundException();

            MonthlyCosts result = new MonthlyCosts();
            result.TrainingCosts = new TrainingCost[FileLength(filename)];

            using (StreamReader sr = new StreamReader(filename))
            {
                int i = 0;
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    result.TrainingCosts[i] = TrainingCost.Parse(line);
                    ++i;
                }
            }

            return result;
        }

        private static int FileLength(string filename)
        {
            return File.ReadAllLines(filename).Length;
        }
        ////////////////////////////////////////////////////////////////////////////////
        //                                    //
        // Innen kezdődik a feladat megoldása //
        //                                    //

        // Teljes költés a hónapban
        public int TeljesKöltés()
        {
            int összeg = 0;
            foreach (TrainingCost item in TrainingCosts)
            {
                összeg += item?.Cost ?? 0;
            }
            return összeg;
        }

        // Teljes költés feltétellel, predikátummal
        public int TeljesKöltés(Predicate<TrainingCost> pre)
        {
            int összeg = 0;
            foreach (TrainingCost item in TrainingCosts)
            {
                if (pre(item))
                    összeg += item?.Cost ?? 0;
            }
            return összeg;
        }

        // Volt-e adott feltételnek megfelelő költés
        public bool VoltE(Predicate<TrainingCost> pre)
        {
            foreach (TrainingCost item in TrainingCosts)
            {
                if (pre(item)) return true;
            }
            return false;
        }

        // Minden megfelel-e egy feltételnek
        // Nézd meg mekkora fun, hogy csak 3 !-el több,
        // mint az előző feladat
        // persze máshogy is lenne rá pont!
        public bool MindenE(Predicate<TrainingCost> pre)
        {
            foreach (TrainingCost item in TrainingCosts)
            {
                if (!pre(item)) return !true;
            }
            return !false;
        }

        // Volt-e legalább K darab feltételnek megfelelő költés
        public bool VoltE(int k, Predicate<TrainingCost> pre)
        {
            // kezdeben 0 db pre-nek megfelelő költés van
            int db = 0;
            foreach (TrainingCost item in TrainingCosts)
            {
                // találtunk egy költést, akkor db++
                if (pre(item)) db++;

                // ha mág db==k -> true
                if (db == k) return true;
            }
            // nem volt db==k, azaz nem volt annyi
            return false;
        }

        // Melyik volt a k adik költés, ha volt ilyen
        public TrainingCost Melyik(int k, Predicate<TrainingCost> pre)
        {
            int db = 0;
            foreach (TrainingCost item in TrainingCosts)
            {
                if (pre(item)) db++;

                // ha megvan a k adik akkor azt az elemet adjuk vissza
                if (db == k) return item;
            }
            // nem volt k nyi, így null ref-et adunk vissza
            return null;
        }

        // hány db költés volt ami megfelelt a feltételnek
        public int DB(Predicate<TrainingCost> pre)
        {
            int db = 0;
            foreach (TrainingCost item in TrainingCosts)
            {
                if (pre(item)) db++;
            }
            return db;
        }

        // legnagyobb kiadással járó költés -> maxtétel
        public TrainingCost Legnagyobb()
        {
            if (TrainingCosts.Length == 0) throw new ZeroLengthArrayException();

            int maxIndex = 0;
            for (int i = 1; i < TrainingCosts.Length; i++)
            {
                if (TrainingCosts[i]?.Cost > TrainingCosts[maxIndex]?.Cost)
                {
                    maxIndex = i;
                }
            }
            return TrainingCosts[maxIndex];
        }

        // legnagyobb költések indexei
        public int[] Maxok()
        {
            // kezdetben akkora tömb, mint az összes cost
            // mert lehet, hogy mindegyik max értékű
            int[] result = new int[TrainingCosts.Length];
            // itt a result értéke végig [0,0,0,0,0]

            // a legnagyobb érték az első indexű lesz
            // a resultban 0-tól indexelve tesszük majd a
            // max-ok indexét
            result[0] = 0;

            // hány db max értékünk van?
            int db = 1; // 0. indexű a max érték

            for (int i = 1; i < TrainingCosts.Length; i++)
            {
                // ha az i. elem nagyobb, mint az eddigi max
                // result[0] eredménye int -> ezt adjuk át másik indexének
                if (TrainingCosts[i].Cost > TrainingCosts[result[0]].Cost)
                {
                    // ő lesz az új max, tehát megy a result elejére
                    result[0] = i;
                    // maxok db számát frissítjük
                    db = 1;
                }

                // ha nem nagyobb, viszont megegyezik az eddigi max-al
                // akkor egy újabb max-ot találunk az indexen
                else if (TrainingCosts[i].Cost == TrainingCosts[result[0]].Cost)
                {
                    // elmentjük a result megfelelő indexére az i-t
                    result[db] = i;
                    // növeljük a max-ok db számát
                    db++;
                }

                // ha kisebbet találtunk mint az eddigi max nem csinálunk semmit
            }

            // átméretezzük a result tömböt -> levágjuk a felesleges hátsó indexeket
            Array.Resize(ref result, db);

            // és így már egy olyan tömbbel térünk vissza amiben csak annyi elem van
            // ahány max érték van
            return result;
        }

        public TrainingCost LegnagyobbFeltétellel(Predicate<TrainingCost> pre)
        {
            // kezdeti legnagyobb érték - végtelen
            int maxErtek = int.MinValue;
            // kezdetben nincs maximum
            int maxIndex = -1;

            for (int i = 0; i < TrainingCosts.Length; i++)
            {
                // ha teljesíti a feltételt
                if (pre(TrainingCosts[i]))
                {
                    // találtunk új max értéket
                    if (TrainingCosts[i].Cost > maxErtek)
                    {
                        maxErtek = TrainingCosts[i].Cost;
                        maxIndex = i;
                    }
                }
            }

            // ha nem találtunk a feltételnek megfelelőt
            // vagy 0 volt a TrainingCosts.Length -> null
            if (maxIndex == -1) return null;

            return TrainingCosts[maxIndex];
        }

        public TrainingCost LegnagyobbSulyozassal()
        {
            // kezdeti legnagyobb érték - végtelen
            int maxErtek = int.MinValue;
            // kezdetben nincs maximum
            int maxIndex = -1;

            for (int i = 0; i < TrainingCosts.Length; i++)
            {
                // cost-ok súlyozása
                int cost = TrainingCosts[i].Cost;

                // ebben az esetben 2x-es osztó van
                if (TrainingCosts[i].Type == TrainingType.Cycling
                    || TrainingCosts[i].Type == TrainingType.Running)
                    cost /= 2;

                if (cost > maxErtek) maxIndex = i;
            }

            // vagy 0 volt a TrainingCosts.Length -> null
            if (maxIndex == -1) return null;

            return TrainingCosts[maxIndex];
        }


        // adott feltételnek eleget tevők indexei
        public int[] FeltételesIndexek(Predicate<TrainingCost> pre)
        {
            // részletes leírást lásd a public int[] Maxok() metódusnál
            int[] result = new int[TrainingCosts.Length];

            // hány db feltételnek eleget tevő elem van
            int db = 0;

            for (int i = 0; i < TrainingCosts.Length; i++)
            {
                if (pre(TrainingCosts[i]))
                {
                    result[db++] = i;
                }
            }

            Array.Resize(ref result, db);
            return result;
        }

        // adott feltételnek eleget tevők minden adata 
        // ugyanaz, mint előbb csak a visszatérési érték más
        public TrainingCost[] FeltételesElemek(Predicate<TrainingCost> pre)
        {
            // részletes leírást lásd a public int[] Maxok() metódusnál
            TrainingCost[] result = new TrainingCost[TrainingCosts.Length];

            // hány db feltételnek eleget tevő elem van
            int db = 0;

            for (int i = 0; i < TrainingCosts.Length; i++)
            {
                if (pre(TrainingCosts[i]))
                {
                    result[db++] = TrainingCosts[i];
                }
            }

            Array.Resize(ref result, db);
            return result;
        }

        // adott feltételt teljesítőket előre helyező metódus
        // Szétválogat helyben prog.tétel
        public void Rendez(Predicate<TrainingCost> pre)
        {
            int bal = 0;
            int jobb = TrainingCosts.Length - 1;

            TrainingCost segéd = TrainingCosts[0];

            while (bal < jobb)
            {
                while ((bal < jobb) && !pre(TrainingCosts[jobb])) jobb--;

                if (bal < jobb)
                {
                    TrainingCosts[bal] = TrainingCosts[jobb];
                    bal++;

                    while ((bal < jobb) && pre(TrainingCosts[jobb])) bal++;
                    if (bal < jobb)
                    {
                        TrainingCosts[jobb] = TrainingCosts[bal];
                        jobb--;
                    }
                }
            }
            TrainingCosts[bal] = segéd;
        }

    }
}
