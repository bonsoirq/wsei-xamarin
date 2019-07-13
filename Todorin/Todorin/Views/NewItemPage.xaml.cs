using System;
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
                TintColor = System.Drawing.Color.Black.ToArgb().ToString(),
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

			((NavigationPage)this.Parent).BarBackgroundColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Item.TintColor));
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
			Item.TintColor = ((System.Drawing.Color)button.BackgroundColor).ToArgb().ToString();
			((NavigationPage)this.Parent).BarBackgroundColor = button.BackgroundColor;
		}

	}
}