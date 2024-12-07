using System;
using System.IO;

namespace AdventOfCode2024
{
	public class T01
	{
		private int[] FirstList;
        private int[] SecondList;

        public T01()
		{
            Console.WriteLine("Day 1");
			LoadData();
            Console.WriteLine(CalculateFirstPart());
            Console.WriteLine(CalculateSecondPart());
            Console.WriteLine("-------------------");
        }

        private int CalculateSecondPart()
        {
            var sum = 0;
            for (int i = 0; i < FirstList.Length; i++)
            {
                sum += FirstList[i] * CountInSecondList(FirstList[i]);
            }
            return sum;
        }

        private int CountInSecondList(int number)
        {
            var sum = 0;
            for (int i = 0; i < SecondList.Length; i++)
            {
                sum += SecondList[i] == number ? 1 : 0;
            }
            return sum;
        }

        private int CalculateFirstPart()
        {
            int[] ClonedFirstList = (int[])FirstList.Clone();
            int[] ClonedSecondList = (int[])SecondList.Clone();
            Array.Sort(ClonedFirstList);
            Array.Sort(ClonedSecondList);
            var sum = 0;
            for(int i = 0; i < ClonedFirstList.Length; i++)
            {
                sum += Math.Abs(ClonedFirstList[i] - ClonedSecondList[i]);
            }
            return sum;
        }

        private void LoadData()
        {
            string[] Rawdata = File.ReadAllLines(Constants.DATA_PATH + "T01Data.txt");
            var Lines = Rawdata.Select(line => line.Split("   ", StringSplitOptions.RemoveEmptyEntries))
                    .Select(items => Tuple.Create(int.Parse(items[0]), int.Parse(items[1])));
            FirstList = Lines.Select(s => s.Item1).ToArray();
            SecondList = Lines.Select(s => s.Item2).ToArray();
        }
    }
}

