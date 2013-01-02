using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project423
{
    public class Configuration : Device
    {
        // Defines the type of configuration the node represents
        public EnumConfigurationType ConfigurationType
        {
            get;
            set;
        }

        // Register Group (address, value,..) this node represents
        public RegisterGroup RegisterGroup
        {
            get;
            set;
        }

    }
}
