using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnD
{
    public partial class Equiped : Form
    {

        List<Label> LabelList = new List<Label>();
        private String[] equipedArr;
        public Equiped(string equiped)
        {
            equipedArr = equiped.Split('#');
            InitializeComponent();
            populateForm();
        }

        private void populateForm()
        {
            int count = 0;
            foreach (String s in equipedArr)
            {
                if (s != "placeholder")
                {
                    CreateLabel(s, 10, 10, 14.25F, count, s);
                    count++;
                }
            }
        }

        public void CreateLabel(string text, int xLocation, int yLocation, float fontSize, int count, string name)
        {
            Label lbl = new Label();
            lbl.Name = "lblPlayer" + (count + 1) + name;
            lbl.Font = new System.Drawing.Font("Modern No. 20", fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbl.Text = text;
            lbl.Location = new System.Drawing.Point(xLocation, yLocation + (25 * count));
            lbl.AutoSize = true;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lbl.ForeColor = Color.White;

            this.Controls.Add(lbl);
            LabelList.Add(lbl);
        }
    }
}
