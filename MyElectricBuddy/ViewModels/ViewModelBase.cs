using ReactiveUI;

namespace MyElectricBuddy.Core.ViewModels;

public class ViewModelBase : ReactiveObject, IActivatableViewModel
{
    public ViewModelActivator Activator { get; } = new();
}