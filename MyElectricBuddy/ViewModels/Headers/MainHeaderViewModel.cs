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

        public ReactiveCommand<Unit, Unit>? OnSettingPressedCommand;

        public MainHeaderViewModel()
        {
            this.WhenActivated((CompositeDisposable disposables) =>
            {
                OnSettingPressedCommand = ReactiveCommand.Create(OnSettingsPressed).DisposeWith(disposables);
            });
        }

        private void OnSettingsPressed()
            => SettingsPressed?.Invoke(this, new());
    }
}