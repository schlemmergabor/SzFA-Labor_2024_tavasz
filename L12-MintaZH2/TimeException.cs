using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L12_MintaZH2
{
    public class TimeException : Exception
    {
        public TimeException(string uzenet) : base (uzenet)
        {
            
        }
    }
}
