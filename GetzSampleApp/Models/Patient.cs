using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetzSampleApp.Models
{
    [Table("Patients")]
    public class Patient
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int ID { get; set; }
        [Column("patient_id")]
        public string PatientId { get; set; }
        [Column("patient_firstname")]
        public string PatientFirstName { get; set; }
        [Column("patient_lastname")]
        public string PatientLastName { get; set; }
        [Column("patient_dob")]
        public string PatientBirthday { get; set; }
        [Column("patient_gender")]
        public string PatientGender { get; set; }
    }
}
