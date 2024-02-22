using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02_Oroklodes
{
    internal class Square : Rectangle
    {
        // nincs adattag, hanem a w=h a négyzetnél

        // ctor() - kézzel írtuk
        // csak egy oldalt adunk meg 
        // base(...)-el ugyanazzal a paraméter értékével hívjuk meg
        public Square(int a, bool lyukas = false, string szin = "red")
            : base(a, a, lyukas, szin)
        {
        }

        // Property-k -> kézzel írtuk
        // szélesség és magasság mindig egyezzen meg

        // ősnek a Property-jét adja vissza
        // ősnek a Property-jét állítja (mindkettőt)

        // new azért, mert az Ősében is van Height

        // new nélkül is fordul működik, de zöld
        // aláhúzással jelez a VS
        // használd a new-t így őt is és a
        // kódodat olvasót is megnyugtatod
        public new int Height
        {
            get { return base.Height; }
            set
            {
                base.Height = value;
                base.Width = value;
            }
        }
        public new int Width
        {
            get { return base.Width; }
            set
            {
                base.Height = value;
                base.Width = value;
            }
        }

        // ToString() override nincs, így az Ősé fog hívódni
        // amúgy nem is szerepelt a feladatok között

        // Equals() override nincs, szintén az Ősé fog hívódni
        // mivel mind a két oldal egyenlő, így oké lesz
    }
}
