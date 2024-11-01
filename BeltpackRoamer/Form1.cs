using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared.ObjectModel;

namespace BeltpackRoamer
{
    public partial class Form1 : Form
    {
        
        Project CurrentProject;
        Configuration CurrentConfiguration;
        int CheckedListIndex =-1;
        VirtualPort CurrentBeltpack;

        Dictionary<string, Configuration> Configurations = new Dictionary<string, Configuration>();
        Dictionary<string, VirtualPort> Beltpacks = new Dictionary<string, VirtualPort>();
        Dictionary<string, VirtualAntennaPort> Transceivers = new Dictionary<string, VirtualAntennaPort>();


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                projectFilename.Text = openFileDialog1.FileName;
                CurrentProject = Project.Import(openFileDialog1.FileName);
                UpdateConfigurations();
            }
        }

        private void UpdateConfigurations()
        {
            Configurations.Clear();
            configurationDropDown.Items.Clear();

            foreach(var frame in CurrentProject.Frames.Values)
            {
                foreach(var configuration in frame.Configurations)
                {
                    Configurations.Add(configuration.Configuration.Name, configuration.Configuration);
                    configurationDropDown.Items.Add(configuration.Configuration.Name);
                }
            }
        }

        private void UpdateAntennas()
        {
            transceiverList.Items.Clear();
            Transceivers.Clear();

            foreach(var antenna in CurrentConfiguration.VirtualAntennaPorts.Values)
            {
                string transceiverDetails = antenna.Label.TalkListen + " :" + antenna.Description;

                if (!Transceivers.ContainsKey(transceiverDetails))
                {
                    transceiverList.Items.Add(transceiverDetails);
                    Transceivers.Add(transceiverDetails, antenna);
                }
            }
        }

        private void UpdateBeltpacks()
        {
            beltpackRoleDropdown.Items.Clear();
            Beltpacks.Clear();

            foreach (var role in CurrentConfiguration.VirtualPorts.Values)
            {
                if (role.AbsolutePortNumber >= 600)
                {
                    string roleDetails = role.Label.TalkListen + " (" + role.Description + ")";
                    if (!Beltpacks.ContainsKey(roleDetails))
                    {
                        Beltpacks.Add(roleDetails, role);
                        beltpackRoleDropdown.Items.Add(roleDetails);
                    }
                }
            }

            if(beltpackRoleDropdown.SelectedIndex == -1)
            {
                beltpackRoleDropdown.SelectedIndex = 0;
            }
        }

        private void configurationDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentConfiguration = Configurations[(string)configurationDropDown.SelectedItem];
            UpdateBeltpacks();
            UpdateAntennas();
        }

        private void beltpackRoleDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            roamingLog.Clear();
            if (Beltpacks.ContainsKey(beltpackRoleDropdown.SelectedItem.ToString()))
            {
                CurrentBeltpack = Beltpacks[beltpackRoleDropdown.SelectedItem.ToString()];
            }
        }

        private void btnAutoRoam_Click(object sender, EventArgs e)
        {
            if(btnAutoRoam.Text == "Auto Roam OFF")
            {
                btnAutoRoam.Text = "Auto Roam ON";
                btnNext.Enabled = true;
                btnBack.Enabled = true;
            }
            else
            {
                btnAutoRoam.Text = "Auto Roam OFF";
                btnNext.Enabled = false;
                btnBack.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int x = 0; x < transceiverList.Items.Count; x++)
            {
                transceiverList.SetItemChecked(x, checkBox1.Checked);

            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(CheckedListIndex == transceiverList.CheckedIndices.Count-1)
            {
                CheckedListIndex = -1;
            }

            CheckedListIndex++;

            var nextTransceiver = transceiverList.CheckedItems[CheckedListIndex];
            string nextTransceiverString = nextTransceiver.ToString();
            if (!string.IsNullOrEmpty(nextTransceiverString))
            {
                if (Transceivers.ContainsKey(nextTransceiverString))
                {
                    var transceiver = Transceivers[nextTransceiverString];

                    RoamToTransceiver(CurrentBeltpack, transceiver);
                }
            }
        }

        private void RoamToTransceiver(VirtualPort currentBeltpack, VirtualAntennaPort transceiver)
        {
            if(currentBeltpack is null)
            {
                roamingLog.AppendText("No beltpack currently selected." + Environment.NewLine);
            } else
            {
                if(transceiver != null)
                {
                    roamingLog.AppendText($"Attempting to roam beltpack {currentBeltpack.Label.TalkListen} to {transceiver.Label.TalkListen}" + Environment.NewLine);

                    IPEndPoint eclipseHCI = new IPEndPoint(CurrentConfiguration.Frame.PrimaryIPAddress, 52020);

                    TcpClient tcpClientToEclipse = new TcpClient();

                    tcpClientToEclipse.Connect(eclipseHCI);

                    ushort number = Convert.ToUInt16(currentBeltpack.AbsolutePortNumber);

                    byte upper = Convert.ToByte(number >> 8);
                    byte lower = Convert.ToByte(number & 0x00FF);
                    byte[] hciMessage = { 0x5a, 0x0f, 0x00, 0x15, 0x01, 0x0b, 0x08, 0xab, 0xba, 0xce, 0xde, 0x01, 0x00, 0x00, 0x09, 0x01, upper, lower, (byte)transceiver.RpnNumber, 0x2e, 0x8d };


                    tcpClientToEclipse.Close();
                }
            }
        }
    }
}
