using InventoryAccountingClient.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryAccountingClient.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthPage : ContentPage
    {
        public AuthPage()
        {
            InitializeComponent();
        }
        public async Task GetPost()
        {
            using (RestClient client = new RestClient())
            {
                var request = new RestRequest("http://www.inventoryaccounting.somee.com/api/authUser/auth", Method.Post);
                var body = new AuthUser
                {
                    Login = EntrLog.Text,
                    Password = EntrPass.Text
                };
                var bodyy = JsonConvert.SerializeObject(body);
                request.AddBody(bodyy);
                RestResponse response = await client.ExecuteAsync(request);
                if (response.IsSuccessStatusCode)
                {                  
                    Classes.AppData.User = response.Content;
                    Classes.AppData.UserId = Convert.ToInt32(response.Content);

                    await Navigation.PushAsync(new Pages.Products());
                }
                else
                {
                    await DisplayAlert("","Пароль или логин неверны", "Ок");
                }
            }
        }

        private async void ButtonAuth_Clicked(object sender, EventArgs e)
        {
            await GetPost();
        }
    }
}