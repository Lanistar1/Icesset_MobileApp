using Icesset.Views;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Poppins-Black.ttf", Alias = "Poppins")]
[assembly: ExportFont("Poppins-Light.ttf", Alias = "Poppins-Light")]
namespace Icesset
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            MainPage = new NavigationPage(new HomePage());
            
        }

        protected override void OnStart()
        {
            AppCenter.Start("android={a6b8d821-e33b-446b-8320-5749151dd907};" +
                  "ios={591582a8-0ddd-4903-ab57-1abb99394555}",
                  typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
