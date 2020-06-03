using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using CalendarTest.Annotations;
using CalendarTest.Models;
using Xamarin.Forms;

namespace CalendarTest.ViewModels
{
    class AppointmentViewModel : INotifyPropertyChanged
    {
        private readonly Appointment m_appointment;

        public AppointmentViewModel(Appointment appointment)
        {
            m_appointment = appointment;
        }

        public string EventName => m_appointment.PatientName;
        public string HealthIssue => m_appointment.HealthIssue;

        public DateTime From => m_appointment.StartTime;

        public DateTime To => m_appointment.EndTime;

        public Color Color { get; set; }

        public string Status => m_appointment.Status;

        // TODO: More properties should be added for scheduleappointment detail page
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
