using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        Dictionary<string, Configuration> Configurations = new Dictionary<string, Configuration>();

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

            foreach(var antenna in CurrentConfiguration.VirtualAntennaPorts.Values)
            {
                transceiverList.Items.Add(antenna.Description);
            }
        }

        private void UpdateBeltpacks()
        {
            beltpackRoleDropdown.Items.Clear();

            foreach (var role in CurrentConfiguration.VirtualPorts.Values)
            {
                if (role.AbsolutePortNumber >= 600)
                {

                    beltpackRoleDropdown.Items.Add(role.Label.TalkListen + " (" + role.Description + ")");
                }
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
            if (checkBox1.Checked)
            {
                foreach(var cbItem in transceiverList.Items)
                {
                    transceiverList.SetItemChecked(transceiverList.Items.IndexOf(cbItem), checkBox1.Checked);
                }
            }
        }
    }
}
