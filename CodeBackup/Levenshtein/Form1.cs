using System;
using System.Windows.Forms;

//Written by Krane Sun 2014-11-18 17:15:00

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Levenshtein distance = new Levenshtein();
        //textBox1 : input first string 输入字符串1
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //textBox2 : input second string 输入字符串2
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
        //button3 : read textbox 1 and 2 and call the calucate method and display it by messagebox
        //读取字符串1和字符串2 然后计算编辑距离  再将结果用messagebox输出
        private void button3_Click(object sender, EventArgs e)
        {
            distance.Str1 = textBox1.Text;
            distance.Str2 = textBox2.Text;
            int num = distance.GetDistance();
            System.Windows.Forms.MessageBox.Show
                (distance.Str1 + " 和 " + distance.Str2 + " 的编辑距离是 " + num);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void kraneSunToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
