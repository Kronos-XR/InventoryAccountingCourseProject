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
    public partial class EditInventoryPage : ContentPage
    {
        public EditInventoryPage()
        {
            InitializeComponent();
            EntrId.Text = Convert.ToString(AppData.Id);
            EntrName.Text = AppData.Name;
            EntrQuantity.Text = Convert.ToString(AppData.Quantity);
            EntrIdCategory.Text = Convert.ToString(AppData.IdCategory);

        }
        private async void btnSave_Clicked(object sender, EventArgs e)
        {

            if (EntrId.Text != "" || EntrName.Text != "" || EntrQuantity.Text != "" || EntrIdCategory.Text != "")
            {
                if (!await Classes.RequestTasks.PutInventory(Convert.ToInt32(EntrId.Text), EntrName.Text, Convert.ToInt32(EntrQuantity.Text), Convert.ToInt32(EntrIdCategory.Text)))
                {
                    await DisplayAlert("ERROR", "Ошибка при добавлении", "ладн :(");
                }
                await Navigation.PushAsync(new Pages.Products());
            }
        }

        private async void btnUndo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.Products());
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Allert", "Вы действительно хотите удалить?", "ДА", "НЕТ"))
            {
                await RequestTasks.DeleteInventory(AppData.Id);
                await Navigation.PushAsync(new Pages.Products());
            }
        }
    }
}