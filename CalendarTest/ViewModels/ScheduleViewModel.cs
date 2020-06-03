using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

        public DayViewSettings DayViewSettings { get; set; }

        public ScheduleViewModel()
        {
            SetDayLabelFormatToMinutes();
            //AppointmentCollection = new ObservableCollection<Meeting>();
            //DoStuff();
            //doStuff2();
            AppointmentCollection = ProvideMeetings();
            //AppointmentCollection
            //AppointmentViewModels = ProvideAppointmentViewModels(ProvideAppointments());
            //OnPropertyChanged(nameof(AppointmentViewModels));
        }

        private void SetDayLabelFormatToMinutes()
        {
            DayViewSettings = new DayViewSettings();
            DayLabelSettings dayLabelSettings = new DayLabelSettings();
            dayLabelSettings.TimeFormat = "hh mm";
            DayViewSettings.DayLabelSettings = dayLabelSettings;
        }

        public ObservableCollection<AppointmentViewModel> AppointmentViewModels;

        private ObservableCollection<Meeting> ProvideMeetings()
        {
            ObservableCollection<Meeting> meetings = new ObservableCollection<Meeting>();
            DateTime currentDate = DateTime.Now;   

            Meeting m1 = new Meeting();
            m1.EventName = "Superevent";
            m1.From = new DateTime (currentDate.Year,currentDate.Month,currentDate.Day, 10, 0, 0); 
            m1.To = new DateTime (currentDate.Year, currentDate.Month,currentDate.Day, 12, 0, 0);
            m1.Color = Color.FromRgb(40, 50, 80);
            meetings.Add(m1);
            return meetings;
        }
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
            return new Color(10,24,60);//System.Drawing.Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }

        ScheduleAppointmentCollection scheduleAppointmentCollection = new ScheduleAppointmentCollection();
        //ScheduleAppointmentCollection appointmentCollection = new ScheduleAppointmentCollection();  
        

        public ObservableCollection<Meeting> AppointmentCollection { get; set; }

        //private void DoStuff()
        //{
             
        //    Creating new event
        //    ScheduleAppointment clientMeeting = new ScheduleAppointment();   
        //    DateTime currentDate = DateTime.Now;   
        //    DateTime startTime = new DateTime (currentDate.Year,currentDate.Month,currentDate.Day, 10, 0, 0);    
        //    DateTime endTime = new DateTime (currentDate.Year, currentDate.Month,currentDate.Day, 12, 0, 0);   
        //    clientMeeting.StartTime = startTime;   
        //    clientMeeting.EndTime = endTime;   
        //    clientMeeting.Color = Color.Blue;   
        //    clientMeeting.Subject = "ClientMeeting";   
        //    appointmentCollection.Add(clientMeeting);
        //}

        private void doStuff2()
        {
            ////Creating new event   
            //ScheduleAppointment clientMeeting = new ScheduleAppointment();   
            //DateTime currentDate = DateTime.Now;   
            //DateTime startTime = new DateTime (currentDate.Year,currentDate.Month,currentDate.Day, 10, 0, 0);    
            //DateTime endTime = new DateTime (currentDate.Year, currentDate.Month,currentDate.Day, 12, 0, 0);   
            //clientMeeting.StartTime = startTime;   
            //clientMeeting.EndTime = endTime;   
            //clientMeeting.Color = Color.Blue;   
            //clientMeeting.Subject = "ClientMeeting";
            //clientMeeting.Notes = "We will discuss eating porridge or pancakes for lunch";
            //clientMeeting.Location = "Room 402";

            //AppointmentCollection.Add(clientMeeting);

            //ScheduleAppointment clientMeeting2 = new ScheduleAppointment();   
            //currentDate = DateTime.Now;   
            //startTime = new DateTime (currentDate.Year,currentDate.Month,currentDate.Day, 10, 0, 0);    
            //endTime = new DateTime (currentDate.Year, currentDate.Month,currentDate.Day, 12, 0, 0);   
            //clientMeeting2.StartTime = startTime;   
            //clientMeeting2.EndTime = endTime;   
            //clientMeeting2.Color = Color.Red;   
            //clientMeeting2.Subject = "Othermeeting";
            //clientMeeting2.Notes = "We will discuss eating porridge or pancakes for lunch";
            //clientMeeting2.Location = "Room 402";

            //AppointmentCollection.Add(clientMeeting2);
        }

    }
}
