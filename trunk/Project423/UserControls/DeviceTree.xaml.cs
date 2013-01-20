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
    public partial class DeviceTree : UserControl
    {
        #region /**************************** variables **************************/

        // Stores the singleton instance of configuraiton store
        ConfigurationStore _configurationStore;

        // Stores the last node selected while clicking in the treeview, contains "null" if nothing is selected
        TreeViewWithIcons _selectedTreeNode = null;
        public TreeViewWithIcons SelectedTreeNode
        {
            get
            {
                return _selectedTreeNode;
            }
        }

        #endregion

        #region /*********************** initialize ***************************************/

        public DeviceTree()
        {
            _configurationStore = ConfigurationStore.getInstance();
            InitializeComponent();

            initTreeWithRoot();

            // call dummy mouse down to disable the context menus
            tree_MouseDown(null, null);
        }
        
        private void initTreeWithRoot()
        {
            Configuration configuration = new Configuration()
            {
                ParentID = -1,
                DeviceId = 0,
                DeviceName = "My Computer",
                ConfigurationType = EnumConfigurationType.MyComputer,
                RegisterGroup = null 
            };
           
            _configurationStore.addConfiguration(configuration);

            updateTree();
        }

        #endregion

        #region /********************************* Tree Select & Update ************************************/

        /// <summary>
        /// Selects the tree view item.
        /// </summary>
        private TreeViewWithIcons SelectTreeViewItem(ItemCollection Collection, String Value)
        {
            if (Collection == null) return null;
            foreach (TreeViewWithIcons Item in Collection)
            {
                /// Find in current
                if (Item.Tag.Equals(Value))
                {
                    Item.IsSelected = true;
                    return Item;
                }
                /// Find in Childs
                if (Item.Items != null)
                {
                    TreeViewWithIcons childItem = this.SelectTreeViewItem(Item.Items, Value);
                    if (childItem != null)
                    {
                        Item.IsExpanded = true;
                        return childItem;
                    }
                }
            }
            return null;
        }

        public void updateTree()
        {
            // clear the tree
            tree.Items.Clear();

            foreach (Device device in _configurationStore.ConfigurationList)
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
            }

        }

        #endregion

        #region /******************* event handlers **********************************/

        /// <summary>
        /// Called when any mouse click is captured in the tree pane
        /// Controls the Context menu according to the node selected
        /// </summary>
        private void tree_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _selectedTreeNode = (TreeViewWithIcons)tree.SelectedItem;
        }

        #endregion


    }
}


 
 
