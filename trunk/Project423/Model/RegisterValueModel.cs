using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project423.Data
{
    class RegisterValueDataModel
    {
        public bool AutoRefreshEnable
        {
            get;
            set;
        }

        public int AutoRefreshInterval
        {
            get;
            set;
        }

        public RegisterGroup RegisterGroup
        {
            set;
            get;
        }

        public string DeviceConnectionStatus
        {
            get;
            set;
        }

        public string FileStatus
        {
            get;
            set;
        }
    }
}
