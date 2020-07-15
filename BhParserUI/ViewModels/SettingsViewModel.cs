using BhParserUI.Properties;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BhParserUI.ViewModels
{
    public class SettingsViewModel : BindableBase
    {
        public DelegateCommand SettingClk { get; }

        public SettingsViewModel()
        {
            SettingClk = new DelegateCommand(SaveSettings);
            EMailToCheckTxt = Settings.Default.EmailAccountToCheck;
            EmailPasswordTxt = Settings.Default.EmailPassword;
        }

        private string _EMailToCheckTxt;
        public string EMailToCheckTxt
        {
            get { return _EMailToCheckTxt; }
            set { SetProperty(ref _EMailToCheckTxt, value); }
        }

        private string _EmailPasswordTxt;
        public string EmailPasswordTxt
        {
            get { return _EmailPasswordTxt; }
            set { SetProperty(ref _EmailPasswordTxt, value); }
        }

        private void SaveSettings()
        {
            Settings.Default.EmailAccountToCheck = EMailToCheckTxt;
            Settings.Default.EmailPassword = EmailPasswordTxt;
            Settings.Default.Save();
            Console.WriteLine("");
        }
    }
}
