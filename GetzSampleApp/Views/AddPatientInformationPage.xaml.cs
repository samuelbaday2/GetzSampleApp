using GetzSampleApp.AppValues;
using GetzSampleApp.Utility;
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
    public partial class AddPatientInformationPage : ContentPage
    {
        AddPatientInformationPageViewModel viewModel;
     
        public AddPatientInformationPage(bool IsAdd,Object obj)
        {
            InitializeComponent();
            BindingContext = viewModel = new AddPatientInformationPageViewModel(IsAdd, obj);
        }

        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            if (viewModel.Patients.PatientId.Length == 0)
            {
                DisplayAlert(AppString.MissingDataInput, AppString.MissingDataMessage + viewModel.PlaceholderId,AppString.ConfirmChoice);
            }
            else if (viewModel.Patients.PatientFirstName.Length == 0)
            {
                DisplayAlert(AppString.MissingDataInput, AppString.MissingDataMessage + viewModel.PlaceholderFirstName, AppString.ConfirmChoice);
            }
            else if (viewModel.Patients.PatientLastName.Length == 0)
            {
                DisplayAlert(AppString.MissingDataInput, AppString.MissingDataMessage + viewModel.PlaceholderLastName, AppString.ConfirmChoice);
            }
            else if (viewModel.Patients.PatientGender.Length == 0)
            {
                DisplayAlert(AppString.MissingDataInput, AppString.MissingDataMessage + viewModel.LblGender, AppString.ConfirmChoice);
            }
            else 
            {
                if (viewModel.EnableUpdateDelete)
                {
                    CallUpdateAlertAsync();
                }
                else
                {
                    CallAddAlertAsync();
                }
            }       
           
        }

        private void BtnDel_Clicked(object sender, EventArgs e)
        {
            CallDeletionAlertAsync();
        }

        public async Task CallDeletionAlertAsync() {
            var result = await this.DisplayAlert(AppString.ConfirmDeletion, AppString.ConfirmDeletionMessage, AppString.ConfirmChoice, AppString.ConfirmCancel);
            if (result)
            {
                await viewModel.DeletePatientAsync();
                await this.Navigation.PopAsync();
            }
        }

        public async Task CallUpdateAlertAsync()
        {
            var result = await this.DisplayAlert(AppString.ConfirmUpdate, AppString.ConfirmUpdateMessage, AppString.ConfirmChoice, AppString.ConfirmCancel);
            if (result)
            {
                await viewModel.AddPatientAsync();
                await this.Navigation.PopAsync();
            }
        }

        public async Task CallAddAlertAsync()
        {
            var result = await this.DisplayAlert(AppString.SaveRecord, AppString.SaveRecordMessage, AppString.ConfirmChoice, AppString.ConfirmCancel);
            if (result)
            {
                if (viewModel.AddPatientAsync().Result)
                {
                    await this.Navigation.PopAsync();
                }
                else {
                    await this.DisplayAlert(AppString.AlertExisting, AppString.AlertExistingMessage, AppString.ConfirmChoice);
                }
               
            }
        }
    }
}