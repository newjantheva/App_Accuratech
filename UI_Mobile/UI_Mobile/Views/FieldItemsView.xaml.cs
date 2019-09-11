﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.ViewModel;
using UI_Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UI_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FieldItemsView : ContentPage
    {
        public FieldItemsView(MenuItemEntityModel menuItemEntityModel)
        {
            InitializeComponent();
            var fieldItemsViewModel = new FieldItemsViewModel();
            fieldItemsViewModel.Reset(menuItemEntityModel);
            BindingContext = fieldItemsViewModel;
        }

        private async void SaveClicked(object sender, EventArgs e)
        {
            var subItems = ((ListView)SubItemsListView).ItemsSource;
            foreach (var item in subItems)
            {
                SubItemEntityModel subItemEntity = (SubItemEntityModel)item;
                var fieldItemViewModel = new FieldItemsViewModel(subItemEntity);
                await fieldItemViewModel.AddRegistrationValue((item as SubItemEntityModel)?.FieldValue);
            }
        }
    }
}