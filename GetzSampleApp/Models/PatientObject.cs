using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetzSampleApp.Models
{
    public class PatientObject
    {
        public int ID { get; set; }
        public string PatientId { get; set; }
        public string PatientFirstName { get; set;}
        public string PatientLastName { get; set; }
        public string PatientBirthday { get; set; }
        public string PatientGender { get; set; }
    }
}
