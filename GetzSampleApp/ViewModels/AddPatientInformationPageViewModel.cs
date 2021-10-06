using GetzSampleApp.AppValues;
using GetzSampleApp.Models;
using GetzSampleApp.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GetzSampleApp.ViewModels
{
    public class AddPatientInformationPageViewModel : BaseViewModel
    {
        DataSync syncData = new DataSync();

        Patient patientObj = new Patient();
        DateTime maxdob = new DateTime();
        DateTime seldob = new DateTime();
        Boolean boolIsAdd;
        Boolean notBoolIsAdd;
        string btnText = string.Empty;
        string btnTextDelete = string.Empty;
        string pageTitle = string.Empty;
        public DateTime MaxDob
        {
            get { return maxdob; }
            set { SetProperty(ref maxdob, value); }
        }
        public Boolean EnableUpdateDelete
        {
            get { return boolIsAdd; }
            set { SetProperty(ref boolIsAdd, value); }
        }
        public Boolean NotEnableUpdateDelete
        {
            get { return notBoolIsAdd; }
            set { SetProperty(ref notBoolIsAdd, value); }
        }
        public DateTime SelDob
        {
            get { return seldob; }
            set { SetProperty(ref seldob, value); }
        }
        public Patient Patients
        {
            get { return patientObj; }
            set { SetProperty(ref patientObj, value); }
        }
        public string BtnAddPatientText
        {
            get { return btnText; }
            set { SetProperty(ref btnText, value); }
        }
        public string BtnDelPatientText
        {
            get { return btnTextDelete; }
            set { SetProperty(ref btnTextDelete, value); }
        }
        public string PageTitle
        {
            get { return pageTitle; }
            set { SetProperty(ref pageTitle, value); }
        }
        public Patient updateDeleteObj = new Patient();

        public AddPatientInformationPageViewModel(Boolean IsAdd, Object obj) {
            EnableUpdateDelete = !IsAdd;
            NotEnableUpdateDelete = IsAdd;

            PlaceholderId = AppString.PlaceholderId;
            PlaceholderFirstName = AppString.PlaceholderFirstName;
            PlaceholderLastName = AppString.PlaceholderLastName;
            LblDob = AppString.LblDob;
            LblGender = AppString.LblGender;
            BtnAddPatientColor = ButtonColor.BtnGreen;
            BtnDelete = ButtonColor.BtnRed;
            BtnAddPatientText = (EnableUpdateDelete ? AppString.BtnUpdateRecord : AppString.BtnSaveRecord);
            BtnDelPatientText = AppString.BtnDelRecord;

            PageTitle = (EnableUpdateDelete ? AppString.PatientDataTitleUpdateDelete : AppString.PatientDataTitleAdd);

            Patients = new Patient();

            Patients.PatientId = "";
            Patients.PatientFirstName = "";
            Patients.PatientLastName = "";
            Patients.PatientGender = "";

            SelDob = DateTime.Now.Date;
            MaxDob = DateTime.Now.Date;

            try {
                if (obj != null) 
                {
                    Patients = obj as Patient;
                    updateDeleteObj = Patients;
                    SelDob = DateTime.Parse(Patients.PatientBirthday);
                }
               
            }
            catch { }       
        }

        public async System.Threading.Tasks.Task<bool> AddPatientAsync()
        {
            Patients.PatientBirthday = SelDob.Date.ToString("MM/dd/yyyy");
            Patients.PatientId = Patients.PatientId.ToUpper();

            if (!EnableUpdateDelete)
            {
                if (!new DatabaseHandler().DoesIdExistAsync(Patients.PatientId))
                {
                    new DatabaseHandler().SaveItemAsync(Patients);
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                new DatabaseHandler().SaveItemAsync(Patients);
                return true;
            }
            
            return false;
        }

        public async System.Threading.Tasks.Task DeletePatientAsync() {
            await new DatabaseHandler().DeleteItemAsync(updateDeleteObj);
            syncData.DeletePatient(updateDeleteObj);
        }
    }
}
