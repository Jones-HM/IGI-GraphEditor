using QLibc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using WpfHexaEditor.Core;
using Media = System.Windows.Media;

namespace IGI_GraphEditor
{
    public partial class IGIGraphEditorUI : Form
    {
        internal static IGIGraphEditorUI mainRef;
        int graphId = 0, nodeId = 0;
        GraphNode graphNode;
        Real64 graphPos;
        private string graphHexBytes;

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
                standardHexBoxCb.Checked = QUtils.standardHex;
                if (standaloneCb.Checked) resetLevelBtn.Enabled = false;


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
                    graphPos = QGraphs.GetGraphPosition(graphId);
                    var qTaskGraph = QGraphs.GetQTaskGraph(graphId);

                    QUtils.aiGraphNodeIdStr = QGraphs.GetNodesForGraph(graphId);
                    levelLbl.Text = "Level" + QUtils.gGameLevel.ToString();

                    string graphArea = QGraphs.GetGraphArea(graphId);
                    graphAreaLbl.Text = graphArea;
                    graphTotalNodesTxt.Text = qTaskGraph.graphData.TotalNodes.ToString();
                    graphMaxNodesTxt.Text = qTaskGraph.graphData.MaxNodes.ToString();

                    //Update Graph Nodes.
                    UpdateUIComponent(nodeIdDD, QUtils.aiGraphNodeIdStr);
                    UpdateUIComponent(graphHexNodeIdDD, QUtils.aiGraphNodeIdStr);
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

            customHexViewerTxt.Clear();
            customHexViewerTxt.ResetText();

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
                        else QUtils.gGameLevel = QMemory.GetCurrentLevel();

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
                "Application Version:  v0.4\n";
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
            //Hex editor selected settingx.
            if (e.TabPage.Name == "graphHexEditor" && QUtils.graphFileSelected)
            {
                if (standardHexBoxCb.Checked)
                {
                    elementHost.Visible = true;
                    customHexViewerTxt.Visible = false;
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
                }
            }
        }

        private void LoadHexEditorViewer()
        {
            //Graph Hex Editor.
            string customHexView = null;
            try
            {
                if (!String.IsNullOrEmpty(QUtils.gameGraphsPath))
                {
                    var graphFileData = File.ReadAllBytes(QUtils.gameGraphsPath);
                    graphHexBytes = BitConverter.ToString(graphFileData).Replace("-", " ");

                    //Load data for Standard Hex viewer.
                    hexEditor.PreloadByteInEditorMode = PreloadByteInEditor.MaxScreenVisibleLineAtDataLoad;
                    //hexEditor.ForegroundSecondColor = Media.Brushes.Blue;
                    hexEditor.FileName = QUtils.gameGraphsPath;


                    //Load data for Custom Hex viewer.
                    //int bytesPerRow = 30,offset = 0;

                    //for (int index = 0; index < graphHexBytes.Length;)
                    //{
                    //    //customHexView += offset.ToString("X8") + "\t";

                    //    for (int i = 0; i < bytesPerRow; ++i)
                    //    {
                    //        customHexView += graphHexBytes[index] + "" + graphHexBytes[index+1] + " ";
                    //        index += 3;
                    //    }
                    //    customHexView += "\n";
                    //    offset += bytesPerRow;
                    //}
                    //graphHexBytes = customHexView;
                    customHexViewerTxt.Text = graphHexBytes;
                }
            }
            catch (Exception ex) { QUtils.LogException(MethodBase.GetCurrentMethod().Name, ex); customHexViewerTxt.Text = customHexView; }
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
                    //if (standardHexBoxCb.Checked) hexEditor.Background = QUtils.WpfGetMediaBrush(color);
                    //Formatting Signatures.
                    //HexViewerFormat("CC DD EE FF", Color.SaddleBrown, "Arial", 12, FontStyle.Underline);
                    //HexViewerFormat(graphDat.Signature, color, "Consolas", 12, FontStyle.Bold);
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

        public void HexViewerFormatter(List<string> keywords, List<Color> colors, string fontName, int fontSize, List<FontStyle> fontStyles)
        {
            for (int index = 0; index < keywords.Count; index++)
            {
                HexViewerFormat(keywords[index], colors[index], fontName, fontSize, fontStyles[index]);
            }
        }

        private void CustHexView_FormatBlocks(QGraphs.GraphDat graphDat, Color color, int nodeIndex, bool selectPos = true)
        {
            QUtils.AddLog(MethodBase.GetCurrentMethod().Name, "GraphDat Item: '" + graphDat.Item + "' Color: " + color.ToString());
            int startPosSig = graphHexBytes.NthIndexOf(graphDat.Signature, nodeIndex + 1);
            int startPosData = startPosSig + 12 * 2;
            int dataLength = 2;
            string sigData = graphHexBytes.Substring(startPosData, dataLength);
            CustHexView_FormatBlock(startPosSig, graphDat.Signature.Length, Color.Black, "Consolas", 12, FontStyle.Bold);
            CustHexView_FormatBlock(startPosData, dataLength, color, "Lucida Sans", 12, FontStyle.Underline);
            if(selectPos) customHexViewerTxt.ScrollToCaret();
        }

        // Format the selected block.
        private void CustHexView_FormatBlock(int start, int length, Color color, string fontName, int fontSize, FontStyle fontStyle)
        {
            QUtils.AddLog(MethodBase.GetCurrentMethod().Name, "Block: start: " + start + " length: " + length + " color:" + color.ToString());

            //int pos = graphHexViewerTxt.Text.IndexOf(target);
            if (start < 0)
            {
                // Not found. Select nothing.
                customHexViewerTxt.Select(0, 0);
                QUtils.AddLog(MethodBase.GetCurrentMethod().Name, "Block selected None");
            }
            else
            {
                QUtils.AddLog(MethodBase.GetCurrentMethod().Name, "Block selecting now...");
                // Found the text. Select it.
                customHexViewerTxt.Select(start, length);
                customHexViewerTxt.SelectionColor = color;
                customHexViewerTxt.SelectionFont = new Font(fontName, fontSize, fontStyle);
                QUtils.AddLog(MethodBase.GetCurrentMethod().Name, "Block selected for CustomHexBox");
            }
            customHexViewerTxt.SelectionStart = start;
            customHexViewerTxt.SelectionLength = 0;
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
            StdHexView_FormatBlock(start, length, Media.Brushes.Black, graphDat.Item.Replace("Node ", "Node #" + nodeIndex + 1 + " "));

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
                    if (standardHexBoxCb.Checked)
                        StdHexView_FormatBlocks(graphDat, QUtils.WpfGetMediaBrush(color), graphHexNodeIdDD.SelectedIndex);
                    else
                        CustHexView_FormatBlocks(graphDat, color, graphHexNodeIdDD.SelectedIndex);
                }
                else
                    QUtils.AddLog(MethodBase.GetCurrentMethod().Name, "Hex viewer data is null of empty.");
            }
            catch (Exception ex)
            {
                QUtils.LogException(MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void standardHexBoxCb_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                elementHost.Visible = true;
                customHexViewerTxt.Visible = false;
                hexEditor.FileName = QUtils.gameGraphsPath;
                QUtils.standardHex = true;
            }
            else
            {
                customHexViewerTxt.Visible = true;
                elementHost.Visible = false;
                hexEditor.FileName = "";
                QUtils.standardHex = false;
            }
        }

