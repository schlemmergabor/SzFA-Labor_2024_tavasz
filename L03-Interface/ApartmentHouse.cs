using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace L03_Interface
{
    internal class ApartmentHouse
    {
        // mezők
        int dbLakas;
        int dbGarazs;

        int maxLakas;
        int maxGarazs;

        public static ApartmentHouse LoadFromFile(string fileName)
        {
            // beolvasom a file minden sorát
            string[] sorok = File.ReadAllLines(fileName);

            // kiszedem a file-ból a garázsok számát
            int garazs = 0;

            foreach (string s in sorok)
            {
                if (s.Split(" ")[0] == "Garazs") garazs++;
            }

            // lakások száma sorok száma - garázsok
            int lakas = sorok.Length - garazs;

            // új ah létrehozása
            ApartmentHouse ah = new ApartmentHouse(lakas, garazs);

            // mégegyszer végig járjuk a beolvasott sorokat
            for (int i = 0; i < sorok.Length; i++)
            {
                // fel daraboljuk a sorokat
                string[] sorDb = sorok[i].Split(" ");

                // nm ér double
                // System.Global... InvariantCulture -> lekezeli a . és a , -t is
                double nm = double.Parse(sorDb[1], System.Globalization.CultureInfo.InvariantCulture);

                // szobaszám
                int rc = int.Parse(sorDb[2]);


                switch (sorDb[0])
                {
                    case "Alberlet":
                        int up = int.Parse(sorDb[3]);

                        ah.Felvétel(new Lodgings(nm, rc, up));
                        break;

                    case "CsaladiApartman":
                        int up2 = int.Parse(sorDb[3]);
                        ah.Felvétel(new FamilyApartment(nm, rc, up2));
                        break;

                    case "Garazs":
                        // fütött-e a garázs?
                        bool f = sorDb[3] == "futott";
                        int up3 = int.Parse(sorDb[2]);
                        ah.Felvétel(new Garage(nm, up3, f));
                        break;

                }
            }
            return ah;
        }

        // Auto-Property
        // set csak private
        public IRealEstate[] Tarolo { get; private set; }

        // Property-k
        // visszaadja házban lakók számát
        public int InhabitantsCount
        {
            get
            {
                int db = 0;
                foreach (IRealEstate item in Tarolo)
                {
                    // ha az item as Flat eredménye null ref. akkor a ?? utáni értéket adja
                    // ha az item as Flat eredménye nem null, akkor a ? utáni értéket adja
                    if (item is Flat) db += (item as Flat)?.InhabitantsCount ?? 0;
                }
                return db;
            }
        }


        // ctor
        public ApartmentHouse(int maxLakas, int maxGarazs)
        {
            this.maxLakas = maxLakas;
            this.maxGarazs = maxGarazs;

            // kezdetben 0 a lakások és garázsok száma
            this.dbLakas = 0;
            this.dbGarazs = 0;

            // létrehozzuk a tömböt
            this.Tarolo = new IRealEstate[maxLakas + maxGarazs];
        }

        // IRealEstate a paraméter, mert mind Garage, mind Flat mehet bele
        public bool Felvétel(IRealEstate obj)
        {
            // ha a paraméter Flat
            if (obj is Flat)
            {
                // még lehet lakás
                if (this.dbLakas < this.maxLakas)
                {
                    Tarolo[this.dbLakas + this.dbGarazs] = obj;
                    this.dbLakas++;
                    return true;
                }
            }

            // ha a paraméter Garage
            if (obj is Garage)
            {
                // még lehet garázs
                if (this.dbGarazs < this.maxGarazs)
                {
                    Tarolo[this.dbLakas + this.dbGarazs] = obj;
                    this.dbGarazs++;
                    return true;
                }
            }

            // ha más nem lehet, vagy más obj-t adtunk át
            return false;
        }


        // használatban lévők össz értéke
        public int TotalValue()
        {
            int sum = 0;
            foreach (IRealEstate item in Tarolo)
            {
                // az item az Lakás
                // ha igen, akkor f példányt csinálunk belőle
                // ha lakók száma > 0
                if (item is Flat f && f.InhabitantsCount > 0)
                    sum += f.TotalValue();

                if (item is Garage g && g.IsBooked)
                    sum += g.TotalValue();
            }
            return sum;
        }
    }
}
