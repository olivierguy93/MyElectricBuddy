using Avalonia.ReactiveUI;
using MyElectricBuddy.Core.ViewModels.Headers;
using ReactiveUI;
using System.Reactive.Disposables;

namespace MyElectricBuddy.Core.Views.Headers
{
    public partial class MainHeaderView : ReactiveUserControl<MainHeaderViewModel>
    {
        public MainHeaderView()
        {
            InitializeComponent();

            this.WhenActivated(disposables =>
            {
                this.BindCommand(ViewModel, x => x.OnSettingPressedCommand, x => x.Settings)
                    .DisposeWith(disposables);

                this.BindCommand(ViewModel, x => x.OnMenuPressedCommand, x => x.Menu)
                    .DisposeWith(disposables);
                //Add binding to button command here
            });
        }
    }
}