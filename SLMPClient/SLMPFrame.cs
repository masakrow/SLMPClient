using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLMPClient
{
    class SLMPFrame
    {
        public static readonly ushort FrameSize = 21;

        /*[ Definition of Frame Type ]*/
        public static readonly ushort SLMP_FTYPE_BIN_REQ_ST = 0x5000;
        public static readonly ushort SLMP_FTYPE_BIN_RES_ST = 0xD000;
        public static readonly ushort SLMP_FTYPE_BIN_REQ_MT = 0x5400;
        public static readonly ushort SLMP_FTYPE_BIN_RES_MT = 0xD400;


        /*[ Definition of Index per frame type ]*/
        public static readonly byte SLMP_FTYPE_BIN_REQ_ST_INDEX = 0x00;
        public static readonly byte SLMP_FTYPE_BIN_RES_ST_INDEX = 0x01;
        public static readonly byte SLMP_FTYPE_BIN_REQ_MT_INDEX = 0x02;
        public static readonly byte SLMP_FTYPE_BIN_RES_MT_INDEX = 0x03;

        /*[ Definition of SLMP Commands ]*/
        /* Device */
        public static readonly ushort SLMP_COMMAND_DEVICE_READ = 0x0401;
        public static readonly ushort SLMP_COMMAND_DEVICE_WRITE = 0x1401;
        public static readonly ushort SLMP_COMMAND_DEVICE_READ_RANDOM = 0x0403;
        public static readonly ushort SLMP_COMMAND_DEVICE_WRITE_RANDOM = 0x1402;
        public static readonly ushort SLMP_COMMAND_DEVICE_ENTRY_MONITOR_DEVICE = 0x0801;
        public static readonly ushort SLMP_COMMAND_DEVICE_EXECUTE_MONITOR = 0x0802;
        public static readonly ushort SLMP_COMMAND_DEVICE_READ_BLOCK = 0x0406;
        public static readonly ushort SLMP_COMMAND_DEVICE_WRITE_BLOCK = 0x1406;

        /* ExtendUnit */
        public static readonly ushort SLMP_COMMAND_EXTEND_UNIT_READ = 0x0601;
        public static readonly ushort SLMP_COMMAND_EXTEND_UNIT_WRITE = 0x1601;

        /*[ Definition of Processor Number ]*/
        public static readonly ushort SLMP_CPU_ACTIVE = 0x03D0;
        public static readonly ushort SLMP_CPU_STANDBY = 0x03D1;
        public static readonly ushort SLMP_CPU_TYPE_A = 0x03D2;
        public static readonly ushort SLMP_CPU_TYPE_B = 0x03D3;
        public static readonly ushort SLMP_CPU_1 = 0x03E0;
        public static readonly ushort SLMP_CPU_2 = 0x03E1;
        public static readonly ushort SLMP_CPU_3 = 0x03E2;
        public static readonly ushort SLMP_CPU_4 = 0x03E3;
        public static readonly ushort SLMP_CPU_DEFAULT = 0x03FF;

        /*[ Definition of Timer Value ]*/
        public static readonly ushort SLMP_TIMER_WAIT_FOREVER = (0x0000);

        /*[ Definition of value ]*/
        public static readonly int SLMP_ERR_OK = 0;
        public static readonly int SLMP_ERR_NG = -1;

        /*[ Definition of mask value ]*/
        public static readonly byte MASK_UPPER4BIT = 0xF0;
        public static readonly byte MASK_LOWER4BIT = 0x0F;

        private static ushort [] uiHeaderLength = { 6, 2, 6, 2, 12, 4, 12, 4 };
        private static ushort[] uiDataAddr = { 15, 11, 19, 15, 30, 22, 38, 30 };
        

        public struct SLMP_INFO
        {
            public ushort usSerialNumber;      /* Serial Number */
            public ushort usNetNumber;     /* Network Number */
            public ushort usNodeNumber;        /* Node Number */
            public ushort usProcNumber;        /* Processor Number */
            public ushort usDataLength;        /* Data Length */
            public ushort usTimer;         /* Timer Value */
            public ushort usCommand;           /* Command */
            public ushort usSubCommand;        /* Sub Command */
            public ushort usEndCode;           /* End Code */
            public byte [] pucData;			/* Data */
        }


        private byte SHIFT_R8(ushort a)
        {
            return (byte)(a >> 8);
        }
        private byte SHIFT_R0(ushort a)
        {
            return (byte)a;
        }
        private ushort CONCAT_2BIN(byte a, byte b)
        {
            return (ushort)((a <<4) | b);
        }

        public int SLMP_MakePacketStream(ushort ulFrameType, SLMP_INFO p, byte [] pucStream)
        {
            int i = 0;
            int iLength = 0;
            int iIndex = 0;
            
            
            if (p.Equals(null) || pucStream == null)
            {
                return SLMP_ERR_NG;
            }
            /*[ Request : Binary Mode, Single Transmission Type ]*/
            if ( ulFrameType == SLMP_FTYPE_BIN_REQ_ST)
            {
                iIndex = SLMP_FTYPE_BIN_REQ_ST_INDEX;
                iLength = p.usDataLength - uiHeaderLength[iIndex];
                if (iLength < 0)
                {
                    return SLMP_ERR_NG;
                }
                else if (iLength > 0)
                {
                    if (p.pucData == null)
                    {
                        return SLMP_ERR_NG;
                    }
                }
                pucStream[0] = SHIFT_R8(SLMP_FTYPE_BIN_REQ_ST);
                pucStream[1] = SHIFT_R0(SLMP_FTYPE_BIN_REQ_ST);
                pucStream[2] = SHIFT_R0(SLMP_FTYPE_BIN_REQ_ST);
                pucStream[3] = SHIFT_R0(p.usNodeNumber);
                pucStream[4] = SHIFT_R0(p.usProcNumber);
                pucStream[5] = SHIFT_R8(p.usProcNumber);
                pucStream[6] = (byte)0x00;
                pucStream[7] = SHIFT_R0(p.usDataLength);
                pucStream[8] = SHIFT_R8(p.usDataLength);
                pucStream[9] = SHIFT_R0(p.usTimer);
                pucStream[10] = SHIFT_R8(p.usTimer);
                pucStream[11] = SHIFT_R0(p.usCommand);
                pucStream[12] = SHIFT_R8(p.usCommand);
                pucStream[13] = SHIFT_R0(p.usSubCommand);
                pucStream[14] = SHIFT_R8(p.usSubCommand);
                for (i = 0; i < iLength; i++)
                {
                    pucStream[uiDataAddr[iIndex] + i] = p.pucData[i];
                }
                return SLMP_ERR_OK;
            }
            /*[ Request : Binary Mode, Multiple Transmission Type ]*/
            else if (ulFrameType == SLMP_FTYPE_BIN_REQ_MT )
	        {
                iIndex = SLMP_FTYPE_BIN_REQ_MT_INDEX;
                iLength = (p.usDataLength) - uiHeaderLength[iIndex];
                if (iLength < 0)
                {
                    return SLMP_ERR_NG;
                }
                else if (iLength > 0)
                {
                    if (p.pucData == null)
                    {
                        return SLMP_ERR_NG;
                    }
                }

                pucStream[0] = SHIFT_R8(SLMP_FTYPE_BIN_REQ_MT);
                pucStream[1] = SHIFT_R0(SLMP_FTYPE_BIN_REQ_MT);
                pucStream[2] = SHIFT_R0(p.usSerialNumber);
                pucStream[3] = SHIFT_R8(p.usSerialNumber);
                pucStream[4] = (byte)0x00;
                pucStream[5] = (byte)0x00;
                pucStream[6] = SHIFT_R0(p.usNetNumber);
                pucStream[7] = SHIFT_R0(p.usNodeNumber);
                pucStream[8] = SHIFT_R0(p.usProcNumber);
                pucStream[9] = SHIFT_R8(p.usProcNumber);
                pucStream[10] = (byte)0x00;
                pucStream[11] = SHIFT_R0(p.usDataLength);
                pucStream[12] = SHIFT_R8(p.usDataLength);
                pucStream[13] = SHIFT_R0(p.usTimer);
                pucStream[14] = SHIFT_R8(p.usTimer);
                pucStream[15] = SHIFT_R0(p.usCommand);
                pucStream[16] = SHIFT_R8(p.usCommand);
                pucStream[17] = SHIFT_R0(p.usSubCommand);
                pucStream[18] = SHIFT_R8(p.usSubCommand);

                for (i = 0; i < iLength; i++)
                {
                    pucStream[uiDataAddr[iIndex] + i] = p.pucData[i];
                }
                return SLMP_ERR_OK;
            }

            return SLMP_ERR_NG;
        }

        public int SLMP_GetSLMPInfo (SLMP_INFO p,  byte[] pucStream)
        {
            int i = 0;
            int iIndex = 0;
            int iLength = 0;
            uint uiTempLength = 0;
            ushort usFrameType = 0;

            if (p.Equals(null) || (pucStream == null))
            {
                return SLMP_ERR_NG;
            }

            usFrameType = CONCAT_2BIN(pucStream[0], pucStream[1]);
            /*[ Response : Binary Mode, Single Transmission Type ]*/
            if (usFrameType == SLMP_FTYPE_BIN_RES_ST)
            {
                iIndex = SLMP_FTYPE_BIN_RES_ST_INDEX;
                uiTempLength = CONCAT_2BIN(pucStream[8], pucStream[7]);

                iLength = (int)(uiTempLength - uiHeaderLength[iIndex]);
                if (iLength < 0)
                {
                    return SLMP_ERR_NG;
                }
                else if (iLength > 0)
                {
                    if (p.pucData == null)
                    {
                        return SLMP_ERR_NG;
                    }
                }

                (p.usNetNumber) = pucStream[2];
                (p.usNodeNumber) = pucStream[3];
                (p.usProcNumber) = CONCAT_2BIN(pucStream[5], pucStream[4]);
                (p.usDataLength) = (ushort)uiTempLength;
                (p.usEndCode) = CONCAT_2BIN(pucStream[10], pucStream[9]);

                for (i = 0; i < iLength; i++)
                {
                    p.pucData[i] = pucStream[uiDataAddr[iIndex] + i];
                }
                return SLMP_ERR_OK;
            }
            
            /*[ Response : Binary Mode, Multiple Transmission Type ]*/
            else if (usFrameType == SLMP_FTYPE_BIN_RES_MT)
            {
                iIndex = SLMP_FTYPE_BIN_RES_MT_INDEX;
                uiTempLength = CONCAT_2BIN(pucStream[12], pucStream[11]);

                iLength = (int)(uiTempLength - uiHeaderLength[iIndex]);
                if (iLength < 0)
                {
                    return SLMP_ERR_NG;
                }
                else if (iLength > 0)
                {
                    if (p.pucData == null)
                    {
                        return SLMP_ERR_NG;
                    }
                }

                (p.usSerialNumber) = CONCAT_2BIN(pucStream[3], pucStream[2]);
                (p.usNetNumber) = pucStream[6];
                (p.usNodeNumber) = pucStream[7];
                (p.usProcNumber) = CONCAT_2BIN(pucStream[9], pucStream[8]);
                (p.usDataLength) = (ushort)uiTempLength;
                (p.usEndCode) = CONCAT_2BIN(pucStream[14], pucStream[13]);

                for (i = 0; i < iLength; i++)
                {
                    p.pucData[i] = pucStream[uiDataAddr[iIndex] + i];
                }
                return SLMP_ERR_OK;
            }
            return SLMP_ERR_NG;
        }


    }
}
