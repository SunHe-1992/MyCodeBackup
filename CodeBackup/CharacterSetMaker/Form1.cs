using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CharacterSetMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox1.Text = @"自动读取指定目录 所有txt文件的文本字符
勾选读取默认字符集 字符会包括 Resource\Fonts 下的 defaultCharacterSet.txt 
策划手动添加字符请写入到  defaultCharacterSet.txt";
            var di = new DirectoryInfo(string.Format(@"{0}..\..\..\", Application.StartupPath));
            this.textBoxSavePath.Text = di.FullName;
            //string defaultPath = Properties.Settings.Default.assetPath;
            //if (!string.IsNullOrEmpty(defaultPath))
            //{
            //    this.textBoxSavePath.Text = defaultPath;
            //}
        }

        HashSet<char> charDic;
        private void button1_Click(object sender, EventArgs e)
        {
            string outputFile = "导出字库.txt";
            charDic = new HashSet<char>();
            string readPath = textBoxSavePath.Text;
            string[] files = Directory.GetFiles(readPath, "*.txt", SearchOption.TopDirectoryOnly);
            List<string> fileList = files.ToList();
            foreach (string fileName in fileList)
            {
                if (fileName == outputFile) continue;
                string allContent = File.ReadAllText(fileName);
                foreach (char c in allContent)
                {
                    charDic.Add(c);
                }
            }
            string writeContent = "";
            foreach (char c in charDic)
            {
                writeContent += c;
            }
            string writePath = Path.Combine(textBoxSavePath.Text, outputFile);
            File.WriteAllText(writePath, writeContent);
            MessageBox.Show("字库生成成功 路径是 " + writePath);

            Properties.Settings.Default.assetPath = textBoxSavePath.Text;
            Properties.Settings.Default.Save();
        }
    }
}
