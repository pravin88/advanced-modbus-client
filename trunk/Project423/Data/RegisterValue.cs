using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project423
{
    // Represents a single register. Stores Address, name and last read value
    public class RegisterValue
    {
        // Register Address
        public int Address
        {
            get;
            set;
        }

        // A text name to the register
        public string Name
        {
            get;
            set;
        }

        // Value of the Address
        public double Value
        {
            get;
            set;
        }
    }
}
