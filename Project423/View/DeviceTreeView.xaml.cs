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
using System.IO;

namespace Project423
{
    /// <summary>
    /// Interaction logic for DeviceTree.xaml
    /// </summary>
    public partial class DeviceTreeView : UserControl
    {
        #region /**************************** variables **************************/


        // Stores the last node selected while clicking in the treeview, contains "null" if nothing is selected
        DeviceTreeModel _selectedTreeNode = null;
        public DeviceTreeModel SelectedTreeNode
        {
            get
            {
                return _selectedTreeNode;
            }
        }

        #endregion

        #region /*********************** initialize ***************************************/

        public DeviceTreeView()
        {
            InitializeComponent();

            // call dummy mouse down to disable the context menus
            tree_MouseDown(null, null);

            DeviceTreeViewModel dtvm = new DeviceTreeViewModel();
            dtvm.init(this);
            DataContext = dtvm;

            contextMenu.init(this);
        }
        

        #endregion

        #region /********************************* Tree Select & Update ************************************/

        public void updateTree()
        {
            List<DeviceTreeModel> t = ((DeviceTreeViewModel)DataContext).ListDeviceTreeModel.ToList();
            ((DeviceTreeViewModel)DataContext).ListDeviceTreeModel = t;

        }
        #endregion

        #region /******************* event handlers **********************************/

        /// <summary>
        /// Called when any mouse click is captured in the tree pane
        /// Controls the Context menu according to the node selected
        /// </summary>
        private void tree_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _selectedTreeNode = (DeviceTreeModel)tv.SelectedItem;

            contextMenu.updateMenuItemStatus();
        }

        #endregion


    }
}


 
 
