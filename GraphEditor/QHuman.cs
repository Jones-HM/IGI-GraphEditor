using QLibc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace IGI_GraphEditor
{
    class QHuman
    {

        internal static QUtils.HTask GetHumanTaskList(bool fromBackup = false)
        {
            //Declare types to store position to qtask.
            QUtils.HTask htask = new QUtils.HTask();
            htask.qtask = new QUtils.QTask();
            htask.weaponsList = new List<string>();

            Real32 orientation = new Real32();
            Real64 position = new Real64();

            string inputQscPath = QUtils.cfgQscPath + QUtils.gGameLevel + "\\" + QUtils.objectsQsc;

            string qscData = (fromBackup) ? QUtils.LoadFile(inputQscPath) : QUtils.LoadFile();

            if (qscData.IsNonASCII()) qscData = QCryptor.Decrypt(QUtils.objectsQsc);

            string idIndexStr = "Task_New(0";
            int idIndex = qscData.IndexOf(idIndexStr);
            string qscTemp = qscData.Substring(idIndex);
            string[] taskNew = qscTemp.Split(',');

            //Parse all the data.
            position.x = Double.Parse(taskNew[(int)QTASKINFO.QTASK_POSX]);
            position.y = Double.Parse(taskNew[(int)QTASKINFO.QTASK_POSY]);
            position.z = Double.Parse(taskNew[(int)QTASKINFO.QTASK_POSZ]);
            orientation.alpha = float.Parse(taskNew[(int)QTASKINFO.QTASK_ALPHA]);
            htask.team = Convert.ToInt32(taskNew[(int)QTASKINFO.QTASK_GAMMA].Trim());

            //Adding position and orientation to qtask.
            htask.qtask.position = position;
            htask.qtask.orientation = orientation;

            string weaponRegex = "[A-Z]{6}_[A-Z]{2}_[A-Z0-9]*";
            var qscSub = qscData.Substring(idIndex).Split('\n');
            int weaponsIndex = 0;
            int maxWeapons = 0xA;

            foreach (var data in qscSub)
            {
                var matchData = Regex.Match(data, weaponRegex);
                if (matchData.Success)
                    htask.weaponsList.Add(matchData.Value);

                //Break after reaching max weapons limit.
                if (weaponsIndex > maxWeapons) break;
                weaponsIndex++;
            }
            return htask;
        }

        static internal Real32 GetPositionCoord(bool addLog = true)
        {
            uint posBaseAddr = (uint)QMemory.GetHumanBaseAddress(false) + (uint)0x24;

            IntPtr xPosAddr = (IntPtr)posBaseAddr + 0x0;
            IntPtr yPosAddr = (IntPtr)posBaseAddr + 0x8;
            IntPtr zPosAddr = (IntPtr)posBaseAddr + 0x10;

            var xpos = GT.GT_ReadFloat(xPosAddr);
            var ypos = GT.GT_ReadFloat(yPosAddr);
            var zpos = GT.GT_ReadFloat(zPosAddr);

            var position = new Real32(xpos, ypos, zpos);

            if (addLog)
            {
                QUtils.AddLog("GetPositionCoord() : posBaseAddr : " + posBaseAddr);
                QUtils.AddLog("GetPositionCoord() xpos : " + xpos);
                QUtils.AddLog("GetPositionCoord() ypos : " + ypos);
                QUtils.AddLog("GetPositionCoord() zpos : " + zpos);
                QUtils.AddLog("GetPositionCoord() : position: " + position);
            }
            return position;
        }

        static internal Real64 GetPositionInMeter(bool addLog = true)
        {
            uint posBaseAddr = (uint)0x005CA138;
            IntPtr xPosAddr = (IntPtr)posBaseAddr + 0x0;
            IntPtr yPosAddr = (IntPtr)posBaseAddr + 0x8;
            IntPtr zPosAddr = (IntPtr)posBaseAddr + 0x10;

            var xpos = GT.GT_ReadDouble(xPosAddr);
            var ypos = GT.GT_ReadDouble(yPosAddr);
            var zpos = GT.GT_ReadDouble(zPosAddr);

            double x = Convert.ToDouble(Decimal.Truncate(Convert.ToDecimal(xpos)));
            double y = Convert.ToDouble(Decimal.Truncate(Convert.ToDecimal(ypos)));
            double z = Convert.ToDouble(Decimal.Truncate(Convert.ToDecimal(zpos)));

            //Fix this angle for Ground reference.
            var position = new Real64(x, y, z - QMemory.deltaToGround);
            if (addLog)
            {
                QUtils.AddLog("GetPositionInMeter() Non-Truncated xpos: " + xpos + " ypos: " + ypos + " zpos: " + zpos);
                QUtils.AddLog("GetPositionInMeter() Truncated x: " + x + " y: " + y + " z: " + z);
            }

            return position;
        }
    }
}
