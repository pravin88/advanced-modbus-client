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
        ConfigurationStore _configurationStore;
        public DeviceTree()
        {
            _configurationStore = ConfigurationStore.getInstance();
            InitializeComponent();

            initTreeWithRoot();
        }

        private void initTreeWithRoot()
        {
            Configuration configuration = new Configuration()
            {
                ParentID = 0,
                DeviceId = 0,
                DeviceName = "My Computer",
                ConfigurationType = EnumConfigurationType.MyComputer,
                RegisterGroup = null 
            };
           
            _configurationStore.addConfiguration(configuration);

            updateTree();
        }

        private void updateTree()
        {
            // clear the tree
            tree.Items.Clear();

            foreach (Device device in _configurationStore.ConfigurationList)
            {
                EnumConfigurationType configType = ((Configuration)device).ConfigurationType;
                if (device.ParentID > 0)
                {
                    if (SelectTreeViewItem(tree.Items, device.ParentID.ToString()) != null)
                    {
                        ((TreeViewItem)tree.SelectedItem).Items.Add(TreeViewWithIcons.createTreeViewItem(device.DeviceId.ToString(), device.DeviceName, CreateImage(getImageForConfigType(configType))));
                    }
                }
                else
                {
                    tree.Items.Add(TreeViewWithIcons.createTreeViewItem(device.DeviceId.ToString(), device.DeviceName, CreateImage(getImageForConfigType(configType))));
                }
            }

        }

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

        private void AddNewDevice_Click(object sender, RoutedEventArgs e)
        {
            Configuration configuration = new Configuration()
            {
                ParentID = 0,
                DeviceId = 0,
                DeviceName = "Test",
                ConfigurationType = EnumConfigurationType.RegisterGroup,
                RegisterGroup = new RegisterGroup()
                {
                    IpAddress = "192.168.8.45",
                    Port = 8080,
                    RegisterValueList = new List<RegisterValue>()
                            {
                                 new RegisterValue() { Address=123, Name="reg1", Value=2}, new RegisterValue() { Address=234, Name= "reg2", Value=4}
                            }
                }
            };



            _configurationStore.addConfiguration(configuration);

            updateTree();
        }




    }
}
