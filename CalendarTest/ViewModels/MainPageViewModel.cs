using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using Syncfusion.SfSchedule.XForms;

namespace CalendarTest.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ScheduleAppointmentCollection AppointmentCollection { get; set; }
        public DayViewSettings DayViewSettings { get; set; }

        public MainPageViewModel()
        {
            AppointmentCollection = new ScheduleAppointmentCollection();
            SetDayLabelFormatToMinutes();
            doStuff();
        }

        private void SetDayLabelFormatToMinutes()
        {
            DayViewSettings = new DayViewSettings();
            DayLabelSettings dayLabelSettings = new DayLabelSettings();
            dayLabelSettings.TimeFormat = "hh mm";
            DayViewSettings.DayLabelSettings = dayLabelSettings;
        }
        private void doStuff()
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
            clientMeeting.Notes = "We will discuss eating porridge or pancakes for lunch";
            clientMeeting.Location = "Room 402";

            AppointmentCollection.Add(clientMeeting);

            ScheduleAppointment clientMeeting2 = new ScheduleAppointment();   
            currentDate = DateTime.Now;   
            startTime = new DateTime (currentDate.Year,currentDate.Month,currentDate.Day, 10, 0, 0);    
            endTime = new DateTime (currentDate.Year, currentDate.Month,currentDate.Day, 12, 0, 0);   
            clientMeeting2.StartTime = startTime;   
            clientMeeting2.EndTime = endTime;   
            clientMeeting2.Color = Color.Red;   
            clientMeeting2.Subject = "Othermeeting";
            clientMeeting2.Notes = "We will discuss eating porridge or pancakes for lunch";
            clientMeeting2.Location = "Room 402";

            AppointmentCollection.Add(clientMeeting2);
        }
    }
}
