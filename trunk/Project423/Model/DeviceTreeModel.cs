using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project423
{
    public class DeviceTreeModel : Configuration
    {
        List<DeviceTreeModel> _listDeviceTreeModel;

        public List<DeviceTreeModel> ListDeviceTreeModel
        {
            get { return _listDeviceTreeModel; }
            set
            {
                _listDeviceTreeModel = value;
            }
        }

    }
}
