﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace OxidePatcher
{
    public partial class ProjectSettingsControl : UserControl
    {
        public Project ProjectObject { get; set; }

        public string ProjectFilename { get; set; }

        public ProjectSettingsControl()
        {
            InitializeComponent();
        }

        private void ProjectSettingsControl_Load(object sender, EventArgs e)
        {
            nametextbox.Text = ProjectObject.Name;
            directorytextbox.Text = ProjectObject.TargetDirectory;
            filenametextbox.Text = ProjectFilename;
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            // Verify
            if (!Directory.Exists(directorytextbox.Text))
            {
                MessageBox.Show(this, "The target directory is invalid.", "Oxide Patcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(Path.GetDirectoryName(filenametextbox.Text)))
            {
                MessageBox.Show(this, "The filename is invalid.", "Oxide Patcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (nametextbox.TextLength == 0)
            {
                MessageBox.Show(this, "The project name is invalid.", "Oxide Patcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Save
            ProjectObject.Name = nametextbox.Text;
            ProjectObject.TargetDirectory = directorytextbox.Text;
            ProjectObject.Save(ProjectFilename);
        }
    }
}
