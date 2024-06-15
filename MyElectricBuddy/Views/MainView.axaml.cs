using Avalonia.ReactiveUI;
using MyElectricBuddy.Core.Extensions;
using MyElectricBuddy.Core.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;

namespace MyElectricBuddy.Core.Views;

public partial class MainView : ReactiveUserControl<MainViewModel>
{
    public MainView()
    {
        InitializeComponent();

        this.WhenActivated(disposables =>
        {
            SidePanel.PaneClosing += OnPaneClosing;

            Disposable.Create(() =>
            {
                SidePanel.PaneClosing -= OnPaneClosing;
            }).DisposeWith(disposables);
        });
    }

    private void OnPaneClosing(object? sender, Avalonia.Interactivity.CancelRoutedEventArgs e)
        => ViewModel.IfNotNull(x => x.IsMenuOpened = false);
}