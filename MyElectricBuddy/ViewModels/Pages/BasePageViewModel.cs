using ReactiveUI;

namespace MyElectricBuddy.Core.ViewModels.Pages
{
    public class BasePageViewModel : ViewModelBase
    {
        public string _title = string.Empty;

        public string Title
        {
            get => _title;
            set => this.RaiseAndSetIfChanged(ref _title, value);
        }
    }
}