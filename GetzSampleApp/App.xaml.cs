using GetzSampleApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GetzSampleApp
{
    public partial class App : Application
    {
        public App()
        {
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjk2ODE5QDMxMzgyZTMyMmUzMGpGcXRVS0lURHk1QjYvUzNxM1hYYThOK21xWmtlMTFiNmV3M2RVelM1MVk9");

            InitializeComponent();

            MainPage = new NavigationPage(new PatientInformation());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }


    }
}
