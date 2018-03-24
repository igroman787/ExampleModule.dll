using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace schistory
{
    public class Class1
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main(object[] args)
        {
            try
            {
                General(args);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        static void General(object[] args)
        {
            args = new object[] { args[0], ObjectToNicknameBase((object[])args[1]), ObjectToDataBase((object[])args[2]) };
            Form form1 = new Form1(args);
            form1.Show();
        }
        static List<NicknameUid> ObjectToNicknameBase(object[] input)
        {
            List<NicknameUid> output = new List<NicknameUid>();
            foreach (object[] item in input)
            {
                NicknameUid buffer = new NicknameUid();
                buffer.nickname = (string)item[0];
                buffer.uid = (Int64)item[1];

                output.Add(buffer);
            }
            return output;
        }
        static List<SC> ObjectToDataBase(object[] input)
        {
            List<SC> output = new List<SC>();
            foreach (object[] item in input)
            {
                SC buffer = new SC();
                buffer.data = new SCdata();
                buffer.data.pvp = new SCdataPvp();
                buffer.data.clan = new SCdataClan();

                buffer.result = (string)item[0];
                buffer.code = (int)item[1];
                buffer.text = (string)item[2];
                buffer.date = (DateTime)item[3];
                buffer.data.effRating = (Int64)item[4];
                buffer.data.karma = (Int64)item[5];
                buffer.data.nickname = (string)item[6];
                buffer.data.prestigeBonus = (double)item[7];
                buffer.data.uid = (Int64)item[8];
                buffer.data.pvp.gamePlayed = (Int64)item[9];
                buffer.data.pvp.gameWin = (Int64)item[10];
                buffer.data.pvp.totalAssists = (Int64)item[11];
                buffer.data.pvp.totalBattleTime = (Int64)item[12];
                buffer.data.pvp.totalDeath = (Int64)item[13];
                buffer.data.pvp.totalDmgDone = (Int64)item[14];
                buffer.data.pvp.totalHealingDone = (Int64)item[15];
                buffer.data.pvp.totalKill = (Int64)item[16];
                buffer.data.pvp.totalVpDmgDone = (Int64)item[17];
                buffer.data.clan.name = (string)item[18];
                buffer.data.clan.tag = (string)item[18];

                output.Add(buffer);
            }
            return output;
        }
    }

    public class SC : IEquatable<SC>, IComparable<SC>
    {
        public string result { get; set; }
        public int code { get; set; }
        public string text { get; set; }
        public SCdata data { get; set; }
        public DateTime date { get; set; }

        public bool Equals(SC sc)
        {
            if (this.data.nickname == sc.data.nickname && this.date.Year == sc.date.Year && this.date.Month == sc.date.Month && this.date.Day == sc.date.Day)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int CompareTo(SC p)
        {
            return this.date.CompareTo(p.date);
        }
    }
    public class SCdata
    {
        public Int64 effRating { get; set; }
        public Int64 karma { get; set; }
        public string nickname { get; set; }
        public double prestigeBonus { get; set; }
        public Int64 uid { get; set; }
        public SCdataPvp pvp { get; set; }
        public SCdataClan clan { get; set; }
    }
    public class SCdataPvp
    {
        public Int64 gamePlayed { get; set; }
        public Int64 gameWin { get; set; }
        public Int64 totalAssists { get; set; }
        public Int64 totalBattleTime { get; set; }
        public Int64 totalDeath { get; set; }
        public Int64 totalDmgDone { get; set; }
        public Int64 totalHealingDone { get; set; }
        public Int64 totalKill { get; set; }
        public Int64 totalVpDmgDone { get; set; }
    }
    public class SCdataClan
    {
        public string name { get; set; }
        public string tag { get; set; }
    }
    public class NicknameUid : IEquatable<NicknameUid>
    {
        public string nickname { get; set; }
        public Int64 uid { get; set; }

        public bool Equals(NicknameUid other)
        {
            if (this.nickname == other.nickname)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
