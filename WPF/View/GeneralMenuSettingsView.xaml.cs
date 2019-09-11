﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.ViewModel;

namespace WPF.View
{
    /// <summary>
    /// Interaction logic for GeneralMenuSettingsView.xaml
    /// </summary>
    public partial class GeneralMenuSettingsView : UserControl
    {
        public GeneralMenuSettingsView()
        {
            InitializeComponent();
        }

        public GeneralMenuSettingsViewModel GeneralMenuSettingsViewModel => DataContext as GeneralMenuSettingsViewModel;

        private async void BtnSaveMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            await GeneralMenuSettingsViewModel.AddMenuItem();
        }

        private void BtnCancelMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}