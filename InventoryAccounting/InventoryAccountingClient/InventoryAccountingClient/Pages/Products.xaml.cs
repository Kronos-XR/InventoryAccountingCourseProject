using InventoryAccountingClient.Classes;
using InventoryAccountingWebApi.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryAccountingClient.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Products : ContentPage
    {
        public Products()
        {
            InitializeComponent();

            LvData.ItemsSource = RequestTasks.GetInventory().Result;

            var idInventory = RequestTasks.GetUsers().Result;
            foreach (var item in idInventory)
            {
                if (item.Id == AppData.UserId)
                {
                    AppData.UserRole = item.IdRole;
                }
            }
            if (AppData.UserRole == 1)
            {
                ButtonShowUsers.IsVisible = true;
                ButtonShowRole.IsVisible = true;
            }
        }
        private async void ButtonAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.AddInventoryPage());
        }
        private async void ListLVData_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = LvData.SelectedItem as Inventory;
            AppData.Id = item.Id;
            AppData.Name = item.Name;
            AppData.Quantity = item.Quantity;
            AppData.IdCategory = item.IdCategory;

            await Navigation.PushAsync(new Pages.EditInventoryPage());
        }
        private async void ButtonShowRole_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.RolePage());
        }

        private async void ButtonShowUsers_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.UsersPage());
        }

        private async void ButtonShowCategory_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.CategoryPage());
        }
    }
}