using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L05_Kivetel
{
    public class IngredientStackHandler
    {
        // belső érték, mező
        IngredientStack verem;
        

        // ctor
        public IngredientStackHandler(IngredientStack verem)
        {
            this.verem = verem;
        }
        public IngredientStackHandler(IStack verem)
        {
            this.verem = verem as IngredientStack;
        }

        

        // hozzáadja a paraméter tömbből az értékeket
        // ami nem fért bele -> visszaadja egy másik tömbben
        public FoodIngredient[] AddItems(FoodIngredient[] foodIngredients)
        {
            // ha belefér mind -> null;
            if (foodIngredients.Length <= this.verem.Meret)
            {
                foreach (FoodIngredient item in foodIngredients)
                {
                    this.verem.Push(item);
                }

                return null;
            }

            if (foodIngredients.Length > this.verem.Meret)
            // nem fog beleférni -> 
            {
                // csinálunk egy tömböt, amibe belerakjuk azokat amik kimaradtak
                FoodIngredient[] result = new FoodIngredient[foodIngredients.Length - this.verem.Meret];
                
                // a kimaradtak melyik indexű elemébe kerül a következő
                int idx = 0; // result[index]


                foreach (FoodIngredient item in foodIngredients)
                {
                    try
                    {
                        this.verem.Push(item);
                    }
                    catch (StackFullException ex)
                    {
                        //result[idx++] = item;
                        // a kivétel tartalmazza azt az elemet, ami nem ment bele
                        // így azt tároljuk el a tömb indexében
                        result[idx++] = ex.NemMentBele;
                    }
                }
                return result;
            }
            return null;
        }
    }

}
