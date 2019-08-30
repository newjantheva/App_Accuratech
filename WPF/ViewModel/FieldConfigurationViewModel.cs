﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.ViewModel;

namespace WPF.ViewModel
{
    public class FieldConfigurationViewModel
    {
        private readonly MenuItemEntity _parentMenuItem;
        private readonly SubItemEntity _parentSubItem;

        public FieldConfigurationViewModel(MenuItemEntity menuItem)
        {
            _parentMenuItem = menuItem;
        }

        public FieldConfigurationViewModel(SubItemEntity subItem)
        {
            _parentSubItem = subItem;
        }

        public string SubItemTitle { get; set; }


        public async Task AddField()
        {
            var subItem = new SubItemEntity() { Name = SubItemTitle, MenuItemId = _parentMenuItem.Id};
            await Processor.CreateFieldItem(subItem);
            NewSubItemCreated?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler NewSubItemCreated;
    }
}
