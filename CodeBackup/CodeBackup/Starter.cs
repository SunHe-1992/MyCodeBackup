using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Linq;
using System.Diagnostics;
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
            //�� "��" ����ַ� �Ѹ������ַ������Ȳ�ȫ��20
            string mystring = @"������Ϸ������";
            Console.WriteLine(mystring.PadRight(20, '��'));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
            //ToString������ַ������������Լ����ø�ʽ
        }

        static string TimeSpan2String(TimeSpan ts)
        {
            string temp = "";
            if (ts.Days > 0)
                temp += ts.Days + "��";
            if (ts.Hours > 0)
                temp += ts.Hours + "Сʱ";
            temp += ts.Minutes + "����";
            return temp;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //����ʱ����ʱ����
            DateTime battleTime = new DateTime(2016, 1, 1); //����

            TimeSpan ts = DateTime.Now.Subtract(battleTime).Duration();
            Console.WriteLine("����" + battleTime.ToShortDateString()
                + "ʱ���� = " + TimeSpan2String(ts));

            Console.WriteLine(TSToString(GetCurrentTimeUnix(battleTime)));
        }
        /// <summary>
        /// ʱ��=>ʱ���
        /// </summary>
        /// <returns></returns>
        static long GetCurrentTimeUnix(DateTime dt)
        {
            TimeSpan cha = (dt - TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)));
            long t = (long)cha.TotalSeconds;
            return t;
        }
        /// <summary>
        /// ������ʱ��� ת���ɾ������ڶ��
        /// </summary>
        /// <param name="givenTS"></param>
        /// <returns></returns>
        static string TSToString(long givenTS)
        {
            long nowTS = GetCurrentTimeUnix(DateTime.Now);
            TimeSpan passed = TimeSpan.FromSeconds(nowTS - givenTS);
            bool isFuture = passed.TotalSeconds < 0;
            string tail = isFuture ? "��" : "ǰ";
            string day = "��";
            string hour = "Сʱ";
            string minute = "����";

            passed = passed.Duration();
            if (passed.TotalDays > 0)
                return (int)passed.TotalDays + day + tail;
            if (passed.TotalHours > 0)
                return (int)passed.TotalHours + hour + tail;
            if (passed.TotalMinutes > 0)
                return (int)passed.TotalMinutes + minute + tail;

            return "�ո�";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Console.WriteLine("11.66 �������� = " + Convert.ToInt32(11.66));
            Console.WriteLine("11.66 ȡ�� = " + Math.Ceiling(11.66));
            Console.WriteLine("11.66 ȡС = " + Math.Floor(11.66));
            float temp = 112.125485f;
            Console.WriteLine("112.125485 ����3λ = " + temp.ToString("#0.000"));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Console.Clear();
        }

        ///<summary>
        ///��������ַ��� 
        ///</summary>
        ///<param name="length">Ŀ���ַ����ĳ���</param>
        ///<param name="useNum">�Ƿ�������֣�1=������Ĭ��Ϊ����</param>
        ///<param name="useLow">�Ƿ����Сд��ĸ��1=������Ĭ��Ϊ����</param>
        ///<param name="useUpp">�Ƿ������д��ĸ��1=������Ĭ��Ϊ����</param>
        ///<param name="useSpe">�Ƿ���������ַ���1=������Ĭ��Ϊ������</param>
        ///<param name="custom">Ҫ�������Զ����ַ���ֱ������Ҫ�������ַ��б�</param>
        ///<returns>ָ�����ȵ�����ַ���</returns>
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

            Console.WriteLine(s1 + " ������?" + IsNum(s1));
            Console.WriteLine(s2 + " ������?" + IsNum(s2));
            Console.WriteLine(s2 + " ���ֻ���?" + IsPhoneNum(s2));
            Console.WriteLine(s3 + " ���ֻ���?" + IsPhoneNum(s3));

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
            Console.WriteLine(fileName + "ȥ����չ����" + RemoveExtension(fileName));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var allProcceses = System.Diagnostics.Process.GetProcesses();

            foreach (var pcs in allProcceses)
            {
                if (pcs.ProcessName == "EXCEL")
                {
                    Console.WriteLine("��⵽excel��������");
                    Console.ReadKey();
                    return;
                }
            }
            Console.WriteLine("û�м�⵽excel");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Console.WriteLine("������ ����Ӳ���ϵ�������");
            return;
            //����Ӳ���ϵ�������
            string path = @"C:\Users\Administrator\Desktop\";
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.WorkingDirectory = path;
            proc.StartInfo.FileName = "abcd.bat";
            proc.StartInfo.CreateNoWindow = false;
            proc.Start();
            proc.WaitForExit();

            /*
             * ��������������д ����svn ����update����
             CD C:\Program Files\TortoiseSVN\bin\
START TortoiseProc.exe /command:update /path:"C:\Project\xxxxx"
START TortoiseProc.exe /command:update /path:"C:\Project\dddddd\"
             */
        }

        OpenFileDialog openFileDialog1 = null;
        private void button11_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.FileOk += OpenFileBtn11;
            openFileDialog1.ShowDialog();
        }

        private void OpenFileBtn11(object sender, CancelEventArgs e)
        {
            /*��ȡӲ�̵��ı��ĵ��������ַ� 
             * ������UTF-8�ַ�����
             * ��ÿ���ַ�����hashset���� ����ȥ�� �󱣴�*/
            HashSet<char> hsTable = new HashSet<char>();
            //StreamReader ��ȡ �򿪵��ļ�
            StreamReader sr = new StreamReader(openFileDialog1.OpenFile());
            string source = sr.ReadToEnd();
            Console.WriteLine("old string Length = " + source.Length);
            foreach (char s in source)
            {
                //Console.WriteLine(s.ToString());
                hsTable.Add(s);
            }
            StringBuilder sb = new StringBuilder();
            foreach (char s in hsTable)
            {
                sb.Append(s);
            }
            string output = sb.ToString();
            System.IO.File.WriteAllText(@"D:\fontcharactors.txt", output);
            Console.WriteLine("new string Length = " + output.Length);
        }

        /// <summary>
        /// ���԰�ť ���д
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click(object sender, EventArgs e)
        {
            //test github
            //string spStirng = "";
            //string fxString = "";
            //string rawString = 
            //    @"����{0}<img src = 'ui://OutsideCombat/���' width = '60' height = '60'/>����������װTXT-43472������װЧ��";
            //Regex rg = new Regex(@"TXT-([0-9][0-9][0-9][0-9][0-9])");
            //MatchCollection matchedAuthors = rg.Matches(rawString);
            //if (matchedAuthors.Count > 0)
            //    fxString = matchedAuthors[0].Value;
            //Console.WriteLine($"MATCH = {fxString}");

            //spStirng = rg.Replace(rawString, "-replace-", 1);
            //Console.WriteLine($" spStirng = {spStirng}");

          

        }
        class DemoClass
        {
            public int id = 123;//class ���������Ĭ��ֵ
            public string name = "tommy";
            public DemoClass(int _id, string _name)
            {
                id = _id;
                name = _name;
            }
        }
        struct DemoStruct
        {
            public int id; //Struct ��������Ĭ��ֵ
            public string name;
            public DemoStruct(int _id, string _name)
            {
                id = _id;
                name = _name;
            }
        }
        //record DemoRecord
        //{

        //}


        /// <summary>
        /// ����=>ʱ���
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static long GetUnixTimeStamp(DateTime d)
        {
            long unixBaseMillis = new DateTime(1970, 1, 1, 0, 0, 0).ToFileTimeUtc() / 10000;
            return ((d.ToFileTime() / 10000) - unixBaseMillis) / 1000;
        }
        /// <summary>
        /// ʱ���=>����
        /// </summary>
        /// <param name="unix"></param>
        /// <returns></returns>
        public static DateTime GetUnixDateTime(long unix)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            DateTime newTime = dtStart.AddSeconds(unix);
            return newTime;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //class
            DemoClass class1 = new DemoClass(1, "red");
            DemoClass class2 = new DemoClass(2, "blue");
            DemoClass class3 = class1;//class ���������� class3 ��class1��ͬһ�������2������
            class3.name = "yellow";
            Console.WriteLine($"class1 name ={class1.name}");
            Console.WriteLine($"class3 name ={class3.name}");

            //struct
            DemoStruct struct1;//struct ��ʹ��newҲ��������  ����int
            struct1.id = 123;
            struct1.name = "apple";

            DemoStruct struct2 = new DemoStruct(122, "melon");//ʹ��newҲ����
            DemoStruct struct3 = struct1;//struct��ֵ���� ʵ������deep����
            struct3.name = "pear";
            Console.WriteLine($"struct1 name ={struct1.name}");
            Console.WriteLine($"struct3 name ={struct3.name}");

            //record
            
        }


    }


}
