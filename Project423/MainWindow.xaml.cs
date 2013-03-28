using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace Project423
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region /******************************** Properties *****************************/

        public DeviceTreeView DeviceTree
        {
            get
            {
                return deviceTree;
            }
        }

        public ViewDeviceTabControl ViewDeviceTabControl
        {
            get
            {
                return viewDeviceTabControl;
            }
        }

        public bool ShowDeviceCrudPanel
        {
            set
            {
                deviceCrudPanels.Visibility = value?Visibility.Visible:Visibility.Hidden;
                crudFolder.Visibility = Visibility.Hidden;
                crudDevice.Visibility = Visibility.Hidden;
            }
        }

        public bool ShowCrudFolder
        {
            set
            {
                ShowDeviceCrudPanel = value;
                crudFolder.Visibility = value ? Visibility.Visible : Visibility.Hidden;                     
            }
        }

        public bool ShowCrudDevice
        {
            set
            {
                ShowDeviceCrudPanel = value;
                crudDevice.Visibility = value ? Visibility.Visible : Visibility.Hidden;                     
            }
        }

        #endregion


        #region /********************* Instance ********************************/

        static MainWindow _instance;
        public static MainWindow Instance
        {
            get
            {
                return _instance;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
            

            _instance = this;

        }

        #endregion

        private void saveConfig_clicked(object sender, RoutedEventArgs e)
        {
            DeviceTreeViewModel dtvm = (DeviceTreeViewModel)deviceTree.DataContext;
            string xmlConfig = XMLHelper<List<DeviceTreeModel>>.objectToXml(dtvm.ListDeviceTreeModel);
            XMLHelper<List<DeviceTreeModel>>.saveFile("config.xml", xmlConfig);
        }

        private void loadConfig_clicked(object sender, RoutedEventArgs e)
        {
            string xmlConfig = XMLHelper<List<DeviceTreeModel>>.readFile("config.xml");

            ((DeviceTreeViewModel)deviceTree.DataContext).ListDeviceTreeModel = XMLHelper<List<DeviceTreeModel>>.xmlToObject(xmlConfig);
        }

       
    }
}
