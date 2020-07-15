using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Linq;

namespace BhParserUI.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager region;
        private readonly NavigationContext context;

        public DelegateCommand SettingsNav { get; private set; }

        public MainWindowViewModel(IRegionManager region, NavigationContext context)
        {
            this.region = region;
            this.context = context;

            SettingsNav = new DelegateCommand(ShowSettingsPage);
        }

        private string _title = "Prism Application";
        
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private void ShowSettingsPage()
        {
            try
            {
                var singleView = this.region.Regions["ContentRegion"].ActiveViews.FirstOrDefault();
                Console.WriteLine(singleView);
                if (singleView != null && singleView.ToString().Contains("Settings"))
                {
                    var test = this.context.NavigationService.Journal;
                    if (test.CanGoBack)
                    {
                        test.GoBack();
                    }
                }
                else
                {
                    this.region.RequestNavigate("ContentRegion", "Settings");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
