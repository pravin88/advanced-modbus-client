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
    /// Interaction logic for ViewDeviceTabControl.xaml
    /// </summary>
    public partial class ViewDeviceTabControl : UserControl
    {
        #region /*********************** private variables ***********************/

        private List<Device> deviceListLoadedInTab = new List<Device>();

        #endregion
        
        public ViewDeviceTabControl()
        {
            InitializeComponent();
        }

        #region /********************** Public methods *********************/
        
        public void showDevice(Device device)
        {
            int tabIndex = -1;
            // check if device already found in list
            
            if ( (tabIndex = getTabItemIndexFromDeviceId(device.DeviceId)) == -1 )
            {
                // If the list doesn't contain any tabItem for the specified deviceID,
                // create a new tabitem and make it visible                
                tabIndex = createNewTabItem(device);
            }

            if (tabIndex == -1) return;

            registerViewTabControl.SelectedIndex = tabIndex;

        }

        #endregion

        #region /***************** Private methods ***********************/

        private int getTabItemIndexFromDeviceId(int deviceId)
        {
            for (int i = 0; i < registerViewTabControl.Items.Count; i++)
            {
                if (((TabItem)registerViewTabControl.Items[i]).Tag != null && (int)((TabItem)registerViewTabControl.Items[i]).Tag == deviceId)
                {
                    return i;
                }
            }

            return -1;
        }

        private int createNewTabItem(Device device)
        {
            TabItem newTabItem = new TabItem()
                                {
                                    Header = device.DeviceName,
                                    Tag = device.DeviceId,
                                    Content = new RegisterValueControl(device.DeviceId)
                                };

            return registerViewTabControl.Items.Add(newTabItem);

        }

        #endregion
    }
}
