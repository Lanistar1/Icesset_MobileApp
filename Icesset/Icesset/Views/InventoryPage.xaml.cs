﻿using Icesset.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Icesset.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InventoryPage : ContentPage
    {
        public InventoryPage()
        {
            InitializeComponent();
            BindingContext = new InventoryViewModel(Navigation);

        }
    }
}