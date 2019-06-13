using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLMPClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Connection SLMPClient = new Connection();
        private SLMPFrame.SLMP_INFO SLMPinfo_req = new SLMPFrame.SLMP_INFO();
        private SLMPFrame.SLMP_INFO SLMPinfo_res = new SLMPFrame.SLMP_INFO();
        private SLMPFrame Frame = new SLMPFrame();
        private int errorID;

        private void lstDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckTextBox();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (SLMPClient.socket == null)
            {
                errorID = SLMPClient.connect(txtIPAddress.Text, Int32.Parse(txtPort.Text));

                if (errorID != 0)
                {
                    MessageBox.Show("Connection Fails!");
                    return;
                }
                btnConnect.Text = "Disconnect";
                boxSLMP.Enabled = true;
            } else if(!SLMPClient.socket.Connected)
            {
                errorID = SLMPClient.connect(txtIPAddress.Text, Int32.Parse(txtPort.Text));

                if (errorID != 0)
                {
                    MessageBox.Show("Connection Fails!");
                    return;
                }
                btnConnect.Text = "Disconnect";
                boxSLMP.Enabled = true;
            }
            else
            {
                errorID = SLMPClient.disconnect();
                if (errorID != 0)
                {
                    MessageBox.Show("Can't disconnect");
                    return;
                }
                btnConnect.Text = "Connect";
                boxSLMP.Enabled = false;
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (!txtDeviceNo.Equals("") || !txtPoints.Equals("") || !lstDevice.Equals(""))
            {
                byte[] acuSend = { 0x64, 0x00, 0x00, 0xA8, 0x05, 0x00 };
                byte[] pucStream = new byte[30];
                
                SLMPinfo_req.usNetNumber = 0;
                SLMPinfo_req.usNodeNumber = 0xFF;
                SLMPinfo_req.usProcNumber = SLMPFrame.SLMP_CPU_DEFAULT;
                SLMPinfo_req.usDataLength = 12;
                SLMPinfo_req.usTimer = SLMPFrame.SLMP_TIMER_WAIT_FOREVER;
                SLMPinfo_req.usCommand = SLMPFrame.SLMP_COMMAND_DEVICE_READ;
                SLMPinfo_req.usSubCommand = 0x0000;
                SLMPinfo_req.pucData = acuSend;

                SLMPClient.Frame.SLMP_MakePacketStream(SLMPFrame.SLMP_FTYPE_BIN_REQ_ST, SLMPinfo_req, pucStream);

                SLMPClient.send(pucStream);

                if (SLMPClient.send(pucStream) == 0)
                {
                    if(SLMPClient.recive(pucStream) == 0)
                    {
                       if( SLMPClient.Frame.SLMP_GetSLMPInfo(SLMPinfo_res, pucStream) == 0)
                        {
                            txtData.Text = BitConverter.ToString(SLMPinfo_res.pucData);
                        }
                    }
                }
            } else
            {
                MessageBox.Show("Set Values!");
            }
        }

        private void CheckTextBox()
        {
            Color ColorNG = Color.LightCoral;
            Color ColorOK = Color.White;
            if (boxSLMP.Enabled == true)
            {
                if(txtDeviceNo.Text == "")
                {
                    txtDeviceNo.BackColor = ColorNG;
                }
                else
                {
                    txtDeviceNo.BackColor = ColorOK;
                }
                if (txtPoints.Text == "")
                {
                    txtPoints.BackColor = ColorNG;
                }
                else
                {
                    txtPoints.BackColor = ColorOK;
                }
                if (lstDevice.Text == "")
                {
                    lstDevice.BackColor = ColorNG;
                }
                else
                {
                    lstDevice.BackColor = ColorOK;
                }
            }
        }

        private void txtDeviceNo_TextChanged(object sender, EventArgs e)
        {
            CheckTextBox();
        }

        private void txtPoints_TextChanged(object sender, EventArgs e)
        {
            CheckTextBox();
        }
    }
}
