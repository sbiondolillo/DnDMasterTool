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
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace DnD
{
    public partial class DnDMasterTool : Form
    {
        public string csvFile;
        public List<string[]> oCsvList = new List<string[]>();
        public List<string> PlayerName = new List<string>();
        public List<string> InitiativeList = new List<string>();
        List<Player> PlayerList = new List<Player>();
        List<Label> LabelList = new List<Label>();
        List<TextBox> TextBoxList = new List<TextBox>();
        List<Button> ButtonList = new List<Button>();
        List<ComboBox> ComboBoxList = new List<ComboBox>();
        List<Spell> spellArr = new List<Spell>();


        public DnDMasterTool(string csvFile)
        {
            this.csvFile = csvFile;
            InitializeComponent();
            populateTool();
        }

        public DnDMasterTool(string csvFile, List<string> InitiativeList)
        {
            this.InitiativeList = InitiativeList;
            this.csvFile = csvFile;
            InitializeComponent();
            populateTool();
            populateInitiatives();
        }

        public void populateTool()
        {
            readCSV();
            readJson();
        }

        public void readJson()
        {
            string json = File.ReadAllText("SpellsTxt.txt");

            using (StreamReader file = File.OpenText(@"SpellsTxt.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //Spell spells2 = (Spell)serializer.Deserialize(file, typeof(Spell));
                spellArr = JsonConvert.DeserializeObject<List<Spell>>(json);
            }

        }

        public void readCSV()
        {
            String file_name = csvFile;
            StreamReader sr = new StreamReader(file_name);
            String line;
            int count = 0;
            while ((line = sr.ReadLine()) != null)
            {
                this.Height += 125;
                btnAddPlayer.Location = new System.Drawing.Point(10, btnAddPlayer.Location.Y+125);
                TxtAddPlayer.Location = new System.Drawing.Point(TxtAddPlayer.Location.X, TxtAddPlayer.Location.Y + 125);
                String[] tokens = line.Split(',');
               // try
               // {
                    PlayerList.Add(new Player(tokens[0], tokens[1], tokens[2], tokens[3], tokens[4], tokens[5], tokens[6], tokens[7], tokens[8], tokens[9],
                        tokens[10], tokens[11], tokens[12], tokens[13], tokens[14], tokens[15], tokens[16], tokens[17], tokens[18], tokens[19], tokens[20], tokens[21]));
                    PopulateForm(count);

                    calculateSpellMods((count+1).ToString());
                    count++;
                /*}
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid CSV file");
                    Application.Exit();
                }*/
            }
            sr.Close();
        }

        public void PopulateForm(int count)
        {
            int firstRow = 20, secondRow = 40, thirdRow = 60, fourthRow = 80;

            //FirstRow
            CreateLabel(PlayerList[count].PlayerName, 10, 10, 21.75F, count, false, "Name");

            CreateComboBox(170, firstRow, 10.00F, count);
            CreateButton("Delete Player", 250, firstRow-10, 12.00F, count);
            CreateLabel("Spell Slots", 420, firstRow, 14.25F, count, false, "SpellSlots");

            //SecondRow
            CreateLabel("Str", 40, secondRow, 14.25F, count, false, "Str");
            CreateLabel("Dex", 80, secondRow, 14.25F, count, false, "Dex");
            CreateLabel("Con", 120, secondRow, 14.25F, count, false, "Con");
            CreateLabel("Int", 160, secondRow, 14.25F, count, false, "Int");
            CreateLabel("Wis", 200, secondRow, 14.25F, count, false, "Wis");
            CreateLabel("Cha", 240, secondRow, 14.25F, count, false, "Cha");
            CreateLabel("lvl", 280, secondRow, 14.25F, count, false, "Lvl");
            CreateLabel("HP", 320, secondRow, 14.25F, count, false, "Hp");
            CreateLabel("AC", 360, secondRow, 14.25F, count, false, "Ac");
            CreateLabel("Lvl", 420, secondRow, 14.25F, count, false, "Lvl");
            CreateLabel("1", 480, secondRow, 14.25F, count, false, "SpellSlot1");
            CreateLabel("2", 510, secondRow, 14.25F, count, false, "SpellSlot2");
            CreateLabel("3", 540, secondRow, 14.25F, count, false, "SpellSlot3");
            CreateLabel("4", 570, secondRow, 14.25F, count, false, "SpellSlot4");
            CreateLabel("5", 600, secondRow, 14.25F, count, false, "SpellSlot5");
            CreateLabel("6", 630, secondRow, 14.25F, count, false, "SpellSlot6");
            CreateLabel("7", 660, secondRow, 14.25F, count, false, "SpellSlot7");
            CreateLabel("8", 690, secondRow, 14.25F, count, false, "SpellSlot8");
            CreateLabel("9", 720, secondRow, 14.25F, count, false, "SpellSlot9");
            CreateLabel("Spell Save DC", 750, secondRow, 14.25F, count, false, "SpellSave");
            CreateLabel("Spell Attack Modifier", 870, secondRow, 14.25F, count, false, "SpellAtkMod");
            CreateLabel("Inititaive", 1120, secondRow, 14.25F, count, false, "Initiative");

            CreateLabel(PlayerList[count].Str, 40, thirdRow, 14.25F, count, true, "Str");
            CreateLabel(PlayerList[count].Dex, 80, thirdRow, 14.25F, count, true, "Dex");
            CreateLabel(PlayerList[count].Con, 120, thirdRow, 14.25F, count, true, "Con");
            CreateLabel(PlayerList[count].Intel, 160, thirdRow, 14.25F, count, true, "Int");
            CreateLabel(PlayerList[count].Wis, 200, thirdRow, 14.25F, count, true, "Wis");
            CreateLabel(PlayerList[count].Cha, 240, thirdRow, 14.25F, count, true, "Cha");
            CreateLabel(PlayerList[count].Level, 280, thirdRow, 14.25F, count, true, "Lvl");
            CreateLabel(PlayerList[count].Hp, 320, thirdRow, 14.25F, count, true, "Hp");
            CreateLabel(PlayerList[count].Ac, 360, thirdRow, 14.25F, count, true, "Ac");
            CreateLabel(PlayerList[count].Spellslot1, 480, thirdRow, 14.25F, count, true, "SpellSlot1");
            CreateLabel(PlayerList[count].Spellslot2, 510, thirdRow, 14.25F, count, true, "SpellSlot2");
            CreateLabel(PlayerList[count].Spellslot3, 540, thirdRow, 14.25F, count, true, "SpellSlot3");
            CreateLabel(PlayerList[count].Spellslot4, 570, thirdRow, 14.25F, count, true, "SpellSlot4");
            CreateLabel(PlayerList[count].Spellslot5, 600, thirdRow, 14.25F, count, true, "SpellSlot5");
            CreateLabel(PlayerList[count].Spellslot6, 630, thirdRow, 14.25F, count, true, "SpellSlot6");
            CreateLabel(PlayerList[count].Spellslot7, 660, thirdRow, 14.25F, count, true, "SpellSlot7");
            CreateLabel(PlayerList[count].Spellslot8, 690, thirdRow, 14.25F, count, true, "SpellSlot8");
            CreateLabel(PlayerList[count].Spellslot9, 720, thirdRow, 14.25F, count, true, "SpellSlot9");
            CreateLabel("", 780, thirdRow, 14.25F, count, false, "SpellSaveCalculated");
            CreateLabel("", 920, thirdRow, 14.25F, count, false, "SpellAtkModCalculated");
            CreateTextBox(1120, thirdRow, 14.25F, count);

            CreateLabel(FindModifier(PlayerList[count].Str), 40, fourthRow, 14.25F, count, false, "StrMod");
            CreateLabel(FindModifier(PlayerList[count].Dex), 80, fourthRow, 14.25F, count, false, "DexMod");
            CreateLabel(FindModifier(PlayerList[count].Con), 120, fourthRow, 14.25F, count, false, "ConMod");
            CreateLabel(FindModifier(PlayerList[count].Intel), 160, fourthRow, 14.25F, count, false, "IntMod");
            CreateLabel(FindModifier(PlayerList[count].Wis), 200, fourthRow, 14.25F, count, false, "WisMod");
            CreateLabel(FindModifier(PlayerList[count].Cha), 240, fourthRow, 14.25F, count, false, "ChaMod");
            CreateButton("Equpied Weapons", 420, fourthRow, 12.00F, count);
            CreateButton("Known Spells", 570, fourthRow, 12.00F, count);
        }

        public void CreateLabel(string text, int xLocation, int yLocation, float fontSize, int count, bool clickable, string name)
        {
            Label lbl = new Label();
            if(!clickable)
                lbl.Name = "lblPlayer" + (count + 1) + name;
            else
                lbl.Name = "lblPlayer" + (count + 1) + name + "clickable";
            lbl.Font = new System.Drawing.Font("Modern No. 20", fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbl.ForeColor = Color.White;
            lbl.Text = text;
            lbl.Location = new System.Drawing.Point(xLocation, yLocation + (125*count));
            lbl.AutoSize = true;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lbl.BackColor = Color.Transparent;

            if (!lbl.Name.Contains("Name"))
            {
                lbl.MouseClick += new MouseEventHandler(lbl_MouseClick);
                lbl.TextChanged += new EventHandler(lbl_TextChanged);
            }
            else
            {
                lbl.MouseClick += new MouseEventHandler(lbl_NameMouseClick);
            }


            this.Controls.Add(lbl);
            LabelList.Add(lbl);
        }

        public void CreateButton(string text, int xLocation, int yLocation, float fontSize, int count)
        {
            Button btn = new Button();
            btn.Name = "btnPlayer" + (count + 1) + text;
            btn.Font = new System.Drawing.Font("Modern No. 20", fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn.Text = text;
            btn.Location = new System.Drawing.Point(xLocation, yLocation + (125 * count));
            btn.Width = 150;
            btn.Height = 30;
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            btn.ForeColor = Color.White;
            if (btn.Name.Contains("Known Spells"))
                btn.MouseClick += new MouseEventHandler(btn_SpellMouseClick);
            else if (btn.Name.Contains("Equpied Weapons"))
                btn.MouseClick += new MouseEventHandler(btn_WeaponMouseClick);
            else if (btn.Name.Contains("Delete Player"))
            {
                btn.Visible = false;
                btn.MouseClick += new MouseEventHandler(btn_DeletePlayerMouseClick);
            }
            this.Controls.Add(btn);
            ButtonList.Add(btn);
        }
        public void CreateTextBox(int xLocation, int yLocation, float fontSize, int count)
        {
            TextBox box = new TextBox();
            box.Name = "btnPlayer" + (count + 1) + "Initiative";
            box.Font = new System.Drawing.Font("Modern No. 20", fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            box.Location = new System.Drawing.Point(xLocation, yLocation + (125 * count));
            box.Width = 80;
            box.Height = 40;
            box.TextAlign = HorizontalAlignment.Center;
            box.TextChanged += new EventHandler(box_TextChanged);
            this.Controls.Add(box);
            TextBoxList.Add(box);
        }

        public void CreateComboBox(int xLocation, int yLocation, float fontSize, int count)
        {
            ComboBox box = new ComboBox();
            box.Name = "comboPlayer" + (count + 1) + "Class";
            box.Font = new System.Drawing.Font("Modern No. 20", fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            box.Location = new System.Drawing.Point(xLocation, yLocation + (125 * count));
            box.Items.Add("Barbarian");
            box.Items.Add("Bard");
            box.Items.Add("Cleric");
            box.Items.Add("Druid");
            box.Items.Add("Fighter");
            box.Items.Add("Monk");
            box.Items.Add("Palidin");
            box.Items.Add("Ranger");
            box.Items.Add("Rouge");
            box.Items.Add("Sorcerer");
            box.Items.Add("Warlock");
            box.Items.Add("Wizard");
            box.Width = 80;
            box.Height = 35;
            box.BackColor = Color.FromName("ControlDarkDark");
            box.ForeColor = Color.White;
            ComboBoxList.Add(box);
            box.SelectedValueChanged += new EventHandler(comboBox_SelectedValueChanged);
            box.SelectedText = PlayerList[count].Class;
            this.Controls.Add(box);
        }

        private void lbl_MouseClick(object sender, MouseEventArgs e)
        {
            var lbl = (Label)sender;
            int textHolder = 0;
            string str = Regex.Replace(lbl.Name, "\\D+", "");
            int n;
            int.TryParse(str, out n);
            if (e.Button == MouseButtons.Left)
            {
                if (lbl.Name.Contains("clickable"))
                {
                    Int32.TryParse(lbl.Text,out textHolder);
                    textHolder++;
                    lbl.Text = textHolder.ToString();
                    updateCSV(lbl.Name, lbl.Text);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (lbl.Name.Contains("clickable"))
                {
                    Int32.TryParse(lbl.Text, out textHolder);
                    textHolder--;
                    lbl.Text = textHolder.ToString();
                    updateCSV(lbl.Name, lbl.Text);
                }
            }
            if(lbl.Name.Contains("Lvl"))
                updateSpecificCSVValue(lbl.Text, n, 21);
            refreshPlayerStats();
            if(!lbl.Name.Contains("SpellSlot"))
                calculateSpellMods(str);
        }

        private void lbl_NameMouseClick(object sender, MouseEventArgs e)
        {
            var lbl = (Label)sender;
            string str = Regex.Replace(lbl.Name, "\\D+", "");
            int index = ButtonList.FindIndex(a => (a.Name.Contains(str)));
            if (ButtonList[index].Visible == true)
                ButtonList[index].Visible = false;
            else
                ButtonList[index].Visible = true;
            calculateSpellMods(str);

        }

        private void lbl_TextChanged(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            string str = lbl.Name;
            str = Regex.Replace(str, "\\D+", "");
            if (lbl.Name.Contains("clickable") && !lbl.Name.Contains("SpellSlot"))
            {
                if (lbl.Name.Contains("Str"))
                    LabelList[LabelList.FindIndex(a => (a.Name.Contains(str)) && (a.Name.Contains("StrMod")))].Text = FindModifier(lbl.Text);
                if (lbl.Name.Contains("Dex"))
                    LabelList[LabelList.FindIndex(a => (a.Name.Contains(str)) && (a.Name.Contains("DexMod")))].Text = FindModifier(lbl.Text);
                if (lbl.Name.Contains("Con"))
                    LabelList[LabelList.FindIndex(a => (a.Name.Contains(str)) && (a.Name.Contains("ConMod")))].Text = FindModifier(lbl.Text);
                if (lbl.Name.Contains("Int"))
                    LabelList[LabelList.FindIndex(a => (a.Name.Contains(str)) && (a.Name.Contains("IntMod")))].Text = FindModifier(lbl.Text);
                if (lbl.Name.Contains("Wis"))
                    LabelList[LabelList.FindIndex(a => (a.Name.Contains(str)) && (a.Name.Contains("WisMod")))].Text = FindModifier(lbl.Text);
                if (lbl.Name.Contains("Cha"))
                    LabelList[LabelList.FindIndex(a => (a.Name.Contains(str)) && (a.Name.Contains("ChaMod")))].Text = FindModifier(lbl.Text);

                calculateSpellMods(str);
            }
        }

        private void comboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            string str = Regex.Replace(combo.Name, "\\D+", "");
            int n;
            int.TryParse(str, out n);

            updateSpecificCSVValue(combo.Text, n, 20);
            calculateSpellMods(str);

        }

        private void box_TextChanged(object sender, EventArgs e)
        {
            List<int> order = new List<int>();
            var box = (TextBox)sender;
            int n;
            
                foreach (TextBox t in TextBoxList)
                {
                    if((t.Text != null || t.Text != "")&& int.TryParse(t.Text, out n))
                        order.Add(n);
                }
            
            order = order.OrderBy(i => -i).ToList();
            string initiativeOrder = "";
            List<string> textBoxName = new List<string>();
            foreach(int x in order)
            {
                for(int i = 0; i < TextBoxList.Count;i++)
                {
                    if(TextBoxList[i].Text == x.ToString() && !textBoxName.Contains(TextBoxList[i].Name))
                    {
                        textBoxName.Add(TextBoxList[i].Name);
                    }
                }
            }
            for(int i = 0; i < textBoxName.Count; i++)
            {
                string str = textBoxName[i];
                str = Regex.Replace(str, "\\D+", "");
                initiativeOrder += LabelList[LabelList.FindIndex(a => (a.Name.Contains(str)) && (a.Name.Contains("Name")))].Text + " (" + order[i] + ") \n";
            }
            initiative.Text = initiativeOrder;
        }

        public void populateInitiatives()
        {
            for(int i = 0; i < InitiativeList.Count; i++)
            {
                if(InitiativeList[i] != null && InitiativeList[i] != "")
                    TextBoxList[i].Text = InitiativeList[i];
            }
        }

        private void btn_SpellMouseClick(object sender, MouseEventArgs e)
        {
            var btn = (Button)sender;
            string str = Regex.Replace(btn.Name, "\\D+", "");
            int n;
            int.TryParse(str, out n);


            String file_name = csvFile;
            StreamReader sr = new StreamReader(file_name);
            String line;
            int count = 0;
            while ((line = sr.ReadLine()) != null)
            {
                String[] tokens = line.Split(',');
                if (count == (n-1))
                {
                    PlayerList[n - 1].KnownSpells = tokens[18];
                    PopulateForm(count);
                }
                count++;
            }
            sr.Close();


            KnownSpellsForm frm = new KnownSpellsForm(PlayerList[n-1].KnownSpells, spellArr, csvFile, n);
            frm.ShowDialog();
        }

        private void btn_WeaponMouseClick(object sender, MouseEventArgs e)
        {
            var btn = (Button)sender;
            string str = Regex.Replace(btn.Name, "\\D+", "");
            int n;
            int.TryParse(str, out n);
            Equiped frm = new Equiped(PlayerList[n - 1].Equiped);
            frm.ShowDialog();
        }

        private void btn_DeletePlayerMouseClick(object sender, MouseEventArgs e)
        {
            var btn = (Button)sender;
            string str = Regex.Replace(btn.Name, "\\D+", "");
            int n;
            int.TryParse(str, out n);
            DeletePlayerCSV(n);
        }

        public void updateCSV(string lblName, string lblText)
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
                if (lblName.Contains((i+1).ToString()))
                {
                    String[] tokens = lines[i].Split(',');
                    if (lblName.Contains("Str"))
                        tokens[1] = lblText;
                    if (lblName.Contains("Dex"))
                        tokens[2] = lblText;
                    if (lblName.Contains("Con"))
                        tokens[3] = lblText;
                    if (lblName.Contains("Int"))
                        tokens[4] = lblText;
                    if (lblName.Contains("Wis"))
                        tokens[5] = lblText;
                    if (lblName.Contains("Cha"))
                        tokens[6] = lblText;
                    if (lblName.Contains("Hp"))
                        tokens[7] = lblText;
                    if (lblName.Contains("Ac"))
                        tokens[8] = lblText;
                    if (lblName.Contains("SpellSlot1"))
                        tokens[9] = lblText;
                    if (lblName.Contains("SpellSlot2"))
                        tokens[10] = lblText;
                    if (lblName.Contains("SpellSlot3"))
                        tokens[11] = lblText;
                    if (lblName.Contains("SpellSlot4"))
                        tokens[12] = lblText;
                    if (lblName.Contains("SpellSlot5"))
                        tokens[13] = lblText;
                    if (lblName.Contains("SpellSlot6"))
                        tokens[14] = lblText;
                    if (lblName.Contains("SpellSlot7"))
                        tokens[15] = lblText;
                    if (lblName.Contains("SpellSlot8"))
                        tokens[16] = lblText;
                    if (lblName.Contains("SpellSlot9"))
                        tokens[17] = lblText;

                    string newLine = "";
                    for(int x =0; x < tokens.Length; x++)
                    {
                        newLine += tokens[x]+ ",";
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

        private void DeletePlayerCSV(int playerNumber)
        {
            int count = 1;
            List<String> lines = new List<String>();
            using (StreamReader reader = new StreamReader(csvFile))
            {
                String line;

                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            using (StreamWriter writer = new StreamWriter(csvFile, false))
            {
                foreach (String line in lines)
                {
                    if(count != playerNumber)
                        writer.WriteLine(line);
                    count++;
                }
            }
            InitiativeList.Clear();
            for (int i = 0; i < PlayerList.Count(); i++)
            {
                InitiativeList.Add(TextBoxList[i].Text);
            }
            DnDMasterTool frm = new DnDMasterTool(csvFile, InitiativeList);
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }

        public void updateSpecificCSVValue(string text, int playerNumber, int tokenNumber)
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
                if (i == playerNumber - 1)
                {
                    String[] tokens = lines[i].Split(',');
                    tokens[tokenNumber] = text;

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

        public string FindModifier(string stat)
        {
            int convertedStat = Int32.Parse(stat);
            double mod = 0;
            mod = ((double)convertedStat - 11) / 2;
            mod = Math.Ceiling(mod);
            if (convertedStat < 10)
                return mod.ToString();
            else
                return "+" + mod;
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            if (TxtAddPlayer.Text != null && TxtAddPlayer.Text != "")
            {
                var btn = (Button)sender;
                TxtAddPlayer.Location = new System.Drawing.Point(TxtAddPlayer.Location.X, TxtAddPlayer.Location.Y + 125);
                btnAddPlayer.Location = new System.Drawing.Point(10, btnAddPlayer.Location.Y + 125);
                this.Height += 125;


                List<String> lines = new List<String>();
                using (StreamReader reader = new StreamReader(csvFile))
                {
                    String line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                    lines.Add(TxtAddPlayer.Text + ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,placeholder,placeholder,Bard,1");
                }
                using (StreamWriter writer = new StreamWriter(csvFile, false))
                {
                    foreach (String line in lines)
                        writer.WriteLine(line);
                }
                InitiativeList.Clear();
                for(int i = 0; i < PlayerList.Count();i++)
                {
                    InitiativeList.Add(TextBoxList[i].Text);
                }
                DnDMasterTool frm = new DnDMasterTool(csvFile, InitiativeList);
                this.Visible = false;
                frm.ShowDialog();
                this.Close();
            }
        }

        private void calculateSpellMods(string playerNumber)
        {
            int intMod = 0, wisMod = 0, charMod = 0,profBonus = 0, level = 0;

            Int32.TryParse(LabelList[LabelList.FindIndex(a => a.Name.Contains(playerNumber) && a.Name.Contains("IntMod"))].Text, out intMod);
            Int32.TryParse(LabelList[LabelList.FindIndex(a => a.Name.Contains(playerNumber) && a.Name.Contains("WisMod"))].Text, out wisMod);
            Int32.TryParse(LabelList[LabelList.FindIndex(a => a.Name.Contains(playerNumber) && a.Name.Contains("ChaMod"))].Text, out charMod);

            string @class = ComboBoxList[ComboBoxList.FindIndex(a => a.Name.Contains(playerNumber))].Text;
            int spellsaveindex = LabelList.FindIndex(a => a.Name.Contains(playerNumber) && a.Name.Contains("SpellSaveCalculated"));
            int spellattackindex = LabelList.FindIndex(a => a.Name.Contains(playerNumber) && a.Name.Contains("SpellAtkModCalculated"));


            Int32.TryParse(PlayerList[Int32.Parse(playerNumber) - 1].Level, out level);
            if (level >= 1 && level <= 4)
                profBonus = 2;
            else if (level >= 5 && level <= 8)
                profBonus = 3;
            else if (level >= 9 && level <= 12)
                profBonus = 4;
            else if (level >= 13 && level <= 16)
                profBonus = 5;
            else if (level >= 17 && level <= 20)
                profBonus = 6;


            if (@class == "Fighter" || @class == "Rouge" || @class == "Wizard")
            {
                LabelList[spellsaveindex].Text = (8 + profBonus + intMod).ToString();
                LabelList[spellattackindex].Text = (profBonus + intMod).ToString();
            }
            else if (@class == "Cleric" || @class == "Druid" || @class == "Ranger")
            {
                LabelList[spellsaveindex].Text = (8 + profBonus + wisMod).ToString();
                LabelList[spellattackindex].Text = (profBonus + wisMod).ToString();
            }
            else if (@class == "Bard" || @class == "Palidin" || @class == "Sorcerer" || @class == "Warlock")
            {
                LabelList[spellsaveindex].Text = (8 + profBonus + charMod).ToString();
                LabelList[spellattackindex].Text = (profBonus + charMod).ToString();
            }
            else
            {
                LabelList[spellsaveindex].Text = "N/A";
                LabelList[spellattackindex].Text = "N/A";
            }
        }

        private void refreshPlayerStats()
        {
            String file_name = csvFile;
            StreamReader sr = new StreamReader(file_name);
            String line;
            int count = 0;
            while ((line = sr.ReadLine()) != null)
            {
                String[] tokens = line.Split(',');
                try
                {
                    PlayerList[count] = new Player(tokens[0], tokens[1], tokens[2], tokens[3], tokens[4], tokens[5], tokens[6], tokens[7], tokens[8], tokens[9],
                        tokens[10], tokens[11], tokens[12], tokens[13], tokens[14], tokens[15], tokens[16], tokens[17], tokens[18], tokens[19], tokens[20], tokens[21]);
                    calculateSpellMods((count + 1).ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid CSV file");
                    Application.Restart();
                }
            }
            sr.Close();
        }
    }
}
