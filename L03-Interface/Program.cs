namespace L03_Interface
{
    // 1. feladat megoldása, saját Interface készítése + saját osztály
    interface IInterface
    {
        // előírásokat tartalmaz
        // Prop, Metódus lehet benne -> public
        // mező, adattag, belső változó nem lehet benne
        // példányosítani nem lehet
        // referencia változó lehet

        int Kor { get; set; }
        void Kiir();
    }

    // osztály ami megvalósítja az interfészeket
    // IComparable -> C# saját belső Interface
    // Array.Sort() működéséhez kell
    class Dog : IInterface, IComparable
    {
        // mező, adattag, Interface-ban nincs
        int kor;

        // Property
        // Interface-ból előírás, a konkrét kód itt
        public int Kor
        {
            get => this.kor;
            set { this.kor = value; }
        }

        // IComperable által előírt metódus megvalósítása
        public int CompareTo(object? obj)
        {
            // ha nem kutya az obj, akkor valamit vissza adunk
            if (!(obj is Dog)) return 0;

            // átcastoljuk, hogy hozzáférjünk a belső mezőkhöz
            Dog temp = (Dog)obj;

            // lásd feladat, dia
            if (this.kor < temp.kor) return -1;

            if (this.kor > temp.kor) return 1;

            return 0; // megegyeznek

        }

        // Interface előírta, itt megvalósítjuk
        public void Kiir()
        {
            Console.WriteLine("Kutya");
        }
    }

    internal class Program
    {
        // első feladat teszteléséhez készített metódus
        static void ElsoFeladat()
        {
            // Készítettünk egy tömböt
            Dog[] kutyak = new Dog[]
            {
                new Dog(){Kor = 10},
                new Dog(){Kor = 3}
            };

            // beépített rendező Metódus
            // IComparable-t meg kellett hozzá valósítani
            Array.Sort(kutyak);

            // itt más sorrendben lesznek a kutyak
        }

        static void Main(string[] args)
        {
            ApartmentHouse OE = ApartmentHouse.LoadFromFile(@"..\..\..\data.txt");

            // tesztelés
            // Lodgings osztály -> OE[0] -> Lodgings
            Lodgings f = (Lodgings)OE.Tarolo[0];
            Console.WriteLine(f);

            // Metódusok a Flat osztályból
            // lakás értéke - 26 104 000 - OK
            Console.WriteLine(f.TotalValue());

            // lakók száma - 0 - OK
            Console.WriteLine(f.InhabitantsCount);

            // Metódusok a Lodgings osztályból
            // le van-e foglalva? - false - mert nem lakják - OK
            Console.WriteLine(f.IsBooked);

            // be lehet-e költözni? - false - nem - OK
            Console.WriteLine(f.MoveIn(2));

            // foglaljuk le 12 hónapra - sikeres - true - OK
            Console.WriteLine(f.Book(12));

            // le van-e most foglalva - true - OK
            Console.WriteLine(f.IsBooked);

            // próbáljuk újra lefoglalni - false - OK
            Console.WriteLine(f.Book(1));

            // beköltözés - true - OK
            Console.WriteLine(f.MoveIn(2));

            // újabb beköltözés - szobák száma/ létszám miatt - false - OK
            Console.WriteLine(f.MoveIn(15));

            // Metódusok a FamilyApartment osztályból
            // FamilyApartment osztály -> OE[0] -> Lodgings
            FamilyApartment fa = (FamilyApartment)OE.Tarolo[1];

            // lefoglalni nem tudjuk, mert nem bérelhető
            // költözni tudunk - true - OK
            Console.WriteLine(fa.MoveIn(2));

            // baba születik - true - OK
            Console.WriteLine(fa.ChildIsBorn());

            // létszám ellenőrzése - 3 - OK
            Console.WriteLine(fa.InhabitantsCount);

            // egyik nagyszülő költözik - 4 true - OK
            Console.WriteLine(fa.MoveIn(1));

            // másik már nem fér el - false - OK
            Console.WriteLine(fa.MoveIn(1));

            // Metódusok a Garage osztályból
            Garage g = (Garage)OE.Tarolo[2];

            // ToString() tesztelése
            Console.WriteLine(g);

            // foglaljuk a garázst - true - OK
            Console.WriteLine(g.Book(12));

            // újra foglalnánk - false - OK
            Console.WriteLine(g.Book(12));

            // beáll a kocsi
            g.UpdateOccupied();
            Console.WriteLine(g);


        }
    }
}
