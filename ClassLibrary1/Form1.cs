using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace schistory
{
    public partial class Form1 : Form
    {
        public Form1(object[] args)
        {
            InitializeComponent();

            richTextBox1.Text = "Start Example module with args: " + String.Join(", ", args);

            string myPath = (string)args[0];
            List<NicknameUid> nicknameBase = (List<NicknameUid>)args[1];
            List<SC> dataBase = (List<SC>)args[2];

            richTextBox1.Text += "\n";
            richTextBox1.Text += "nicknameBase length: " + nicknameBase.Count;

            richTextBox1.Text += "\n";
            richTextBox1.Text += "dataBase length: " + dataBase.Count;

            richTextBox1.Text += "\n";
            richTextBox1.Text += "The first nickname from the nickname list: " + nicknameBase[0].nickname;

            richTextBox1.Text += "\n";
            richTextBox1.Text += "The last nickname from the database: " + dataBase[dataBase.Count - 1].data.nickname;

            File.WriteAllText(myPath + "b12bd7dqb23inaw.txt", "hi b12bd7dqb23inaw");
        }
    }

    
}
