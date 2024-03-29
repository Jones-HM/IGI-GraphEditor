﻿using QLibc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WpfHexaEditor.Core;
using WpfHexaEditor.Core.EventArguments;
using Media = System.Windows.Media;

namespace IGI_GraphEditor
{
    public partial class IGIGraphEditorUI : Form
    {
        internal static IGIGraphEditorUI mainRef;
        int graphId = 0, nodeId = 0;
        GraphNode graphNode;
        Real64 graphPos;
        private string graphHexBytes, graphDataTmp;

        //Main-Start - Ctr.
        public IGIGraphEditorUI()
        {
            try
            {
                bool status = false;
                InitializeComponent();
                //hexEditor settings.

                var uxLib = new UXLib();
                uxLib.CustomFormMover(formMoverPanel, this);
                this.MinimizeBox = this.MaximizeBox = false;
                mainRef = this;

                //Disable Editor on Load.
                editorTabs.Enabled = false;
                versionLbl.Text = "Version: " + QUtils.appVersion;

                //Parse config on AppStart.
                QUtils.AppInit();

                //Show Game set path dialog.
                if (!File.Exists(QUtils.cfgFile))
                    QUtils.ShowGamePathDialog();
                else QUtils.gamePathSet = true;

                //Read paths from config.
                QUtils.ParseConfig();

                //Settings after read config.
                standaloneCb.Checked = QUtils.standalone;
                enableLogsCb.Checked = QUtils.logEnabled;

                //Initialize app data for QEditor.
                if (!QUtils.gamePathSet) QUtils.AppInit();

                //Set app properties from Config file.

                if (QUtils.appOutPath != null)
                    if (QUtils.appOutPath.Length > 0) saveGraphBtn.Enabled = saveNodeBtn.Enabled = true;

                statusLbl.Text = "Output: " + Path.GetFullPath(QUtils.appOutPath);
                enableLogsCb.Checked = QUtils.logEnabled;

                //Connect to game.
                if (!standaloneCb.Checked)
                    QUtils.gameFound = GT.GT_FindGameProcess(QMemory.gameName) != null;

                //Init GraphDat.
                QGraphs.InitGraphDatList();

                //Add Graph items list.
                var graphDatItems = QGraphs.GetGraphDatItems();
                foreach (var item in graphDatItems)
                {
                    graphHexItemsDD.Items.Add(item);
                }

                //DD Settings.
                graphHexItemsDD.SelectedIndex = graphHexColorsDD.SelectedIndex = 0;

            }

            catch (Exception ex)
            {
                QUtils.ShowSystemFatalError("Exception: " + ex.Message);
            }
        }

