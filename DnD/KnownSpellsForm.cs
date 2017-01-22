using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace DnD
{
    public partial class KnownSpellsForm : Form
    {
        private int playerNumber;
        public string csvFile;
        int count, searchCount = 0;
        private String[] knownSepllsArr;
        List<Label> LabelList = new List<Label>();
        List<Label> SearchedLabelList = new List<Label>();
        List<Spell> spellArr = new List<Spell>();
        List<Spell> searchedSpellArr = new List<Spell>();
        private string knownSpells;


        public KnownSpellsForm(string knownSpells, List<Spell> spellArr, string csvFile, int playerNumber)
        {
            this.knownSpells = knownSpells;
            this.playerNumber = playerNumber;
            this.csvFile = csvFile;
            this.spellArr = spellArr;
            knownSepllsArr = knownSpells.Split('#');
            InitializeComponent();
            populateForm();
        }

        private void populateForm()
        {
            count = 0;
            foreach(String s in knownSepllsArr)
            {
                if (s != "placeholder")
                {
                    CreateLabel(s, 10, 40, 14.25F, count, s);
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
            lbl.BackColor = Color.Transparent;

            lbl.MouseClick += new MouseEventHandler(lbl_MouseClick);

            this.Controls.Add(lbl);
            LabelList.Add(lbl);

        }

        private void lbl_MouseClick(object sender, MouseEventArgs e)
        {
            var lbl = (Label)sender;

            try
            {
                Spell spell = spellArr[spellArr.FindIndex(a => a.name == lbl.Text)];
                updateSpellText(spell);
            }
            catch(Exception ex)
            {
                lblSpellInfo.Text = "Spell Not Found";
            }
        }

        private void txtSpellSearch_TextChanged(object sender, EventArgs e)
        {
            searchedSpellArr.Clear();
            List<Label> NewSearchedLabelList = new List<Label>();
            var box = (TextBox)sender;
            searchCount = 0;


            if (box.Text != null && box.Text != "")
            {
                try
                {
                    Spell spell = spellArr[spellArr.FindIndex(a => a.name.ToLower().Contains(box.Text.ToLower()))];
                    updateSpellText(spell);
                    for (int i = 0; i < spellArr.Count; i++)
                    {
                        if (spellArr[i].name.ToLower().Contains(box.Text.ToLower()))
                        {
                            searchedSpellArr.Add(spellArr[i]);
                        }
                    }
                    clearSearchList(this);
                    foreach (Label l in SearchedLabelList)
                    {
                        SearchedLabelList.Clear();
                    }

                    List<string> spellSearched = new List<string>();

                    foreach (Spell s in searchedSpellArr)
                    {
                        string name = s.name;
                        spellSearched.Add(name);
                        //CreateLabel(name, 245, 40, 14.25F, searchCount, name + "!Searched!");
                        searchCount++;
                    }
                    lstBoxSearch.DataSource = spellSearched;

                }
                catch (Exception ex)
                {

                }
            }
        }

        public void updateCSV(string text)
        {

            List<String> lines = new List<String>();
            using (StreamReader reader = new StreamReader(csvFile))
            {
                String line;

                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            for (int i = 0; i < lines.Count; i++)
            {
                if (i == playerNumber-1)
                {
                    String[] tokens = lines[i].Split(',');
                    tokens[18] = tokens[18] + "#" + text;

                    string newLine = "";
                    for (int x = 0; x < tokens.Length; x++)
                    {
                        newLine += tokens[x] + ",";
                    }
                    if (newLine.EndsWith(","))
                        newLine = newLine.TrimEnd(',');
                    lines[i] = newLine;
                }
            }

            using (StreamWriter writer = new StreamWriter(csvFile, false))
            {
                foreach (String line in lines)
                    writer.WriteLine(line);
            }
        }

        private void btnAddSpell_Click(object sender, EventArgs e)
        {
            var item = spellArr.FirstOrDefault(o => o.name.ToLower() == txtSpellSearch.Text.ToLower());
            string spellName = "";
            try
            {
                spellName = spellArr[spellArr.FindIndex(o => o.name.ToLower() == txtSpellSearch.Text.ToLower())].name;
            }
            catch(Exception ex)
            {

            }
            if (item != null && spellName != "")
            {
                updateCSV(spellName);
                knownSpells += "#" + spellName;
                CreateLabel(spellName, 10, 40, 14.25F, count, spellName);
                KnownSpellsForm frm = new KnownSpellsForm(knownSpells, spellArr, csvFile, playerNumber);
                this.Visible = false;
                frm.ShowDialog();
                this.Close();
            }
        }

        private void updateSpellText(Spell spell)
        {
            lblSpellInfo.Text =
                    "Name: " + spell.name + "\n" +
                    "Level: " + spell.level + "\n" +
                    "Description: " + spell.desc + "\n" +
                    "Range: " + spell.range + "\n" +
                    "Components: " + spell.components + "\n" +
                    "Material: " + spell.material + "\n" +
                    "Ritual: " + spell.ritual + "\n" +
                    "Duration: " + spell.duration + "\n" +
                    "Concentration: " + spell.concentration + "\n" +
                    "Casting Time: " + spell.casting_time + "\n" +
                    "School: " + spell.school + "\n" +
                    "Class: " + spell.@class + "\n" +
                    "Higher Level: " + spell.higher_level + "\n"
                    ;
        }

        private void lstBoxSearch_Click(object sender, EventArgs e)
        {
            var lstbox = (ListBox)sender;

            try
            {
                Spell spell = spellArr[spellArr.FindIndex(a => a.name == lstbox.Text)];
                updateSpellText(spell);
                txtSpellSearch.Text = lstbox.Text;
            }
            catch (Exception ex)
            {
                lblSpellInfo.Text = "Spell Not Found";
            }
        }

        public void clearSearchList(Control control)
        {
            List<string> acceptedNames = new List<string>();
            foreach(Spell s in searchedSpellArr)
            {
                acceptedNames.Add(s.name);
            }
            foreach (Control c in this.Controls)
            {
                foreach (string s in acceptedNames)
                {
                    if (c.GetType() == typeof(Label) && c.Name.Contains("!Searched!") && !c.Name.Contains(s))
                    {
                        this.Controls.Remove(c);
                    }
                }
            }
        }
    }
}
