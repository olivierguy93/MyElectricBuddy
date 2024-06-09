using MyElectricBuddy.Core.Resources.Strings;

namespace MyElectricBuddy.Core.ViewModels.Headers
{
    public class MainHeaderViewModel : ViewModelBase
    {
        public string Title { get; set; } = Globalization.app_name;
    }
}