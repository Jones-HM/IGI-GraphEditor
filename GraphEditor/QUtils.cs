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
        internal static string nodeCriteria, inputMissionPath = @"\missions\location0\level", inputQscPath = @"\IGI_QSC", qfilesPath = @"\QFiles", objectsQsc = "objects.qsc", objectsQvm = "objects.qvm", aiGraphTask = "AIGraph", qEditor = "QEditor", qscData = null, graphFile = null, projAppName;
        internal static string qGraphsPath, igiEditorQEdPath, appdataPath, levelGraphsPath, gameGraphsPath;
        private static string cfgQvmPath;
        internal static int gGameLevel;
        internal static Dictionary<int, string> graphAreas = new Dictionary<int, string>();
        internal static long GAME_MAX_LEVEL = 14;
        internal const string CAPTION_CONFIG_ERR = "Config - Error", CAPTION_FATAL_SYS_ERR = "Fatal sytem - Error", CAPTION_APP_ERR = "Application - Error", CAPTION_COMPILER_ERR = "Compiler - Error", EDITOR_LEVEL_ERR = "EDITOR ERROR";

        internal static string inputDatPath;

        internal static bool gamePathSet = false, cfgMultiDll = false, cfgAutoInject = false;
        internal static int cfgDelayDll = 10, cfgGameLevel = 1, IGI1_MAX_LEVEL = 14, IGI2_MAX_LEVEL = 19;
        internal static string cfgQscPath, gameAbsPath, appOutPath, cfgGamePath, cfgGameName = "igi", cfgFile, cfgGameMode = "windowed", injectorFile = @"bin\igi-injector-cmd.exe";
        internal static bool gameFound = false, logEnabled = false, gameReset = false, editorOnline = false;
        private static string logFile, appCurrPath;
        internal static float appEditorVersion = 0.3f, viewPortDelta = 3000.0f;

        private static QIniParser qIniParser;
        private static IniParser iniParser;
        internal static string PATH_SEC = "PATH", EDITOR_SEC = "EDITOR";
        private static string inputQvmPath = @"\IGI_QVM", cfgGamePathEx = @"\missions\location0\level";


        public class QTask
        {
            public Int32 id;
            public string name;
            public string note;
            public Real64 position;
            public Real32 orientation;
            public string model;
        };

        public class HTask
        {
            public int team;
            public QTask qtask;
            public List<string> weaponsList;
        };

        internal static string LoadFile()
        {
            return LoadFile(objectsQsc);
        }

        internal static string LoadFile(string fileName)
        {
            string data = null;
            if (File.Exists(fileName))
                data = File.ReadAllText(fileName);
            return data;
        }

        internal static void SaveFile(string data = null, bool appendData = false)
        {
            SaveFile(objectsQsc, data, appendData);
        }

        internal static void SaveFile(string fileName, string data, bool appendData = false)
        {
            if (appendData)
                File.AppendAllText(fileName, data);
            else
                File.WriteAllText(fileName, data);
        }

        internal static bool DllRunner(bool dllInject)
        {
            bool status;
            if (inputDatPath.Length > 0 && inputDatPath.Length > 3)
            {
                bool gameRunning = IsGameRunning();
                if (gameRunning)
                {
                    string inputDllPath = "";

                    foreach (var dllName in inputDatPath)
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
            cfgQvmPath = igiEditorQEdPath + qfilesPath + inputQvmPath + inputMissionPath;
            cfgQscPath = igiEditorQEdPath + qfilesPath + inputQscPath + inputMissionPath;
            QUtils.projAppName = AppDomain.CurrentDomain.FriendlyName.Replace(".exe", String.Empty);
            QUtils.cfgFile = QUtils.projAppName + ".ini";
            QUtils.logFile = QUtils.projAppName + ".log";
            QUtils.appCurrPath = Directory.GetCurrentDirectory();
            qIniParser = new QIniParser(cfgFile);
            //gGameLevel = QMemory.GetCurrentLevel();
        }

        internal static void ShowGamePathDialog()
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            folderBrowser.FileName = "Folder Selection.";
            folderBrowser.Title = "Select Game path";

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                gameAbsPath = appOutPath = Path.GetDirectoryName(folderBrowser.FileName) + Path.DirectorySeparatorChar;
                cfgGamePath = (!String.IsNullOrEmpty(gameAbsPath)) ? (gameAbsPath.Trim() + QMemory.gameName + ".exe") : null;
                bool status = File.Exists(cfgGamePath);

                if (!status)
                {
                    gamePathSet = false;
                    ShowSystemFatalError("Error occurred while setting game path.");
                }
                else
                {
                    ShowInfo("Game path was saved successfully.");
                    gamePathSet = true;
                }
            }
        }

        internal static void ParseConfig()
        {
            try
            {
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
                        ShowGamePathDialog();//Prompt for Game path on invalid path.
                    }
                    QUtils.gameAbsPath = gPath;
                    QUtils.cfgGamePath = configPath.Trim() + QUtils.cfgGamePathEx;


                    QUtils.logEnabled = bool.Parse(qIniParser.Read("app_logs", EDITOR_SEC));
                    QUtils.gameReset = bool.Parse(qIniParser.Read("game_reset", EDITOR_SEC));
                }
                else
                {
                    //ShowWarning("Config file not found in current directory", QUtils.CAPTION_CONFIG_ERR);
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
            qIniParser.Write("app_logs", logEnabled.ToString(), EDITOR_SEC);

            if (!gameFound) Environment.Exit(1);
        }

        internal static void AddLog(string methodName, string logMsg)
        {
            if (logEnabled)
            {
                methodName = methodName.Replace("_Click", String.Empty).Replace("_SelectedIndexChanged", String.Empty).Replace("_SelectedValueChanged", String.Empty);
                File.AppendAllText(logFile, "[" + DateTime.Now.ToString("yyyy-MM-dd - HH:mm:ss") + "] " + methodName + "(): " + logMsg + "\n");
            }
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

        public static DialogResult ShowDialog(string infoMsg, string caption = "INFO")
        {
            return MessageBox.Show(infoMsg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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


        internal static void LogException(string methodName, Exception ex)
        {
            methodName = methodName.Replace("_Click", String.Empty).Replace("_SelectedIndexChanged", String.Empty).Replace("_SelectedValueChanged", String.Empty);
            AddLog(methodName, "Exception MESSAGE: " + ex.Message + "\nREASON: " + ex.StackTrace);
        }

        internal static void ShowException(string methodName, Exception ex)
        {
            ShowError("MESSAGE: " + ex.Message + "\nREASON: " + ex.StackTrace, methodName + " Exception");
        }

        internal static void ShowLogException(string methodName, Exception ex)
        {
            methodName = methodName.Replace("_Click", String.Empty).Replace("_SelectedIndexChanged", String.Empty).Replace("_SelectedValueChanged", String.Empty);
            //Show and Log exception for method name.
            ShowException(methodName, ex);
            LogException(methodName, ex);
        }

        internal static void ShowLogError(string methodName, string errMsg, string caption = "ERROR")
        {
            methodName = methodName.Replace("_Click", String.Empty).Replace("_SelectedIndexChanged", String.Empty).Replace("_SelectedValueChanged", String.Empty);
            //Show and Log error for method name.
            ShowError(methodName + "(): " + errMsg, caption);
            AddLog(methodName, errMsg);
        }

        internal static void ShowLogStatus(string methodName, string logMsg)
        {
            ShowStatusInfo(logMsg);
            AddLog(methodName, logMsg);
        }

        internal static void ShowLogInfo(string methodName, string logMsg)
        {
            ShowInfo(logMsg);
            AddLog(methodName, logMsg);
        }

        internal static void RestoreLevel(int gameLevel)
        {
            if (gameLevel < 0 || gameLevel > GAME_MAX_LEVEL) gameLevel = 1;
            var gPath = cfgGamePath;

            if (cfgGamePath.Contains(" ")) gPath = cfgGamePath.Replace("\"", String.Empty);

            gPath = cfgGamePath + gameLevel;
            string outputQvmPath = gPath + "\\" + objectsQvm;
            string inputQvmPath = cfgQvmPath + gameLevel + "\\" + objectsQvm;

            File.Delete(outputQvmPath);
            File.Copy(inputQvmPath, outputQvmPath);

            var inFileData = File.ReadAllText(inputQvmPath);
            var outFileData = File.ReadAllText(outputQvmPath);

            if (inFileData == outFileData)
                ShowStatusInfo("Restrore of level '" + gameLevel + "' success");
            else
                ShowStatusInfo("Error in restroing level : " + gameLevel);
        }

        internal static void ResetFile(int level)
        {
            var inputQscPath = cfgQscPath + level + "\\" + objectsQsc;

            if (File.Exists(objectsQsc)) File.Delete(objectsQsc);
            File.Copy(inputQscPath, objectsQsc);

            var fileData = QUtils.LoadFile(objectsQsc);
            File.WriteAllText(objectsQsc, fileData);
        }
    }


    enum QTASKINFO
    {
        QTASK_ID,
        QTASK_NAME,
        QTASK_NOTE,
        //Object pos in Real64x3.
        QTASK_POSX,
        QTASK_POSY,
        QTASK_POSZ,
        //Object orientation in Real32x9.
        QTASK_ALPHA,
        QTASK_BETA,
        QTASK_GAMMA,
        //Mode ID in String16
        QTASK_MODEL,
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

        public Real64 Real64Operator(Real64 real1, Real64 real2, string operatorType)
        {
            Real64 real = new Real64();

            if (operatorType == "+")
            {
                real.x = real1.x + real2.x;
                real.y = real1.y + real2.y;
                real.z = real1.z + real2.z;
            }
            else if (operatorType == "-")
            {
                real.x = real1.x - real2.x;
                real.y = real1.y - real2.y;
                real.z = real1.z - real2.z;
            }
            return real;
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