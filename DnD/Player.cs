using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD
{
    class Player
    {
        private string playerName;
        private string str;
        private string dex;
        private string con;
        private string intel;
        private string wis;
        private string cha;
        private string hp;
        private string ac;
        private string spellslot1;
        private string spellslot2;
        private string spellslot3;
        private string spellslot4;
        private string spellslot5;
        private string spellslot6;
        private string spellslot7;
        private string spellslot8;
        private string spellslot9;
        private string knownSpells;
        private string equiped;
        private string @class;
        private string level;

        public Player(string playerName, string str, string dex, string con, string intel, string wis, string cha, string hp, string ac,
            string spellslot1, string spellslot2, string spellslot3, string spellslot4, string spellslot5, string spellslot6, string spellslot7,
            string spellslot8, string spellslot9, string knownSpells, string equiped, string @class, string level)
        {
            this.playerName = playerName;
            this.str = str;
            this.dex = dex;
            this.con = con;
            this.intel = intel;
            this.wis = wis;
            this.cha = cha;
            this.hp = hp;
            this.ac = ac;
            this.spellslot1 = spellslot1;
            this.spellslot2 = spellslot2;
            this.spellslot3 = spellslot3;
            this.spellslot4 = spellslot4;
            this.spellslot5 = spellslot5;
            this.spellslot6 = spellslot6;
            this.spellslot7 = spellslot7;
            this.spellslot8 = spellslot8;
            this.spellslot9 = spellslot9;
            this.knownSpells = knownSpells;
            this.equiped = equiped;
            this.@class = @class;
            this.level = level;
        }

        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        public string Str
        {
            get { return str; }
            set { str = value; }
        }

        public string Dex
        {
            get { return dex; }
            set { dex = value; }
        }

        public string Con
        {
            get { return con; }
            set { con = value; }
        }

        public string Intel
        {
            get { return intel; }
            set { intel = value; }
        }

        public string Wis
        {
            get { return wis; }
            set { wis = value; }
        }

        public string Cha
        {
            get { return cha; }
            set { cha = value; }
        }

        public string Hp
        {
            get { return hp; }
            set { hp = value; }
        }

        public string Ac
        {
            get { return ac; }
            set { ac = value; }
        }

        public string Spellslot1
        {
            get { return spellslot1; }
            set { spellslot1 = value; }
        }

        public string Spellslot2
        {
            get { return spellslot2; }
            set { spellslot2 = value; }
        }

        public string Spellslot3
        {
            get { return spellslot3; }
            set { spellslot3 = value; }
        }

        public string Spellslot4
        {
            get { return spellslot4; }
            set { spellslot4 = value; }
        }

        public string Spellslot5
        {
            get { return spellslot5; }
            set { spellslot5 = value; }
        }

        public string Spellslot6
        {
            get { return spellslot6; }
            set { spellslot6 = value; }
        }

        public string Spellslot7
        {
            get { return spellslot7; }
            set { spellslot7 = value; }
        }

        public string Spellslot8
        {
            get { return spellslot8; }
            set { spellslot8 = value; }
        }

        public string Spellslot9
        {
            get { return spellslot9; }
            set { spellslot9 = value; }
        }

        public string KnownSpells
        {
            get { return knownSpells; }
            set { knownSpells = value; }
        }

        public string Equiped
        {
            get { return equiped; }
            set { equiped = value; }
        }

        public string @Class
        {
            get { return @class; }
            set { @class = value; }
        }

        public string Level
        {
            get { return level; }
            set { level = value; }
        }
    }
}