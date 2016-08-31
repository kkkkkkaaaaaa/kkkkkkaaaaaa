using System;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Linq;

namespace kkkkkkaaaaaa.ComponentModel
{
    public static class NotifyPropertyChangedExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        public static IObservable<EventPattern<PropertyChangedEventArgs>> PropertyChangedAsObservable(this INotifyPropertyChanged vm)
        {
            return Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                handler => handler.Invoke
                , handler => vm.PropertyChanged += handler
                , handler => vm.PropertyChanged -= handler);
        }
    }
}