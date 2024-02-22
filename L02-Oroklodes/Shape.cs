using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02_Oroklodes
{
    // abstract osztály, mert van legalább egy abstract metódusa
    internal abstract class Shape
    {
        // lyukas-e?
        bool isHoley; // kezdőérték false
        // szín
        string color;

        // Property - VS-ből generálva
        public string Color { get => color; 
            set => color = value; }

        // ctor - VS-ből generálva
        protected Shape(bool isHoley, string color)
        {
            this.isHoley = isHoley;
            this.color = color;
        }

        // egy paraméters ctor() kézzel megírva
        // meghívjuk a saját ctor-t paraméterekkel
        // this -> saját magunk
        protected Shape(string color) : this(false, color)
        {
        }

        public void MakeHoley()
        {
            // kilyukaszt
            isHoley = true; 
        }

        // abstract metódusok jelentése: metódus definiálva
        // megadod a metódus szignatúráját (visszatérési érték, neve, paraméterei)
        // de itt nem töltöd ki a metódus törzsét, nincs megadva, hogy mit csinál
        //
        // hol fogjuk megadni, hogy mit csinál a metódus?
        // a leszármazott osztályban
        // 
        // ezen abstract metódus miatt abstract az osztály
        // mivel az osztály abstract nem lehet példányosítani, mivel
        // nem tudnánk, hogy ez a metódus mit csinál...
        // bővebben lásd: labor moodle oldal
        public abstract double Perimeter();
        public abstract double Area();

        // Object osztályból származó ToString() felülírása
        // VS-ből generáljuk
        public override string? ToString()
        {
            return $"{this.color} " +
                $"- {(this.isHoley ? "" :"nem")} " + // ternary operator
                $"lyukas - K: {this.Perimeter()} -" +
                $" T: {this.Area()}";
        }
    }
}
