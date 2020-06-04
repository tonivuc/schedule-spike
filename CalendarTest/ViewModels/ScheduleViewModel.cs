using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using CalendarTest.Models;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;
using Random = System.Random;

namespace CalendarTest.ViewModels
{
    class ScheduleViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<AppointmentViewModel> AppointmentViewModels { get; set; }
        public ObservableCollection<AppointmentViewModel> TimeSlotViewModels { get; set; }

        public ScheduleViewModel()
        {
            AppointmentViewModels = ProvideAppointmentViewModels(ProvideAppointments());
            TimeSlotViewModels = ProvideTimeSlotViewModels(ProvideTimeSlots());
        }

        private List<Appointment> ProvideAppointments()
        {
            var appointments = new List<Appointment>();
            DateTime currentDate = DateTime.Now;   
            DateTime startTime = new DateTime (currentDate.Year,currentDate.Month,currentDate.Day, 10, 0, 0);    
            DateTime endTime = new DateTime (currentDate.Year, currentDate.Month,currentDate.Day, 12, 0, 0);   
            DateTime startTime2 = new DateTime (currentDate.Year,currentDate.Month,currentDate.Day, 9, 0, 0);    
            DateTime endTime2 = new DateTime (currentDate.Year, currentDate.Month,currentDate.Day, 11, 0, 0);   

            appointments.Add(new Appointment("Chris MacArthur Diddlebaum", startTime2, endTime));
            appointments.Add(new Appointment("Timmothy Garfield", startTime, endTime2));
            return appointments;
        }

        private List<Appointment> ProvideTimeSlots()
        {
            var appointments = new List<Appointment>();
            DateTime currentDate = DateTime.Now;   
            DateTime startTime = new DateTime (currentDate.Year,currentDate.Month,currentDate.Day, 9, 0, 0);    
            DateTime endTime = new DateTime (currentDate.Year, currentDate.Month,currentDate.Day, 12, 0, 0);   
            DateTime startTime2 = new DateTime (currentDate.Year,currentDate.Month,currentDate.Day, 12, 0, 0);    
            DateTime endTime2 = new DateTime (currentDate.Year, currentDate.Month,currentDate.Day, 12, 30, 0);   

            appointments.Add(new Appointment("Poliklinikk", startTime, endTime));
            appointments.Add(new Appointment("Lunsj", startTime2, endTime2));
            return appointments;
        }

        private ObservableCollection<AppointmentViewModel> ProvideAppointmentViewModels(List<Appointment> appointments)
        {
            var appointmentViewModels = new ObservableCollection<AppointmentViewModel>();


            foreach (var appointment in appointments) {
                appointmentViewModels.Add(new AppointmentViewModel(appointment) { Color = GetRandomColor()});
            }

            return appointmentViewModels;
        }

        private ObservableCollection<AppointmentViewModel> ProvideTimeSlotViewModels(List<Appointment> appointments)
        {
            var appointmentViewModels = new ObservableCollection<AppointmentViewModel>();
            if (appointments == null) return appointmentViewModels;

            if (appointments[0] != null)
            {
                appointmentViewModels.Add(new AppointmentViewModel(appointments[0]) { Color = Color.CornflowerBlue});
            }
            if (appointments[1] != null)
            {
                appointmentViewModels.Add(new AppointmentViewModel(appointments[1]) { Color = Color.LightGray});
            }

            return appointmentViewModels;
        }

        private Color GetRandomColor()
        {
            var rnd = new Random();
            return Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }
    }
}
