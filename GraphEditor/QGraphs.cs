using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static IGI_GraphEditor.QUtils;

namespace IGI_GraphEditor
{
    class QGraphs
    {
        enum QTASKINFO
        {
            QTASK_ID,
            QTASK_NAME,
            QTASK_NOTE,
            //Object pos in Real64x3.
            QTASK_POSX,
            QTASK_POSY,
            QTASK_POSZ,

            //Graph data.
            QTASK_UPDATE,
            QTASK_GRAPH_TOTAL_NODES,
            QTASK_GRAPH_MAX_NODES,
            QTASK_GRAPH_DATA,

            //Graph properties in Real64.
            QTASK_MID_OFFSET,
            QTASK_TOP_OFFSET,
            QTASK_HEIGH_DIFF,
            QTASK_NODE_WIDTH,
            QTASK_GROUND_DIST,
            QTASK_USE_PRECISE,
            QTASK_PRECISE_STEP_VAL
        }

        public class QGraphData
        {
            private int totalNodes;
            private int maxNodes;
            private int data;

            public int TotalNodes { get => totalNodes; set => totalNodes = value; }
            public int MaxNodes { get => maxNodes; set => maxNodes = value; }
            public int Data { get => data; set => data = value; }
        }
        public class QTaskGraph
        {
            public Int32 id;
            public string name;
            public string note;
            public Real64 position;
            public bool update;
            public bool usePrecise;
            public QGraphData graphData;
            public Double midOffsets;
            public Double topOffsets;
            public Double heightDiff;
            public Double nodeWidth;
            public Double groundDist;
            public Double preciseStepVal;
        };

        internal static List<GraphNode> ReadGraphNodeData(string graphFile)
        {
            var graphFileData = File.ReadAllBytes(graphFile);
            List<GraphNode> graphNodeData = new List<GraphNode>();

            for (int index = 0; index < graphFileData.Length; index++)
            {
                //Find Node signature - 04CE
                if (graphFileData[index] == 0x04 && graphFileData[index + 1] == 0xCE)
                {
                    var graphData = new GraphNode();
                    double x, y, z;
                    var nodeIdData = graphFileData.Skip(index + 8).Take(4).ToArray();
                    int nodeId = BitConverter.ToInt32(nodeIdData, 0);

                    //Read Node X,Y,Z Position offset.

                    int nodePosXIndex = index + 20;
                    int nodePosYIndex = nodePosXIndex + 8;
                    int nodePosZIndex = nodePosYIndex + 8;

                    var nodePosXData = graphFileData.Skip(nodePosXIndex).Take(8).ToArray();
                    x = BitConverter.ToDouble(nodePosXData, 0);

                    var nodePosYData = graphFileData.Skip(nodePosYIndex).Take(8).ToArray();
                    y = BitConverter.ToDouble(nodePosYData, 0);

                    var nodePosZData = graphFileData.Skip(nodePosZIndex).Take(8).ToArray();
                    z = BitConverter.ToDouble(nodePosZData, 0);

                    //Read node criteria.
                    int nodeCriteriaIndex = index + 88 + 1;
                    var nodeCriteriaData = graphFileData.Skip(nodeCriteriaIndex).Take(18).ToArray();
                    string nodeCriteria = Encoding.UTF8.GetString(nodeCriteriaData);
                    nodeCriteria = nodeCriteria.IsNonASCII() ? String.Empty : nodeCriteria;

                    //Adding Graph Node data.
                    graphData.NodeId = nodeId;
                    graphData.NodePos = new Real64(x, y, z);
                    graphData.NodeCriteria = nodeCriteria;
                    graphNodeData.Add(graphData);
                }
            }
            return graphNodeData;
        }

