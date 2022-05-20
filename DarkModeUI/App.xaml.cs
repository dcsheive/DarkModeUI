using DarkModeUI.Helpers;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DarkModeUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            TheTheme.SetTheme();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            TheTheme.SetTheme();
            RequestedThemeChanged += App_SetRequestedTheme;
        }

        protected override void OnSleep()
        {
            TheTheme.SetTheme();
            RequestedThemeChanged -= App_SetRequestedTheme;
        }

        protected override void OnResume()
        {
            TheTheme.SetTheme();
            RequestedThemeChanged += App_SetRequestedTheme;
        }

        private void App_SetRequestedTheme(object sender, AppThemeChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                TheTheme.SetTheme();
            });
        }
    }
}
