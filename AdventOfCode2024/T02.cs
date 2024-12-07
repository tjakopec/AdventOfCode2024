using System;
using System.IO;

namespace AdventOfCode2024
{
	public class T02
	{
		private readonly List<List<int>> Data;

        public T02()
		{
            Console.WriteLine("Day 2");
            Data = new List<List<int>>();
			LoadData();
            Console.WriteLine(CalculateFirstPart());
            //Console.WriteLine(CalculateSecondPart());
            Console.WriteLine("-------------------");
        }

        

        private int CalculateFirstPart()
        {
            
            var sum = 0;


            foreach (var l in Data)
            {
                sum += (CheckLevelsIncreasing(l) || CheckLevelsDecreasing(l)) && LevelDistance(l) ? 1 : 0;
            }


            return sum;
        }

        private bool LevelDistance(List<int> l)
        {
            for(int i = 0; i < l.Count; i++)
            {
                if (i+1<l.Count && Math.Abs(l[i] - l[i + 1]) > 3 )
                {
                    return false;
                }
            }
            return true; 
        }

        private bool CheckLevelsIncreasing(List<int> l)
        {

            for (int i = 0; i < l.Count; i++)
            {
                if (i + 1 < l.Count && l[i] >= l[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckLevelsDecreasing(List<int> l)
        {

            for (int i = 0; i < l.Count; i++)
            {
                if (i + 1 < l.Count && l[i] <= l[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        private void LoadData()
        {
            List<int> l;
            string[] Rawdata = File.ReadAllLines(Constants.DATA_PATH + "T02Data.txt");
            foreach(var s in Rawdata)
            {
                l = new List<int>();
                foreach (var n in s.Split(" "))
                {
                    l.Add(int.Parse(n));
                }
                Data.Add(l);
            }
        }
    }
}