        internal static bool WriteGraphNodeData(string graphFile, int node, Real64 nodePos, string nodeCriteria, string outPath)
        {
            QUtils.AddLog("WriteGraphNodeData(): file: '" + graphFile + "' nodeId: " + node + " NodePos X: " + nodePos.x + " NodePos Y: " + nodePos.y + " NodePos Z: " + nodePos.z + " NodeCriteria: " + nodeCriteria + " OutPath: '" + outPath + "'");
            bool nodeIdFound = false;
            var graphFileData = File.ReadAllBytes(graphFile);
            List<byte> graphBytes = new List<byte>();
            graphBytes = graphFileData.ToList();

            for (int index = 0; index < graphFileData.Length; index++)
            {
                //Find Node signature - 04CE
                if (graphFileData[index] == 0x04 && graphFileData[index + 1] == 0xCE)
                {
                    double x, y, z;
                    var nodeIdData = graphFileData.Skip(index + 8).Take(4).ToArray();
                    int nodeId = BitConverter.ToInt32(nodeIdData, 0);

                    if (nodeId == node)
                    {
                        //Read Node X,Y,Z Position offset.

                        int nodePosXIndex = index + 20;
                        int nodePosYIndex = nodePosXIndex + 8;
                        int nodePosZIndex = nodePosYIndex + 8;

                        var nodeX = BitConverter.GetBytes(nodePos.x);
                        var nodeY = BitConverter.GetBytes(nodePos.y);
                        var nodeZ = BitConverter.GetBytes(nodePos.z);

                        //Write Node position X,Y,Z in Double format.
                        Buffer.BlockCopy(nodeX, 0, graphFileData, nodePosXIndex, 8);
                        Buffer.BlockCopy(nodeY, 0, graphFileData, nodePosYIndex, 8);
                        Buffer.BlockCopy(nodeZ, 0, graphFileData, nodePosZIndex, 8);

                        //Read node criteria.
                        int nodeCriteriaIndex = index + 88 + 1;
                        var nodeCriteriaData = graphFileData.Skip(nodeCriteriaIndex).Take(18).ToArray();
                        string nodeCriteriaType = Encoding.UTF8.GetString(nodeCriteriaData);
                        nodeCriteriaType = nodeCriteriaType.IsNonASCII() ? String.Empty : nodeCriteriaType;
                        int nodeCriteriaTypeLen = nodeCriteriaType.Length;
                        int nodeCriteriaLen = nodeCriteria.Length;

                        //Write Node criteria.
                        if (!nodeCriteria.Contains("NONE"))
                        {
                            QUtils.AddLog("WriteGraphNodeData() Updating NodeCriteria from '" + nodeCriteriaType + "' to '" + nodeCriteria + "'");
                            if (nodeCriteriaType.Contains('\0'))
                                nodeCriteriaTypeLen -= 1;

                            if (nodeCriteriaTypeLen != nodeCriteriaLen)
                            {
                                //QUtils.ShowWarning("NodeCriteria length error for '" + nodeCriteria + "'", "GraphNodeData - ERROR");
                                QUtils.AddLog("WriteGraphNodeData() NodeCriteria length error Provided Length: " + nodeCriteria.Length + " Expected Length: " + nodeCriteriaType.Length);
                                nodeCriteria += '\0';
                            }


                            {
                                var nodeCriteriaArrr = Encoding.ASCII.GetBytes(nodeCriteria);
                                Buffer.BlockCopy(nodeCriteriaArrr, 0, graphFileData, nodeCriteriaIndex, nodeCriteriaArrr.Length);
                                QUtils.AddLog("WriteGraphNodeData() NodeCriteria written...");
                            }
                        }
                        else QUtils.AddLog("WriteGraphNodeData() NodeCriteria skipped...");

                        nodeIdFound = true;
                        break;
                    }
                }
            }
            if (nodeIdFound)
            {
                QUtils.AddLog("WriteGraphNodeData() NodeId found for Writing data...");
                File.WriteAllBytes(outPath, graphFileData);
            }
            else
                QUtils.AddLog("WriteGraphNodeData() NodeId not found for Writing");
            return nodeIdFound;
        }

