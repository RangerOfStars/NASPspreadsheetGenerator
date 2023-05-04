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
using System.Xml;


namespace NASPspreadsheetGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string fileName = null;
        Dictionary<string, List<string>> archerData = new Dictionary<string, List<string>>();
        Dictionary<string, List<string>> schoolData = new Dictionary<string, List<string>>();


        private void Form1_Load(object sender, EventArgs e)
        {
            cboFilter.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ofdOpen.Filter = "Comma Seperated Values (*.csv)|*.csv";
            if (ofdOpen.ShowDialog() == DialogResult.OK)
            {
                fileName = ofdOpen.FileName;
                resetData();
            }
        }

        private void resetData()
        {
            archerData.Clear();

            var lines = File.ReadAllLines(fileName);

            foreach (var line in lines)
            {
                var values = line.Split(',');
                /*tournament name, school name, archer name, archer history ID,
                 *grade, gender, state, country, end date, range type, division type (school only not gender),
                 *rank (gender and divison, ex. High School Boys), 10s, 9s, 8s, 7s, Arrow 1, Arrow 2, Arrow 3,
                 *Arrow 4, Arrow 5, Arrow 6, Arrow 7, Arrow 8, Arrow 9, Arrow 10, Arrow 11, Arrow 12, Arrow 13,
                 *Arrow 14, Arrow 15, Arrow 16, Arrow 17, Arrow 18, Arrow 19, Arrow 20, Arrow 21, Arrow 22, Arrow 23,
                 *Arrow 24, Arrow 25, Arrow 26, Arrow 27, Arrow 28, Arrow 29, Arrow 30
                 */



            }





        }
    }
}