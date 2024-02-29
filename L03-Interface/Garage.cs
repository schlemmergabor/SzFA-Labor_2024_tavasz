using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L03_Interface
{
    // Interface-ek
    internal class Garage : IRent, IRealEstate
    {
        // mezők
        double area;
        int unitPrice;
        bool isHeated;
        int months;
        bool isOccupied;

        // ctor
        // opcionális paraméterek: isHeated, months, isOccupied
        // ezek nélkül is működik a ctor és ekkor az = utáni értéket adja át
        public Garage(double area, int unitPrice, bool isHeated = false, int months = 0, bool isOccupied = false)
        {
            this.area = area;
            this.unitPrice = unitPrice;
            this.isHeated = isHeated;
            this.months = months;
            this.isOccupied = isOccupied;
        }

        // ki/be állás 
        public void UpdateOccupied()
        {
            // mező negáltjának beállítása
            this.isOccupied = !this.isOccupied;

            // alábbiakban két hasonló megoldás:
            // if (isOccupied) this.isOccupied = false;
            // if (!isOccupied) this.isOccupied = true;

            // ő is megoldás lehet
            // this.isOccupied = this.isOccupied == false; // F==F -> T, T==F -> F
        }

        // szokásos override
        public override string? ToString()
        {
            return $"Garázs, T:{this.area}, UP: {this.unitPrice}, {(this.isHeated ? "" : "nem ")}fütött, H: {this.months}, {(this.isOccupied ? "" : "nem ")}foglalt";
        }

        // Property
        public bool IsBooked
        {
            get
            {
                if (this.months > 0 || this.isOccupied) return true;
                return false;
            }
        }

        // foglalás -> ugyanaz, mint a másikban
        public bool Book(int months)
        {
            if (!this.IsBooked) // nincs foglalva -> lehet
            {
                this.months = months;
                return true;
            }

            // foglalva van -> nem sikerült foglalni
            return false;
        }

        // értéke
        public int GetCost(int months)
        {
            // ha fűtött -> 1.5, amúgy 1 a szorzó
            double szorzo = this.isHeated ? 1.5 : 1;

            return (int)((double)this.TotalValue() / 120 * szorzo);
        }

        public int TotalValue()
        {
            return (int)(this.area * this.unitPrice);
        }
    }
}
