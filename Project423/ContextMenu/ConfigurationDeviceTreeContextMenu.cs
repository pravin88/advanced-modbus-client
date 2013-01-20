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

        #region /****************************** Context menu **********************************/

        private void ContextMenuOpened_Click(object sender, RoutedEventArgs e)
        {
            addDevice.IsEnabled = false;
            addFolder.IsEnabled = false;
            delete.IsEnabled = false;
            viewDevice.IsEnabled = false;


            if (MainWindow.Instance.DeviceTree != null && MainWindow.Instance.DeviceTree.SelectedTreeNode != null)
            {
                int deviceId = int.Parse(MainWindow.Instance.DeviceTree.SelectedTreeNode.Tag.ToString());
                Configuration configuration = ConfigurationStore.getInstance().getConfiguration(deviceId);
                
                if (configuration.ConfigurationType == EnumConfigurationType.MyComputer)
                {
                    addDevice.IsEnabled = true;
                    addFolder.IsEnabled = true;
                }
                else if (configuration.ConfigurationType == EnumConfigurationType.Folder )
                {
                    delete.IsEnabled = true;

                    addDevice.IsEnabled = true;
                    addFolder.IsEnabled = true;
                }
                else if (configuration.ConfigurationType == EnumConfigurationType.RegisterGroup)
                {
                    delete.IsEnabled = true;
                    viewDevice.IsEnabled = true;
                }
                
            }

        }


        private void AddNewDevice_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.ShowCrudDevice = true;
        }

        private void AddNewFolder_Click(object sender, RoutedEventArgs e)
        {

            MainWindow.Instance.ShowCrudFolder = true;
        }

        private void DeleteDevice_Click(object sender, RoutedEventArgs e)
        {
            int selectedNode = int.Parse(MainWindow.Instance.DeviceTree.SelectedTreeNode.Tag.ToString());

            ConfigurationStore.getInstance().deleteConfiguration(selectedNode);

            MainWindow.Instance.DeviceTree.updateTree();
        }

        private void ViewDevice_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.Instance.DeviceTree != null && MainWindow.Instance.DeviceTree.SelectedTreeNode != null)
            {
                int deviceId = int.Parse(MainWindow.Instance.DeviceTree.SelectedTreeNode.Tag.ToString());
                Configuration configuration = ConfigurationStore.getInstance().getConfiguration(deviceId);

                MainWindow.Instance.ShowDeviceCrudPanel = false;
                MainWindow.Instance.viewDeviceTabControl.showDevice(configuration);
            }
        }

        #endregion
    }
}
