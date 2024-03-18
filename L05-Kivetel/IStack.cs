using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L05_Kivetel
{
    public interface IStack
    {
        int Meret { get; }
        bool Empty();
        public FoodIngredient Pop();
        public void Push(FoodIngredient newItem);
        
      
    }

}