        internal static string UpdateAiGraphData(int graphId, Real64 graphPos, QGraphData qGraphData)
        {
            string qscData = null;
            try
            {
                var qTaskGraph = GetQTaskGraph(graphId);
                if (qTaskGraph == null) { QUtils.ShowError("QTaskGraph is empty for GraphId#" + graphId); return null; }

                string inputQscPath = QUtils.cfgQscPath + QUtils.gGameLevel + "\\" + QUtils.objectsQsc;
                qscData = QUtils.LoadFile(inputQscPath);
                QUtils.AddLog("UpdateAiGraphData() :IsNonASCII : " + qscData.IsNonASCII());

                qscData = qscData.IsNonASCII() ? QCryptor.Decrypt(inputQscPath) : qscData;

                var position = graphPos;//qTaskGraph.position;
                QUtils.AddLog("UpdateAiGraphData() position : X:" + position.x + " Y: " + position.y + " Z: " + position.z);
                QUtils.AddLog("UpdateAiGraphData() data : MaxNodes:" + qGraphData.MaxNodes + " TotalNodes: " + qGraphData.TotalNodes + " Data: " + qGraphData.Data);

                string aiGraphTaskId = "Task_New(" + graphId;
                int qtaskIndex = qscData.IndexOf(aiGraphTaskId);
                int newlineIndex = qscData.IndexOf("\n", qtaskIndex);
                var aiGraphLine = qscData.Slice(qtaskIndex, newlineIndex);

                var endCount = aiGraphLine.Count(o => o == ')');

                string aiGraphTask = "Task_New(" + graphId + ",\"AIGraph\",\"AIGraph Data\"," + position.x + "," + position.y + "," + position.z + "," + qTaskGraph.update.ToString().ToUpperInvariant() + "," + qGraphData.TotalNodes + "," + qGraphData.MaxNodes + "," + qTaskGraph.graphData.Data + "," + qTaskGraph.midOffsets + "," + qTaskGraph.topOffsets + "," + qTaskGraph.heightDiff + "," + qTaskGraph.nodeWidth.ToString("R") + "," + qTaskGraph.groundDist + "," + qTaskGraph.usePrecise.ToString().ToUpperInvariant() + "," + qTaskGraph.preciseStepVal.ToString("R");

                QUtils.AddLog("UpdateAiGraphData() Ai GraphTask line :" + aiGraphTask);
                if (endCount == 1)
                    aiGraphTask += "),";
                else
                {
                    for (int i = 1; i <= endCount; ++i)
                    {
                        aiGraphTask += ")";
                    }
                    aiGraphTask += ",";
                }

                qscData = qscData.Remove(qtaskIndex, newlineIndex - qtaskIndex).Insert(qtaskIndex, aiGraphTask);
            }
            catch (Exception ex)
            {
                QUtils.AddLog("UpdateAiGraphData() Exception: " + ex.Message ?? ex.StackTrace);
            }
            return qscData;
        }

