using System;
using System.CodeDom.Compiler;
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
        IDictionary<string, List<string>> archerData = new Dictionary<string, List<string>>();
        IDictionary<string, List<string>> schoolData = new Dictionary<string, List<string>>();
        List<string> archerAlphabeticalNames = new List<string>();


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
            schoolData.Clear();

            var lines = File.ReadAllLines(fileName);
            int k = 0;
            foreach (var line in lines)
            {
                if (k > 0)
                {
                    var values = line.Split(',');
                    /*tournament name, school name, archer name("Graham Jones"), archer history ID,
                     *grade, gender, state, country, end date, range type, division type (school only not gender),
                     *rank (gender and divison, ex. High School Boys), score, 10s, 9s, 8s, 7s, Arrow 1, Arrow 2, Arrow 3,
                     *Arrow 4, Arrow 5, Arrow 6, Arrow 7, Arrow 8, Arrow 9, Arrow 10, Arrow 11, Arrow 12, Arrow 13,
                     *Arrow 14, Arrow 15, Arrow 16, Arrow 17, Arrow 18, Arrow 19, Arrow 20, Arrow 21, Arrow 22, Arrow 23,
                     *Arrow 24, Arrow 25, Arrow 26, Arrow 27, Arrow 28, Arrow 29, Arrow 30
                     */
                    List<string> temp = new List<string>();
                    string tournamentName = values[0];
                    string schoolName = values[1];

                    #region Archer Name Setup
                    string archerFullName = values[2];
                    var nameHold = archerFullName.Split(' ');
                    string archerLastName = nameHold[1];
                    string archerFirstName = nameHold[0];
                    string alphabetizedArcherName = $"{archerLastName}, {archerFirstName}";
                    archerAlphabeticalNames.Add(alphabetizedArcherName);
                    MessageBox.Show(alphabetizedArcherName);
                    #endregion

                    string archerHistoryID = values[3];
                    string grade = values[4];
                    string gender = values[5];
                    string state = values[6];
                    string country = values[7];
                    string endDate = values[8];
                    string rangeType = values[9];
                    string division = values[10];
                    string rank = values[11];
                    int score = Convert.ToInt32(values[12]);
                    int tens = Convert.ToInt32(values[13]);
                    int nines = Convert.ToInt32(values[14]);
                    int eights = Convert.ToInt32(values[15]);
                    int sevens = Convert.ToInt32(values[16]);
                    int arrow1 = Convert.ToInt32(values[17]);
                    int arrow2 = Convert.ToInt32(values[18]);
                    int arrow3 = Convert.ToInt32(values[19]);
                    int arrow4 = Convert.ToInt32(values[20]);




                    //archerData.Add();

                }
                else
                {
                    k++;
                }
            }
        }
    }
}