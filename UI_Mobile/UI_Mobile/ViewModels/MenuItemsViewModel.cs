﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Common;
using Common.Services;
using UI_Mobile.Annotations;
using Xamarin.Forms;

namespace UI_Mobile.ViewModels
{
    public class MenuItemsViewModel : INotifyPropertyChanged
    {
        private readonly MenuItemDataStore _dataStore;
        private ObservableCollection<MenuItemEntityModel> _items;
        private MenuItemEntityModel _menuItemEntityModel;
        private ICollection<MenuItemEntityModel> _menuItemsCollection;
        private ICollection<SubItemEntityModel> _subItemsCollection;
        MenuItemDataStore menuItemDataStore = new MenuItemDataStore();
        FieldItemDataStore fieldItemDataStore = new FieldItemDataStore();


        public ObservableCollection<MenuItemEntityModel> Items
        {
            get => _items;
            set
            {
                _items = value;
                NotifyPropertyChanged();
            }
        }

        public MenuItemEntityModel MenuItemEntityModel
        {
            get => _menuItemEntityModel;
            set
            {
                _menuItemEntityModel = value;
                NotifyPropertyChanged();
            }
        }

        public ICollection<MenuItemEntityModel> MenuItemsCollection
        {
            get => _menuItemsCollection;
            set
            {
                _menuItemsCollection = value;
                NotifyPropertyChanged();
            }
        }

        public ICollection<SubItemEntityModel> SubItemsCollection
        {
            get => _subItemsCollection;
            set
            {
                _subItemsCollection = value;
                NotifyPropertyChanged();
            }
        }

        public MenuItemsViewModel()
        {
            _dataStore = new MenuItemDataStore();
            Items = new ObservableCollection<MenuItemEntityModel>();
        }

        public void Reset(MenuItemEntityModel menuItemEntityModel)
        {
            MenuItemEntityModel = menuItemEntityModel;
        }
        public async Task Reset()
        {
            MenuItemsCollection = await menuItemDataStore.GetItemsAsync();
            SubItemsCollection = await fieldItemDataStore.GetItemsAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
