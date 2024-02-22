using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02_Oroklodes
{
    internal class Circle : Shape
    {
        // adattagok ami csak ebben az osztályban lesz
        // r = sugár
        int r;

        // ctor -> Kézzel 
        // opcionális paraméterekkel (lásd többi osztály)
        // base(...) -el meghívjuk az ős ctor()-ját
        public Circle(int r, bool lyukas = false, string color = "red")
            : base(lyukas, color)
        {
            // beállítjuk a csak ebben az osztályban létező adattagot
            this.r = r;
        }

        // Property a mezőhöz VS-ből generálva
        public int R
        {
            get => r;
            set => r = value;
        }

        // Equals felülírása
        // magyarázatot lásd Rectangle.cs-nél
        public override bool Equals(object? obj)
        {
            if (obj is Circle)
            {
                Circle temp = (Circle)obj;
                return this.r == temp.r;
            }
            return false;
        }

        // az Ős-ben abstractként megjelölt
        // örökölt metódusok - VS-ből generáltuk
        public override double Area()
        {
            return r * r * Math.PI;
        }

        public override double Perimeter()
        {
            return 2 * r * Math.PI;
        }
    }
}
