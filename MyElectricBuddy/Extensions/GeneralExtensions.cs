using System;

namespace MyElectricBuddy.Core.Extensions
{
    public static class GeneralExtensions
    {
        /// <summary>
        /// Execute action if the element is not null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element">The element to check</param>
        /// <param name="action">The action to execute</param>
        public static void IfNotNull<T>(this T? element, Action<T> action)
            where T : class
        {
            if (element is null)
            {
                return;
            }

            action.Invoke(element);
        }
    }
}