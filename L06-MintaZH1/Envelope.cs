using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L06_MintaZH1
{
    // public a tesztelés miatt

    // : után megvalósított interfész neve
    // azzal kezd, hogy megvalósítod az interfészt,
    // azaz amit előír (most 2 Prop és 1 Metódus)
    // készítsd el
    public class Envelope : IDeliverable
    {
        // mező, adattag, belső változó
        string leiras;

        // egyik, az IFace által előírt Prop
        public int Weight
        {
            get;
            set;
        }
        // másik előírt Prop
        public string Address
        {
            get;
            set;
        }

        // ctor feladat szerint
        public Envelope(string leiras, int weight, string address)
        {
            this.leiras = leiras;
            Weight = weight;
            Address = address;
        }

        // IFace által előírt metódus
        // a feladat szerint megoldva
        public double CalculatePrice(bool fromLocker)
        {
            if (this.Weight <= 50) return 200;
            if (this.Weight <= 500) return 400;
            if (this.Weight <= 2000) return 1000;
            // 2000 felett exception-t dob
            // Exception külön osztály
            throw new OverweightException();
        }

        // ToString() felülírása
        public override string? ToString()
        {
            return $"Címzett: {this.Address} / " +
                $"Leírás: {this.leiras} / " +
                $"Tömeg:{this.Weight} g";
        }
    }

}
