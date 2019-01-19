using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace BatchIconReplace
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class IconFile
        {
            public int width;
            public int height;
            public string path;

            public IconFile(string _path)
            {
                Image _icon = Image.FromFile(_path);
                width = _icon.Width;
                height = _icon.Height;
                _icon.Dispose();
                path = _path;
            }
        }
        #region android&ios icons

        string[] androidIcons =
        {
        "\\SdkAndroidProject\\SDK\\res\\drawable\\app_icon.png" ,
        "\\SdkAndroidProject\\SDK\\res\\drawable-hdpi\\app_icon.png",
        "\\SdkAndroidProject\\SDK\\res\\drawable-ldpi\\app_icon.png",
        "\\SdkAndroidProject\\SDK\\res\\drawable-mdpi\\app_icon.png",
        "\\SdkAndroidProject\\SDK\\res\\drawable-xhdpi\\app_icon.png",
        "\\SdkAndroidProject\\SDK\\res\\drawable-xxhdpi\\app_icon.png",
        "\\SdkAndroidProject\\SDK_WithGS\\res\\drawable\\app_icon.png",
        "\\SdkAndroidProject\\SDK_WithGS\\res\\drawable-hdpi\\app_icon.png",
        "\\SdkAndroidProject\\SDK_WithGS\\res\\drawable-ldpi\\app_icon.png",
        "\\SdkAndroidProject\\SDK_WithGS\\res\\drawable-mdpi\\app_icon.png",
        "\\SdkAndroidProject\\SDK_WithGS\\res\\drawable-xhdpi\\app_icon.png",
        "\\SdkAndroidProject\\SDK_WithGS\\res\\drawable-xxhdpi\\app_icon.png"
        };
        string[] iosIcons =
        {
            "\\SdkXcodePriject\\Images.xcassets\\AppIcon.appiconset\\114.png",
            "\\SdkXcodePriject\\Images.xcassets\\AppIcon.appiconset\\120.png",
            "\\SdkXcodePriject\\Images.xcassets\\AppIcon.appiconset\\144.png",
            "\\SdkXcodePriject\\Images.xcassets\\AppIcon.appiconset\\152.png",
            "\\SdkXcodePriject\\Images.xcassets\\AppIcon.appiconset\\180.png",
            "\\SdkXcodePriject\\Images.xcassets\\AppIcon.appiconset\\57.png",
            "\\SdkXcodePriject\\Images.xcassets\\AppIcon.appiconset\\72.png",
            "\\SdkXcodePriject\\Images.xcassets\\AppIcon.appiconset\\76.png",
        };

        #endregion


        string[] files;
        string projectFolder;
        List<IconFile> newIcons = new List<IconFile>();
        private void button1_Click(object sender, EventArgs e)
        {
            files = Directory.GetFiles(newIconFolder.Text, "*.png");
            newIcons.Clear();
            foreach (string file in files)
            {
                newIcons.Add(new IconFile(file));
            }
            MessageBox.Show("成功读取新图标!");
        }

        private void btnHongqueFolder_Click(object sender, EventArgs e)
        {
            projectFolder = textbox2.Text;
            MessageBox.Show("成功读取工程路径!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //开始批量替换图片
            foreach (string oldIconPath in androidIcons)
            {
                IconFile oldFile = new IconFile(projectFolder + oldIconPath);
                string newIconPath = FindNewIcon(oldFile.width, oldFile.height);
                File.Copy(newIconPath, projectFolder + oldIconPath, true);
            }

            foreach (string oldIconPath in iosIcons)
            {
                IconFile oldFile = new IconFile(projectFolder + oldIconPath);
                string newIconPath = FindNewIcon(oldFile.width, oldFile.height);
                if (string.IsNullOrEmpty(newIconPath) == false)
                {
                    File.Copy(newIconPath, projectFolder + oldIconPath, true);
                }
            }
            MessageBox.Show("批量替换图标完成!");
        }

        /// <summary>
        /// 根据原来的icon 长度宽度 找到对应新icon的路径
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        string FindNewIcon(int width, int height)
        {
            foreach (IconFile icon in newIcons)
            {
                if (icon.height == height && icon.width == width)
                {
                    return icon.path;
                }
            }
            return null;
        }
    }
}

