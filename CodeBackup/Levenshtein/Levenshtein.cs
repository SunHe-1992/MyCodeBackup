using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Written by Krane Sun 2014-11-18 17:15:36

namespace WindowsFormsApplication2
{
    class Levenshtein
    {
        //declear 2 strings
        private string str1;

        public string Str1
        {
            get { return str1; }
            set { str1 = value; }
        }
        private string str2;

        public string Str2
        {
            get { return str2; }
            set { str2 = value; }
        }
        
        public int GetDistance()
        {
            //declear the matrix
            int[,] d = new int[30, 30];

            //fill in str1 and str2
            for (int i = 0; i < str1.Length; i++)
                d[0, i + 1] = str1[i];
            for (int i = 0; i < str2.Length; i++)
                d[i + 1, 0] = str2[i];

            //calculate  fill the matrix 
            for (int i = 1; i < str1.Length + 2; i++)
                for (int j = 1; j < str2.Length + 2; j++)
                {
                    int cost = 0;

                    if (d[0, i] == d[j, 0])
                    { cost = 0; }
                    else
                    { cost = 1; }
                    //find out which is minum
                    d[i, j] = d[i - 1, j] + 1;

                    if (d[i, j] > d[i, j - 1] + 1)
                    {
                        d[i, j] = d[i, j - 1] + 1;
                    }

                    if (d[i, j] > d[i - 1, j - 1] + cost)
                    {
                        d[i, j] = d[i - 1, j - 1] + cost;
                    }
                }
            return d[str1.Length + 1, str2.Length + 1];//get Levenshtein distance
        }



    }
}
