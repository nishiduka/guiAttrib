using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atalho
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            update();
        }

        private void update()
        {
            DriveInfo []
            allDrives = DriveInfo.GetDrives();
            cmbPrincipal.Items.Clear();
            foreach (DriveInfo d in allDrives)
            {
                if (d.Name != @"C:\")
                {
                    if (d.IsReady)
                        cmbPrincipal.Items.Add(d.Name + "-" + d.VolumeLabel);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string unidade="", argumentos;

            unidade = cmbPrincipal.SelectedItem.ToString();
            string[] letter = unidade.Split('-');
            
            argumentos = "-r - h - s / s / d "+letter[0]+@"\*.*";
            Process.Start("attib",argumentos);
        }
    }
}
