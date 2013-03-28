using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using WSMBT;

namespace Project423
{
    class RegisterGroupViewModel : PropertyChangedHandler
    {
        
        #region /******************** fields *****************/

        RegisterGroup _registerGroup;
        ICommand _autoRefreshCommand;
        string _comStatusError;
        string _fileStatusError;

        #endregion

        #region /***************** constructor ********************/

        public RegisterGroupViewModel(RegisterGroup registerGroup)
        {
            _registerGroup = registerGroup;

            initModbusClient();
        }

        #endregion

        #region /***************** Properties ***************/

        public RegisterGroup RegisterGroup
        {
            get { return _registerGroup; }
        }

        public ICommand AutoRefreshCommand
        {
            get
            {
                if (_autoRefreshCommand == null)
                    _autoRefreshCommand = new RelayCommand(param => AutoRefresh());
                return _autoRefreshCommand;
            }
            set { _autoRefreshCommand = value; }
        }

        public string CommStatusError
        {
            get
            {
                return _comStatusError;
            }
            set
            {
                _comStatusError = value;
                OnPropertyChanged("CommStatusError");
            }
        }

        public string FileStatusError
        {
            get
            {
                return _fileStatusError;
            }
            set
            {
                _fileStatusError = value;
                OnPropertyChanged("FileStatusError");
            }
        }

        #endregion

        #region /***************************** modbus *********************/

        WSMBTControl wsmbtControl;

        void initModbusClient()
        {
            wsmbtControl = new WSMBTControl();

            wsmbtControl.Mode = Mode.TCP_IP;
            wsmbtControl.ResponseTimeout = 1000;
            wsmbtControl.ConnectTimeout = 1000;
            Result result = wsmbtControl.Connect(_registerGroup.IpAddress, _registerGroup.Port);

            if (result != Result.SUCCESS)
            {
                _comStatusError = "Not able to connect to Device:" + _registerGroup.IpAddress;
            }
            else if (result == Result.SUCCESS)
            {
                _comStatusError = "Connected to Device:" + _registerGroup.IpAddress;
            }
        }

        private void AutoRefresh()
        {
            _registerGroup.readData(wsmbtControl);
        }


        #endregion
    }


}
