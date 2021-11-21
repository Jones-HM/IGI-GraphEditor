using QLibc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IGI_GraphEditor
{
    class QHuman
    {

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
                QUtils.AddLog("GetPositionInMeter() : xpos: " + xpos + " ypos: " + ypos + " zpos: " + zpos);
                QUtils.AddLog("GetPositionInMeter() : x: " + x + " y: " + y + " z: " + z);
                QUtils.AddLog("GetPositionInMeter() : position: " + position);
            }

            return position;
        }
    }
}
