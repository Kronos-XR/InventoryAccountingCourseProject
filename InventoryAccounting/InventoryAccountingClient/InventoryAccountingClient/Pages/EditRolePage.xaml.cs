using InventoryAccountingClient.Classes;
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
    public partial class EditRolePage : ContentPage
    {
        public EditRolePage()
        {
            InitializeComponent();
            EntrId.Text =Convert.ToString(AppData.Id);
            EntrName.Text = AppData.RoleName;
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            if (EntrId.Text != "" || EntrName.Text != "")
            {
                if (!await Classes.RequestTasks.PutRole(Convert.ToInt32(EntrId.Text), EntrName.Text))
                {
                    await DisplayAlert("ERROR", "Ошибка при добавлении", "ладн :(");
                }
                await Navigation.PushAsync(new Pages.RolePage());
            }
        }
        private async void btnUndo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.RolePage());
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Allert", "Вы действительно хотите удалить?", "ДА", "НЕТ"))
            {
                await RequestTasks.DeleteRole(AppData.Id);
                await Navigation.PushAsync(new Pages.RolePage());
            }
        }
    }
}