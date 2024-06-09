using Avalonia.Controls;
using Avalonia.Controls.Templates;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyElectricBuddy.Core.Helpers
{
    public class ViewLocator(IEnumerable<ViewLocator.ViewLocationDescriptor> descriptors) : IDataTemplate
    {
        private readonly Dictionary<Type, Func<Control>> _dictionary = descriptors.ToDictionary(x => x.ViewModel, x => x.Factory);

        public Control? Build(object? param) => _dictionary[param!.GetType()].Invoke();

        public bool Match(object? data) => data is not null && _dictionary.ContainsKey(data.GetType());

        public record ViewLocationDescriptor(Type ViewModel, Func<Control> Factory);
    }
}