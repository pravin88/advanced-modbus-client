using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;

namespace Project423
{
    class CrudDeviceViewModel : PropertyChangedHandler
    {
        
        #region /******************** fields *****************/

        string _feedbackMessage;
        CrudDeviceModel _crudDeviceModel;
        ICommand _saveCommand;

        #endregion

        #region /***************** constructor ********************/

        public CrudDeviceViewModel()
        {
            _crudDeviceModel = new CrudDeviceModel();
        }

        #endregion

        #region /***************** Properties ***************/

        public CrudDeviceModel CrudDeviceModel
        {
            get { return _crudDeviceModel; }
        }

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new RelayCommand(param => SaveCrudDevice());
                return _saveCommand;
            }
            set { _saveCommand = value; }
        }

        public string FeedbackMessage
        {
            get { return _feedbackMessage; }
            set
            {
                _feedbackMessage = value;
                OnPropertyChanged("FeedbackMessage");
            }
        }

        #endregion

        private void SaveCrudDevice()
        {
            CrudDeviceViewModel viewModel = null;
            CrudDeviceModel model = null;

            viewModel = this;

            if (viewModel != null && viewModel.CrudDeviceModel != null)
                model = viewModel.CrudDeviceModel;


            List<_RegisterValue> registerValueList = new List<_RegisterValue>();
            for (int i = 0; i < model.RegisterCount; i++)
            {
                //string name = (model.AutoGenerateName == true) ? model.DeviceName + "_reg_" + i : "";
                //TODO default considered to be checked
                string name = model.DeviceName + "_reg_" + i;
                int address = model.StartingAddress + i;
                _RegisterValue registerValue = _RegisterValue.getRegisterValueFactory((EnumRegisterType)model.RegisterType, address, name);
                registerValueList.Add(registerValue);
            }

            RegisterGroup registerGroup = RegisterGroup.getRegisterGroupFactory(model, registerValueList);

            DeviceTreeModel configuration = new DeviceTreeModel()
            {
                DeviceName = model.DeviceName,
                ConfigurationType = EnumConfigurationType.RegisterGroup,
                RegisterGroup = registerGroup
            };

            
            MainWindow.Instance.DeviceTree.SelectedTreeNode.ListDeviceTreeModel.Add(configuration);
            //ConfigurationStore.getInstance().addConfiguration(configuration);

            MainWindow.Instance.DeviceTree.updateTree();
            MainWindow.Instance.ShowCrudDevice = false;



            string message = "Device Created successfully";
            viewModel.FeedbackMessage = message;

        }

        


    }


}
