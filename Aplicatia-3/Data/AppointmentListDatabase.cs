using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aplicatia_3.Models;

namespace Aplicatia_3.Data
{
    public class AppointmentListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public AppointmentListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<AppointmentList>().Wait();
            _database.CreateTableAsync<Patient>().Wait();
            _database.CreateTableAsync<ListPatient>().Wait();
        }
        public Task<int> SavePatientAsync(Patient patient)
        {
            if (patient.ID != 0)
            {
                return _database.UpdateAsync(patient);
            }
            else
            {
                return _database.InsertAsync(patient);
            }
        }
        public Task<int> DeletePatientAsync(Patient patient)
        {
            return _database.DeleteAsync(patient);
        }
        public Task<List<Patient>> GetPatientsAsync()
        {
            return _database.Table<Patient>().ToListAsync();
        }


        public Task<List<AppointmentList>> GetAppointmentListsAsync()
        {
            return _database.Table<AppointmentList>().ToListAsync();
        }
        public Task<AppointmentList> GetAppointmentListAsync(int id)
        {
            return _database.Table<AppointmentList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveAppointmentListAsync(AppointmentList alist)
        {
            if (alist.ID != 0)
            {
                return _database.UpdateAsync(alist);
            }
            else
            {
                return _database.InsertAsync(alist);
            }
        }
        public Task<int> DeleteAppointmentListAsync(AppointmentList alist)
        {
            return _database.DeleteAsync(alist);
        }

        public Task<int> SaveListPatientAsync(ListPatient listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Patient>> GetListPatientsAsync(int appointmentlistid)
        {
            return _database.QueryAsync<Patient>(
            "select P.ID, P.PatientName from Patient P" + " inner join ListPatient LP" + " on P.ID = LP.PatientID where LP.AppointmentListID = ?",
            appointmentlistid);
        }
    }
}


