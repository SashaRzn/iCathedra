using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iCathedra.Forms.Service
{
    public partial class FormSetRoom : Form
    {
        public string Room;

        public FormSetRoom()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Room = textBoxRoom.Text;
            Close();
        }

        private void FormSetRoom_Load(object sender, EventArgs e)
        {
            textBoxRoom.Text = Room;
        }
    }
}
