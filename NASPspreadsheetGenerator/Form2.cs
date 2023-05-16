using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NASPspreadsheetGenerator
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public List<string> names = new List<string>();
        public List<string> key = new List<string>();
        public List<string> gender = new List<string>();
        public List<string> school = new List<string>();
        public List<string> grade = new List<string>();

        List<Label> labels = new List<Label>();
        List<Button> buttons = new List<Button>();
        

        private void Form2_Load(object sender, EventArgs e)
        {
            names.Clear();
            labels.Clear();
            buttons.Clear();

            labels.Add(lblArcher1);
            labels.Add(lblArcher2);
            labels.Add(lblArcher3);
            labels.Add(lblArcher4);
            labels.Add(lblArcher5);
            labels.Add(lblArcher6);
            labels.Add(lblArcher7);
            labels.Add(lblArcher8);
            labels.Add(lblArcher9);
            labels.Add(lblArcher10);

            buttons.Add(btnArcher1);
            buttons.Add(btnArcher2);
            buttons.Add(btnArcher3);
            buttons.Add(btnArcher4);
            buttons.Add(btnArcher5);
            buttons.Add(btnArcher6);
            buttons.Add(btnArcher7);
            buttons.Add(btnArcher8);
            buttons.Add(btnArcher9);
            buttons.Add(btnArcher10);


            
                for (int i = 0; i < (names.Count-1); i++)
                {
                    labels[i].Text = $"{names[i]}\n{gender[i]}\n{school[i]}\n{grade[i]}";
                    buttons[i].Tag = key[i];
                }

                for (int i = names.Count; i < labels.Count; i++)
                {
                    labels[i].Hide();
                    buttons[i].Hide();
                }
            
        }
    }
}
