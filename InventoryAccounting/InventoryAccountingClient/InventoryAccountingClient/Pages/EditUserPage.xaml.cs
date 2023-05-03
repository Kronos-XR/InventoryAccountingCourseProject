using InventoryAccountingClient.Classes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryAccountingClient.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditUserPage : ContentPage
    {
        public EditUserPage()
        {
            InitializeComponent();
            EntrId.Text = Convert.ToString(AppData.Id);
            EntrLogin.Text = AppData.Login;
            EntrPassword.Text = AppData.Password;
            EntrIdRole.Text = Convert.ToString(AppData.IdRole);
        }
        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            if (EntrId.Text != "" || EntrLogin.Text != "" || EntrPassword.Text != "" || EntrIdRole.Text != "")
            {
                if (!await Classes.RequestTasks.PutUsers(Convert.ToInt32(EntrId.Text), EntrLogin.Text, EntrPassword.Text, Convert.ToInt32(EntrIdRole.Text)))
                {
                    await DisplayAlert("ERROR", "Ошибка при добавлении", "ладн :(");
                }
                await Navigation.PushAsync(new Pages.UsersPage());
            }
        }
        private async void btnUndo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.UsersPage());
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Allert", "Вы действительно хотите удалить?", "ДА", "НЕТ"))
            {
                await RequestTasks.DeleteUsers(AppData.Id);
                await Navigation.PushAsync(new Pages.UsersPage());
            }
        }
    }
}