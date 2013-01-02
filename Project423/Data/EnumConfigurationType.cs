using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project423
{
    // Defines the type of configuration a node represents
    public enum EnumConfigurationType
    {
        // A folder which has no functions but to group further nodes
        Folder = 1,

        // Represents the node which contains functionalities of registers
        RegisterGroup = 2,

        // RootNode
        MyComputer = 3
    }
}
