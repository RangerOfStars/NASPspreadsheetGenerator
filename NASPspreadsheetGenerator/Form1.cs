﻿using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;


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
        List<string> schools = new List<string>();

        Form2 archerSelect = new Form2();
        


        private void Form1_Load(object sender, EventArgs e)
        {
            cboFilter.SelectedIndex = 0;
            archerSelect.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        { 
            archerSelect.key.Clear();
            archerSelect.gender.Clear();
            archerSelect.names.Clear();
            archerSelect.grade.Clear();
            archerSelect.school.Clear();
            changeItemShowing(archerSelect.final);
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
            archerAlphabeticalNames.Clear();
            List<int> elementary = new List<int>() { 4, 5 };
            List<int> middle = new List<int>() { 6, 7, 8 };
            List<int> high = new List<int>() { 9, 10, 11, 12 };
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
                    Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                    string tournamentName = rgx.Replace(values[0],"");
                    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                    string schoolName = textInfo.ToTitleCase(values[1].ToLower());
                    schools.Add(schoolName);

                    #region Archer Name Setup
                    
                    string archerFullName = textInfo.ToTitleCase(values[2].ToLower());

                    int countSpaces = archerFullName.Count(Char.IsWhiteSpace); // 6
                    int countWords = archerFullName.Split().Length; // 7
                    string archerHistoryID = values[3];
                    string key = null;
                    string tempName = null;

                    if (countWords == 2)
                    {
                        var nameHold = archerFullName.Split(' ');

                        string archerLastName = nameHold[1];
                        archerLastName = rgx.Replace(archerLastName, "");

                        string archerFirstName = nameHold[0];
                        archerFirstName = rgx.Replace(archerFirstName, "");

                        string alphabetizedArcherName = $"{archerLastName}, {archerFirstName}";
                        archerAlphabeticalNames.Add(alphabetizedArcherName);
                        tempName = alphabetizedArcherName;
                        key = $"{alphabetizedArcherName} ({archerHistoryID})";
                    }
                    else
                    {
                        tempName = archerFullName;
                        archerAlphabeticalNames.Add(archerFullName);
                        key = $"{archerFullName} ({archerHistoryID})";
                    }
                    #endregion

                    
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

                    string div = null;

                    //need to fix
                    if (gender == "M" && elementary.Contains(Convert.ToInt32(grade)) ){
                        div = "Elementary School Boy";
                    } else if (gender == "F" && elementary.Contains(Convert.ToInt32(grade))){
                        div = "Elementary School Girl";
                    } else if (gender == "M" && middle.Contains(Convert.ToInt32(grade))){
                        div = "Middle School Boy";
                    } else if (gender == "F" && middle.Contains(Convert.ToInt32(grade))){
                        div = "Middle School Girl";
                    } else if (gender == "M" && high.Contains(Convert.ToInt32(grade))){
                        div = "High School Boy";
                    } else if (gender == "F" && high.Contains(Convert.ToInt32(grade))){
                        div = "High School Girl";
                    }

                    //var schoolKeys = schoolData.Keys.ToArray();
                    //foreach (var school in schoolKeys)
                    //{
                    //    if (!schoolData.ContainsKey(school))
                    //    {
                    //        //add
                    //        schoolData.Add(school, new List<string>());
                    //    }
                    //    schoolData[school].Add(alphabetizedArcherName);
                    //}

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
                    int arrow22 = Convert.ToInt32(values[38]);
                    int arrow23 = Convert.ToInt32(values[39]);
                    int arrow24 = Convert.ToInt32(values[40]);
                    int arrow25 = Convert.ToInt32(values[41]);
                    int arrow26 = Convert.ToInt32(values[42]);
                    int arrow27 = Convert.ToInt32(values[43]);
                    int arrow28 = Convert.ToInt32(values[44]);
                    int arrow29 = Convert.ToInt32(values[45]);
                    int arrow30 = Convert.ToInt32(values[46]);
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
                    

                    temp.Add(tournamentName);//0
                    temp.Add(schoolName);//1
                    temp.Add(archerFullName);//2
                    temp.Add(archerHistoryID);//3
                    temp.Add(grade);//4
                    temp.Add(gender);//5
                    temp.Add(state);//6
                    temp.Add(country);//7
                    temp.Add(div);//8
                    temp.Add(endDate);//9
                    temp.Add(rangeType);//10
                    temp.Add(division);//11
                    temp.Add(rank);//12
                    temp.Add(score.ToString());//13
                    temp.Add(tens.ToString());//14
                    temp.Add(nines.ToString());//15
                    temp.Add(eights.ToString());//16
                    temp.Add(sevens.ToString());//17
                    temp.Add(round1.ToString());//18
                    temp.Add(round2.ToString());//19
                    temp.Add(round3.ToString());//20
                    temp.Add(round4.ToString());//21
                    temp.Add(round5.ToString());//22
                    temp.Add(round6.ToString());//23
                    temp.Add(tenMeter50s.ToString());//24
                    temp.Add(fifteenMeter50s.ToString());//25
                    temp.Add(tempName);//26

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
                lstPrimary.Sorted = true;
                lstSecondary.Items.Clear();
                foreach (string i in archerAlphabeticalNames)
                {
                    if (!lstPrimary.Items.Contains(i))
                    {
                        lstPrimary.Items.Add(i);
                    }
                }
                
                string input = txtPrimary.Text;
                lstPrimary.Items.Clear();
                foreach (string name in archerAlphabeticalNames)
                {
                    if (name.ToLowerInvariant().Contains(input.ToLowerInvariant()) && !lstPrimary.Items.Contains(name))
                    {
                        lstPrimary.Items.Add(name);
                    }
                }
                
            } else if (cboFilter.SelectedIndex == 1)
            {
                lstPrimary.Items.Clear();
                lstPrimary.Sorted = true;
                lstSecondary.Items.Clear();
                foreach (string i in schools)
                {
                    if (!lstPrimary.Items.Contains(i))
                    {
                        lstPrimary.Items.Add(i);
                    }
                }
                
                string input = txtPrimary.Text;
                lstPrimary.Items.Clear();
                foreach (string name in schools)
                {
                    if (name.ToLowerInvariant().Contains(input.ToLowerInvariant()) && !lstPrimary.Items.Contains(name))
                    {
                        lstPrimary.Items.Add(name);
                    }
                }
                
            }
            else
            {
                lstPrimary.Items.Clear();
                lstSecondary.Items.Clear();
                lstPrimary.Sorted = false;

                lstPrimary.Items.Add("Elementary School Girls");
                lstPrimary.Items.Add("Elementary School Boys");
                lstPrimary.Items.Add("Middle School Girls");
                lstPrimary.Items.Add("Middle School Boys");
                lstPrimary.Items.Add("High School Girls");
                lstPrimary.Items.Add("High School Boys");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (cboFilter.SelectedIndex == 0)
            {
                string input = txtPrimary.Text;
                lstPrimary.Items.Clear();
                foreach (string name in archerAlphabeticalNames)
                {
                    if (name.ToLowerInvariant().Contains(input.ToLowerInvariant()) && !lstPrimary.Items.Contains(name))
                    {
                        lstPrimary.Items.Add(name);
                    }
                }
            } else if (cboFilter.SelectedIndex == 1)
            {
                string input = txtPrimary.Text;
                lstPrimary.Items.Clear();
                foreach (string name in schools)
                {
                    if (name.ToLowerInvariant().Contains(input.ToLowerInvariant()) && !lstPrimary.Items.Contains(name))
                    {
                        lstPrimary.Items.Add(name);
                    }
                }
            }
        }
        /*tournament name, school name, archer name("Graham Jones"), archer history ID,
         *grade, gender, state, country, end date, range type, division type (school only not gender),
                        *rank (gender and divison, ex. High School Boys), score, 10s, 9s, 8s, 7s, Arrow 1, Arrow 2, Arrow 3,
                        *Arrow 4, Arrow 5, Arrow 6, Arrow 7, Arrow 8, Arrow 9, Arrow 10, Arrow 11, Arrow 12, Arrow 13,
                        *Arrow 14, Arrow 15, Arrow 16, Arrow 17, Arrow 18, Arrow 19, Arrow 20, Arrow 21, Arrow 22, Arrow 23,
                        *Arrow 24, Arrow 25, Arrow 26, Arrow 27, Arrow 28, Arrow 29, Arrow 30
                        */

        private void changeItemShowing(string key)
        {
            if (key != null)
            {
                if (key == "{SCHOOL DATA}")
                {
                    var temp = archerData.Keys.ToArray();
                    List<string> tenMeters = new List<string>();
                    List<string> fifteenMeters = new List<string>();
                    List<string> boys = new List<string>();
                    List<string> girls = new List<string>();
                    string schoolDivision = null;
                    string tournamentName = null;


                    foreach (string i in temp)
                    {
                        if (archerData[i][1].Contains(lstPrimary.SelectedItem.ToString()) && Convert.ToInt16(archerData[i][24]) > 0)
                        {
                            tenMeters.Add($"{archerData[i][2]} ({archerData[i][24]})");
                        }
                        if (archerData[i][1].Contains(lstPrimary.SelectedItem.ToString()) && Convert.ToInt16(archerData[i][25]) > 0)
                        {
                            fifteenMeters.Add($"{archerData[i][2]} ({archerData[i][25]})");
                        }
                        if (archerData[i][1].Contains(lstPrimary.SelectedItem.ToString()) && Convert.ToInt16(archerData[i][12]) <= 10)
                        {
                            schoolDivision = archerData[i][11];
                            if (archerData[i][5]== "M")
                            {
                                boys.Add($"{AddOrdinal(Convert.ToInt16(archerData[i][12]))} place: {archerData[i][2]} {archerData[i][13]}");
                            }
                            else
                            {
                                girls.Add($"{AddOrdinal(Convert.ToInt16(archerData[i][12]))} place: {archerData[i][2]} {archerData[i][13]}");
                            }
                        }
                        tournamentName = archerData[i][0];
                    }

                    string output = tournamentName + "\n";

                    if (girls.Count> 0)
                    {
                        output += $"\nTop 10 {schoolDivision} Girls\n";
                        girls.Sort();
                        foreach(string i in girls)
                        {
                            output += i + "\n";
                        }
                    }

                    if (boys.Count > 0)
                    {
                        output += $"\nTop 10 {schoolDivision} Boys:\n";
                        boys.Sort();
                        foreach (string i in boys)
                        {
                            output += i + "\n";
                        }
                    }

                    if (tenMeters.Count > 0)
                    {
                        output += "\nTen Meter 50s:\n";
                        foreach (string i in tenMeters)
                        {
                            output += i + "\n";
                        }
                    }

                    if (fifteenMeters.Count > 0)
                    {
                        output += "\nFifteen Meter 50s:\n";
                        foreach (string i in fifteenMeters)
                        {
                            output += i + "\n";
                        }
                    }
                    lblArcher.Text = output;
                }
                else
                {
                    List<string> selectedArcher = archerData[key];
                    lblArcher.Text = $"Tournament Name: {selectedArcher[0]}\nSelected Archer: {selectedArcher[2]}\nSchool: {selectedArcher[1]}\nGrade: {selectedArcher[4]}\nGender: {selectedArcher[5]}\nDivision: {selectedArcher[8]}" +
                        $"\nScore: {selectedArcher[13]} ({selectedArcher[14]} tens)\nDivision Ranking: {AddOrdinal(Convert.ToInt16(selectedArcher[12]))}\nRound 1: {selectedArcher[18]}\nRound 2: {selectedArcher[19]}" +
                        $"\nRound 3: {selectedArcher[20]}\nRound 4: {selectedArcher[21]}\nRound 5: {selectedArcher[22]}\nRound 6: {selectedArcher[23]}\n10 Meter 50s: {selectedArcher[24]}\n15 Meter 50s: {selectedArcher[25]}";
                }
            }
        }

        public static string AddOrdinal(int num)
        {
            if (num <= 0) return num.ToString();

            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num + "th";
            }

            switch (num % 10)
            {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }
        }

        private void lstPrimary_Click(object sender, EventArgs e)
        {
            if (lstPrimary.SelectedItem != null)
            {
                if (cboFilter.SelectedIndex == 0)
                {
                    var arrayOfAllKeys = archerData.Keys.ToArray();
                    List<string> temporarystorage = new List<string>();
                    foreach (string key in arrayOfAllKeys)
                    {
                        if (key.Contains(lstPrimary.SelectedItem.ToString()))
                        {
                            temporarystorage.Add(key);
                        }
                    }

                    if (temporarystorage.Count > 1)
                    {
                        for (int i = 0; i < temporarystorage.Count; i++)
                        {
                            /*tournament name, school name, archer name("Graham Jones"), archer history ID,
                            *grade, gender, state, country, end date, range type, division type (school only not gender),
                            *rank (gender and divison, ex. High School Boys), score, 10s, 9s, 8s, 7s, Arrow 1, Arrow 2, Arrow 3,
                            *Arrow 4, Arrow 5, Arrow 6, Arrow 7, Arrow 8, Arrow 9, Arrow 10, Arrow 11, Arrow 12, Arrow 13,
                            *Arrow 14, Arrow 15, Arrow 16, Arrow 17, Arrow 18, Arrow 19, Arrow 20, Arrow 21, Arrow 22, Arrow 23,
                            *Arrow 24, Arrow 25, Arrow 26, Arrow 27, Arrow 28, Arrow 29, Arrow 30
                            */
                            archerSelect.key.Add(temporarystorage[i]);
                            archerSelect.names.Add(archerData[temporarystorage[i]][2]);
                            archerSelect.gender.Add(archerData[temporarystorage[i]][5]);
                            archerSelect.school.Add(archerData[temporarystorage[i]][1]);
                            archerSelect.grade.Add(archerData[temporarystorage[i]][4]);

                        }
                        archerSelect.ShowDialog(this);
                    }
                    else
                    {
                        changeItemShowing(temporarystorage[0]);
                    }
                    temporarystorage.Clear();
                } else if (cboFilter.SelectedIndex == 1)
                {
                    lstSecondary.Items.Clear();
                    var tempNames = archerData.Keys.ToArray();
                    foreach (string i in tempNames)
                    {
                        
                        if ((lstPrimary.SelectedItem.ToString() == archerData[i.ToString()][1]) && !lstSecondary.Items.Contains(archerData[i][26]))
                        {
                            lstSecondary.Items.Add(archerData[i][26]);
                        }
                    }
                    lstSecondary.Items.Add("{SCHOOL DATA}");
                }
                else
                {
                    lstSecondary.Items.Clear();
                    var tempNames = archerData.Keys.ToArray();
                    foreach (string i in tempNames)
                    {

                        if ((lstPrimary.SelectedItem.ToString()+"s").Contains(archerData[i.ToString()][8]) && !lstSecondary.Items.Contains(archerData[i][26]))
                        {
                            lstSecondary.Items.Add(archerData[i][26]);
                        }
                    }
                }
            }
        }

        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxSetup();
            if (cboFilter.SelectedIndex == 1 || cboFilter.SelectedIndex == 2)
            {
                lstSecondary.Show();
            }
            else
            {
                lstSecondary.Hide();
            }
        }

        private void lstSecondary_Click(object sender, EventArgs e)
        {
            if (lstSecondary.SelectedItem != null)
            {
                if (cboFilter.SelectedIndex == 1)
                {
                    if (lstSecondary.SelectedItem.ToString() != "{SCHOOL DATA}")
                    {
                        var arrayOfAllKeys = archerData.Keys.ToArray();
                        List<string> temporarystorage = new List<string>();
                        foreach (string key in arrayOfAllKeys)
                        {
                            if (key.Contains(lstSecondary.SelectedItem.ToString()) && lstPrimary.SelectedItem.ToString().Contains(archerData[key][1]))
                            {
                                temporarystorage.Add(key);
                            }
                        }

                        if (temporarystorage.Count > 1)
                        {
                            for (int i = 0; i < temporarystorage.Count; i++)
                            {
                                /*tournament name, school name, archer name("Graham Jones"), archer history ID,
                                *grade, gender, state, country, end date, range type, division type (school only not gender),
                                *rank (gender and divison, ex. High School Boys), score, 10s, 9s, 8s, 7s, Arrow 1, Arrow 2, Arrow 3,
                                *Arrow 4, Arrow 5, Arrow 6, Arrow 7, Arrow 8, Arrow 9, Arrow 10, Arrow 11, Arrow 12, Arrow 13,
                                *Arrow 14, Arrow 15, Arrow 16, Arrow 17, Arrow 18, Arrow 19, Arrow 20, Arrow 21, Arrow 22, Arrow 23,
                                *Arrow 24, Arrow 25, Arrow 26, Arrow 27, Arrow 28, Arrow 29, Arrow 30
                                */
                                archerSelect.key.Add(temporarystorage[i]);
                                archerSelect.names.Add(archerData[temporarystorage[i]][2]);
                                archerSelect.gender.Add(archerData[temporarystorage[i]][5]);
                                archerSelect.school.Add(archerData[temporarystorage[i]][1]);
                                archerSelect.grade.Add(archerData[temporarystorage[i]][4]);

                            }
                            archerSelect.ShowDialog(this);
                        }
                        else
                        {
                            changeItemShowing(temporarystorage[0]);
                        }
                    }
                    else
                    {
                        changeItemShowing(lstSecondary.SelectedItem.ToString());
                    }
                }
                else
                {
                    var arrayOfAllKeys = archerData.Keys.ToArray();
                    List<string> temporarystorage = new List<string>();
                    foreach (string key in arrayOfAllKeys)
                    {
                        if (key.Contains(lstSecondary.SelectedItem.ToString()) && lstPrimary.SelectedItem.ToString().Contains(archerData[key][8]))
                        {
                            temporarystorage.Add(key);
                        }
                    }

                    if (temporarystorage.Count > 1)
                    {
                        for (int i = 0; i < temporarystorage.Count; i++)
                        {
                            /*tournament name, school name, archer name("Graham Jones"), archer history ID,
                            *grade, gender, state, country, end date, range type, division type (school only not gender),
                            *rank (gender and divison, ex. High School Boys), score, 10s, 9s, 8s, 7s, Arrow 1, Arrow 2, Arrow 3,
                            *Arrow 4, Arrow 5, Arrow 6, Arrow 7, Arrow 8, Arrow 9, Arrow 10, Arrow 11, Arrow 12, Arrow 13,
                            *Arrow 14, Arrow 15, Arrow 16, Arrow 17, Arrow 18, Arrow 19, Arrow 20, Arrow 21, Arrow 22, Arrow 23,
                            *Arrow 24, Arrow 25, Arrow 26, Arrow 27, Arrow 28, Arrow 29, Arrow 30
                            */
                            archerSelect.key.Add(temporarystorage[i]);
                            archerSelect.names.Add(archerData[temporarystorage[i]][2]);
                            archerSelect.gender.Add(archerData[temporarystorage[i]][5]);
                            archerSelect.school.Add(archerData[temporarystorage[i]][1]);
                            archerSelect.grade.Add(archerData[temporarystorage[i]][4]);

                        }
                        archerSelect.ShowDialog(this);
                    }
                    else
                    {
                        changeItemShowing(temporarystorage[0]);
                    }
                }
            }
        }
    }
}