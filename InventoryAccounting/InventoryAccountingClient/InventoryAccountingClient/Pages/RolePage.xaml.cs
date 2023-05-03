using InventoryAccountingClient.Classes;
using InventoryAccountingWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryAccountingClient.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RolePage : ContentPage
    {
        public RolePage()
        {
            InitializeComponent();
            LvData.ItemsSource = RequestTasks.GetRole().Result;
            if (AppData.UserRole == 1)
            {
                ButtonShowUsers.IsVisible = true;
            }
        }
        private async void ButtonAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.AddRolePage());
        }

        private async void ListLVData_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = LvData.SelectedItem as Role;
            AppData.Id = item.Id;
            AppData.RoleName = item.RoleName;
            await Navigation.PushAsync(new Pages.EditRolePage());
        }

        private async void ButtonShowInventory_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.Products());
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