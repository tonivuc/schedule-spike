using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using CalendarTest.Models;
using Syncfusion.SfSchedule.XForms;
using Random = System.Random;

namespace CalendarTest.ViewModels
{
    class ScheduleViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DayViewSettings DayViewSettings { get; set; }

        public ScheduleViewModel()
        {
            SetDayLabelFormatToMinutes();
            DoStuff();
            AppointmentViewModels = ProvideAppointmentViewModels(ProvideAppointments());
            OnPropertyChanged(nameof(AppointmentViewModels));
            OnPropertyChanged(nameof(appointmentCollection));
            
        }

        private void SetDayLabelFormatToMinutes()
        {
            DayViewSettings = new DayViewSettings();
            DayLabelSettings dayLabelSettings = new DayLabelSettings();
            dayLabelSettings.TimeFormat = "hh mm";
            DayViewSettings.DayLabelSettings = dayLabelSettings;
        }

        public ObservableCollection<AppointmentViewModel> AppointmentViewModels;

        private List<Appointment> ProvideAppointments()
        {
            var appointments = new List<Appointment>();
            DateTime currentDate = DateTime.Now;   
            DateTime startTime = new DateTime (currentDate.Year,currentDate.Month,currentDate.Day, 10, 0, 0);    
            DateTime endTime = new DateTime (currentDate.Year, currentDate.Month,currentDate.Day, 12, 0, 0);   

            appointments.Add(new Appointment("Chris MacArthur Diddlebaum", startTime, endTime));
            appointments.Add(new Appointment("Timmothy Garfield", startTime, endTime));
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

        private Color GetRandomColor()
        {
            var rnd = new Random();
            return Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }

        ScheduleAppointmentCollection scheduleAppointmentCollection = new ScheduleAppointmentCollection();
        ScheduleAppointmentCollection appointmentCollection = new ScheduleAppointmentCollection();  

        private void DoStuff()
        {
             
            //Creating new event   
            ScheduleAppointment clientMeeting = new ScheduleAppointment();   
            DateTime currentDate = DateTime.Now;   
            DateTime startTime = new DateTime (currentDate.Year,currentDate.Month,currentDate.Day, 10, 0, 0);    
            DateTime endTime = new DateTime (currentDate.Year, currentDate.Month,currentDate.Day, 12, 0, 0);   
            clientMeeting.StartTime = startTime;   
            clientMeeting.EndTime = endTime;   
            clientMeeting.Color = Color.Blue;   
            clientMeeting.Subject = "ClientMeeting";   
            appointmentCollection.Add(clientMeeting);
        }

    }
}
