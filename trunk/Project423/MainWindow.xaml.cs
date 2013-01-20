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

namespace Project423
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region /******************************** Properties *****************************/

        public DeviceTree DeviceTree
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
            }
        }

        public bool ShowCrudFolder
        {
            set
            {
                ShowDeviceCrudPanel = value;
                crudFodler.Visibility = value ? Visibility.Visible : Visibility.Hidden;                     
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

            _instance = this;

        }

        #endregion

        public void ViewDevice()
        {

        }
    }
}
