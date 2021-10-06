using GetzSampleApp.Models;
using GetzSampleApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GetzSampleApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PatientInformation : ContentPage
    {
        public PatientInformationViewModel viewModel;
        public PatientInformation()
        {
            InitializeComponent();

            BindingContext = viewModel = new PatientInformationViewModel();

            Appearing += (s, e) =>
            {
                viewModel.PopulateListAsync();
            };

        }

        private async void BtnAddNew_Clicked(object sender, EventArgs e)
        {
            NavigatePage(true,null);
        }

        public async void NavigatePage(Boolean IsAdd,Object obj) {
            try
            {
                await Navigation.PushAsync(new AddPatientInformationPage(IsAdd,obj));
            }
            catch { }
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Patient)e.SelectedItem;
            NavigatePage(false, obj);
        }
    }
}