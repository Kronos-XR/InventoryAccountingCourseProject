using InventoryAccountingClient.Classes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryAccountingClient.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditCategoryPage : ContentPage
	{
		public EditCategoryPage ()
        {
			InitializeComponent ();
            EntrId.Text = Convert.ToString(AppData.Id);
            EntrName.Text = AppData.CategoryName;
        }
        private async void btnSave_Clicked(object sender, EventArgs e)
        {

            if (EntrId.Text != "" || EntrName.Text != "")
            {
                if (!await Classes.RequestTasks.PutCategory(Convert.ToInt32(EntrId.Text),EntrName.Text))
                {
                    await DisplayAlert("ERROR", "Ошибка при добавлении", "ладн :(");
                }
                await Navigation.PushAsync(new Pages.CategoryPage());
            }
        }
        private async void btnUndo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.CategoryPage());
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Allert", "Вы действительно хотите удалить?", "ДА", "НЕТ"))
            {
                await RequestTasks.DeleteCategory(AppData.Id);
                await Navigation.PushAsync(new Pages.CategoryPage());
            }
        }
    }
}