using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using MyElectricBuddy.Core.Helpers;
using MyElectricBuddy.Core.ViewModels;

namespace MyElectricBuddy.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddView<TViewModel, TView>(this IServiceCollection services)
            where TView : Control, new()
            where TViewModel : ViewModelBase
        {
            services.AddTransient<TViewModel>();
            services.AddSingleton(new ViewLocator.ViewLocationDescriptor(typeof(TViewModel), () => new TView()));
            return services;
        }
    }
}