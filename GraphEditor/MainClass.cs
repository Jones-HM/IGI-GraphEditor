using QLibc;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace IGI_GraphEditor
{
    static class QClass
    {
        [STAThread]
        static void Main()
        {
            try
            {
                bool instanceCount = false;
                Mutex mutex = null;
                var projAppName = AppDomain.CurrentDomain.FriendlyName;
                AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnAppExit);

                mutex = new Mutex(true, projAppName, out instanceCount);
                if (instanceCount)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new IGIGraphEditorUI());
                    mutex.ReleaseMutex();
                }
                else
                {
                    QUtils.ShowError("IGI Graph Editor is already running");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.Message + "\nStack: " + ex.StackTrace, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void OnAppExit(object sender, EventArgs e)
        {
            //Update config on exit.
            QUtils.CreateConfig();
        }
    }
}
