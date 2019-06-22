using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

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
        private bool conneted;

       

        private void lstDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckTextBoxSLMP();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            CheckTextBoxConnection();
            if(txtPort.Text == "" || txtIPAddress.Text == "")
            {
                return;
            }

            if (SLMPClient.socket == null)
            {
                errorID = SLMPClient.connect(txtIPAddress.Text, Int32.Parse(txtPort.Text));

                if (errorID != 0)
                {
                    MessageBox.Show("Connection Fails!");
                    return;
                }
                conneted = true;
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
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
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (!txtDeviceNo.Text.Equals("") || !txtPoints.Text.Equals("") || !lstDevice.Text.Equals(""))
            {
                byte[] pucStream = new byte[1518];
                
                SLMPinfo_req.usNetNumber = 0;
                SLMPinfo_req.usNodeNumber = 0xFF;
                SLMPinfo_req.usProcNumber = SLMPFrame.SLMP_CPU_DEFAULT;
                SLMPinfo_req.usDataLength = 12;
                SLMPinfo_req.usTimer = SLMPFrame.SLMP_TIMER_WAIT_FOREVER;
                SLMPinfo_req.usCommand = SLMPFrame.SLMP_COMMAND_DEVICE_READ;
                SLMPinfo_req.usSubCommand = 0x0000;
                SLMPinfo_req.pucData = SLMPClient.Frame.DeviceConv(txtDeviceNo.Text, lstDevice.Text, txtPoints.Text);

                SLMPClient.Frame.SLMP_MakePacketStream(SLMPFrame.SLMP_FTYPE_BIN_REQ_ST, SLMPinfo_req, pucStream);

                //txtData.Text = BitConverter.ToString(pucStream);

                SLMPClient.send(pucStream);

                if (SLMPClient.send(pucStream) == 0)
                {
                    if(SLMPClient.recive(pucStream) == 0)
                    {
                        //txtData.Text = BitConverter.ToString(pucStream);
                        if ( SLMPClient.Frame.SLMP_GetSLMPInfo(SLMPinfo_res, pucStream) == 0)
                        {
                            txtData.Text = "";
                            int j=0;
                            for(int i = 0; i<SLMPinfo_res.pucData.Length/2; i++)
                            {
                                int offset = Int32.Parse(txtDeviceNo.Text)+i;
                                txtData.Text += lstDevice.Text + offset.ToString() + "=" + SLMPFrame.CONCAT_2BIN(SLMPinfo_res.pucData[j+1], SLMPinfo_res.pucData[j]).ToString() + "\r\n";
                                j += 2;
                            }
                            //txtData.Text = BitConverter.ToString(SLMPinfo_res.pucData);
                        }
                        else
                        {
                            Debug.WriteLine("Frame Error");
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Recived Error");
                    }
                }
                else
                {
                    Debug.WriteLine("Send Error");
                }
            } else
            {
                MessageBox.Show("Set Values!");
            }
        }

        private void CheckTextBoxSLMP()
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

        private void CheckTextBoxConnection()
        {
            Color ColorNG = Color.LightCoral;
            Color ColorOK = Color.White;

            if(txtIPAddress.Text == "")
            {
                txtIPAddress.BackColor = ColorNG;
            }
            else
            {
                txtIPAddress.BackColor = ColorOK;
            }
            if (txtPort.Text == "")
            {
                txtPort.BackColor = ColorNG;
            }
            else
            {
                txtPort.BackColor = ColorOK;
            }
        }

        private void txtDeviceNo_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxSLMP();
        }

        private void txtPoints_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxSLMP();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            byte [] acuStream = SLMPClient.Frame.DeviceConv(txtDeviceNo.Text, lstDevice.Text, txtPoints.Text);

            txtData.Text = BitConverter.ToString(acuStream);
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
           errorID = SLMPClient.disconnect();

            if(errorID != 0)
            {
                MessageBox.Show("Something goes wrong!");
                return;
            }

         
            if (!SLMPClient.socket.Connected)
            {
                conneted = false;
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
                boxSLMP.Enabled = false;
            }
        }
    }
}
