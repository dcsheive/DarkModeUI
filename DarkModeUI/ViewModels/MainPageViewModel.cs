using DarkModeUI.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DarkModeUI.ViewModels
{

    public class MainPageViewModel
    {
        public bool ThemeSystem { get; set; }
        public bool ThemeLight { get; set; }
        public bool ThemeDark { get; set; }

        public string SelectedTheme { get; set; }
        public ICommand SaveSettings { get; }

        public MainPageViewModel()
        {
            SaveSettings = new Command(() =>
            {
                SaveTheme();
            });
        }

        public void Init()
        {
            DoSettings();
        }

        private void DoSettings()
        {
            switch (Settings.Theme)
            {
                case 0:
                    ThemeSystem = true;
                    break;
                case 1:
                    ThemeLight = true;
                    break;
                case 2:
                    ThemeDark = true;
                    break;
            }
        }

        private void SaveTheme()
        {
            if (ThemeSystem)
            {
                Settings.Theme = 0;
            }
            else if (ThemeLight)
            {
                Settings.Theme = 1;
            }
            else
            {
                Settings.Theme = 2;
            }
            TheTheme.SetTheme();
        }

    }

        
}
