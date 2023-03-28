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

namespace Ukol2_Binarni
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream datovytok = new FileStream("sport.dat", FileMode.OpenOrCreate, FileAccess.Write);
            StreamReader ctenar = new StreamReader("sport.txt", Encoding.GetEncoding("windows-1250"));
            BinaryWriter zapisovac = new BinaryWriter(datovytok, Encoding.GetEncoding("windows-1250"));
            while (!ctenar.EndOfStream)
            {
                string data = ctenar.ReadLine();
                string[] deleni = data.Split(';');
                int osc = Convert.ToInt32(deleni[0]);
                string jmeno = deleni[1];
                string prijmeni = deleni[2];
                char pohlavi = Convert.ToChar(deleni[3]);
                int vyska = Convert.ToInt32(deleni[4]);
                int hmotnost = Convert.ToInt32(deleni[5]);
                zapisovac.Write(osc + jmeno + prijmeni + pohlavi + vyska + hmotnost + "\n");
            }

            datovytok.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            FileStream datovytok = new FileStream("sport.dat", FileMode.Open, FileAccess.Read);
            BinaryReader ctenar = new BinaryReader(datovytok, Encoding.GetEncoding("windows-1250"));
            ctenar.BaseStream.Position = 0;
            int i = 0;
            while(ctenar.BaseStream.Position < ctenar.BaseStream.Length)
            {
                textBox1.Text += ctenar.ReadInt32().ToString() + " " + ctenar.ReadString() + " " + ctenar.ReadString() + " " + ctenar.ReadChar().ToString() + " " + ctenar.ReadInt32().ToString() + "cm " + ctenar.ReadInt32().ToString() + "kg.";
                i++;
            }
            datovytok.Close();
            ctenar.Close();
        }
    }
}
