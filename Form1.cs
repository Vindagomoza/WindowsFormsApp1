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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OpenFileDialog OpenDlg = new OpenFileDialog();
        SaveFileDialog SaveDlg = new SaveFileDialog();
        string[] s;
        string flag;

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.BeginUpdate();

            foreach (object Item in listBox1.SelectedItems)
            {
                listBox2.Items.Add(Item);
            }
            listBox2.EndUpdate();
            for (int i = listBox1.Items.Count - 1; i >= 0; i--)
            {
                if (listBox1.GetSelected(i)) listBox1.Items.RemoveAt(i);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            listBox1.BeginUpdate();

            string[] Strings = richTextBox1.Text.Split(new char[] { '\n', '\t', ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in Strings)
            {
                string Str = s.Trim();

                if (Str == String.Empty) continue;
                if (radioButton1.Checked) listBox1.Items.Add(Str);
                if (radioButton2.Checked)
                {
                    if (Regex.IsMatch(Str, @"\d")) listBox1.Items.Add(Str);
                }
                if (radioButton3.Checked)
                {
                    if (Regex.IsMatch(Str, @"\w+@\w+\.\w+")) listBox1.Items.Add(Str);
                }
            }
            listBox1.EndUpdate();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            if (richTextBox1.Text!="")
            {
                richTextBox1.Text="";
            }
            if (textBox1.Text != "")
            {
                textBox1.Text="";
            }
            checkBox1.Checked = true;
            checkBox2.Checked = false;
            radioButton1.Checked = true;


        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
 
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenDlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader Reader = new StreamReader(OpenDlg.FileName, Encoding.Default);
                richTextBox1.Text = Reader.ReadToEnd();
                Reader.Close();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveDlg.ShowDialog() == DialogResult.OK)
                    {
                StreamWriter Writer =   new StreamWriter(SaveDlg.FileName);
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    Writer.WriteLine((string)listBox2.Items[i]);
                }
                Writer.Close(); 
            }
            SaveDlg.Dispose();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Информация о приложении и разработчике");
        }

        private void button4_Click(object sender, EventArgs e)
            {
                if (comboBox1.Text == "Алфавиту(по возрастанию)")
                {
                    listBox2.Sorted = true;
                }
                else if (comboBox1.Text == "Алфавиту(по убыванию)")
                {
                    listBox2.Sorted = true;
                    int a = listBox2.Items.Count;
                    s = new string[a];
                    for (int i = 0; i < a; i++)
                    {
                        s[i] = listBox2.Items[i].ToString();
                        //listBox1.Items.AddRange(s[i]);
                    }
                    listBox2.Items.Clear();
                    listBox2.Sorted = false;
                    for (int i = 0; i < a; i++)
                    {
                        listBox2.Items.Insert(i, s[a - 1 - i]);
                    }
                }
                else if (comboBox1.Text == "Длине слова(по возрастанию)")
                {
                    int a = listBox2.Items.Count;
                    s = new string[a];
                    for (int i = 0; i < a; i++)
                    {
                        s[i] = listBox2.Items[i].ToString();
                    }
                    listBox2.Items.Clear();
                    for (int i = 0; i < a; i++)
                    {
                        for (int b = 0; b < a - 1; b++)
                        {
                            if (s[b].Length > s[b + 1].Length)
                            {
                                flag = s[b];
                                s[b] = s[b + 1];
                                s[b + 1] = flag;
                            }

                        }
                    }
                    listBox2.Sorted = false;
                    for (int i = 0; i < a; i++)
                    {
                        listBox2.Items.Insert(i, s[i]);
                    }
                }
                else if (comboBox1.Text == "Длине слова(по убыванию)")
                {
                    int a = listBox2.Items.Count;
                    s = new string[a];
                    for (int i = 0; i < a; i++)
                    {
                        s[i] = listBox2.Items[i].ToString();
                    }
                    listBox2.Items.Clear();
                    for (int i = 0; i < a; i++)
                    {
                        for (int b = 0; b < a - 1; b++)
                        {

                            if (s[b].Length > s[b + 1].Length)
                            {
                                flag = s[b];
                                s[b] = s[b + 1];
                                s[b + 1] = flag;
                            }

                        }
                    }
                    listBox2.Sorted = false;
                    for (int i = 0; i < a; i++)
                    {
                        listBox2.Items.Insert(i, s[a - 1 - i]);
                    }
                }
            }

        private void button13_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();

            string Find = textBox1.Text;

            if (checkBox1.Checked)
            {
                foreach (string String in listBox1.Items)
                {
                    if (String.Contains(Find)) listBox3.Items.Add(String);
                }
            }
            if (checkBox2.Checked)
            {
                foreach (string String in listBox2.Items)
                {
                    if (String.Contains(Find)) listBox3.Items.Add(String);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 AddRec = new Form2();

            AddRec.Owner = this;
            AddRec.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.Items.Count - 1; i >= 0; i--)
            {
                if (listBox1.GetSelected(i)) listBox1.Items.RemoveAt(i);
            }
            for (int i = listBox2.Items.Count - 1; i >= 0; i--)
            {
                if (listBox2.GetSelected(i)) listBox2.Items.RemoveAt(i);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            listBox1.BeginUpdate();

            foreach (object Item in listBox2.SelectedItems)
            {
                listBox1.Items.Add(Item);
            }
            listBox1.EndUpdate();
            for (int i = listBox2.Items.Count - 1; i >= 0; i--)
            {
                if (listBox2.GetSelected(i)) listBox2.Items.RemoveAt(i);
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(listBox2.Items);
            listBox2.Items.Clear();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            listBox2.Items.AddRange(listBox1.Items);
            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text=="Алфавиту(по возрастанию)")
            {
                listBox1.Sorted = true;
            }
            else if (comboBox2.Text =="Алфавиту(по убыванию)")
            {
                listBox1.Sorted = true;
                int a = listBox1.Items.Count;
                s = new string[a];
                for (int i = 0; i < a; i++)
                {
                    s[i] = listBox1.Items[i].ToString();
                    //listBox1.Items.AddRange(s[i]);
                }
                listBox1.Items.Clear();
                listBox1.Sorted = false;
                for (int i = 0; i < a; i++)
                {
                    listBox1.Items.Insert(i,s[a-1-i]);
                }
            }
            else if (comboBox2.Text == "Длине слова(по возрастанию)")
            {
                int a = listBox1.Items.Count;
                s = new string[a];
                for (int i = 0; i < a; i++)
                {
                    s[i] = listBox1.Items[i].ToString();
                }
                listBox1.Items.Clear();
                for (int i = 0; i < a; i++)
                {
                    for (int b=0; b < a-1; b++)
                    { 
                        if (s[b].Length > s[b + 1].Length)
                        {
                            flag = s[b];
                            s[b] = s[b + 1];
                            s[b + 1] = flag;
                        }
                            
                    }
                }
                listBox1.Sorted = false;
                for (int i = 0; i < a; i++)
                {
                    listBox1.Items.Insert(i, s[i]);
                }
            }
            else if (comboBox2.Text == "Длине слова(по убыванию)")
            {
                int a = listBox1.Items.Count;
                s = new string[a];
                for (int i = 0; i < a; i++)
                {
                    s[i] = listBox1.Items[i].ToString();
                }
                listBox1.Items.Clear();
                for (int i = 0; i < a; i++)
                {
                    for (int b = 0; b < a - 1; b++)
                    {

                        if (s[b].Length > s[b + 1].Length)
                        {
                            flag = s[b];
                            s[b] = s[b + 1];
                            s[b + 1] = flag;
                        }

                    }
                }
                listBox1.Sorted = false;
                for (int i = 0; i < a; i++)
                {
                    listBox1.Items.Insert(i, s[a-1-i]);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Алфавиту(по возрастанию)")
            {
                listBox2.Sorted = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
