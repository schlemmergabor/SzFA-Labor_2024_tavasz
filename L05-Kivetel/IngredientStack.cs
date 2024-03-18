using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L05_Kivetel
{
    // A Stack-ünk úgy fog működni, hogy van egy tömb és egy idx segédváltozó.
    // idx-ben az tároljuk, hogy melyik indexen van a legutoljára eltárolt elem
    // idx kezdben -1
    // Push(...) esetében idx=idx+1 és tömb[idx]=newItem
    // Pop() esetében return[idx], majd idx--
    // Pop-nál nem állítjuk null ref-re (megspóroljuk)
    // ugyanis egy újabb Push(...)-al felül fogjuk majd azt írni.
    // vagy a GarbageCollector majd intézi...
    public class IngredientStack : IStack
    {
        // ebben a tömbben tároljuk az értékeket
        FoodIngredient[] tömb;

        // utolsó tárolt elem indexe
        int idx = -1;

        // Prop -> Tömb mérete -> felhasználjuk az IngredientStackHandler-ben
        public int Meret
        {
            get
            {
                return this.tömb.Length;
            }
        }

        public IngredientStack(int meret)
        {
            this.tömb = new FoodIngredient[meret];
        }

        public bool Empty()
        {
            // kezdetben a legutolsó indexe -1, így ha még -1 az érték akkor üres
            return idx == -1;
        }

        // Stack tetejére elhelye
        public void Push(FoodIngredient newItem)
        {
            // ha idx == utolsó tömbbeli elemme -> nem fér bele
            if (idx == tömb.Length - 1)
                // dobunk új saját kivételt
                // paramétere this, el nem helyezett elem
                throw new StackFullException(this, newItem);

            // el tudjuk helyezni a tömbben
            // ++idx -> először megnöveljük az értékét, utána használjuk fel
            // kezdetben -1, ++idx -> 0 lesz és a tömb[0] -ba kerül a newItem
            this.tömb[++idx] = newItem;

        }

        // kivesz egy elemet a tetejéről
        public FoodIngredient Pop()
        {
            // ha üres -> új saját kivétel dobása
            if (this.Empty())
                throw new StackEmptyException(this);

            // idx-- -> felhasználja az értékét és utána csökkenti
            return this.tömb[idx--];

        }

        // csak "megmutatja" mi a felső elem
        public FoodIngredient Top()
        {
            // null ref. ha üres
            if (this.Empty()) return null;

            return this.tömb[idx];
        }
    }
}
