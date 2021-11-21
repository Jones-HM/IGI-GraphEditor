using QLibc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace IGI_GraphEditor
{
    public partial class IGIGraphEditorUI : Form
    {
        internal static IGIGraphEditorUI mainRef;
        int graphId = 0, nodeId = 0;
        GraphNode graphNode;
        Real64 graphPos;

        public IGIGraphEditorUI()
        {
            try
            {
                InitializeComponent();
                var uxLib = new UXLib();
                uxLib.CustomFormMover(formMoverPanel, this);

                this.MinimizeBox = this.MaximizeBox = false;
                mainRef = this;

                QUtils.inputDatPaths = new List<string>();

                //Parse config on AppStart.
                QUtils.AppInit();

                //Read paths from config.
                QUtils.ParseConfig();

                //Set app properties from Config file.

                if (QUtils.appOutPath.Length > 0) saveGraphBtn.Enabled = saveNodeBtn.Enabled = true;

                //setOutputPathBtn.Enabled = false;
                statusLbl.Text = "Output: " + Path.GetFullPath(QUtils.appOutPath);

                //Connect to game.
                QUtils.gameFound = GT.GT_FindGameProcess(QMemory.gameName) != null;
            }

            catch (Exception ex)
            {
                QUtils.ShowSystemFatalError("Exception: " + ex.Message);
            }
        }

        private void LoadGraphNodesData()
        {
            graphIdTxt.Text = graphId.ToString();
            graphPos = QGraphs.GetGraphPosition(graphId);
            var qTaskGraph = QGraphs.GetQTaskGraph(graphId);

            QUtils.aiGraphNodeIdStr = QGraphs.GetNodesForGraph(graphId);
            levelLbl.Text = "Level " + QUtils.gGameLevel.ToString();

            string graphArea = QGraphs.GetGraphArea(graphId);
            graphAreaLbl.Text = graphArea;
            graphTotalNodesTxt.Text = qTaskGraph.graphData.TotalNodes.ToString();
            graphMaxNodesTxt.Text = qTaskGraph.graphData.MaxNodes.ToString();

            //Update Graph Nodes.
            UpdateUIComponent(nodeIdDD, QUtils.aiGraphNodeIdStr);
        }

        private void browseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.Filter = "Graph files (*.dat)|*.dat|All files (*.*)|*.*";
            //fileDlg.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            fileDlg.Title = "Select Graph file";
            fileDlg.DefaultExt = ".dat";
            fileDlg.Multiselect = false;
            fileDlg.CheckFileExists = fileDlg.RestoreDirectory = fileDlg.AddExtension = true;

            DialogResult resultDlg = fileDlg.ShowDialog();
            if (resultDlg == DialogResult.OK)
            {
                QUtils.inputDatPaths.Clear();
                try
                {
                    foreach (var datFile in fileDlg.FileNames)
                    {
                        if (datFile.Contains("level"))
                        {
                            var gameLevelStr = datFile.Substring(datFile.IndexOf("level"), 7);
                            QUtils.gGameLevel = Convert.ToInt32(Regex.Match(gameLevelStr, @"\d+").Value);
                        }
                        else QUtils.gGameLevel = QMemory.GetCurrentLevel();

                        QUtils.inputDatPaths.Add(datFile);
                        browseFile.Text = Path.GetFileName(datFile);
                        graphId = Convert.ToInt32(Regex.Match(Path.GetFileName(datFile), @"\d+").Value);
                        QUtils.gameGraphsPath = QUtils.cfgGamePath + QUtils.gGameLevel + @"\graphs\graph" + graphId + ".dat";
                        resetGraphBtn.Enabled = true;
                    }
                    statusLbl.Text = "";
                    LoadGraphNodesData();
                    if (graphPosCb.Checked) LoadGraphPosData();
                    graphPosCb.Checked = false;
                    QUtils.graphAreas.Clear();
                }
                catch (IOException ex)
                {
                    QUtils.ShowStatusError(ex.Message);
                }
            }
            else resetGraphBtn.Enabled = false;
        }

        private void setGamePathBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            folderBrowser.FileName = "Folder Selection.";

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                QUtils.appOutPath = Path.GetDirectoryName(folderBrowser.FileName) + Path.DirectorySeparatorChar;
                QUtils.ShowStatusInfo("Output path set success");
                saveGraphBtn.Enabled = saveNodeBtn.Enabled = true;
            }
            else saveGraphBtn.Enabled = saveNodeBtn.Enabled = false;
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            string infoMsg = "IGI-GraphEditor is tool to Edit Graphs Nodes in Game\n" +
                "Developed by: Haseeb Mir\n" +
                "App/Language: C# (.NET 4.0) / GUI.\n" +
                "Tools/Language: C++17 / CMD.\n" +
                "Application Version:  v1.1\n";
            QUtils.ShowInfo(infoMsg);
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void gameTypeDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            var gameName = ((ComboBox)sender).Text;
            var gameIndex = ((ComboBox)sender).SelectedIndex;
            if (!String.IsNullOrEmpty(gameName))
            {
                QUtils.cfgGameName = gameName.Replace("Project ", String.Empty).Replace(" ", String.Empty).ToLower();
                if (QUtils.cfgGameName.Contains("igi1")) QUtils.cfgGameName = QUtils.cfgGameName.Replace("igi1", "igi");
            }
        }

        private void delayTxt_ValueChanged(object sender, EventArgs e)
        {
            QUtils.cfgDelayDll = Int32.Parse(((NumericUpDown)(sender)).Value.ToString());
        }

        private void gameTypeDD_MouseClick(object sender, MouseEventArgs e)
        {
            setOutputPathBtn.Enabled = true;
        }

        //Generic Update UI method for DropDowns,TextBox etc.
        private void UpdateUIComponent<T>(ComboBox itemDD, List<T> dataSrcList)
        {
            try
            {
                itemDD.DataSource = null;
                itemDD.Items.Clear();
                itemDD.DataSource = dataSrcList;
                itemDD.Invalidate();
                itemDD.Update();
                itemDD.Refresh();
                itemDD.SelectedIndex = 0;
                Application.DoEvents();
            }
            catch (Exception) { }
        }


        private void saveNodeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var outGraphPath = QUtils.appOutPath + Path.GetFileName(QUtils.inputDatPaths[0]);
                int node = Convert.ToInt32(nodeIdDD.SelectedItem);
                var nodePos = new Real64();
                nodePos.x = float.Parse(nodeXTxt.Text);
                nodePos.y = float.Parse(nodeYTxt.Text);
                nodePos.z = float.Parse(nodeZTxt.Text);

                QUtils.AddLog("SaveGraph(): NodeId: " + node + " X:" + nodePos.x + " Y: " + nodePos.y + " Z:" + nodePos.z);

                var status = QGraphs.WriteGraphNodeData(QUtils.inputDatPaths[0], node, nodePos, outGraphPath);


                if (status)
                {
                    if (overwriteCb.Checked)
                    {
                        if (File.Exists(outGraphPath))
                        {
                            if (File.Exists(QUtils.gameGraphsPath))
                                File.Delete(QUtils.gameGraphsPath);
                            File.Move(outGraphPath, QUtils.gameGraphsPath);
                        }
                    }

                    QUtils.ShowStatusInfo("Node information saved.");
                    nodeCurrPosCb.Checked = false;
                }
            }
            catch (Exception) { QUtils.ShowStatusError("Node data saving Error."); }
        }

        private void resetGraphBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (QUtils.gGameLevel == 0 || QUtils.gGameLevel == -1) return;
                var qedGameGraphs = QUtils.levelGraphsPath + @"\level" + QUtils.gGameLevel + @"\graph" + graphId + ".dat";

                if (File.Exists(QUtils.gameGraphsPath))
                    File.Delete(QUtils.gameGraphsPath);

                File.Copy(qedGameGraphs, QUtils.gameGraphsPath);
                QUtils.ShowStatusInfo("Graph reset success.");
            }
            catch (Exception) { }
        }

        private void currPosCb_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked && QUtils.inputDatPaths.Count > 0)
            {
                if (QUtils.gameFound)
                {
                    var currPosMeter = QHuman.GetPositionInMeter();

                    graphPos = QGraphs.GetGraphPosition(graphId);

                    //Convert Node position Single to Double.
                    var grapNodePos = new Real64();
                    grapNodePos.x = graphPos.x + graphNode.NodePos.x;
                    grapNodePos.y = graphPos.y + graphNode.NodePos.y;
                    grapNodePos.z = graphPos.z + graphNode.NodePos.z;

                    //Get real Node positions.
                    var realNodePos = new Real64();
                    realNodePos.x = currPosMeter.x - grapNodePos.x;
                    realNodePos.y = currPosMeter.y - grapNodePos.y;
                    realNodePos.z = (currPosMeter.z - grapNodePos.z);

                    nodeXTxt.Text = realNodePos.x.ToString("0.0");
                    nodeYTxt.Text = realNodePos.y.ToString("0.0");
                    nodeZTxt.Text = realNodePos.z.ToString("0.0");
                }
            }
            else
            {
                nodeXTxt.Text = graphNode.NodePos.x.ToString("0.0");
                nodeYTxt.Text = graphNode.NodePos.y.ToString("0.0");
                nodeZTxt.Text = graphNode.NodePos.z.ToString("0.0");
            }
        }

        private void saveGraphBtn_Click(object sender, EventArgs e)
        {
                try
            {
                var aiGraphPos = new Real64();
                aiGraphPos.x = float.Parse(nodeXTxt.Text);
                aiGraphPos.y = float.Parse(nodeYTxt.Text);
                aiGraphPos.z = float.Parse(nodeZTxt.Text);

                var qGraphData = new QGraphs.QGraphData();
                qGraphData.MaxNodes = Convert.ToInt32(graphMaxNodesTxt.Text);
                qGraphData.TotalNodes = Convert.ToInt32(graphTotalNodesTxt.Text);

                var qscData = QGraphs.UpdateAiGraphData(graphId, aiGraphPos, qGraphData);
                File.WriteAllText(QUtils.appOutPath + @"\" + QUtils.objectsQsc, qscData);
                string outputQvmPath = QUtils.cfgGamePath + "\\" + QUtils.objectsQvm;

                var outObjectsPath = QUtils.appOutPath + @"\" + QUtils.objectsQsc;
                if (overwriteCb.Checked)
                {
                    if (File.Exists(outObjectsPath))
                    {
                        if (File.Exists(outputQvmPath))
                            File.Delete(outputQvmPath);
                        File.Move(outObjectsPath, outputQvmPath);
                    }
                }
                QUtils.ShowStatusInfo("Graph data saved.");
            }
            catch (Exception) { QUtils.ShowStatusError("Graph data saving Error."); }
        }

        private void LoadGraphPosData()
        {
            graphPos = QGraphs.GetGraphPosition(graphId);
            nodeXTxt.Text = graphPos.x.ToString("0.0");
            nodeYTxt.Text = graphPos.y.ToString("0.0");
            nodeZTxt.Text = graphPos.z.ToString("0.0");
        }

        private void graphPosCb_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked && QUtils.inputDatPaths.Count > 0)
            {
                LoadGraphPosData();
            }
        }

        private void statusLbl_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(QUtils.appOutPath);
            QUtils.ShowInfo("Path copied successfully.");
        }

        private void nodeCriteriaDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            QUtils.nodeCriteria = ((ComboBox)sender).Text;
        }

        private void resetLevelBtn_Click(object sender, EventArgs e)
        {
            int level = QMemory.GetCurrentLevel();
            if (level < 0 || level > QUtils.GAME_MAX_LEVEL) level = 1;
            QUtils.RestoreLevel(level);
            QUtils.ResetFile(level);
        }

        private void nodeIdDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Load Node data.
            if (nodeIdDD.SelectedIndex == -1) nodeIdDD.SelectedIndex = 0;
            nodeId = QUtils.aiGraphNodeIdStr[nodeIdDD.SelectedIndex];
            graphNode = QGraphs.GetGraphNodeData(graphId, nodeId);

            //Setting Node properties.
            nodeCriteriaDD.Text = graphNode.NodeCriteria;
            if (graphNode.NodeCriteria.Length == 0)
                nodeCriteriaDD.SelectedIndex = 0;


            nodeXTxt.Text = graphNode.NodePos.x.ToString("0.0");
            nodeYTxt.Text = graphNode.NodePos.y.ToString("0.0");
            nodeZTxt.Text = graphNode.NodePos.z.ToString("0.0");
        }
    }
}
