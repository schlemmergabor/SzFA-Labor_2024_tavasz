using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02_Oroklodes
{

    internal class Program
    {

        static void Kilyukaszt(Shape s)
        {
            // ha nagyobb a területe, mint a kerülete
            if (s.Area() > s.Perimeter())
                s.MakeHoley(); // kilyukasztás
        }

        static Shape Készít(int a, int b)
        {
            // ha a két oldal =, akkor négyzet
            if (a == b) return new Square(a);

            // minden más esetben téglalap
            return new Rectangle(a, b);
        }

        static Shape Legnagyobb(Shape[] tömb)
        {
            // max tétel lásd jegyzet, így kérjük vizsgán, ZH-n!
            int maxIndex = 0;

            // figyelj rá, hogy 1-től indul
            for (int i = 1; i < tömb.Length; i++)
            {
                // indexeken keresztül nézed meg a > 
                // nem tárolsz számított értéket
                if (tömb[i].Area() > tömb[maxIndex].Area())
                    maxIndex = i;
            }

            // figyelj, hogy mit returnolsz vissza
            return tömb[maxIndex];
        }


        static void Main(string[] args)
        {
            // Tesztelés során létrehozott objektumok
            // és azok ToString()-jének kiírása
            Rectangle r1 = new Rectangle(2, 3);
            Console.WriteLine(r1);

            Square sq1 = new Square(10);
            // kipróbáljuk, hogy w=h mindig
            sq1.Width = 8;
            Console.WriteLine(sq1);

            Circle c1 = new Circle(10);
            Console.WriteLine(c1);

            // Öt alakzatot egy tömbben
            // az Ős lesz a tömb referencia
            // az egyes indexen lévő értékek 
            // az Ős leszármazottjai
            // 
            // nézd át: korai kötés, késői kötés

            Shape[] sikidomok = new Shape[]
            {
                new Circle(10),
                new Rectangle(2, 3, true, "yellow"),
                new Rectangle(10, 10),
                new Square(3,false,"blue"),
                new Circle(3, false, "green")
            };


            // kilyukasztjuk az egyik sikidomot

            Kilyukaszt(sikidomok[2]);

            // de rég használtuk...
            Console.Clear();

            // végigjárjuk a sikidomok tömböt és ToString()-ek
            foreach (Shape s in sikidomok)
            {
                Console.WriteLine(s);
            }

            // Készít metódus tesztelése
            Shape valamit = Készít(3, 3);

            // ha az elkészült négyzet
            if (valamit is Square)
                Console.WriteLine("Valami az négyzet");

            // különben ha téglalap
            else if (valamit is Rectangle)
                Console.WriteLine("Valami az téglalap");

            // legnagyobb területi kiválasztása és tesztelése
            Shape nagy = Legnagyobb(sikidomok);
            Console.WriteLine(nagy);
        }
    }
}