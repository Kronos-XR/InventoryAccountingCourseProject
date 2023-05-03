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
    public partial class CategoryPage : ContentPage
    {
        public CategoryPage()
        {
            InitializeComponent();
            LvData.ItemsSource = RequestTasks.GetCategory().Result;
            if (AppData.UserRole == 1)
            {
                ButtonShowUsers.IsVisible = true;
                ButtonShowRole.IsVisible = true;
            }
        }

        private async void ButtonAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.AddCategoryPage());
        }
        private async void ListLVData_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = LvData.SelectedItem as Category;
            AppData.Id = item.Id;
            AppData.CategoryName = item.CategoryName;
            await Navigation.PushAsync(new Pages.EditCategoryPage());
        }

        private async void ButtonShowInventory_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.Products());
        }

        private async void ButtonShowRole_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.RolePage());
        }

        private async void ButtonShowUsers_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.UsersPage());
        }
    }
}