        private void standaloneCb_CheckedChanged(object sender, EventArgs e)
        {
            resetLevelBtn.Enabled = !((CheckBox)sender).Checked;
        }

        private void customHexViewerTxt_MouseUp(object sender, MouseEventArgs e)
        {
            RichTextBox box = (RichTextBox)sender;
            Point mouseLocation = new Point(e.X, e.Y);
            box.SelectionStart = box.GetCharIndexFromPosition(mouseLocation);
            box.SelectionLength = 0;
            int selectionStart = customHexViewerTxt.SelectionStart;
            int lineFromCharIndex = box.GetLineFromCharIndex(selectionStart);
            int charIndexFromLine = box.GetFirstCharIndexFromLine(lineFromCharIndex);

            var line = box.GetLineFromCharIndex(selectionStart) + 1;
            var col = box.SelectionStart - charIndexFromLine + 1;
            graphHexDataTxt.Text = "Line: " + line + " Col: " + col;
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
                                if (standardHexBoxCb.Checked)
                                    StdHexView_FormatBlocks(graphDat, RandomBrushes.PickBrush(), node, false);
                                else
                                    CustHexView_FormatBlocks(graphDat, QUtils.WpfGetDrawingColor(RandomBrushes.PickBrush()), node, false);
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
            if (standardHexBoxCb.Checked)
            {
                DialogResult resultDlg = QUtils.ShowDialog("Do you want to save the changes to file?");
                if (resultDlg == DialogResult.Yes)
                {
                    hexEditor.SaveCurrentState(QUtils.projAppName + "_State.dat");
                    //hexEditor.SubmitChanges();

                    Application.UseWaitCursor = true;
                    hexEditor.SubmitChanges();

                    Application.UseWaitCursor = false;
                    QUtils.ShowStatusInfo("File changes saved successfully");
                }
            }
        }

        private void HexViewerFormat(string phrase, Color color, string fontName, int fontSize, FontStyle fontStyle)
        {
            int pos = customHexViewerTxt.SelectionStart;
            string text = customHexViewerTxt.Text;
            int startIndex = 0;
            do
            {
                int index = text.IndexOf(phrase, startIndex, StringComparison.CurrentCultureIgnoreCase);
                if (index < 0) break;
                customHexViewerTxt.SelectionStart = index;
                customHexViewerTxt.SelectionLength = phrase.Length;
                customHexViewerTxt.SelectionColor = color;
                customHexViewerTxt.SelectionFont = new Font(fontName, fontSize, fontStyle);
                startIndex = index + 1;
            } while (true);

            customHexViewerTxt.SelectionStart = pos;
            customHexViewerTxt.SelectionLength = 0;
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
