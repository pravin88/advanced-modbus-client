using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Project423
{
    public class CrudDeviceModel : PropertyChangedHandler
    {
        #region /********************** fields ********************/
        
        string _deviceName, _deviceAddress;
        int _devicePort,_startingAddress,_registerCount;
        bool _autoGenerateName;
        EnumRegisterType _registerType;
        
        #endregion

        #region /************** properties *******************/

        public string DeviceName
        {
            get { return _deviceName; }
            set
            {
                _deviceName = value;
                OnPropertyChanged("DeviceName");
            }
        }

        public string DeviceAddress
        {
            get { return _deviceAddress; }
            set
            {
                _deviceAddress = value;
                OnPropertyChanged("DeviceAddress");
            }
        }

        public int DevicePort
        {
            get { return _devicePort; }
            set
            {
                _devicePort = value;
                OnPropertyChanged("DevicePort");
            }
        }

        public EnumRegisterType RegisterType
        {
            get { return _registerType; }
            set
            {
                _registerType = value;
                OnPropertyChanged("RegisterType");
            }
        }

        public int StartingAddress
        {
            get { return _startingAddress; }
            set
            {
                _startingAddress = value;
                OnPropertyChanged("StartingAddress");
            }
        }

        public int RegisterCount
        {
            get { return _registerCount; }
            set
            {
                _registerCount = value;
                OnPropertyChanged("RegisterCount");
            }
        }

        public bool AutoGenerateName
        {
            get { return _autoGenerateName; }
            set
            {
                _autoGenerateName = value;
                OnPropertyChanged("AutoGenerateName");
            }
        }

        #endregion
        
    }
}
