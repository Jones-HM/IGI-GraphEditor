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

                if (QUtils.appOutPath.Length > 0) saveGraphBtn.Enabled = true;

                //setOutputPathBtn.Enabled = false;
                statusLbl.Text = "Output: " + Path.GetFullPath(QUtils.appOutPath);

            }

            catch (Exception ex)
            {
                QUtils.ShowSystemFatalError("Exception: " + ex.Message);
            }
        }

        private void LoadGraphNodesData()
        {
            graphIdTxt.Text = graphId.ToString();
            //var graphPos = QGraphs.GetGraphPosition(graphId);

            QUtils.aiGraphNodeIdStr = QGraphs.GetNodesForGraph(graphId);
            var graphTotalNodes = QUtils.aiGraphNodeIdStr.Count;

            string graphArea = QGraphs.GetGraphArea(graphId);
            graphAreaLbl.Text = graphArea;
            graphTotalNodesTxt.Text = graphTotalNodes.ToString();

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

                        QUtils.inputDatPaths.Add(datFile);
                        browseFile.Text = Path.GetFileName(datFile);
                        graphId = Convert.ToInt32(Regex.Match(Path.GetFileName(datFile), @"\d+").Value);
                        QUtils.gameGraphsPath = QUtils.cfgGamePath + QUtils.gGameLevel + @"\graphs\graph" + graphId + ".dat";
                        resetGraphBtn.Enabled = true;
                    }
                    statusLbl.Text = "";
                    LoadGraphNodesData();
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
                saveGraphBtn.Enabled = true;
            }
            else saveGraphBtn.Enabled = false;
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            string infoMsg = "IGI-GraphEditor is tool to Edit Graphs Nodes in Game\n" +
                "Developed by: Haseeb Mir\n" +
                "App/Language: C# (.NET 4.0) / GUI.\n" +
                "Tools/Language: C++17 / CMD.\n" +
                "Application Version:  v1.0\n";
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


        private void saveGraphBtn_Click(object sender, EventArgs e)
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
                        File.Move(outGraphPath ,QUtils.gameGraphsPath);
                    }
                }

                QUtils.ShowStatusInfo("Node information saved.");
            }
        }

        private void resetGraphBtn_Click(object sender, EventArgs e)
        {
            if (QUtils.gGameLevel == 0 || QUtils.gGameLevel == -1) return;
            var qedGameGraphs = QUtils.levelGraphsPath + @"\level" + QUtils.gGameLevel + @"\graph" + graphId + ".dat";

            if (File.Exists(QUtils.gameGraphsPath))
                File.Delete(QUtils.gameGraphsPath);

            File.Move(qedGameGraphs, QUtils.gameGraphsPath);
            QUtils.ShowStatusInfo("Graph reset success.");
        }

        private void nodeIdDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Load Node data.
            if (nodeIdDD.SelectedIndex == -1) nodeIdDD.SelectedIndex = 0;
            nodeId = QUtils.aiGraphNodeIdStr[nodeIdDD.SelectedIndex];
            var graphNode = QGraphs.GetGraphNodeData(graphId, nodeId);

            //Setting Node properties.
            nodeCriteriaTxt.Text = graphNode.NodeCriteria;

            nodeXTxt.Text = graphNode.NodePos.x.ToString("0.0");
            nodeYTxt.Text = graphNode.NodePos.y.ToString("0.0");
            nodeZTxt.Text = graphNode.NodePos.z.ToString("0.0");
        }
    }
}
