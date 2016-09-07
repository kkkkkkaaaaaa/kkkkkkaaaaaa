using System;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Linq;

namespace kkkkkkaaaaaa.Reactive.ComponentModel
{
    public static class NotifyPropertyChangedExtensions
    {
        public static IObservable<EventPattern<PropertyChangedEventArgs>> PropertyChangedAsObservable(this INotifyPropertyChanged vm)
        {
            return Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                handler => (sender, e) => handler?.Invoke(sender, e)
                , handler => vm.PropertyChanged += handler
                , handler => vm.PropertyChanged -= handler);
        }
    }
}