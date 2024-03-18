using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L05_Kivetel
{
    public class StackException : Exception
    {
        // mezői
        IStack stack;

        // ctor - message üzenettel
        public StackException(IngredientStack stack) : base("Stack Hiba történt")
        {
            this.stack = stack;
        }

        public StackException(IStack stack) : base("Stack Hiba történt")
        {
            this.stack = stack;
        }
    }

}
