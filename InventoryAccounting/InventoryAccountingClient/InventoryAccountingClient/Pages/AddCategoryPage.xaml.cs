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
    public partial class AddCategoryPage : ContentPage
    {
        public AddCategoryPage()
        {
            InitializeComponent();
        }
        private async void btnSave_Clicked(object sender, EventArgs e)
        {

            if (EntrName.Text != "")
            {
                if (!await Classes.RequestTasks.PostCategory(EntrName.Text))
                {
                    await DisplayAlert("ERROR", "Ошибка при добавлении", "ладн :(");
                }
                await Navigation.PushAsync(new Pages.CategoryPage());
            }
        }
    }
}