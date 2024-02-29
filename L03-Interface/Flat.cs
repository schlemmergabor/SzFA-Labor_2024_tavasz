using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L03_Interface
{
    // abstract mert van legalább egy abstract metódusa
    // megvalósítja az Interface-t

    internal abstract class Flat : IRealEstate
    {
        // protected láthatóságok, hogy a leszármazottban
        // (pl.: Lodgings) majd láthatóak legyenek
        protected double area;
        protected int roomsCount;
        protected int inhabitantsCount;
        protected int unitPrice;

        // Property
        public int InhabitantsCount {
            get => inhabitantsCount; 
        }

        // ctor
        protected Flat(double area, int roomsCount, int unitPrice)
        {
            this.area = area;
            this.roomsCount = roomsCount;
            
            // kezdeti lakosok száma 0
            this.inhabitantsCount = 0;
            this.unitPrice = unitPrice;
        }
        public abstract bool MoveIn(int newInhabitants);

        // lakás összértéke
        public int TotalValue()
        {
            // area double, de int-et kell visszaadni, mert
            // az Interface azt írta elő
            return (int)(this.area * this.unitPrice);
        }

        // ToString() overrideolása
        public override string? ToString()
        {
            return $"T: {this.area}, " +
                $"SzSz: {this.roomsCount}, " +
                $"LSz: {this.inhabitantsCount}, " +
                $"UP: {this.unitPrice}";
        }
    }
}
