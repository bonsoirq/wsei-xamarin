﻿using System;
using System.Diagnostics;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Todorin.Models;

namespace Todorin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }
        public int CornerRadius { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Item
            {
                TintColor = Color.Black,
                Text = "Item name",
                Description = "This is an item description."
            };

			switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    CornerRadius = 40;
                    break;
                default:
                    CornerRadius = 100;
                    break;
            }

            BindingContext = this;
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();

			((NavigationPage)this.Parent).BarBackgroundColor = Item.TintColor;
		}

		async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        void OnColorButton_Clicked(object sender, EventArgs e)
		{
			var button = sender as Button;
			Item.TintColor = button.BackgroundColor;
			((NavigationPage)this.Parent).BarBackgroundColor = Item.TintColor;
		}

	}
}