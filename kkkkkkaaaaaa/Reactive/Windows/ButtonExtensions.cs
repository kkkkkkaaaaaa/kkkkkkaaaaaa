using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace kkkkkkaaaaaa.Reactive.Windows
{
    public static class ButtonExtensions
    {
        /// <summary>
        /// Click イベント Observable。
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        public static IObservable<EventPattern<RoutedEventArgs>> ClickAsObservable(this ButtonBase button)
        {
            // return Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(
            //     ((handler) => { return (sender, e) => handler.Invoke(button, e); })
            //     , ((handler) => { button.Click += handler; })
            //     , ((handler) => { button.Click -= handler; }));
            return Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(
                handler => (sender, e) => handler?.Invoke(button, e)
                , handler => button.Click += handler
                , handler => button.Click -= handler);
        }
    }
}