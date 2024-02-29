using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L03_Interface
{
    // Flat az őse -> ezért a
    // IRealEstate-et is megvalósítja
    internal class FamilyApartment : Flat
    {
        // mező
        int childrenCount;

        // ctor
        public FamilyApartment(double area, int roomsCount, int unitPrice)
            : base(area, roomsCount, unitPrice)
        {
            // gyermekek száma kezdetben 0
            this.childrenCount = 0;
        }

        // gyermek születik
        public bool ChildIsBorn()
        {
            // felnöttek száma = össz - gyerekekszáma
            int felnottek = this.inhabitantsCount - this.childrenCount;

            // ha legalább 2-n vannak -> GO
            if (felnottek >= 2)
            {
                this.inhabitantsCount++;
                this.childrenCount++;
                return true;
            }
            return false;
        }

        public override bool MoveIn(int newInhabitants)
        {
            // összLakókSzáma -> felnőttek + újak (felnőttek) + (gyerekek * 0.5)
            double total = (this.inhabitantsCount - this.childrenCount) + newInhabitants
                + this.childrenCount * 0.5;

            // többen vannak, mint 2 egy szobában -> nem lehet költözni
            if (total > this.roomsCount * 2) return false;

            // összNm = (felnőtt + újak) * 10 + gyerek * 5
            int totalnm = ((this.inhabitantsCount - this.childrenCount)
                + newInhabitants) * 10 +
                this.childrenCount * 5;

            // nincs elég nm mindenkinek -> nem lehet költözni
            if (this.area < totalnm) return false;

            // lakószám növelés - az újakkal
            // csak felnőttek költöznek
            this.inhabitantsCount += newInhabitants;
            return true;
        }

        // szokásos override
        public override string? ToString()
        {
            return base.ToString() + $" Gy: {this.childrenCount}";
        }
    }
}
