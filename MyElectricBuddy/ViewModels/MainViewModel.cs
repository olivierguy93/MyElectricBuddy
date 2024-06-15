using MyElectricBuddy.Core.Events.Headers;
using MyElectricBuddy.Core.ViewModels.Headers;
using MyElectricBuddy.Core.ViewModels.Menus;
using MyElectricBuddy.Core.ViewModels.Pages;
using ReactiveUI;
using System.Reactive.Disposables;

namespace MyElectricBuddy.Core.ViewModels;

public class MainViewModel : ViewModelBase
{
    private MainHeaderViewModel _header;

    public MainHeaderViewModel Header
    {
        get => _header;
        set => this.RaiseAndSetIfChanged(ref _header, value);
    }

    private BasePageViewModel? _content;

    public BasePageViewModel? Content
    {
        get => _content;
        set => this.RaiseAndSetIfChanged(ref _content, value);
    }

    private bool _isMenuOpened;

    public bool IsMenuOpened
    {
        get => _isMenuOpened;
        set => this.RaiseAndSetIfChanged(ref _isMenuOpened, value);
    }

    private MainMenuViewModel _menu;

    public MainMenuViewModel Menu
    {
        get => _menu;
        set => this.RaiseAndSetIfChanged(ref _menu, value);
    }

    public MainViewModel()
    {
        // Keeping it for now so the main view can be displayed in the designer
    }

    public MainViewModel(MainHeaderViewModel headerViewModel,
        HomePageViewModel homePageViewModel,
        MainMenuViewModel mainMenuViewModel)
    {
        Header = _header = headerViewModel;
        Content = _content = homePageViewModel;
        Menu = _menu = mainMenuViewModel;

        this.WhenActivated((CompositeDisposable disposables) =>
        {
            Header.SettingsPressed += OnSettingsPressed;
            Header.MenuPressed += OnMenuPressed;

            Disposable.Create(() =>
            {
                Header.SettingsPressed -= OnSettingsPressed;
                Header.MenuPressed -= OnMenuPressed;
            }).DisposeWith(disposables);
        });
    }

    private void OnSettingsPressed(object? sender, SettingsPressedEventArgs e)
    {
        //TODO display the settings view
    }

    private void OnMenuPressed(object? sender, MenuPressedEventArgs e)
        => IsMenuOpened = !IsMenuOpened;
}