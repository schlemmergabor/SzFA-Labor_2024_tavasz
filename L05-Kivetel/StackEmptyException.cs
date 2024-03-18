using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L05_Kivetel
{
    public class StackEmptyException : StackException
    {
        public StackEmptyException(IngredientStack stack) : base(stack)
        {
        }
    }

}
