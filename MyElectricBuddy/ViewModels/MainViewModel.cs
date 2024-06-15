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

    private bool _isMenuOpened;

    public bool IsMenuOpened
    {
        get => _isMenuOpened;
        set => this.RaiseAndSetIfChanged(ref _isMenuOpened, value);
    }

    public MainViewModel()
    {
        // Keeping it for now so the main view can be displayed in the designer
    }

    public MainViewModel(MainHeaderViewModel headerViewModel, HomePageViewModel homePageViewModel)
    {
        HeaderViewModel = _headerViewModel = headerViewModel;
        MainContentViewModel = _mainContentViewModel = homePageViewModel;

        HeaderViewModel.SettingsPressed += OnSettingsPressed;
        HeaderViewModel.MenuPressed += OnMenuPressed;
    }

    private void OnSettingsPressed(object? sender, SettingsPressedEventArgs e)
    {
        //TODO display the settings view
    }

    private void OnMenuPressed(object? sender, MenuPressedEventArgs e)
        => IsMenuOpened = !IsMenuOpened;
}