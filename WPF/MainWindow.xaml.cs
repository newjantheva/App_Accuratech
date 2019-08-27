﻿using Common;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
using Common.ViewModel;
using WPF.View;
using WPF.ViewModel;

namespace WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
             InitializeComponent();
            ApiHelper.InitializeClient();
            DataContextChanged += Reset;
            DataContext = new MainWindowViewModel();
        }

        private async void Reset(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (MainWindowViewModel != null) await MainWindowViewModel?.Reset();
        }

        MainWindowViewModel MainWindowViewModel => DataContext as MainWindowViewModel;

        private void ButtonPopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnAddMenu_Click(object sender, RoutedEventArgs e)
        {
            var menuConfigurationViewModel = new MenuConfigurationViewModel();
            menuConfigurationViewModel.NewMenuItemCreated += async (_, __) => await MainWindowViewModel?.Reset();
            var addNewMenuView = new MenuConfigurationView { DataContext = menuConfigurationViewModel };
            Main.Content = addNewMenuView;
        }
        private void BtnMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var menuConfigurationViewModel = new MenuConfigurationViewModel();
            var menuConfigurationView = new MenuConfigurationView{ DataContext = menuConfigurationViewModel};
            Main.Content = menuConfigurationView;
        }

        private void BtnFieldItem_OnClick(object sender, RoutedEventArgs e)
        {
            var button = (Button) sender;
            var menuItem = (MenuItemEntity) button.DataContext;
            var fieldConfigurationViewModel = new FieldConfigurationViewModel(menuItem);
            var fieldConfigurationView = new MenuConfigurationView {DataContext = fieldConfigurationViewModel};
            Main.Content = fieldConfigurationView;
        }

        private void AddNewField(object sender, RoutedEventArgs e)
        {
            var button = (Button) sender;
            var menuItem = (MenuItemEntity) button.DataContext;
            var fieldConfigurationViewModel = new FieldConfigurationViewModel(menuItem);
            fieldConfigurationViewModel.NewSubItemCreated += async (_, __) => await MainWindowViewModel?.Reset();
            var fieldConfigurationView = new FieldConfigurationView { DataContext = fieldConfigurationViewModel };
            Main.Content = fieldConfigurationView;
        }

        //private async void BtnDeleteMenuItem_Click(object sender, RoutedEventArgs e)
        //{
        //    var button = (Button)sender;
        //    var menuItem = (MenuItemEntity)button.DataContext;
        //    var menuConfigurationViewModel = new MenuConfigurationViewModel();


        //    var forLunch = new Task<Task>(async () => await MainWindowViewModel.Reset());

        //    // TODO: Make sure MainWindowViewModel is fully awaited
        //    menuConfigurationViewModel.MenuItemRemoved += (_,__) => forLunch.RunSynchronously();


        //    await menuConfigurationViewModel.DeleteMenuItem(menuItem);
        //    var lunchIsOver = await forLunch;
        //    await lunchIsOver;
        //}
        private async void BtnDeleteSubItem_OnClick(object sender, RoutedEventArgs e)
        {
            var button = (Button) sender;
//            await Processor.DeleteSubItem();
//            await MainWindowViewModel.Reset();
        }



    }
}
