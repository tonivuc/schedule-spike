using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using CalendarTest.Annotations;
using Xamarin.Forms;

namespace CalendarTest.ViewModels
{
    class MeetingViewModel : INotifyPropertyChanged
    {
        public MeetingViewModel(Meeting meeting)
        {
            EventName = meeting.EventName;
            From = meeting.From;
            To = meeting.To;
            Color = meeting.Color;
        }

        public string EventName { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Color Color { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
