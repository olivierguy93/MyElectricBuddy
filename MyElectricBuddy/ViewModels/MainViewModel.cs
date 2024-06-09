using MyElectricBuddy.Core.Events.Headers;
using MyElectricBuddy.Core.ViewModels.Headers;
using ReactiveUI;

namespace MyElectricBuddy.Core.ViewModels;

public class MainViewModel : ViewModelBase
{
    private MainHeaderViewModel _headerViewModel;

    public MainHeaderViewModel HeaderViewModel
    {
        get => _headerViewModel;
        set => this.RaiseAndSetIfChanged(ref _headerViewModel, value);
    }

    private ViewModelBase? _mainContentViewModel;

    public ViewModelBase? MainContentViewModel
    {
        get => _mainContentViewModel;
        set => this.RaiseAndSetIfChanged(ref _mainContentViewModel, value);
    }

    public MainViewModel(MainHeaderViewModel headerViewModel)
    {
        HeaderViewModel = _headerViewModel = headerViewModel;
        HeaderViewModel.SettingsPressed += OnSettingsPressed;
    }

    private void OnSettingsPressed(object? sender, SettingsPressedEventArgs e)
    {
        //TODO display the settings view
    }
}