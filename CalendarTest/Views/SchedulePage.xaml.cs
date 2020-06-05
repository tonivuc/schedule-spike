using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalendarTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SchedulePage : ContentPage
    {
        public SchedulePage()
        {
            InitializeComponent();
            SfSchedule.Locale = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            App.Current.MainPage.DisplayAlert("Alert", "Alert alert code red!","No worries!");
            DateTime currentDate = DateTime.Now;   
            DateTime startTime = new DateTime (currentDate.Year,currentDate.Month,currentDate.Day, 14, 0, 0);
            SfSchedule2.MoveToDate = startTime;
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;   
            DateTime startTime = new DateTime (currentDate.Year,currentDate.Month,currentDate.Day, 14, 0, 0);
            var date = SfSchedule.SelectedDate;
            SfSchedule.MoveToDate = date.Value;

        }
    }
}