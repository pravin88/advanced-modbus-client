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
    /// Interaction logic for CrudFolder.xaml
    /// </summary>
    public partial class CrudFolder : UserControl
    {
        ConfigurationStore _configurationStore = ConfigurationStore.getInstance();

        public CrudFolder()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            int parentId = int.Parse(MainWindow.Instance.DeviceTree.SelectedTreeNode.Tag.ToString());

            Configuration configuration = new Configuration()
            {
                ParentID = parentId,
                DeviceId = ConfigurationStore.nextAvailableDeviceId(),
                DeviceName = folderName.Text,
                ConfigurationType = EnumConfigurationType.Folder,
                RegisterGroup = null
            };
            
            _configurationStore.addConfiguration(configuration);

            MainWindow.Instance.DeviceTree.updateTree();
            MainWindow.Instance.ShowCrudFolder = false;

        }
    }
}