        //Parse the Objects.
        private static List<QTaskGraph> ParseGraphData(string qscData)
        {
            var qtaskList = new List<QTaskGraph>();
            try
            {
                //Remove all whitespaces.
                qscData = qscData.Replace("\t", String.Empty);
                string[] qscDataSplit = qscData.Split('\n');


                foreach (var data in qscDataSplit)
                {
                    if (data.Contains(QUtils.taskNew))
                    {
                        var startIndex = data.IndexOf(',') + 1;
                        var endIndex = data.IndexOf(',', startIndex);
                        var taskName = data.Slice(startIndex, endIndex).Trim().Replace("\"", String.Empty);

                        if (taskName.Contains(QUtils.aiGraphTask))
                        {
                            var qtask = new QTaskGraph();
                            var position = new Real64();
                            var qGraphData = new QGraphData();

                            string[] taskNew = data.Split(',');
                            int taskIndex = 0;

                            foreach (var task in taskNew)
                            {
                                if (taskIndex == (int)QTASKINFO.QTASK_ID)
                                {
                                    var taskId = task.Substring(task.IndexOf('(') + 1);
                                    qtask.id = Convert.ToInt32(taskId);
                                }
                                else if (taskIndex == (int)QTASKINFO.QTASK_NAME)
                                    qtask.name = task.Trim();

                                else if (taskIndex == (int)QTASKINFO.QTASK_NOTE)
                                    qtask.note = task.Trim();

                                else if (taskIndex == (int)QTASKINFO.QTASK_POSX)
                                    position.x = Double.Parse(task);

                                else if (taskIndex == (int)QTASKINFO.QTASK_POSY)
                                    position.y = Double.Parse(task);

                                else if (taskIndex == (int)QTASKINFO.QTASK_POSZ)
                                    position.z = Double.Parse(task);

                                else if (taskIndex == (int)QTASKINFO.QTASK_UPDATE)
                                    qtask.update = Boolean.Parse(task.Trim());

                                else if (taskIndex == (int)QTASKINFO.QTASK_GRAPH_TOTAL_NODES)
                                    qGraphData.TotalNodes = Int32.Parse(task.Trim());

                                else if (taskIndex == (int)QTASKINFO.QTASK_GRAPH_MAX_NODES)
                                    qGraphData.MaxNodes = Int32.Parse(task.Trim());

                                else if (taskIndex == (int)QTASKINFO.QTASK_GRAPH_DATA)
                                    qGraphData.Data = Int32.Parse(task.Trim());

                                else if (taskIndex == (int)QTASKINFO.QTASK_MID_OFFSET)
                                    qtask.midOffsets = Double.Parse(task);

                                else if (taskIndex == (int)QTASKINFO.QTASK_TOP_OFFSET)
                                    qtask.topOffsets = Double.Parse(task);

                                else if (taskIndex == (int)QTASKINFO.QTASK_HEIGH_DIFF)
                                    qtask.heightDiff = Double.Parse(task);

                                else if (taskIndex == (int)QTASKINFO.QTASK_NODE_WIDTH)
                                    qtask.nodeWidth = Double.Parse(task);

                                else if (taskIndex == (int)QTASKINFO.QTASK_GROUND_DIST)
                                    qtask.groundDist = Double.Parse(task);

                                else if (taskIndex == (int)QTASKINFO.QTASK_USE_PRECISE)
                                    qtask.usePrecise = Boolean.Parse(task.Trim());

                                else if (taskIndex == (int)QTASKINFO.QTASK_PRECISE_STEP_VAL)
                                    qtask.preciseStepVal = Double.Parse(task.Trim().Replace(")", String.Empty));

                                qtask.position = position;
                                qtask.graphData = qGraphData;
                                taskIndex++;
                            }
                            qtaskList.Add(qtask);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AddLog("ParseGraphData exception: " + ex.Message ?? ex.StackTrace);
            }
            return qtaskList;
        }

        internal static GraphNode GetGraphNodeData(int graphId, int nodeId)
        {
            string graphFile = QUtils.inputDatPath;
            QUtils.AddLog("GetGraphNodeData() GraphFile: '" + graphFile + "'");

            if (QUtils.graphNodesList.Count == 0) QUtils.graphNodesList = QGraphs.ReadGraphNodeData(graphFile);

            foreach (var node in QUtils.graphNodesList)
            {
                if (node.NodeId == nodeId)
                {
                    QUtils.AddLog("GetGraphNodeData() returned NodeId: '" + node.NodeId + "'");
                    return node;
                }
            }
            QUtils.AddLog("GetGraphNodeData() returned Null");
            return null;
        }

        internal static string GetGraphArea(int graphId)
        {

            QUtils.graphFile = QUtils.qGraphsPath + "\\" + "graph_area_level" + QUtils.gGameLevel + ".txt";
            //QUtils.ShowInfo("graphFile: " + graphFile);
            QUtils.AddLog("GetGraphArea(): Level: " + QUtils.gGameLevel + " graphId: " + graphId + " graphFile: '" + graphFile + "'");
            if (!System.IO.File.Exists(graphFile)) { return "Area Not Available."; }

            if (QUtils.graphAreas.Count == 0) QUtils.graphAreas = GetGraphAreasList(graphFile);

            foreach (var graph in QUtils.graphAreas)
            {
                if (graph.Key == graphId) return graph.Value;
            }
            return null;
        }

        internal static Dictionary<int, string> GetGraphAreasList(string graphFile)
        {
            var fileData = System.IO.File.ReadAllLines(graphFile);
            var graphAreas = new Dictionary<int, string>();
            string areaSub = "Area : ";

            foreach (var data in fileData)
            {
                var graphIdStr = data.Slice(0, data.IndexOf(areaSub)).Trim();
                var graphArea = data.Substring(data.IndexOf(areaSub) + areaSub.Length + 1).Replace("\"", String.Empty).Trim();
                int graphId = Int32.Parse(Regex.Match(graphIdStr, @"\d+").Value);
                graphAreas.Add(graphId, graphArea);
            }
            QUtils.AddLog("GetGraphArea(): Level: " + QUtils.gGameLevel + " graphFile: " + graphFile + " retured Area count: " + graphAreas.Count);
            return graphAreas;
        }


        internal static List<int> GetNodesForGraph(int graphId)
        {
            List<int> graphNodeIds = new List<int>();
            string graphFile = QUtils.inputDatPath;//QUtils.graphsPath + "\\" + "graph" + graphId + QUtils.datExt;

            QUtils.graphNodesList = QGraphs.ReadGraphNodeData(graphFile);
            int totalNodes = QUtils.graphNodesList.Count;

            if (totalNodes == 0) QUtils.ShowError("OpenGraph(): Invalid Graph file selected.");
            else
            {
                foreach (var node in QUtils.graphNodesList)
                {
                    if (node.NodeId > 0 && node.NodeId < 5000)
                        graphNodeIds.Add(node.NodeId);
                }

                QUtils.AddLog("GetNodesForGraph() GraphFile: '" + graphFile + "'" + " NodeId Count: " + graphNodeIds.Count);
            }

            return graphNodeIds;
        }

        internal static List<QTaskGraph> GetQTaskGraphList(bool sorted = false, bool fromBackup = false, int level = -1)
        {
            try
            {
                //For current level.
                if (level == -1) level = QUtils.gGameLevel;
                level = (level == 0) ? QMemory.GetCurrentLevel() : level;

                string inputQscPath = QUtils.cfgQscPath + level + "\\" + QUtils.objectsQsc;
                QUtils.AddLog("GetQTaskGraphList() : called with level : " + level + " backup : " + fromBackup + " InputQsc Path '" + inputQscPath + "'");
                string qscData = fromBackup ? QUtils.LoadFile(inputQscPath) : QUtils.LoadFile();
                QUtils.AddLog("GetQTaskGraphList() :IsNonASCII : " + qscData.IsNonASCII());

                qscData = qscData.IsNonASCII() ? QCryptor.Decrypt(inputQscPath) : qscData;
                var qtaskList = ParseGraphData(qscData);

                if (sorted) qtaskList = qtaskList.OrderBy(q => q.id).ToList();
                QUtils.gGameLevel = level;
                return qtaskList;
            }
            catch (Exception ex)
            {
                AddLog("GetQTaskGraphList() Exception: " + ex.Message ?? ex.StackTrace);
            }
            return null;
        }

        internal static QTaskGraph GetQTaskGraph(int graphId)
        {
            try
            {
                var qGraphList = GetQTaskGraphList(true, true);

                foreach (var qGraph in qGraphList)
                {
                    if (qGraph.id == graphId)
                    {
                        QUtils.AddLog("GetQTaskGraph(): found valid GraphData");
                        return qGraph;
                    }
                }

            }
            catch (Exception ex)
            {
                AddLog("GetQTaskGraph() Exception: " + ex.Message ?? ex.StackTrace);
            }
            QUtils.AddLog("GetQTaskGraph(): found invalid GraphData");
            return null;
        }

        internal static Real64 GetGraphPosition(string graphId)
        {
            var qGraphList = GetQTaskGraphList(true, true);
            Real64 qGraphPos = new Real64();

            foreach (var qGraph in qGraphList)
            {
                if (qGraph.id.ToString() == graphId)
                {
                    qGraphPos = qGraph.position;
                    break;
                }
            }
            return qGraphPos;
        }


        internal static Real64 GetGraphPosition(int graphId)
        {
            return GetGraphPosition(graphId.ToString());
        }
    }

    public static class Extensions
    {
        public static string Slice(this string source, int start, int end)
        {
            if (end < 0)
            {
                end = source.Length + end;
            }
            int len = end - start;
            return source.Substring(start, len);
        }


        public static string ReplaceFirst(this string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        public static string ReplaceLast(this string text, string search, string replace)
        {
            int place = text.LastIndexOf(search);

            if (place == -1)
                return text;

            string result = text.Remove(place, search.Length).Insert(place, replace);
            return result;
        }

        public static bool IsNonASCII(this string str)
        {
            return (Encoding.UTF8.GetByteCount(str) != str.Length);
        }

        public static bool HasBinaryContent(this string content)
        {
            return content.Any(ch => char.IsControl(ch) && ch != '\r' && ch != '\n');
        }

        public static double ToRadians(this double angle)
        {
            // Angle in 10th of a degree
            return (angle * Math.PI) / 180;
        }
    }

}