        private void LoadGraphNodesData()
        {
            try
            {
                bool levelContinue = true;
                var currLevel = 1;
                if (!standaloneCb.Checked)
                {
                    if (QUtils.gGameLevel < 0)
                        currLevel = QMemory.GetCurrentLevel();

                    if (currLevel != QUtils.gGameLevel)
                    {
                        var showDlg = QUtils.ShowDialog("Game Level " + currLevel + " is running but you have selected Graph Files from Level " + QUtils.gGameLevel + "\nDo you want to continue ?");
                        levelContinue = showDlg == DialogResult.Yes;
                    }
                }

                if (levelContinue)
                {
                    if (standaloneCb.Checked)
                    {
                        QUtils.aiGraphNodeIdStr = QGraphs.GetNodesForGraph(graphId);
                        UpdateUIComponent(graphHexNodeIdDD, QUtils.aiGraphNodeIdStr);
                    }
                    else
                    {
                        graphPos = QGraphs.GetGraphPosition(graphId);
                        var qTaskGraph = QGraphs.GetQTaskGraph(graphId);

                        QUtils.aiGraphNodeIdStr = QGraphs.GetNodesForGraph(graphId);
                        levelLbl.Text = "Level" + QUtils.gGameLevel.ToString();

                        string graphArea = QGraphs.GetGraphArea(graphId);
                        graphAreaLbl.Text = graphArea;
                        graphTotalNodesTxt.Text = qTaskGraph.graphData.TotalNodes.ToString();
                        graphMaxNodesTxt.Text = qTaskGraph.graphData.MaxNodes.ToString();
                    }

                    //Update Graph Nodes.
                    UpdateUIComponent(nodeIdDD, QUtils.aiGraphNodeIdStr);

                }
            }
            catch (Exception ex)
            {
                QUtils.LogException(MethodBase.GetCurrentMethod().Name, ex);
            }
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
                //Enable Editor on Graph selection.
                QUtils.graphFileSelected = editorTabs.Enabled = true;

                QUtils.inputDatPath = String.Empty;
                try
                {
                    foreach (var datFile in fileDlg.FileNames)
                    {
                        if (datFile.Contains("level"))
                        {
                            var gameLevelStr = datFile.Substring(datFile.IndexOf("level"), 7);
                            QUtils.gGameLevel = Convert.ToInt32(Regex.Match(gameLevelStr, @"\d+").Value);
                        }
                        else if (!standaloneCb.Checked) QUtils.gGameLevel = QMemory.GetCurrentLevel();

                        QUtils.inputDatPath = datFile;
                        browseFile.Text = Path.GetFileName(datFile);
                        graphId = Convert.ToInt32(Regex.Match(Path.GetFileName(datFile), @"\d+").Value);
                        QUtils.gameGraphsPath = QUtils.cfgGamePath + QUtils.gGameLevel + @"\graphs\graph" + graphId + ".dat";
                        resetGraphBtn.Enabled = true;
                    }
                    statusLbl.Text = "";
                    LoadGraphNodesData();
                    LoadHexEditorViewer();
                    if (graphPosCb.Checked) LoadGraphPosData();
                    graphPosCb.Checked = false;
                    QUtils.graphAreas.Clear();
                }
                catch (Exception ex)
                {
                    QUtils.ShowLogException(MethodBase.GetCurrentMethod().Name, ex);
                }
            }
            else
            {
                QUtils.graphFileSelected = resetGraphBtn.Enabled = editorTabs.Enabled = false;
            }
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
                "Application Version: v" + QUtils.appVersion + "\n";
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
                var outGraphPath = QUtils.appOutPath + Path.GetFileName(QUtils.inputDatPath);
                int node = Convert.ToInt32(nodeIdDD.SelectedItem);
                var nodePos = new Real64();
                nodePos.x = float.Parse(nodeXTxt.Text);
                nodePos.y = float.Parse(nodeYTxt.Text);
                nodePos.z = float.Parse(nodeZTxt.Text);

                QUtils.AddLog(MethodBase.GetCurrentMethod().Name, "NodeId: " + node + " X:" + nodePos.x + " Y: " + nodePos.y + " Z:" + nodePos.z);

                var status = QGraphs.WriteGraphNodeData(QUtils.inputDatPath, node, nodePos, QUtils.nodeCriteria, outGraphPath);

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
            catch (Exception ex)
            {
                QUtils.LogException(MethodBase.GetCurrentMethod().Name, ex);
                QUtils.ShowStatusError("Node data saving Error.");
            }
        }

        private void resetGraphBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (QUtils.gGameLevel == 0 || QUtils.gGameLevel == -1) return;
                var qedGameGraphs = QUtils.levelGraphsPath + @"\level" + QUtils.gGameLevel + @"\graph" + graphId + ".dat";
                QUtils.AddLog(MethodBase.GetCurrentMethod().Name, "GraphPath: '" + qedGameGraphs + "'");

                if (File.Exists(QUtils.gameGraphsPath)) File.Delete(QUtils.gameGraphsPath);

