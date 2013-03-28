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

        private List<Configuration> deviceListLoadedInTab = new List<Configuration>();

        #endregion
        
        public ViewDeviceTabControl()
        {
            InitializeComponent();
        }

        #region /********************** Public methods *********************/
        
        public void showDevice(Configuration device)
        {
            int tabIndex = -1;
            // check if device already found in list
            
            if ( (tabIndex = getTabItemIndexFromDeviceId(device)) == -1 )
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

        private int getTabItemIndexFromDeviceId(Configuration device)
        {
            for (int i = 0; i < registerViewTabControl.Items.Count; i++)
            {
                if (((TabItem)registerViewTabControl.Items[i]).Tag != null && ((TabItem)registerViewTabControl.Items[i]).Tag == device)
                {
                    return i;
                }
            }

            return -1;
        }

        private int createNewTabItem(Configuration device)
        {
            TabItem newTabItem = new TabItem()
                                {
                                    Header = device.DeviceName,
                                    Tag = device,
                                    Content = new RegisterGroupView(device)
                                };

            return registerViewTabControl.Items.Add(newTabItem);

        }

        #endregion
    }
}
