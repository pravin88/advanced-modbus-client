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
    public partial class CrudDevice : UserControl
    {
        ConfigurationStore _configurationStore = ConfigurationStore.getInstance();

        public CrudDevice()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            int parentId = int.Parse(MainWindow.Instance.DeviceTree.SelectedTreeNode.Tag.ToString());

            List<RegisterValue> registerValueList = new List<RegisterValue>();
            for(int i = 0; i < int.Parse(registerCount.Text); i++)
            {
                string name = (autoGenerateName.IsChecked==true)?deviceName.Text + "_reg_" + i:"";
                
                registerValueList.Add(new RegisterValue() 
                    { 
                        Address =  int.Parse(startingAddress.Text) + i,
                        Name = name,
                        Value = 0 
                    });
            }

            Configuration configuration = new Configuration()
            {
                ParentID = parentId,
                DeviceId = ConfigurationStore.nextAvailableDeviceId(),
                DeviceName = deviceName.Text,
                ConfigurationType = EnumConfigurationType.RegisterGroup,
                RegisterGroup = new RegisterGroup()
                {
                    IpAddress = deviceAddress.Text,
                    Port = int.Parse(devicePort.Text),
                    RegisterType = (EnumRegisterType)int.Parse(registerType.Text),
                    RegisterValueList = registerValueList
                }
            };
            

            _configurationStore.addConfiguration(configuration);

            MainWindow.Instance.DeviceTree.updateTree();
            MainWindow.Instance.ShowCrudDevice = false; 



        }
    }
}
