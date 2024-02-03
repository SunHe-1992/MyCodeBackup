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
namespace SetUserPath
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = "PATH";
            var scope = EnvironmentVariableTarget.User; // or User
            var oldValue = Environment.GetEnvironmentVariable(name, scope);

            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string[] namelist = userName.Split('\\');
            string uname = namelist[namelist.Length - 1];
            List<string> paths = new List<string>();
            //paths.Add(string.Format(@"C:\Users\{0}\AppData\Roaming\npm", uname));

            var readStrings = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "paths.txt");
            paths.AddRange(readStrings);

            string newString = oldValue + "";
            foreach (var path in paths)
            {
                newString += path + ";";
            }
            //MessageBox.Show(newString);
            //var newValue = oldValue + @";C:\Program Files\MySQL\MySQL Server 5.1\bin\\";
            Environment.SetEnvironmentVariable(name, newString, scope);
            System.Windows.Forms.Application.Exit();
        }
    }
}
