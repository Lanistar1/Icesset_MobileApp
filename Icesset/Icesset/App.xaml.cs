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
            AppCenter.Start("android={c3bd2c25-b3da-4f19-b329-4fc7e0977c0b};" +
                  "ios={238e8272-6f26-4c8f-9d10-283d485570cb}",
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
