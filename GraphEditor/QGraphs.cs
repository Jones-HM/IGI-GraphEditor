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
            QTASK_GRAPH_DATA_X,
            QTASK_GRAPH_DATA_Y,
            QTASK_GRAPH_DATA_Z,

            //Graph properties in Real64.
            QTASK_MID_OFFSET,
            QTASK_TOP_OFFSET,
            QTASK_HEIGH_DIFF,
            QTASK_NODE_WIDTH,
            QTASK_GROUND_DIST,
            QTASK_USE_PRECISE,
            QTASK_PRECISE_STEP_VAL
        }

        public class Graph
        {
            public int x, y, z;

            public Graph() { x = y = z = 0; }
            public Graph(int x)
            {
                this.x = x;
                this.y = this.z = 0;
            }

            public Graph(int x, int y)
            {
                this.x = x;
                this.y = y;
                this.z = 0;
            }

            public Graph(int x, int y, int z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        };

        public class QTaskGraph
        {
            public Int32 id;
            public string name;
            public string note;
            public Real64 position;
            public Graph graph;
            public bool update;
            public bool usePrecise;
            public Int32 graphData;
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

        internal static bool WriteGraphNodeData(string graphFile, int node, Real64 nodePos, string outPath)
        {
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

                        //var nodeX = BitConverter.GetBytes(float.Parse(nodePos.x.ToString("0.0")));
                        //var nodeY = BitConverter.GetBytes(float.Parse(nodePos.y.ToString("0.0")));
                        //var nodeZ = BitConverter.GetBytes(float.Parse(nodePos.z.ToString("0.0")));

                        var nodeX = BitConverter.GetBytes(nodePos.x);
                        var nodeY = BitConverter.GetBytes(nodePos.y);
                        var nodeZ = BitConverter.GetBytes(nodePos.z);

                        Buffer.BlockCopy(nodeX, 0,graphFileData, nodePosXIndex, 8);
                        Buffer.BlockCopy(nodeY, 0,graphFileData, nodePosYIndex, 8);
                        Buffer.BlockCopy(nodeZ, 0,graphFileData, nodePosZIndex, 8);

                        //InsertToByte(ref graphFileData, nodeX, nodePosXIndex);
                        //InsertToByte(ref graphFileData, nodeY, nodePosYIndex);
                        //InsertToByte(ref graphFileData, nodeZ, nodePosZIndex);

                        //graphBytes.InsertRange(nodePosXIndex, nodeX);
                        //graphBytes.InsertRange(nodePosYIndex, nodeY);
                        //graphBytes.InsertRange(nodePosZIndex, nodeZ);

                        //graphFileData = AddByteToArray(graphFileData, nodeX);
                        //graphFileData = AddByteToArray(graphFileData, nodeY);
                        //graphFileData = AddByteToArray(graphFileData, nodeZ);

                        nodeIdFound = true;
                        break;
                    }
                }
            }
            if (nodeIdFound)
                File.WriteAllBytes(outPath, graphFileData);
            return nodeIdFound;
        }

        public static void InsertToByte(ref byte[] bArray, byte[] newByte, int index)
        {
            Buffer.BlockCopy(bArray, index, newByte, 0, 8);
            //for (int i = 0; i < 8; ++i)
            //{
            //    try
            //    {
            //        bArray[index + i] = newByte[i];
            //    }
            //    catch (Exception ex)
            //    {
            //        bArray[index + i] = 0;
            //    }
            //}
        }

        //Parse the Objects.
        private static List<QTaskGraph> ParseGraphData(string qscData)
        {
            //Remove all whitespaces.
            qscData = qscData.Replace("\t", String.Empty);
            string[] qscDataSplit = qscData.Split('\n');

            var qtaskList = new List<QTaskGraph>();
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
                        Real64 position = new Real64();
                        Graph graph = new Graph();

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

                            else if (taskIndex == (int)QTASKINFO.QTASK_GRAPH_DATA_X)
                                graph.x = Int32.Parse(task.Trim());

                            else if (taskIndex == (int)QTASKINFO.QTASK_GRAPH_DATA_Y)
                                graph.y = Int32.Parse(task.Trim());

                            else if (taskIndex == (int)QTASKINFO.QTASK_GRAPH_DATA_Z)
                                graph.z = Int32.Parse(task.Trim());

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
                            qtask.graph = graph;
                            taskIndex++;
                        }
                        qtaskList.Add(qtask);
                    }
                }
            }
            return qtaskList;
        }

        internal static GraphNode GetGraphNodeData(int graphId, int nodeId)
        {
            string graphFile = QUtils.inputDatPaths[0];
            QUtils.AddLog("graphIdDD() GraphFile: '" + graphFile + "'");

            if (QUtils.graphNodesList.Count == 0) QUtils.graphNodesList = QGraphs.ReadGraphNodeData(graphFile);

            foreach (var node in QUtils.graphNodesList)
            {
                if (node.NodeId == nodeId)
                    return node;
            }
            return null;
        }

        internal static string GetGraphArea(int graphId)
        {

            QUtils.graphFile = QUtils.qGraphsPath + "\\" + "graph_area_level" + QUtils.gGameLevel + ".txt";
            //QUtils.ShowInfo("graphFile: " + graphFile);
            QUtils.AddLog("GetGraphArea(): Level: " + QUtils.gGameLevel + " graphId: " + graphId + " graphFile: " + graphFile);
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
            string graphFile = QUtils.inputDatPaths[0];//QUtils.graphsPath + "\\" + "graph" + graphId + QUtils.datExt;

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
            //For current level.
            //if (level == -1) level = QMemory.GetCurrentLevel();

            //string inputQscPath = QUtils.cfgQscPath + level + "\\" + QUtils.objectsQsc;
            //string qscData = fromBackup ? QUtils.LoadFile(inputQscPath) : QUtils.LoadFile();
            var qscData = File.ReadAllText(QUtils.qscData);
            var qtaskList = ParseGraphData(qscData);

            if (sorted) qtaskList = qtaskList.OrderBy(q => q.id).ToList();
            return qtaskList;
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


        internal static object GetGraphPosition(int graphId)
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
