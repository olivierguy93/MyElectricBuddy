using MyElectricBuddy.Core.Events.Headers;
using MyElectricBuddy.Core.Resources.Strings;
using ReactiveUI;
using System;
using System.Reactive;
using System.Reactive.Disposables;

namespace MyElectricBuddy.Core.ViewModels.Headers
{
    public class MainHeaderViewModel : ViewModelBase
    {
        public string Title { get; set; } = Globalization.app_name;

        public EventHandler<SettingsPressedEventArgs>? SettingsPressed;
        public EventHandler<MenuPressedEventArgs>? MenuPressed;

        public ReactiveCommand<Unit, Unit>? OnSettingPressedCommand;
        public ReactiveCommand<Unit, Unit>? OnMenuPressedCommand;

        public MainHeaderViewModel()
        {
            this.WhenActivated((CompositeDisposable disposables) =>
            {
                OnSettingPressedCommand = ReactiveCommand.Create(OnSettingsPressed).DisposeWith(disposables);
                OnMenuPressedCommand = ReactiveCommand.Create(OnMenuPressed).DisposeWith(disposables);
            });
        }

        private void OnSettingsPressed()
            => SettingsPressed?.Invoke(this, new());

        private void OnMenuPressed()
            => MenuPressed?.Invoke(this, new());
    }
}