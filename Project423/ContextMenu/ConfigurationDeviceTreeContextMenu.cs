using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;


namespace Project423
{
    class ConfigurationDeviceTreeContextMenu : ContextMenu
    {
        
        private MenuItem addDevice;
        private MenuItem addFolder;
        private MenuItem delete;
        private MenuItem viewDevice;


        private DeviceTreeView _deviceTreeView;

        public ConfigurationDeviceTreeContextMenu()
        {                    
            addDevice = new MenuItem();
            addDevice.Header = "Add Device";
            addDevice.Click += new RoutedEventHandler(AddNewDevice_Click);
            AddChild(addDevice);

            addFolder = new MenuItem();
            addFolder.Header = "Add Folder";
            addFolder.Click += new RoutedEventHandler(AddNewFolder_Click);
            AddChild(addFolder);

            delete = new MenuItem();
            delete.Header = "Delete";
            delete.Click += new RoutedEventHandler(DeleteDevice_Click);
            AddChild(delete);

            viewDevice = new MenuItem();
            viewDevice.Header = "View Device";
            viewDevice.Click += new RoutedEventHandler(ViewDevice_Click);
            AddChild(viewDevice);

            this.Opened += new RoutedEventHandler(ContextMenuOpened_Click);
        }

        public void init(DeviceTreeView deviceTreeView)
        {
            _deviceTreeView = deviceTreeView;
        }
        #region /****************************** Context menu **********************************/

        /// <summary>
        /// Event handler when loading a new context menu.
        /// Determines which menu items are enables / disabled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuOpened_Click(object sender, RoutedEventArgs e)
        {
            addDevice.IsEnabled = false;
            addFolder.IsEnabled = false;
            delete.IsEnabled = false;
            viewDevice.IsEnabled = false;
            
            updateMenuItemStatus();

        }

        public void updateMenuItemStatus()
        {
            if (_deviceTreeView != null && _deviceTreeView.SelectedTreeNode != null)
            {
                DeviceTreeModel dtm = _deviceTreeView.SelectedTreeNode;

                // Enable menu items for configuration type root
                if (dtm.ConfigurationType == EnumConfigurationType.MyComputer)
                {
                    addDevice.IsEnabled = true;
                    addFolder.IsEnabled = true;
                }
                // enable menu items for configuration type folder
                else if (dtm.ConfigurationType == EnumConfigurationType.Folder)
                {
                    delete.IsEnabled = true;

                    addDevice.IsEnabled = true;
                    addFolder.IsEnabled = true;
                }
                // enable menu utems for configuration type register group
                else if (dtm.ConfigurationType == EnumConfigurationType.RegisterGroup)
                {
                    delete.IsEnabled = true;
                    viewDevice.IsEnabled = true;
                }

            }
        }


        private void AddNewDevice_Click(object sender, RoutedEventArgs e)
        {
            ((DeviceTreeViewModel)_deviceTreeView.DataContext).AddDevice();

        }

        private void AddNewFolder_Click(object sender, RoutedEventArgs e)
        {
            ((DeviceTreeViewModel)_deviceTreeView.DataContext).AddFolder();
        }

        private void DeleteDevice_Click(object sender, RoutedEventArgs e)
        {
            ((DeviceTreeViewModel)_deviceTreeView.DataContext).Delete();
        }

        private void ViewDevice_Click(object sender, RoutedEventArgs e)
        {
            ((DeviceTreeViewModel)_deviceTreeView.DataContext).viewDevice();
        }

        #endregion
    }
}
