using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EbayItemSort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> specList = new List<string>()
        {
        "Brand",
"Color",
"Department",
"Additional",
"Customized",
"Style Code",
"Model",
"Product Line",
"Model",
"Country/Region of Manufacture",
"Style",
"Shoe Width",
"Shoe Shaft Style",
"Release Year",
"Upper Material",
"Type",
"Vintage",
"Character",
"Theme",
"Performance/Activity",
"Features",
"Year Manufactured",
"Pattern",
"Silhouette",
"Insole Material",
"Lining Material",
"Outsole Material",
"Closure",
"Season",
"Occasion",
"Signed",
"Cleat Type",
        };

        HashSet<string> specHash = new HashSet<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            specHash = specList.ToHashSet<string>();
            List<ItemSpec> ItemSpecList = new List<ItemSpec>();
            Dictionary<string, int> specDic = new Dictionary<string, int>();
            for (int i = 0; i < specList.Count; i++)
            {
                specDic[specList[i]] = i;
            }

            string outputStr = "";
            string inputStr = this.textBox1.Text;
            Console.WriteLine(inputStr);

            var strArray = inputStr.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (string strOriginal in strArray)
            {
                //Console.WriteLine(str);
                //outputStr += str + "*" + Environment.NewLine;
                string str = strOriginal.Replace('：', ':');
                var subArray = str.Split(':');
                if (subArray.Length == 2)
                {
                    string specName = subArray[0].Trim();
                    string specValue = subArray[1].Trim();
                    if (specDic.ContainsKey(specName))
                    {
                        int index = specDic[specName];
                        ItemSpecList.Add(new ItemSpec(
                                index,
                                specName,
                                specValue));
                    }
                    else
                    {
                        MessageBox.Show("spec not found " + str);
                    }
                }
            }
            ItemSpecList.Sort(ItemSpecSorter);

            foreach (var item in ItemSpecList)
            {
                outputStr += item.ToString();
            }

            this.textBox2.Text = outputStr;
        }

        int ItemSpecSorter(ItemSpec i1, ItemSpec i2)
        {
            return i1.index.CompareTo(i2.index);
        }
    }

    public class ItemSpec
    {
        public int index;
        public string SpecName;
        public string SpecValue;

        public ItemSpec(int index, string specName, string specValue)
        {
            this.index = index;
            SpecName = specName;
            SpecValue = specValue;
        }

        public override string ToString()
        {
            return $"{SpecName}= {SpecValue}{Environment.NewLine}";
        }
    }

}
