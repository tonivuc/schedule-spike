using System;
using CalendarTest.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalendarTest
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjY2MjM5QDMxMzgyZTMxMmUzMFgrS1JiNHBqd2U0cUhUdDR3dVlEUEdrMUlSeU9qZ0xqR2E5bDduL0tWS0k9");
            InitializeComponent();
            MainPage = new SchedulePage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
