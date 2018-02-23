using System;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

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
            string workingDirectory = Path.GetDirectoryName((new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath);
            string unescapedWorkingDirectory = Uri.UnescapeDataString(workingDirectory);
            string masterFP = Path.Combine(unescapedWorkingDirectory, "CharacterStats.csv");
            textBox1.Text = masterFP;
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