using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Project423
{
    class DeviceTreeViewModel : PropertyChangedHandler
    {

        #region /********************** fields *********************/

        List<DeviceTreeModel> _listDeviceTreeModel;

        ICommand _addDevice, _addFolder, _delete, _viewDevice;
        private DeviceTreeView _deviceTreeView;

        #endregion

        #region /************************ constructor *******************/

        public DeviceTreeViewModel()
        {
            _listDeviceTreeModel = new List<DeviceTreeModel>(); // ConfigurationStore.getInstance().ConfigurationList;

            DeviceTreeModel configuration = new DeviceTreeModel()
            {
                DeviceName = "My Computer",
                ConfigurationType = EnumConfigurationType.MyComputer,
                RegisterGroup = null,
                ListDeviceTreeModel = new List<DeviceTreeModel>()
            };

            _listDeviceTreeModel.Add(configuration);   


        }

        public void init(DeviceTreeView deviceTreeView)
        {
            _deviceTreeView = deviceTreeView;
        }

        #endregion

        #region /*********************** properties *************************/

        public List<DeviceTreeModel> ListDeviceTreeModel
        {
            get { return _listDeviceTreeModel; }
            set
            {
                _listDeviceTreeModel = value;
                OnPropertyChanged("ListDeviceTreeModel");
            }
        }

        public ICommand AddDeviceCommand
        {
            get
            {
                if (_addDevice == null)
                    _addDevice = new RelayCommand(param => AddDevice());
                return _addDevice;
            }
            set { _addDevice = value; }
        }

        public void AddDevice()
        {
            MainWindow.Instance.ShowCrudDevice = true;
        }

        public ICommand AddFolderCommand
        {
            get
            {
                if (_addFolder == null)
                    _addFolder = new RelayCommand(param => AddFolder());
                return _addFolder;
            }
            set { _addDevice = value; }
        }

        public void AddFolder()
        {
            MainWindow.Instance.ShowCrudFolder = true;
        }

        public ICommand DeleteCommand
        {
            get
            {
                if (_delete == null)
                    _delete = new RelayCommand(param => Delete());
                return _delete;
            }
            set { _delete = value; }
        }

        public void Delete()
        {
            MainWindow.Instance.DeviceTree.updateTree();
        }

        public ICommand ViewDeviceCommand
        {
            get
            {
                if (_viewDevice == null)
                    _viewDevice = new RelayCommand(param => viewDevice());
                return _viewDevice;
            }
            set { _viewDevice = value; }
        }

        public void viewDevice()
        {
            if (_deviceTreeView != null && _deviceTreeView.SelectedTreeNode != null)
            {
                DeviceTreeModel device = _deviceTreeView.SelectedTreeNode;

                MainWindow.Instance.ShowDeviceCrudPanel = false;
                MainWindow.Instance.viewDeviceTabControl.showDevice(device);
            }
        }

        #endregion

        public void UpdateTree()
        {
            // clear the tree
            /*ListDeviceTreeModel.Clear();

            foreach (Device device in ConfigurationStore.getInstance().ConfigurationList)
            {

                EnumConfigurationType configType = ((Configuration)device).ConfigurationType;
                if (device.ParentID >= 0)
                {
                    if (SelectTreeViewItem(tree.Items, device.ParentID.ToString()) != null)
                    {
                        ((TreeViewItem)tree.SelectedItem).Items.Add(TreeViewWithIcons.createTreeViewItem(device.DeviceId.ToString(), device.DeviceName, ConfigTypeToImageSourceConverter.convert(configType)));
                    }
                }
                else
                {
                    // for first root node
                    tree.Items.Add(TreeViewWithIcons.createTreeViewItem(device.DeviceId.ToString(), device.DeviceName, ConfigTypeToImageSourceConverter.convert(configType)));
                }
            }*/
        }
    }
}
