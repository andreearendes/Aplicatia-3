using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicatia_3.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aplicatia_3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var alist = (AppointmentList)BindingContext;
            alist.Date = DateTime.UtcNow;
            await App.Database.SaveAppointmentListAsync(alist);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var alist = (AppointmentList)BindingContext;
            await App.Database.DeleteAppointmentListAsync(alist);
            await Navigation.PopAsync();
        }
        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PatientPage((AppointmentList)
           this.BindingContext)
            {
                BindingContext = new Patient()
            });

        }
      
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var appointmentl = (AppointmentList)BindingContext;

            listView.ItemsSource = await App.Database.GetListPatientsAsync(appointmentl.ID);
        }
    }
}