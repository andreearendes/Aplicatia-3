using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Aplicatia_3.Models;

namespace Aplicatia_3.Models 
{
   public class AppointmentList
{
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
