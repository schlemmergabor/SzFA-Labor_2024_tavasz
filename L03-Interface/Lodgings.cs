using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L03_Interface
{
    // öröklődik a Flat-ből, megvalósítja az IRent-et
    // mivel Flat megvalósította IRealEstate-et, így Ő is
    internal class Lodgings : Flat, IRent
    {
        // mező - foglalt hónapok száma
        int bookedMonths;

        // ctor
        // : base(...) -> ős ctorjának meghívása
        public Lodgings(double area, int roomsCount, int unitPrice)
            : base(area, roomsCount, unitPrice)
        {
            // ős ctor-ja után beállítjuk az osztály mezőit
            this.bookedMonths = 0;
        }

        // Proprety IRent-ből
        public bool IsBooked 
        {
            get
            {
                // foglalt - true - ha hónapokszáma > 0
                return this.bookedMonths > 0;
            }
        }
        // Metódus IRent-ből
        public bool Book(int months)
        {
            // nincs foglalva -> lehet
            if (!this.IsBooked) 
            {
                this.bookedMonths = months;
                return true;
            }

            // foglalva van -> nem sikerült foglalni
            return false;
        }

        // Metódus IRent-ből
        public int GetCost(int months)
        {
            // ha nincs benne még senki -> 0

            if (this.inhabitantsCount == 0) return 0;

            // 0-val nem osztunk, fenti Early Exit lekezeli
            // double cast -> mert az int/int = int -> tizedes vesztés
            // (int) cast -> visszatérési érték ez
            return (int)((double)this.TotalValue() / 240 / this.inhabitantsCount) * months;
        }

        // Flat absctract metódusa - override
        public override bool MoveIn(int newInhabitants)
        {
            // Early exit megoldásssal
            
            // nincs még lefoglalva -> nem lehet költözni
            if (!this.IsBooked) return false;

            // össz létszám -> eddigi bentlakók + új lakók
            int total = this.inhabitantsCount + newInhabitants;

            // többen vannak, mint 8 egy szobában -> nem lehet költözni
            if (total > this.roomsCount * 8) return false;

            // nincs mindenkinek legalább 2 nm -> nem lehet költözni
            if (this.area  < total * 2) return false;
            
            // lakószám növelés - az újakkal
            this.inhabitantsCount += newInhabitants;
            return true;
        }

        public override string? ToString()
        {
            // ős ToString() meghívása
            return base.ToString() + $" FH: {this.bookedMonths}";
        }
    }
}
