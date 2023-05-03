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
    public partial class AddUsersPage : ContentPage
    {
        public AddUsersPage()
        {
            InitializeComponent();
            
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            if (EntrLogin.Text != "" || EntrPassword.Text != "" || EntrIdRole.Text != "")
            {
                if (!await Classes.RequestTasks.PostUsers(EntrLogin.Text, EntrPassword.Text, Convert.ToInt32(EntrIdRole.Text)))
                {
                    await DisplayAlert("ERROR", "Ошибка при добавлении", "ладн :(");
                }
                await Navigation.PushAsync(new Pages.CategoryPage());
            }
        }
    }
}