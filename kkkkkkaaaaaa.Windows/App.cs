using System;
using System.Threading;
using System.Windows;

namespace kkkkkkaaaaaa.Windows
{
    /// <summary>
    /// このアプリケーションのメインクラスです。
    /// </summary>
    public class App : Application
    {
        /// <summary>
        /// このアプリケーションのエントリーポイントです。
        /// </summary>
        /// <returns></returns>
        [STAThread()]
        public static int Main()
        {
            // 二重機動
            var createdNew = default(bool);
            var mutex = new Mutex(true, App._app.GetType().Assembly.FullName, out createdNew);
            if (!createdNew) { return 1; }

            // 初期化
            App.initializeApplication();

            // ウィンドウ
            var startup = new Uri(string.Format(@"{0}.xaml", typeof (MainWindow).Name), UriKind.Relative);
            var main = Application.LoadComponent(startup);

            // 開始
            var run = App._app.Run((Window)main);

            // 終了
            mutex.ReleaseMutex();

            return run;
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
        /// このアプリケーションを初期化します。
        /// </summary>
        private static void initializeApplication()
        {
            // プロパティ
            App._app.ShutdownMode = ShutdownMode.OnMainWindowClose;

            // イベント
            App._app.Startup += App._app_Startup;
            App._app.Exit += App._app_Exit;
        }

        /// <summary></summary>
        private readonly static App _app = new App();

        #endregion
    }
}