                File.Copy(qedGameGraphs, QUtils.gameGraphsPath);
                QUtils.ShowStatusInfo("Graph reset success.");
            }
            catch (Exception ex) { QUtils.LogException(MethodBase.GetCurrentMethod().Name, ex); QUtils.ShowLogStatus(MethodBase.GetCurrentMethod().Name, "Error while resetting graph file"); }
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
                    QUtils.AddLog(MethodBase.GetCurrentMethod().Name, "Overwrite: OutQscPath: '" + outObjectsPath + "' OutQvmPath: '" + outputQvmPath + "' ");
                    if (File.Exists(outObjectsPath) && File.Exists(outputQvmPath))
                    {
                        if (File.Exists(outputQvmPath))
                            File.Delete(outputQvmPath);
                        File.Move(outObjectsPath, outputQvmPath);
                    }
                }
                QUtils.ShowStatusInfo("Graph data saved.");
            }
            catch (Exception ex)
            {
                QUtils.AddLog(MethodBase.GetCurrentMethod().Name, "Exception: " + ex.Message ?? ex.StackTrace);
                QUtils.ShowStatusError("Graph data saving Error.");
            }
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
            if (((CheckBox)sender).Checked && QUtils.inputDatPath.Length > 0)
            {
                QUtils.AddLog(MethodBase.GetCurrentMethod().Name, " getting Graph position...");
                LoadGraphPosData();
            }
            else
            {
                nodeXTxt.Text = nodeYTxt.Text = nodeZTxt.Text = "";
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
            if (!standaloneCb.Checked)
            {
                int level = QMemory.GetCurrentLevel();
                if (level < 0 || level > QUtils.GAME_MAX_LEVEL) level = 1;
                QUtils.RestoreLevel(level);
                QUtils.ResetFile(level);
                QUtils.ShowInfo("Reset level successfully.");
            }
        }

        private void nodeCurrPosCb_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked && QUtils.inputDatPath.Length > 0)
            {
                if (QUtils.gameFound)
                {
                    QUtils.AddLog(MethodBase.GetCurrentMethod().Name, "getting Node position...");

                    var currPosMeter = QHuman.GetPositionInMeter();
                    graphPos = QGraphs.GetGraphPosition(graphId);

                    //Convert Node position Single to Double.
                    var grapNodePos = new Real64().Real64Operator(graphPos, graphNode.NodePos, "+");

                    //Get real Node positions.
                    var realNodePos = new Real64().Real64Operator(currPosMeter, grapNodePos, "-");
                    realNodePos.z = realNodePos.z < 0 ? 0.0f : Math.Abs(realNodePos.z);

                    nodeXTxt.Text = realNodePos.x.ToString("0.0");
                    nodeYTxt.Text = realNodePos.y.ToString("0.0");
                    nodeZTxt.Text = realNodePos.z.ToString("0.0");
                }
            }
            else
            {
                var currPos = QHuman.GetPositionInMeter();
                var humanPos = QHuman.GetHumanTaskList(true).qtask.position;

                //Get real Node positions.
                var grapNodePos = new Real64().Real64Operator(humanPos, currPos, "-");
                //realNodePos.z = realNodePos.z < 0 ? 0.0f : Math.Abs(realNodePos.z);

                //var realNodePos = new Real64();
                //realNodePos.x = graphPos.x - grapNodePos.x;
                //realNodePos.y = graphPos.y - grapNodePos.y;
                //realNodePos.z = graphPos.z - grapNodePos.z;

                nodeXTxt.Text = grapNodePos.x.ToString("R");
                nodeYTxt.Text = grapNodePos.y.ToString("R");
                nodeZTxt.Text = grapNodePos.z.ToString("R");


                //nodeXTxt.Text = graphNode.NodePos.x.ToString("0.0");
                //nodeYTxt.Text = graphNode.NodePos.y.ToString("0.0");
                //nodeZTxt.Text = graphNode.NodePos.z.ToString("0.0");
            }
        }

        private void playerCurrPosCb_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked && QUtils.inputDatPath.Length > 0)
            {
                if (QUtils.gameFound)
                {
                    var currPosMeter = QHuman.GetPositionInMeter();
                    nodeXTxt.Text = currPosMeter.x.ToString("0.0");
                    nodeYTxt.Text = currPosMeter.y.ToString("0.0");
                    nodeZTxt.Text = currPosMeter.z.ToString("0.0");
                }
            }
            else
            {
                nodeXTxt.Text = nodeYTxt.Text = nodeZTxt.Text = "";
            }
        }

        private void enableLogsCb_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                QUtils.logEnabled = true;
                QUtils.ShowStatusInfo("Editor logs enabled...");
            }
            else
            {
                QUtils.logEnabled = false;
                QUtils.ShowStatusInfo("Editor logs disabled...");
            }
        }

        private void editorTabs_Selected(object sender, TabControlEventArgs e)
        {
            //GHex editor selected settingx.
            if (e.TabPage.Name == "graphHexEditor" && QUtils.graphFileSelected)
            {
                elementHost.Visible = true;
                hexEditor.ZoomScale = 1.3f;
                hexEditor.Background = new Media.SolidColorBrush(Media.Color.FromArgb(0x1, 0x34, 0x35, 0x54));
                //hexEditor.Background = Media.Brushes.Fuchsia;
                hexEditor.Foreground = hexEditor.ForegroundSecondColor = Media.Brushes.White;
                hexEditor.ForegroundOffSetHeaderColor = hexEditor.ForegroundHighLightOffSetHeaderColor = Media.Brushes.ForestGreen;
                graphHexColorsDD.SelectedIndex = graphHexColorsDD.Items.Count - 2;
                hexEditor.ShowByteToolTip = true;
                hexEditor.AllowAutoHighLightSelectionByte = false;
                //hexEditor.BytePerLine = 8;
                hexEditor.ByteGrouping = ByteSpacerGroup.EightByte;
                hexEditor.ByteSpacerVisualStyle = ByteSpacerVisual.Dash;
                hexEditor.ByteModifiedColor = Media.Brushes.SaddleBrown;
                hexEditor.TblEndLineColor = Media.Brushes.Red;
                hexEditor.ByteClick += new EventHandler<ByteEventArgs>(HexByteClick);
                hexEditor.ReadOnlyMode = true;
            }
        }

        long bytePos = 0;

        private void HexByteClick(object sender, ByteEventArgs e)
        {
            //var hexa = ((WpfHexaEditor.Core.Bytes)sender).HexValue;
            bytePos = e.BytePositionInStream;

            if (graphHexDataTypeTxt.Text == ("Integer"))
            {
                var data = BitConverter.ToUInt32(hexEditor.GetAllBytes().Skip((int)bytePos).Take(4).ToArray(), 0);
                graphHexDataTxt.Text = data.ToString();
            }
            else if (graphHexDataTypeTxt.Text == ("Single"))
            {
                var data = BitConverter.ToSingle(hexEditor.GetAllBytes().Skip((int)bytePos).Take(4).ToArray(), 0);
                graphHexDataTxt.Text = data.ToString();
            }
            else if (graphHexDataTypeTxt.Text == ("Double"))
            {
                var data = BitConverter.ToDouble(hexEditor.GetAllBytes().Skip((int)bytePos).Take(8).ToArray(), 0);
                graphHexDataTxt.Text = data.ToString();
            }
            else if (graphHexDataTypeTxt.Text == ("Real64x3"))
            {
                var posX = BitConverter.ToDouble(hexEditor.GetAllBytes().Skip((int)bytePos).Take(8).ToArray(), 0);
                var posY = BitConverter.ToDouble(hexEditor.GetAllBytes().Skip((int)bytePos + 8).Take(8).ToArray(), 0);
                var posZ = BitConverter.ToDouble(hexEditor.GetAllBytes().Skip((int)bytePos + 16).Take(8).ToArray(), 0);
                graphHexDataTxt.Text = posX.ToString("0.0000") + "," + posY.ToString("0.0000") + "," + posZ.ToString("0.0000");
            }
            else if (graphHexDataTypeTxt.Text == ("Stringx18"))
            {
                var data = Encoding.UTF8.GetString(hexEditor.GetAllBytes().Skip((int)bytePos).Take(18).ToArray());
                graphHexDataTxt.Text = data;
            }
            else
                graphHexDataTxt.Text = hexEditor.GetByte(bytePos).singleByte.ToString();
            graphDataTmp = graphHexDataTxt.Text;
        }

        private void LoadHexEditorViewer()
        {
            //Graph Hex Editor.
            string customHexView = null;
            try
            {
                if (!String.IsNullOrEmpty(QUtils.inputDatPath))
                {
                    var graphFileData = File.ReadAllBytes(QUtils.inputDatPath);
                    graphHexBytes = BitConverter.ToString(graphFileData).Replace("-", " ");

                    //Load data for Standard Hex viewer.
                    hexEditor.PreloadByteInEditorMode = PreloadByteInEditor.MaxScreenVisibleLineAtDataLoad;
                    hexEditor.FileName = QUtils.inputDatPath;
                }
            }
            catch (Exception ex) { QUtils.ShowLogException(MethodBase.GetCurrentMethod().Name, ex); }
        }

        private void graphHexItemsDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = graphHexItemsDD.SelectedIndex;
                var colorStr = graphHexColorsDD.SelectedItem.ToString();
                var color = Color.FromName(colorStr);
                var graphDat = QGraphs.GetGraphDat(index);

                if (graphDat != null)
                {
                    graphHexDataTypeTxt.Text = graphDat.Datatype;
                    graphHexSigTxt.Text = graphDat.Signature;
                }
            }
            catch (Exception ex)
            {
                QUtils.ShowLogException(MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void nodeIdDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                QUtils.LogException(MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void StdHexView_FormatBlocks(QGraphs.GraphDat graphDat, Media.SolidColorBrush color, int nodeIndex, bool selectPos = true)
        {

            var sigBytes = graphDat.Signature.Split(' ').Select(value => Convert.ToByte(value, 16)).ToArray();
            var posList = hexEditor.FindAll(sigBytes).ToArray();
            QUtils.AddLog(MethodBase.GetCurrentMethod().Name, "GraphDat Item: '" + graphDat.Item + "' Color: " + color.ToString() + " node index: " + nodeIndex + " select pos: " + selectPos);

            if (nodeIndex < 0 || nodeIndex > posList.Length || posList.Length <= 0 || posList[0] == -1) return;
            //Format block for signature.
            long start = posList[nodeIndex];
            int length = 4;
            StdHexView_FormatBlock(start, length, Media.Brushes.Black, graphDat.Item.Replace("Node ", "Node #" + (nodeIndex + 1) + " "));

            //Format block for data.
            long dataStart = start + 8;
            int dataLength = graphDat.Datasize;
            StdHexView_FormatBlock(dataStart, dataLength, color, graphDat.Item);

            if (selectPos) hexEditor.SetPosition(start);
        }

        private void StdHexView_FormatBlock(long start, int length, Media.SolidColorBrush color, string desc)
        {
            var cbb = new CustomBackgroundBlock(start, length, color, desc);
            QUtils.AddLog(MethodBase.GetCurrentMethod().Name, "Block: start: " + start + " length: " + length + " color:" + color.ToString());
            hexEditor.CustomBackgroundBlockItems.Add(cbb);
            hexEditor.RefreshView();
        }

        private void graphHexNodeIdDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = graphHexItemsDD.SelectedIndex;
                var colorStr = graphHexColorsDD.SelectedItem.ToString();
                var color = Color.FromName(colorStr);
                var graphDat = QGraphs.GetGraphDat(index);

                //Formatting Signature and data.
                if (!String.IsNullOrEmpty(graphHexBytes))
                {
                    StdHexView_FormatBlocks(graphDat, QUtils.WpfGetMediaBrush(color), graphHexNodeIdDD.SelectedIndex);
                }
                else
                    QUtils.AddLog(MethodBase.GetCurrentMethod().Name, "Hex viewer data is null of empty.");
            }
            catch (Exception ex)
            {
                QUtils.LogException(MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void standaloneCb_CheckedChanged(object sender, EventArgs e)
        {
            resetLevelBtn.Enabled = !((CheckBox)sender).Checked;
        }

        private void graphHexResetDataCb_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                hexEditor.ClearCustomBackgroundBlock();
                hexEditor.ClearAllChange();
                hexEditor.ClearAllScrollMarker();
                QUtils.ShowStatusInfo("Reset data success");
                ((CheckBox)sender).Checked = false;
            }
        }

        private void graphHexFormatCb_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                try
                {
                    for (int node = 0; node < nodeIdDD.Items.Count; node++)
                    {
                        try
                        {
                            foreach (var graphDat in QGraphs.graphDatList)
                            {
                                StdHexView_FormatBlocks(graphDat, RandomBrushes.PickBrush(), node, false);
                            }
                        }
                        catch (Exception) { };
                    }
                    QUtils.ShowStatusInfo("All data format success");
                }
                catch (Exception ex)
                {
                    QUtils.LogException(MethodBase.GetCurrentMethod().Name, ex);
                }
            ((CheckBox)sender).Checked = false;
            }
        }

        private void graphHexSaveBtn_Click(object sender, EventArgs e)
        {

            DialogResult resultDlg = QUtils.ShowDialog("Do you want to save the changes to file?");
            if (resultDlg == DialogResult.Yes)
            {
                hexEditor.SaveCurrentState(QUtils.projAppName + "_state.dat");
                Application.UseWaitCursor = true;
                hexEditor.SubmitChanges();
                Application.UseWaitCursor = false;
                QUtils.ShowStatusInfo("File changes saved successfully");
            }
        }

        private void editModeCb_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                var showDlg = QUtils.ShowDialog("Do you want to enable edit mode ?");
                if (showDlg == DialogResult.Yes)
                    hexEditor.ReadOnlyMode = false;
                else (((CheckBox)sender).Checked) = false;
            }
            else {
                hexEditor.ReadOnlyMode = true;
            }
        }

        private void graphHexDataTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void graphHexDataTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    var graphHexData = graphHexDataTxt.Text;
                    byte[] bytes = new byte[0];

                    if (graphHexDataTypeTxt.Text == ("Integer"))
                        bytes = BitConverter.GetBytes(Convert.ToUInt32(graphHexData));
                    else if (graphHexDataTypeTxt.Text == ("Single"))
                        bytes = BitConverter.GetBytes(Convert.ToSingle(graphHexData));
                    else if (graphHexDataTypeTxt.Text == ("Double"))
                        bytes = BitConverter.GetBytes(Convert.ToDouble(graphHexData));
                    else if (graphHexDataTypeTxt.Text == ("Real64x3"))
                    {
                        var strX = graphHexData.Slice(0, graphHexData.IndexOf(","));
                        QUtils.AddLog(MethodBase.GetCurrentMethod().Name, "String XPos: " + strX);
                        var bytesX = BitConverter.GetBytes(Convert.ToSingle(strX));
                        QUtils.AddLog(MethodBase.GetCurrentMethod().Name, "Bytes XPos: " + bytesX.Length);

                        var strY = graphHexData.Slice(graphHexData.IndexOf(",") + 1, graphHexData.LastIndexOf(","));
                        QUtils.AddLog(MethodBase.GetCurrentMethod().Name, "String YPos: " + strY);
                        var bytesY = BitConverter.GetBytes(Convert.ToDouble(strY));
                        QUtils.AddLog(MethodBase.GetCurrentMethod().Name, "Bytes YPos: " + bytesY.Length);

                        var strZ = graphHexData.Substring(graphHexData.LastIndexOf(",") + 1);
                        QUtils.AddLog(MethodBase.GetCurrentMethod().Name, "String ZPos: " + strZ);
                        var bytesZ = BitConverter.GetBytes(Convert.ToSingle(strZ));
                        QUtils.AddLog(MethodBase.GetCurrentMethod().Name, "Bytes ZPos: " + bytesZ.Length);

                        if (!graphDataTmp.Contains(strX)) { bytes = bytesX; };
                        if (!graphDataTmp.Contains(strY)) { bytes = bytesY; bytePos += 8; };
                        if (!graphDataTmp.Contains(strZ)) { bytes = bytesZ; bytePos += 16; };

                        //Write Node position X,Y,Z in Double format.
                        //Buffer.BlockCopy(bytesX, 0, bytes, 0, bytesX.Length);
                        //Buffer.BlockCopy(bytesY, 0, bytes, 8, bytesY.Length);
                        //Buffer.BlockCopy(bytesZ, 0, bytes, 16, bytesZ.Length);

                        //Array.Reverse(bytesX); Array.Reverse(bytesY); Array.Reverse(bytesZ);

                    }
                    else if (graphHexDataTypeTxt.Text == ("Stringx18"))
                        bytes = Encoding.ASCII.GetBytes(graphHexDataTxt.Text);

                    //Write updated bytes to Hex Editor.
                    for (int i = 0; i < bytes.Length; ++i)
                        hexEditor.FillWithByte(bytePos + i, 1, bytes[i]);
                    //    hexEditor.ModifyByte(bytes[i],bytePos);
                }

                catch (Exception ex)
                {
                    QUtils.LogException(MethodBase.GetCurrentMethod().Name, ex);
                }

            }
        }
    }

    public static class StringExtender
    {
        public static int NthIndexOf(this string target, string value, int n)
        {
            Match m = Regex.Match(target, "((" + Regex.Escape(value) + ").*?){" + n + "}");

            if (m.Success)
                return m.Groups[2].Captures[n - 1].Index;
            else
                return -1;
        }
    }

    public static class RichTextBoxExtender
    {
        public static void ScrollToLine(this RichTextBox box, int line)
        {
            if (line > box.Lines.Count()) return;

            int index = box.GetFirstCharIndexFromLine(line);
            box.Select(index, 0);
            box.ScrollToCaret();
        }
    }
}
