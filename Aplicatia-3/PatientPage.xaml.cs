using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Aplicatia_3.Models;

namespace Aplicatia_3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PatientPage : ContentPage
    {
        AppointmentList al;
        public PatientPage(AppointmentList alist)
        {
            InitializeComponent();
            al = alist;
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var patient = (Patient)BindingContext;
            await App.Database.SavePatientAsync(patient);
            listView.ItemsSource = await App.Database.GetPatientsAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var patient = (Patient)BindingContext;
            await App.Database.DeletePatientAsync(patient);
            listView.ItemsSource = await App.Database.GetPatientsAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetPatientsAsync();
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            Patient p;
            if (e.SelectedItem != null)
            {
                p = e.SelectedItem as Patient;
                var lp = new ListPatient()
                {
                    AppointmentListID = al.ID,
                    PatientID = p.ID
                };
                await App.Database.SaveListPatientAsync(lp);
                p.ListPatients = new List<ListPatient> { lp };

                await Navigation.PopAsync();
            }
        }
    }
}