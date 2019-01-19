using System;
using System.IO;
using System.Windows.Forms;
namespace FilesRename
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DirectoryInfo di1 = null, di2 = null;
        private void button1_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fbd.SelectedPath;
                di1 = new DirectoryInfo(fbd.SelectedPath);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = fbd.SelectedPath;
                di2 = new DirectoryInfo(fbd.SelectedPath);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (di1 == null || di2 == null)
            {
                MessageBox.Show("请正确选择文件夹!");
                return;
            }
            if (di1.GetFiles().Length != di2.GetFiles().Length)
            {
                MessageBox.Show("2个文件夹的文件数量不相等!");
                return;
            }

            FileInfo[] info1 = di1.GetFiles();
            FileInfo[] info2 = di2.GetFiles();
            string animPath = info1[0].DirectoryName;

            for (int i = 0; i < info1.Length; i++)
            {
                string from = info2[i].FullName;
                string to = animPath + "\\" + Path.GetFileNameWithoutExtension(info1[i].FullName) + info2[i].Extension;
                File.Move(from, to);
            }
            MessageBox.Show("OK");
        }

    }
}
