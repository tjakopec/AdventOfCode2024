using System;
using System.IO;
using System.Text;

namespace AdventOfCode2024
{
	public class T03
	{
		private string Data="";

        public T03()
		{
            Console.WriteLine("Day 3");
			LoadData();
            Console.WriteLine(CalculateFirstPart());
            //Console.WriteLine(CalculateSecondPart());
            Console.WriteLine("-------------------");
        }

        

        private int CalculateFirstPart()
        {
            
            var sum = 0;
            string[] left;
            string[] right;
            int first;
            string[] split = Data.Split(",");
            for(int i = 0; i < split.Length; i++)
            {
                if (i + 1 == split.Length)
                {
                    continue;
                }
                left = split[i].Split("mul(");
                right = split[i + 1].Split(")");
                try
                {
                    first = int.Parse(left[^1]);
                    sum += first * int.Parse(right[0]);
                }
                catch { }
            }
            return sum;
        }

       

        

        private void LoadData()
        {
            string[] Rawdata = File.ReadAllLines(Constants.DATA_PATH + "T03Data.txt");
            var sb = new StringBuilder();
            foreach(var s in Rawdata)
            {
                sb.Append(s);
            }
            Data = sb.ToString();
        }
    }
}

