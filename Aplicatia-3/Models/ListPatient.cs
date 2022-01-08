using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Aplicatia_3.Models
{
    public class ListPatient
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(AppointmentList))]
        public int AppointmentListID { get; set; }
        public int PatientID { get; set; }
    }
}
