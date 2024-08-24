using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppFinal.Exceptions
{
    internal class NoSuchItemException:Exception
    {
        public NoSuchItemException(string message):base(message) 
        {
            
        }
    }
}
