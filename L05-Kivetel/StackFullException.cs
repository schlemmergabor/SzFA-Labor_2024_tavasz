using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L05_Kivetel
{
    public class StackFullException : StackException
    {
        FoodIngredient nemMentBele;

        // Property, amit azért csináltunk, hogy letudjuk kérni, hogy
        // melyik elem nem ment bele -> ezt fogjuk elmenteni a tömbbe
        public FoodIngredient NemMentBele
        {
            get => nemMentBele;
        }

        // ctor
        public StackFullException(IngredientStack stack, FoodIngredient m) : base(stack)
        {
            this.nemMentBele = m;
        }

        public StackFullException(IStack stack, FoodIngredient m) : base(stack)
        {
            this.nemMentBele = m;
        }


    }

}
