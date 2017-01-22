using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace DnD
{
    public partial class Form1 : Form
    {
        public bool exit;
        public Form1()
        {
            exit = true;
            InitializeComponent();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                textBox1.Text = file;
            }
            Console.WriteLine(size); // <-- Shows file size in debugging mode.
            Console.WriteLine(result); // <-- For debugging use.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null || textBox1.Text != "")
            {
                DnDMasterTool frm = new DnDMasterTool(textBox1.Text);
                this.Visible = false;
                frm.ShowDialog();
                this.Close();
            }
        }
    }
}