using GetzSampleApp.AppValues;
using GetzSampleApp.Models;
using GetzSampleApp.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace GetzSampleApp.ViewModels
{
    public class PatientInformationViewModel : BaseViewModel
    {
        ObservableCollection<Patient> patienList = new ObservableCollection<Patient>();
        DataSync dataSync = new DataSync();
        public ObservableCollection<Patient> PatientList
        {
            get { return patienList; }
            set { SetProperty(ref patienList, value); }
        }

        string btnText = string.Empty;
        string insText = string.Empty;
        Boolean instructionVisibility;
        public Boolean InstructionVisibility
        {
            get { return instructionVisibility; }
            set { SetProperty(ref instructionVisibility, value); }
        }
        public string BtnAddPatientText
        {
            get { return btnText; }
            set { SetProperty(ref btnText, value); }
        }
        public string LblListText
        {
            get { return insText; }
            set { SetProperty(ref insText, value); }
        }

        public PatientInformationViewModel() {
            BtnAddPatientText = AppString.BtnAddNewPatient;
            BtnAddPatientColor = ButtonColor.BtnGreen;
            PlaceholderId = AppString.PlaceholderId;
            PlaceholderFirstName = AppString.PlaceholderFirstName;
            PlaceholderLastName = AppString.PlaceholderLastName;
            LblDob = AppString.LblDob;
            LblGender = AppString.LblGender;

            LblListText = AppString.ListViewInstructions;

            //PopulateListAsync();

            MessagingCenter.Subscribe<object, Patient>(this, "Query", (sender, patient) => {           
                bool willAdd = true;
                foreach (Patient pt in PatientList) {
                    if (pt.PatientId.Equals(patient.PatientId)) {
                        willAdd = false;
                    }
                }

                if (willAdd) {
                    PatientList.Add(patient);
                }
            });
        }

        public async System.Threading.Tasks.Task PopulateListAsync() {
            List<Patient> list = await new DatabaseHandler().GetItemsAsync();
            PatientList = new ObservableCollection<Patient>();

            foreach (Patient obj in list) {
                PatientList.Add(obj);
                dataSync.AddPatient(obj);
            }

            dataSync.GetAllPatients();

            InstructionVisibility = PatientList.Count > 0;
        }
    }
}
