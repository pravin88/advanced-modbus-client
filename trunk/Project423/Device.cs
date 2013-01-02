using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project423
{
    public class Device
    {
        // Unique record Id for the node
        public int DeviceId
        {
            get;
            set;
        }

        // Id of the parent node in the hierarchy
        public int ParentID
        {
            get;
            set;
        }

        // Name of the device
        public string DeviceName
        {
            get;
            set;
        }

    }
}
