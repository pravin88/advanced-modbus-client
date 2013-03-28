using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;

namespace Project423
{
    class CrudFolderViewModel : PropertyChangedHandler
    {
        
        #region /******************** fields *****************/

        string _feedbackMessage;
        CrudFolderModel _crudFolderModel;
        ICommand _saveCommand;

        #endregion

        #region /***************** constructor ********************/

        public CrudFolderViewModel()
        {
            _crudFolderModel = new CrudFolderModel();
        }

        #endregion

        #region /***************** Properties ***************/

        public CrudFolderModel CrudFolderModel
        {
            get { return _crudFolderModel; }
        }

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new RelayCommand(param => SaveCrudFolder());
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

        private void SaveCrudFolder()
        {
            CrudFolderViewModel viewModel = null;
            CrudFolderModel model = null;

            viewModel = this;

            if (viewModel != null && viewModel.CrudFolderModel != null)
                model = viewModel._crudFolderModel;

            //int parentId = MainWindow.Instance.DeviceTree.SelectedTreeNode.DeviceId;

            DeviceTreeModel configuration = new DeviceTreeModel()
            {
                DeviceName = model.FolderName,
                ConfigurationType = EnumConfigurationType.Folder,
                RegisterGroup = null,
                ListDeviceTreeModel = new List<DeviceTreeModel>() 
            };

            MainWindow.Instance.DeviceTree.SelectedTreeNode.ListDeviceTreeModel.Add(configuration);
            //MainWindow.Instance.DeviceTree.updateTree();
            MainWindow.Instance.ShowCrudFolder = false;

            MainWindow.Instance.DeviceTree.updateTree();
        }


    }


}
