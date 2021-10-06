using GetzSampleApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GetzSampleApp.Utility
{
    public class DatabaseHandler
    {
        private static SQLiteAsyncConnection _db;
        
        public DatabaseHandler()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Patients.db");

            _db = new SQLiteAsyncConnection(databasePath);
            _db.CreateTableAsync<Patient>().Wait();
       
        }

        public static void AddPatient(Object patientObj)
        {
            var obj = patientObj as PatientObject;
            var patient = new Patient()
            {
                PatientId = obj.PatientId,
                PatientFirstName = obj.PatientFirstName,
                PatientLastName = obj.PatientLastName,
                PatientBirthday = obj.PatientBirthday,
                PatientGender = obj.PatientGender
            };
            _db.InsertAsync(patient);
          //  Console.WriteLine("DB_INS" + patient.ID patient.PatientFirstName,patient.PatientLastName);
        }

        public Task<List<Patient>> GetItemAsync(string patientId)
        {
            return Task.Run(() => _db.QueryAsync<Patient>("select * from Patients where patient_id ='" + patientId +"'"));
        }
        public Task<List<Patient>> GetItemsAsync()
        {
            return Task.Run(() => _db.Table<Patient>().ToListAsync());
        }
        public Task<int> DeleteItemAsync(Patient person)
        {
            return _db.DeleteAsync(person);
        }
        public Task<int> SaveItemAsync(Patient person)
        {
            if (person.ID != 0)
            {
                return _db.UpdateAsync(person);
            }
            else
            {         
                return _db.InsertAsync(person);
            }
        }

        public bool DoesIdExistAsync(string pt) {
            try
            {
                var person =  GetItemAsync(pt.ToUpper());
                if (person.Result.Count != 0)
                {
                    return true;
                }
                else {
                    return false;
                }
              
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
                return false;
            }
          
        }

    }
}
