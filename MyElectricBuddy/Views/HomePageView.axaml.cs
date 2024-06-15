using Avalonia.ReactiveUI;
using MyElectricBuddy.Core.ViewModels.Pages;

namespace MyElectricBuddy.Core.Views
{
    public partial class HomePageView : ReactiveUserControl<HomePageViewModel>
    {
        public HomePageView()
        {
            InitializeComponent();
        }
    }
}