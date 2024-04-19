using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L10_Rendezes
{
    public enum SortingMethod
    {
        Selection,
        Bubble,
        Insertion
    }
    public class OrderedItemsHandler
    {
        // Property-t, adattagok
        public IComparable[] Tömb { get; private set; }

        // ctor
        public OrderedItemsHandler(IComparable[] tömb)
        {
            Tömb = tömb;
        }

        // Metódus

        // Rendezett-E?
        // 2.5. Algoritmus Növekvő rendezettség vizsgálata
        public bool IsOrdered(bool isAscending = true)
        {
            // isAscending == true -> növekvő rendezett? -> A->Z

            if (isAscending)
            {
                // Early Exit -> növekvő A->Z
                for (int i = 0; i < Tömb.Length - 1; i++)
                {
                    // ha az i. nagyobb, mint a i+1 -> false
                    if (Tömb[i].CompareTo(Tömb[i + 1]) > 0)
                        return false;
                }
                return true;
            }
            // isAscending == false -> csökkenő 
            // Early Exit -> csökkenő Z->A
            for (int i = 0; i < Tömb.Length - 1; i++)
            {
                // ha az i. nagyobb, mint a i+1 -> false
                if (Tömb[i].CompareTo(Tömb[i + 1]) < 0)
                    return false;
            }
            return true;

        }
        // fordítsuk meg a tömböt
        private void Reverse()
        {
            IComparable[] temp = new IComparable[Tömb.Length];

            int index = 0; // temp[index]

            for (int i = Tömb.Length - 1; i >= 0; i--)
            {
                temp[index++] = Tömb[i];
            }

            // visszacserél
            Tömb = temp;

        }

        // Rendezést megvalósító metódus
        public void Sort(SortingMethod sortingMethod, bool isAscending = true)
        {

            // Rendezés-> növekvőre
            switch (sortingMethod)
            {
                case SortingMethod.Selection:
                    // private metódus hívása
                    // névtelen metódussal, lambdával
                    SelectionSort((a, b) => a.CompareTo(b) < 0);
                    break;
                case SortingMethod.Bubble:
                    break;
                case SortingMethod.Insertion:
                    // Beillesztéses rendezés meghívása
                    InsertionSort((a, b) => a.CompareTo(b) < 0);
                    break;
                default:
                    break;
            }

            // isAscending == false -> Reverse
            if (!isAscending) Reverse();
        }
        // Rendezés -> Beillesztéses rendezés
        private void InsertionSort(Func<IComparable, IComparable, bool> less)
        {
            if (less == null) throw new ArgumentNullException();

            for (int i = 1; i < Tömb.Length; i++)
            {
                int j = i - 1;
                IComparable temp = Tömb[i];

                while ((j >= 0) && less(temp, Tömb[j]))
                {
                    Tömb[j + 1] = Tömb[j];
                    j--;
                }
                Tömb[j + 1] = temp;
            }
        }

        // Rendezés -> kiválasztásos rendezés
        private void SelectionSort(Func<IComparable, IComparable, bool> less)
        {
            if (less == null) throw new ArgumentNullException();

            for (int i = 0; i < Tömb.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = minIndex; j < Tömb.Length; j++)
                {
                    if (less(Tömb[j], Tömb[minIndex]))
                    {
                        minIndex = j;
                    }
                }
                // Tömb elemek cseréje
                (Tömb[minIndex], Tömb[i]) = (Tömb[i], Tömb[minIndex]);
            }
        }
        public int BinKeresRek(IComparable keresett)
        {
            // ha nem rendezett
            if (!IsOrdered()) throw new NotOrderedItems(Tömb);
            // itt indítjuk a keresést
            return BinKeresRek(0, Tömb.Length - 1, keresett);
        }

        // BINKER
        private int BinKeresRek(int bal, int jobb, IComparable keresett)
        {
            // Nincs benne az elem
            if (bal > jobb) return -1;

            int center = (bal + jobb) / 2;

            // megtaláltuk -> őt kerestük
            if (keresett == Tömb[center]) return center;

            // kisebb felében van -> 
            if (Tömb[center].CompareTo(keresett) > 0)
                return BinKeresRek(bal, center - 1, keresett);

            // nagyobb felében van -> ...
            return BinKeresRek(center + 1, jobb, keresett);
        }

        // Elemszám, ami egy adott értékkel egyenlő
        public int Darabszám(Predicate<IComparable> pre)
        {
            int db = 0;
            for (int i = 0; i < Tömb.Length; i++)
            {
                if (pre(Tömb[i])) db++;
            }
            return db;
        }

        // Elemszám ami egy adott tartományba esik
        public int Darabszám(Predicate<IComparable> pre1, Predicate<IComparable> pre2)
        {
            int db = 0;
            for (int i = 0; i < Tömb.Length; i++)
            {
                if (pre1(Tömb[i]) && pre2(Tömb[i])) db++;
            }
            return db;
        }
    }
}

