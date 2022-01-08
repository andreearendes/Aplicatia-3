using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Aplicatia_3.Models
{
    public class Patient
{
        
            [PrimaryKey, AutoIncrement]
            public int ID { get; set; }
            public string PatientName { get; set; }
            public string Disease { get; set; }
            [OneToMany]
        public List<ListPatient> ListPatients { get; set; }
        
    }
}
