using Firebase.Database;
using Firebase.Database.Query;
using GetzSampleApp.Models;
using GetzSampleApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GetzSampleApp.Utility
{
    public class DataSync
    {
        private static FirebaseClient firebase = null;

        public DataSync() {
            firebase = new FirebaseClient("https://norpacfreshcatch.firebaseio.com/");
        }
        public async Task<List<Patient>> GetAllPatients()
        {
            List<Patient> list = new List<Patient>();
            var items = await firebase
               .Child("Patients")
               .OnceAsync<Patient>();

            foreach (var item in items)
            {
                Console.Write("fire_return" + item.Key + "_" + item.Object.PatientFirstName);
                Patient pt = new Patient { 
                    ID = item.Object.ID,
                    PatientId = item.Object.PatientId,
                    PatientFirstName = item.Object.PatientFirstName,
                    PatientLastName = item.Object.PatientLastName,
                    PatientBirthday = item.Object.PatientBirthday,
                    PatientGender = item.Object.PatientGender
                };

                MessagingCenter.Send<object, Patient>(this, "Query", pt);
            }
            return list;
        }

        public async Task AddPatient(Patient obj)
        {
            try
            {
                await firebase
           .Child("Patients").Child(obj.PatientId)
           .PutAsync(obj);
            }
            catch { }

        }

        public async Task DeletePatient(Patient obj)
        {
            try
            {
                await firebase
           .Child("Patients").Child(obj.PatientId)
           .DeleteAsync();
            }
            catch { }

        }
    }
}
