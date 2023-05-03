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
    public partial class UsersPage : ContentPage
    {
        public UsersPage()
        {
            InitializeComponent();
            LvData.ItemsSource = RequestTasks.GetUsers().Result;
            if (AppData.UserRole == 1)
            {
                ButtonShowRole.IsVisible = true;
            }
        }

        private async void ButtonAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.AddUsersPage());
        }

        private async void ListLVData_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = LvData.SelectedItem as User;
            AppData.Id = item.Id;
            AppData.Login = item.Login;
            AppData.Password = item.Password;
            AppData.IdRole = item.IdRole;
            await Navigation.PushAsync(new Pages.EditUserPage());
        }

        private async void ButtonShowRole_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.RolePage());
        }

        private async void ButtonInventory_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.Products());
        }

        private async void ButtonShowCategory_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.CategoryPage());
        }
    }
}