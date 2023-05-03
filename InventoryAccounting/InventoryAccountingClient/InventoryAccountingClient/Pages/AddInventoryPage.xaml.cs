using InventoryAccountingWebApi.Models;
using Newtonsoft.Json;
using RestSharp;
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
    public partial class AddInventoryPage : ContentPage
    {
        public AddInventoryPage()
        {
            InitializeComponent();
        }
        private async void btnSave_Clicked(object sender, EventArgs e)
        {          
            if (EntrName.Text != "" || EntrQuantity.Text != "" || EntrIdCategory.Text != "")
            {
                if (!await Classes.RequestTasks.PostInventory(EntrName.Text, Convert.ToInt32(EntrQuantity.Text), Convert.ToInt32(EntrIdCategory.Text))) 
                {
                    await DisplayAlert("ERROR", "Ошибка при добавлении", "ладн :(" );
                }
                await Navigation.PushAsync(new Pages.Products());
            }
        }
    }
}