using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CalendarTest.ViewModels
{
    class MeetingViewModel
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
    }
}
