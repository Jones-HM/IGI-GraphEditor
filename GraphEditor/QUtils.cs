using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace IGI_GraphEditor
{
    internal class QUtils
    {
        internal static string taskNew = "Task_New", taskDecl = "Task_DeclareParameters";
        internal static List<int> aiGraphIdStr = new List<int>();
        internal static List<int> aiGraphNodeIdStr = new List<int>();
        internal static List<GraphNode> graphNodesList = new List<GraphNode>();
        internal static string aiGraphTask = "AIGraph", qEditor = "QEditor", qscData = null, graphFile = null;
        internal static string qGraphsPath, igiEditorQEdPath, appdataPath, levelGraphsPath, gameGraphsPath;
        internal static int gGameLevel;
        internal static Dictionary<int, string> graphAreas = new Dictionary<int, string>();
        internal static long GAME_MAX_LEVEL = 14;
        internal const string CAPTION_CONFIG_ERR = "Config - Error", CAPTION_FATAL_SYS_ERR = "Fatal sytem - Error", CAPTION_APP_ERR = "Application - Error", CAPTION_COMPILER_ERR = "Compiler - Error", EDITOR_LEVEL_ERR = "EDITOR ERROR";


        private static string projAppName, cfgDllPath, keyBase = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";
        internal static List<string> inputDatPaths;

        internal static bool isGamePathSet = false, cfgMultiDll = false, cfgAutoInject = false;
        internal static int cfgDelayDll = 10, cfgGameLevel = 1, IGI1_MAX_LEVEL = 14, IGI2_MAX_LEVEL = 19;
        internal static string gameAbsPath,appOutPath, cfgGamePath, cfgGameName = "igi", cfgFile, cfgGameMode = "windowed", injectorFile = @"bin\igi-injector-cmd.exe";
        private static bool gameFound;
        private static bool appLogs;
        private static bool gameReset;
        private static bool editorOnline;
        private static string logFile;
        private static string appCurrPath;
        private static QIniParser qIniParser;
        private static IniParser iniParser;
        internal static string PATH_SEC = "PATH", EDITOR_SEC = "EDITOR";
        private static string cfgGamePathEx = @"\missions\location0\level";

        internal static bool DllRunner(bool dllInject)
        {
            bool status;
            if (inputDatPaths.Count > 0 && inputDatPaths[0].Length > 3)
            {
                bool gameRunning = IsGameRunning();
                if (gameRunning)
                {
                    string inputDllPath = "";

                    foreach (var dllName in inputDatPaths)
                        inputDllPath += dllName + " ";

                    string injectCmd = injectorFile + " -n " + cfgGameName + ".exe" + ((dllInject) ? " -i " : " -e ") + inputDllPath;

                    string shellOut = ShellExec(injectCmd);
                    if (shellOut.Contains("Could not find module") || shellOut.Contains("Error"))
                    {
                        ShowStatusError("DLL " + ((dllInject) ? "injection" : "ejection") + " was unsuccessful");
                        status = false;
                    }
                    else status = true;
                }
                else
                {
                    ShowStatusError("IGI game is not running.");
                    status = false;
                }
            }
            else
            {
                ShowStatusError("No DLL files were selected.");
                status = false;
            }
            return status;
        }

        //Execute shell command and get std-output.
        private static string ShellExec(string cmdArgs, string shell = "cmd.exe")
        {
            var process = new Process();
            var startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.FileName = shell;
            startInfo.Arguments = "/c " + cmdArgs;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            process.StartInfo = startInfo;
            process.Start();
            string output = process.StandardError.ReadToEnd();
            process.WaitForExit();
            return output;
        }

        internal static void AppInit()
        {
            appdataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            igiEditorQEdPath = appdataPath + Path.DirectorySeparatorChar + qEditor;
            qGraphsPath = igiEditorQEdPath + @"\QGraphs";
            levelGraphsPath = igiEditorQEdPath + @"\LevelGraphs";
            //gGameLevel = QMemory.GetCurrentLevel();
        }

        internal static void ParseConfig()
        {
            try
            {
                QUtils.projAppName = AppDomain.CurrentDomain.FriendlyName.Replace(".exe", String.Empty);
                QUtils.cfgFile = QUtils.projAppName + ".ini";
                QUtils.logFile = QUtils.projAppName + ".log";
                QUtils.appCurrPath = Directory.GetCurrentDirectory();
                qIniParser = new QIniParser(cfgFile);

                if (File.Exists(QUtils.cfgFile))
                {
                    //Read properties from PATH section.
                    var configPath = qIniParser.Read("game_path", PATH_SEC);
                    appOutPath = qIniParser.Read("output_path", PATH_SEC);

                    string gPath = configPath.Trim();
                    if (gPath.Contains("\""))
                        gPath = configPath = gPath.Replace("\"", String.Empty);
                    if (!File.Exists(gPath + Path.DirectorySeparatorChar + QMemory.gameName + ".exe"))
                    {
                        QUtils.ShowError("Invalid path selected! Game 'IGI' not found at path '" + gPath + "'", QUtils.CAPTION_FATAL_SYS_ERR);
                        Environment.Exit(1);
                    }
                    QUtils.gameAbsPath = gPath;
                    QUtils.cfgGamePath = configPath.Trim() + QUtils.cfgGamePathEx;


                    QUtils.appLogs = bool.Parse(qIniParser.Read("app_logs", EDITOR_SEC));
                    QUtils.gameReset = bool.Parse(qIniParser.Read("game_reset", EDITOR_SEC));
                }
                else
                {
                    ShowWarning("Config file not found in current directory", QUtils.CAPTION_CONFIG_ERR);
                    QUtils.CreateConfig();
                }
            }
            catch (FormatException ex)
            {
                if (ex.StackTrace.Contains("Boolean"))
                    ShowConfigError("app_logs or game_reset");
                else if (ex.StackTrace.Contains("Int32"))
                    ShowConfigError("");
            }
            catch (Exception ex)
            {
                ShowSystemFatalError("Exception: " + ex.Message);
            }
        }

        internal static void CreateConfig()
        {
            gameFound = true;

            if (String.IsNullOrEmpty(cfgGamePath))
            {
                ShowWarning("Game path could not be detected automatically! Please select game path in config file", CAPTION_CONFIG_ERR);
                gameFound = false;
            }
            else
            {

                if (!File.Exists(gameAbsPath + Path.DirectorySeparatorChar + QMemory.gameName + ".exe"))
                {
                    ShowError("Invalid path selected! Game 'IGI' not found at path '" + gameAbsPath + "'", CAPTION_FATAL_SYS_ERR);
                    gameFound = false;
                }
            }

            //Write App path to config.
            qIniParser.Write("game_path", gameAbsPath is null ? "\n" : gameAbsPath, PATH_SEC);
            qIniParser.Write("output_path", appOutPath is null ? "\n" : appOutPath, PATH_SEC);

            //Write App properties to config.
            qIniParser.Write("game_reset", gameReset.ToString(), EDITOR_SEC);
            qIniParser.Write("app_logs", appLogs.ToString(), EDITOR_SEC);

            if (!gameFound) Environment.Exit(1);
        }

        internal static void AddLog(string logMsg)
        {
                File.AppendAllText("GraphEditor.log", "[" + DateTime.Now.ToString("yyyy-MM-dd - HH:mm:ss") + "] " + logMsg + "\n");
        }



        internal static void ShowStatusInfo(string text)
        {
            IGIGraphEditorUI.mainRef.statusLbl.ForeColor = System.Drawing.Color.ForestGreen;
            IGIGraphEditorUI.mainRef.statusLbl.Text = "INFO: " + text; ;
        }

        internal static void ShowStatusError(string text)
        {
            IGIGraphEditorUI.mainRef.statusLbl.ForeColor = System.Drawing.Color.Tomato;
            IGIGraphEditorUI.mainRef.statusLbl.Text = "ERROR: " + text;
        }

        internal static bool IsGameRunning()
        {
            Process[] pname = Process.GetProcessesByName(QMemory.gameName);
            bool isRunning = pname.Length > 0;
            return isRunning;
        }

        internal static void GameProcessExit()
        {
            bool gameRunning = IsGameRunning();
            if (gameRunning && !String.IsNullOrEmpty(QMemory.gameName))
            {
                var process = Process.GetProcessesByName(QMemory.gameName);
                if (process.Length > 0)
                    process[0].Kill();
            }
        }

        internal static void ShowWarning(string warnMsg, string caption = "WARNING")
        {
            MessageBox.Show(warnMsg, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        internal static void ShowError(string errMsg, string caption = "ERROR")
        {
            MessageBox.Show(errMsg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal static void ShowInfo(string infoMsg, string caption = "INFO")
        {
            MessageBox.Show(infoMsg, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal static void ShowSystemFatalError(string errMsg)
        {
            ShowError(errMsg, CAPTION_FATAL_SYS_ERR);
            Environment.Exit(1);
        }

        private static void ShowConfigError(string keyword)
        {
            ShowError("Config file has invalid property for '" + keyword + "'", CAPTION_CONFIG_ERR);
            Environment.Exit(1);
        }

    }

    public class Real32
    {
        public float alpha, beta, gamma;

        public Real32() { alpha = beta = gamma = 0.0f; }
        public Real32(float alpha)
        {
            this.alpha = alpha;
            this.beta = this.gamma = 0.0f;
        }

        public Real32(float alpha, float beta)
        {
            this.alpha = alpha;
            this.beta = beta;
            this.gamma = 0.0f;
        }

        public Real32(float alpha, float beta, float gamma)
        {
            this.alpha = alpha;
            this.beta = beta;
            this.gamma = gamma;
        }
    };

    public class Real64
    {
        public double x, y, z;
        public Real64() { x = y = z = 0.0f; }
        public Real64(double x)
        {
            this.x = x;
            this.y = this.z = 0.0f;
        }
        public Real64(double x, double y)
        {
            this.x = x;
            this.y = y;
            this.z = 0.0f;
        }

        public Real64(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

    };

    public class GraphNode
    {
        int nodeId;//Node Id.
        Real64 nodePos;//Node position (Offset not exact values).
        string nodeCriteria; //Node criteria. View,Stairs,Door.

        public GraphNode()
        {
            this.NodeId = 0;
            this.NodePos = null;
            this.NodeCriteria = String.Empty;
        }

        public GraphNode(int nodeId, Real64 nodePos, string nodeCriteria)
        {
            this.NodeId = nodeId;
            this.NodePos = nodePos;
        }

        public int NodeId { get => nodeId; set => nodeId = value; }
        public string NodeCriteria { get => nodeCriteria; set => nodeCriteria = value; }
        internal Real64 NodePos { get => nodePos; set => nodePos = value; }
    }
}