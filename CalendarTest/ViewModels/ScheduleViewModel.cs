﻿using System;
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

        public ScheduleViewModel()
        {
            AppointmentViewModels = new ObservableCollection<AppointmentViewModel>();
            AddRange(AppointmentViewModels,ProvideEmptyTimeSlotViewModels(ProvideEmptyTimeSlots()));
            AddRange(AppointmentViewModels, ProvideAppointmentViewModels(ProvideAppointments()));
            AddRange(AppointmentViewModels,ProvideTimeSlotViewModels(ProvideTimeSlots()));

        }

        private void AddRange(ObservableCollection<AppointmentViewModel> originalList, ObservableCollection<AppointmentViewModel> listToAppend)
        {
            foreach (var item in listToAppend)
            {
                originalList.Add(item);
            }
        }

        private List<Appointment> ProvideAppointments()
        {
            var appointments = new List<Appointment>();
            DateTime currentDate = DateTime.Now;   
            DateTime startTime = new DateTime (currentDate.Year,currentDate.Month,currentDate.Day, 9, 0, 0);    
            DateTime endTime = new DateTime (currentDate.Year, currentDate.Month,currentDate.Day, 10, 0, 0);
            DateTime startTime2 = new DateTime (currentDate.Year,currentDate.Month,currentDate.Day, 10, 0, 0);    
            DateTime endTime2 = new DateTime (currentDate.Year, currentDate.Month,currentDate.Day, 12, 0, 0);

            appointments.Add(new Appointment("Chris MacArthur Diddlebaum", startTime, endTime));
            appointments.Add(new Appointment("Timmothy Garfield", startTime2, endTime2));
            return appointments;
        }

        private List<Appointment> ProvideEmptyTimeSlots()
        {
            var appointments = new List<Appointment>();
            DateTime currentDate = DateTime.Now;   
            DateTime startTime = new DateTime (currentDate.Year,currentDate.Month,currentDate.Day, 10, 0, 0);    
            DateTime endTime = new DateTime (currentDate.Year, currentDate.Month,currentDate.Day, 12, 0, 0);   
            DateTime startTime2 = new DateTime (currentDate.Year,currentDate.Month,currentDate.Day, 12, 30, 0);    
            DateTime endTime2 = new DateTime (currentDate.Year, currentDate.Month,currentDate.Day, 16, 0, 0);
            DateTime startTime3 = new DateTime (currentDate.Year,currentDate.Month,currentDate.Day, 9, 00, 0);    
            DateTime endTime3 = new DateTime (currentDate.Year, currentDate.Month,currentDate.Day, 10, 0, 0);
            
            appointments.Add(new Appointment("Ittjno", startTime, endTime));
            appointments.Add(new Appointment("Ittjno", startTime2, endTime2));
            appointments.Add(new Appointment("Ittjno", startTime3, endTime3));
            return appointments;
        }

        private List<Appointment> ProvideTimeSlots()
        {
            var appointments = new List<Appointment>();
            DateTime currentDate = DateTime.Now;
            DateTime startTime2 = new DateTime (currentDate.Year,currentDate.Month,currentDate.Day, 12, 0, 0);    
            DateTime endTime2 = new DateTime (currentDate.Year, currentDate.Month,currentDate.Day, 12, 30, 0);   

            appointments.Add(new Appointment("Lunsj", startTime2, endTime2));
            return appointments;
        }

        private ObservableCollection<AppointmentViewModel> ProvideTimeSlotViewModels(List<Appointment> appointments)
        {
            var appointmentViewModels = new ObservableCollection<AppointmentViewModel>();
            if (appointments == null) return appointmentViewModels;

            if (appointments[0] != null)
            {
                appointmentViewModels.Add(new AppointmentViewModel(appointments[0]) { Color = Color.LightGray});
            }

            return appointmentViewModels;
        }

        private ObservableCollection<AppointmentViewModel> ProvideAppointmentViewModels(List<Appointment> appointments)
        {
            var appointmentViewModels = new ObservableCollection<AppointmentViewModel>();


            foreach (var appointment in appointments) {
                appointmentViewModels.Add(new AppointmentViewModel(appointment) { Color = GetRandomColor()});
            }

            return appointmentViewModels;
        }

        private ObservableCollection<AppointmentViewModel> ProvideEmptyTimeSlotViewModels(List<Appointment> appointments)
        {
            var appointmentViewModels = new ObservableCollection<AppointmentViewModel>();


            foreach (var appointment in appointments) {
                appointmentViewModels.Add(new AppointmentViewModel(appointment) { Color = Color.Transparent});
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
