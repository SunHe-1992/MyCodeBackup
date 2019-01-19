using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace CodeBackup
{
    public partial class Starter : Form
    {
        public Starter()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //用 "补" 这个字符 把给定的字符串长度补全到20
            string mystring = @"美国游戏发行商";
            Console.WriteLine(mystring.PadRight(20, '补'));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
            //ToString里面的字符串根据需求自己设置格式
        }

        static string TimeSpan2String(TimeSpan ts)
        {
            string temp = "";
            if (ts.Days > 0)
                temp += ts.Days + "天";
            if (ts.Hours > 0)
                temp += ts.Hours + "小时";
            temp += ts.Minutes + "分钟";
            return temp;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //两个时间点的时间间隔
            DateTime battleTime = new DateTime(2016, 1, 1); //日期
            TimeSpan ts = DateTime.Now.Subtract(battleTime).Duration();
            Console.WriteLine("距离" + battleTime.ToShortDateString()
                + "时间间隔 = " + TimeSpan2String(ts));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Console.WriteLine("11.66 四舍五入 = " + Convert.ToInt32(11.66));
            Console.WriteLine("11.66 取大 = " + Math.Ceiling(11.66));
            Console.WriteLine("11.66 取小 = " + Math.Floor(11.66));
            float temp = 112.125485f;
            Console.WriteLine("112.125485 保留3位 = " + temp.ToString("#0.000"));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Console.Clear();
        }

        ///<summary>
        ///生成随机字符串 
        ///</summary>
        ///<param name="length">目标字符串的长度</param>
        ///<param name="useNum">是否包含数字，1=包含，默认为包含</param>
        ///<param name="useLow">是否包含小写字母，1=包含，默认为包含</param>
        ///<param name="useUpp">是否包含大写字母，1=包含，默认为包含</param>
        ///<param name="useSpe">是否包含特殊字符，1=包含，默认为不包含</param>
        ///<param name="custom">要包含的自定义字符，直接输入要包含的字符列表</param>
        ///<returns>指定长度的随机字符串</returns>
        static string GetRandomString(int length, bool useNum, bool useLow, bool useUpp, bool useSpe, string custom = "")
        {
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            System.Random r = new System.Random(BitConverter.ToInt32(b, 0));
            string s = null, str = custom;
            if (useNum == true) { str += "0123456789"; }
            if (useLow == true) { str += "abcdefghijklmnopqrstuvwxyz"; }
            if (useUpp == true) { str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
            if (useSpe == true) { str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~"; }
            for (int i = 0; i < length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }
            return s;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Console.WriteLine(GetRandomString(9, true, true, true, false));
        }

        static bool IsPhoneNum(string content)
        {
            return System.Text.RegularExpressions.Regex.IsMatch
                (content, @"^1(3|4|5|7|8)\d{9}$");
        }
        static bool IsNum(string content)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(content, "^[0-9]*$");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string s1 = "15698ds";
            string s2 = "1569833";
            string s3 = "17099998888";

            Console.WriteLine(s1 + " 是数字?" + IsNum(s1));
            Console.WriteLine(s2 + " 是数字?" + IsNum(s2));
            Console.WriteLine(s2 + " 是手机号?" + IsPhoneNum(s2));
            Console.WriteLine(s3 + " 是手机号?" + IsPhoneNum(s3));

        }

        static string RemoveExtension(string name)
        {
            if (name.Contains("."))
            {
                name = System.IO.Path.GetFileNameWithoutExtension(name);
                return RemoveExtension(name);
            }
            else
                return name;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string fileName = @"file.ext.ccc.ddd";
            Console.WriteLine(fileName + "去掉扩展名是" + RemoveExtension(fileName));
        }
    }
}
