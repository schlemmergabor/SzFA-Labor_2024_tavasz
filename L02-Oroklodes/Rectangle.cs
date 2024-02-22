using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02_Oroklodes
{
    // : jelzi az öröklődést, azaz
    // Rectangle megörökli a Shape "dolgait"
    // metódusait, mezőit, Property-it, stb.
    internal class Rectangle : Shape
    {
        // adattag, mező, belsőváltozók
        int height, width;

        // kézzel készített ctor
        // megadod a h, w, a többi pedig opcionális paraméter
        // ezért van a lyukas = és a szin =
        // base(...) -> ős ctor() hívása a ... paraméterekkel
        public Rectangle(int h, int w, bool lyukas = false, string szin = "red") :
            base(lyukas, szin)
        {
            // ős ctor hívása után ezek futnak le
            // azaz beállítjuk a szélességet, magasságot
            this.height = h;
            this.width = w;
        }

        // Property-k -> VS-ből generáltuk
        public int Height
        {
            get => height;
            set => height = value;
        }
        public int Width
        {
            get => width;
            set => width = value;
        }

        // Ősből (Shape) származó abstract metódusok megvalósítása
        // overrideolni kell, VS-ből generáltuk le
        // (nem kell emlékezni a szignatúrára)
        // terület számítás T=a*b
        public override double Area()
        {
            return this.height * this.width;
        }

        // kerület számítás K=2*(a+b)
        public override double Perimeter()
        {
            return 2 * (this.width + this.height);
        }

        // ennek a ToString()-jét kiegészítjük azzal az információval,
        // hogy téglalap
        // base. -al eléred az Ős-t (és most annak a ToString()-ét)
        public override string? ToString()
        {
            return "TÉGLALAP " + base.ToString();
        }

        // Object-ből származó Equals metódus
        // összetudjuk hasonlítani két objektumot, hogy
        // ugyanaz-e a tartalmuk (ugyanazok-e)
        // mivel az objektum == objektum a két referenciát
        // hasonlítja össze, ezért ezt kell használni/megírni
        public override bool Equals(object? obj)
        {
            // ha a obj paraméter amúgy olyan osztálybeli
            // elem, mint amiben most vagyunk
            if (obj is Rectangle)
            {
                // átmeneti átalakítás () castolás
                Rectangle temp = (Rectangle)obj;

                // megnézzük, hogy egyeznek-e a belső mezők
                // mivel ugyanolyan osztályban vagyunk így
                // hozzáférünk a private mezőkhöz
                return this.height == temp.height
                    && this.width == temp.width;
            }

            // minden más esetben, azaz, ha nem Rectangle
            // osztálybeli objektum volt az átadott obj, akkor
            // false-al térünk vissza
            // pl Kutya nem lesz sosem egyenlő Rectangle-al...
            return false;
        }
    }
}
