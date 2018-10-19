using System;
using System.Reactive.Linq;
using System.Windows;

namespace kkkkkkaaaaaa.Reactive.Windows
{
	public static class ApplicationExtensiona
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="app"></param>
		/// <returns></returns>
		public static IObservable<StartupEventArgs> StartupAsObservable(this Application app)
		{
			return Observable.FromEvent<StartupEventHandler, StartupEventArgs>(
				(handler) => ((sender, e) => handler.Invoke(e)), 
				(handler) => app.Startup += handler, 
				(handler) => app.Startup -= handler);
		}
	}
}