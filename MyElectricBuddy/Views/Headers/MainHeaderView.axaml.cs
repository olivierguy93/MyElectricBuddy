using Avalonia.ReactiveUI;
using Microsoft.Extensions.DependencyInjection;
using MyElectricBuddy.Core.ViewModels.Headers;

namespace MyElectricBuddy.Core.Views.Headers
{
    public partial class MainHeaderView : ReactiveUserControl<MainHeaderViewModel>
    {
        public MainHeaderView()
        {
            InitializeComponent();
            DataContext = App.Services?.GetRequiredService<MainHeaderViewModel>();
        }
    }
}