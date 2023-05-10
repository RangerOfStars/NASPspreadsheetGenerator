using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using System.Xml.Linq;


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
                    Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                    archerLastName = rgx.Replace(archerLastName, "");

                    string archerFirstName = nameHold[0];
                    archerFirstName = rgx.Replace(archerFirstName, "");

                    string alphabetizedArcherName = $"{archerLastName}, {archerFirstName}";
                    archerAlphabeticalNames.Add(alphabetizedArcherName);
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
                    #region arrows
                    int arrow1 = Convert.ToInt32(values[17]);
                    int arrow2 = Convert.ToInt32(values[18]);
                    int arrow3 = Convert.ToInt32(values[19]);
                    int arrow4 = Convert.ToInt32(values[20]);
                    int arrow5 = Convert.ToInt32(values[21]);
                    int arrow6 = Convert.ToInt32(values[22]);
                    int arrow7 = Convert.ToInt32(values[23]);
                    int arrow8 = Convert.ToInt32(values[24]);
                    int arrow9 = Convert.ToInt32(values[25]);
                    int arrow10 = Convert.ToInt32(values[26]);
                    int arrow11 = Convert.ToInt32(values[27]);
                    int arrow12 = Convert.ToInt32(values[28]);
                    int arrow13 = Convert.ToInt32(values[29]);
                    int arrow14 = Convert.ToInt32(values[30]);
                    int arrow15 = Convert.ToInt32(values[31]);
                    int arrow16 = Convert.ToInt32(values[32]);
                    int arrow17 = Convert.ToInt32(values[33]);
                    int arrow18 = Convert.ToInt32(values[34]);
                    int arrow19 = Convert.ToInt32(values[35]);
                    int arrow20 = Convert.ToInt32(values[36]);
                    int arrow21 = Convert.ToInt32(values[37]);
                    int arrow22 = Convert.ToInt32(values[37]);
                    int arrow23 = Convert.ToInt32(values[38]);
                    int arrow24 = Convert.ToInt32(values[39]);
                    int arrow25 = Convert.ToInt32(values[40]);
                    int arrow26 = Convert.ToInt32(values[41]);
                    int arrow27 = Convert.ToInt32(values[41]);
                    int arrow28 = Convert.ToInt32(values[42]);
                    int arrow29 = Convert.ToInt32(values[43]);
                    int arrow30 = Convert.ToInt32(values[44]);
                    #endregion

                    #region Round Scores
                    int tenMeter50s = 0;
                    int fifteenMeter50s = 0;
                    int round1 = arrow1 + arrow2 + arrow3 + arrow4 + arrow5;
                    int round2 = arrow6 + arrow7 + arrow8 + arrow9 + arrow10;
                    int round3 = arrow12 + arrow13 + arrow14 + arrow15 + arrow11;
                    int round4 = arrow17 + arrow18 + arrow19 + arrow20 + arrow16;
                    int round5 = arrow22 + arrow23 + arrow24 + arrow25 + arrow21;
                    int round6 = arrow27 + arrow28 + arrow29 + arrow30 + arrow26;

                    if (round1 == 50)
                    {
                        tenMeter50s++;
                    }
                    if (round2 == 50)
                    {
                        tenMeter50s++;
                    }
                    if (round3 == 50)
                    {
                        tenMeter50s++;
                    }
                    if (round4 == 50)
                    {
                        fifteenMeter50s++;
                    }
                    if (round5 == 50)
                    {
                        fifteenMeter50s++;
                    }
                    if (round6 == 50)
                    {
                        fifteenMeter50s++;
                    }
                    #endregion

                    #region Archer Data Setup
                    string key = $"{alphabetizedArcherName} ({archerHistoryID})";

                    temp.Add(tournamentName);
                    temp.Add(schoolName);
                    temp.Add(archerFullName);
                    temp.Add(archerHistoryID);
                    temp.Add(grade);
                    temp.Add(gender);
                    temp.Add(state);
                    temp.Add(country);
                    temp.Add(endDate);
                    temp.Add(rangeType);
                    temp.Add(division);
                    temp.Add(rank);
                    temp.Add(score.ToString());
                    temp.Add(tens.ToString());
                    temp.Add(nines.ToString());
                    temp.Add(eights.ToString());
                    temp.Add(sevens.ToString());
                    temp.Add(round1.ToString());
                    temp.Add(round2.ToString());
                    temp.Add(round3.ToString());
                    temp.Add(round4.ToString());
                    temp.Add(round5.ToString());
                    temp.Add(round6.ToString());
                    temp.Add(tenMeter50s.ToString());
                    temp.Add(fifteenMeter50s.ToString());
                    archerData.Add(key, temp);
                    //key = "Jones, Graham (1234567)"
                    //MAJOR ISSUE WITH DUPLICATE ARCHER NAMES, NEED TO FIND A SOLUTION
                    //.contains with the key to see if the list of items that match is > 1, if so then bring up dialog selecting between the two
                    #endregion

                }
                else
                {
                    k++;
                }
            }
            ListBoxSetup();
        }

        private void ListBoxSetup()
        {
            if (cboFilter.SelectedIndex == 0) //student setup
            {
                lstPrimary.Items.Clear();
                foreach (string i in archerAlphabeticalNames)
                {
                    if (!lstPrimary.Items.Contains(i))
                    {
                        lstPrimary.Items.Add(i);
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string input = txtPrimary.Text;
            lstPrimary.Items.Clear();
            foreach (string name in archerAlphabeticalNames)
            {
                if (name.ToLowerInvariant().Contains(input.ToLowerInvariant()) && !!lstPrimary.Items.Contains(name))
                {
                    lstPrimary.Items.Add(name);
                }
            }
        }
    }
}