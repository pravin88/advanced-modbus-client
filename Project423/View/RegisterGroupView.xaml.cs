﻿using System;
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
    /// Interaction logic for registerValueControl.xaml
    /// </summary>
    public partial class RegisterGroupView : UserControl
    {


        public RegisterGroupView(Configuration selectedDevice)
        {

            InitializeComponent();


            DataContext = new RegisterGroupViewModel(selectedDevice.RegisterGroup);


        }
    }
}
