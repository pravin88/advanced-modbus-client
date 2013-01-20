using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project423
{
    // Assigned to a node and represents the functional aspects
    public class RegisterGroup
    {
        // IP address to communicate with the device
        public string IpAddress
        {
            get;
            set;
        }

        // Port to communicate with the device
        public int Port
        {
            get;
            set;
        }

        // RegisterType of all the registers in the RegisterValueList
        public EnumRegisterType RegisterType
        {
            get;
            set;
        }

        // List of register and values. One for each register
        public List<RegisterValue> RegisterValueList
        {
            get;
            set;
        }


    }
}
