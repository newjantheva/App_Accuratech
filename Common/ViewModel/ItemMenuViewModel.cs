﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Common.ViewModel
{
    public class ItemMenuViewModel : INotifyPropertyChanged
    {
        private ICollection<MenuItemEntity> _menuItemsCollection;

        public ICollection<MenuItemEntity> MenuItemsCollection
        {
            get { return _menuItemsCollection; }
            set
            {
                _menuItemsCollection = value;
                NotifyPropertyChanged();
            }
        }

        private ICollection<SubItemEntity> _subMenuItemsCollection;

        public ICollection<SubItemEntity> SubMenuItemsCollection
        {
            get { return _subMenuItemsCollection; }
            set
            {
                _subMenuItemsCollection = value;
                NotifyPropertyChanged();
            }
        }

        public async Task Reset()
        {
            MenuItemsCollection = await MenuItemProcessor.LoadMenus();
            SubMenuItemsCollection = await SubItemProcessor.LoadSubMenus();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
