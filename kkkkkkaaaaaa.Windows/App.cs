using System;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace kkkkkkaaaaaa.Windows
{
    /// <summary>
    /// このアプリケーションのメインクラスです。
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// このアプリケーションのエントリーポイントです。
        /// </summary>
        /// <returns></returns>
        [STAThread()]
        public static int Main()
        {
            // 二重起動
            if(!App._mutex.WaitOne(0, false)) { MessageBox.Show(@"ああ"); return 1; }

            //var createdNew = default(bool);
            //var mutex = new Mutex(true, App._app.GetType().Assembly.FullName, out createdNew);
            //if (!createdNew) { return 1; }

            // 初期化
            App.initializeApplication();

            // ウィンドウ
            var startup = new Uri(string.Format(@"{0}.xaml", typeof (MainWindow).Name), UriKind.Relative);
            var main = Application.LoadComponent(startup);

            // 開始
            var run = App._app.Run((Window)main);

            // 終了
            App._mutex.ReleaseMutex();
            //mutex.ReleaseMutex();

            return 0;
        }

        #region Private members...

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void _app_Startup(object sender, StartupEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void _app_Exit(object sender, ExitEventArgs e)
        {
            e.ApplicationExitCode = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        private static void _app_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            var exception = e.Exception;

            //e.Handled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject;
        }


        /// <summary>
        /// このアプリケーションを初期化します。
        /// </summary>
        private static void initializeApplication()
        {
            // プロパティ
            App._app.ShutdownMode = ShutdownMode.OnMainWindowClose;

            // イベント
            App._app.Startup += App._app_Startup;
            App._app.DispatcherUnhandledException += App._app_DispatcherUnhandledException;
            App._app.Exit += App._app_Exit;

            // AppDomain
            AppDomain.CurrentDomain.UnhandledException += App.CurrentDomain_UnhandledException;
        }

        /// <summary></summary>
        private readonly static App _app = new App();
        /// <summary></summary>
        private readonly static Mutex _mutex = new Mutex(false, Assembly.GetExecutingAssembly().CodeBase);

        #endregion
    }
}