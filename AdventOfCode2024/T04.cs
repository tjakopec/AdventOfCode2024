using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2024
{
	public class T04
	{
		private char[,] Data;
        private int rows = 0;
        private int columns = 0;
        private bool[,] Used;

        public T04()
		{
            Console.WriteLine("Day 4");
			LoadData();
            //Console.WriteLine(CalculateFirstPart());
            //PrintFirstPart();
            Console.WriteLine(CalculateSecondPart());
            Console.WriteLine("-------------------");
        }

        private int CalculateSecondPart()
        {
            Used = new bool[rows, columns];
            return X();
        }



        private int X()
        {
            var sum = 0;
            for (int i = 0; i < rows - 2; i++)
            {
                for (int j = 0; j < columns - 2; j++)
                {
                    /*
                    Console.WriteLine("{0}.{1}\n.{2}.\n{3}.{4}",
                        Data[i, j] ,
                        Data[i, j + 2] ,
                        Data[i + 1, j + 1] ,
                        Data[i + 2, j],
                        Data[i + 2, j + 2]);
                    */

                    if ((Data[i, j] == 'M' &&
                        Data[i, j + 2] == 'S' &&
                        Data[i + 1, j + 1] == 'A' &&
                        Data[i + 2, j] == 'M' &&
                        Data[i + 2, j + 2] == 'S'
                        )
                        ||
                        (Data[i, j] == 'M' &&
                        Data[i, j + 2] == 'M' &&
                        Data[i + 1, j + 1] == 'A' &&
                        Data[i + 2, j] == 'S' &&
                        Data[i + 2, j + 2] == 'S'
                        )
                        ||
                        (Data[i, j] == 'S' &&
                        Data[i, j + 2] == 'M' &&
                        Data[i + 1, j + 1] == 'A' &&
                        Data[i + 2, j] == 'S' &&
                        Data[i + 2, j + 2] == 'M'
                        )
                        ||
                        (Data[i, j] == 'S' &&
                        Data[i, j + 2] == 'S' &&
                        Data[i + 1, j + 1] == 'A' &&
                        Data[i + 2, j] == 'M' &&
                        Data[i + 2, j + 2] == 'M'
                        )
                        )
                    {
                        sum++;
                    }
                }
            }
            return sum;
        }




        private int CalculateFirstPart()
        {
            return LeftToRight()
                + RightToLeft()
                + TopToBottom()
                + BottomToTop()
                + DiagonalRightToBottom()
                + DiagonalLeftToBottom()
                + DiagonalBottomToRight()
                + DiagonalBottomToLeft();
        }

        private int DiagonalBottomToLeft()
        {
            var sum = 0;
            for (int i = rows - 1; i >=3; i--)
            {
                for (int j = columns-1; j >=3; j--)
                {
                    if (Data[i, j] == 'X' &&
                        Data[i - 1, j - 1] == 'M' &&
                        Data[i - 2, j - 2] == 'A' &&
                        Data[i - 3, j - 3] == 'S')
                    {
                        sum++;
                        Used[i, j] = true;
                        Used[i - 1, j - 1] = true;
                        Used[i - 2, j - 2] = true;
                        Used[i - 3, j - 3] = true;
                    }
                }
            }
            Console.WriteLine("DiagonalBottomToLeft: {0}", sum);
            return sum;
        }


        private int DiagonalBottomToRight()
        {
            var sum = 0;
            for (int i = rows-1; i >=3; i--)
            {
                for (int j = 0; j < columns - 3; j++)
                {
                   
                    if (Data[i, j] == 'X' &&
                        Data[i - 1, j + 1] == 'M' &&
                        Data[i - 2, j + 2] == 'A' &&
                        Data[i - 3, j + 3] == 'S')
                    {
                        sum++;
                        Used[i, j] = true;
                        Used[i - 1, j + 1] = true;
                        Used[i - 2, j + 2] = true;
                        Used[i - 3, j + 3] = true;
                    }
                }
            }
            Console.WriteLine("DiagonalBottomToRight: {0}", sum);
            return sum;
        }


        private int DiagonalLeftToBottom()
        {
            var sum = 0;
            for (int i = 0; i <rows-3; i++)
            {
                for (int j = columns-1; j >=3; j--)
                {
                    if (Data[i, j] == 'X' &&
                        Data[i + 1, j - 1] == 'M' &&
                        Data[i + 2, j - 2] == 'A' &&
                        Data[i + 3, j - 3] == 'S')
                    {
                        sum++;
                        Used[i, j] = true;
                        Used[i + 1, j - 1] = true;
                        Used[i + 2, j - 2] = true;
                        Used[i + 3, j - 3] = true;
                    }
                }
            }
            Console.WriteLine("DiagonalLeftToBottom: {0}", sum);
            return sum;
        }


        private int DiagonalRightToBottom()
        {
            var sum = 0;
            for (int i = 0; i < rows-3; i++)
            {
                for (int j = 0; j < columns-3; j++)
                {
                    if (Data[i, j] == 'X' &&
                        Data[i+1, j + 1] == 'M' &&
                        Data[i+2, j + 2] == 'A' &&
                        Data[i+3, j + 3] == 'S')
                    {
                        sum++;
                        Used[i, j] = true;
                        Used[i+1, j + 1] = true;
                        Used[i+2, j + 2] = true;
                        Used[i+3, j + 3] = true;
                    }
                }
            }
            Console.WriteLine("DiagonalRightToBottom: {0}", sum);
            return sum;
        }



        private int BottomToTop()
        {
            var sum = 0;
            for (int i = rows-1; i >=3; i--)
            {
                for (int j = 0; j <columns; j++)
                {
                    if (Data[i, j] == 'X' &&
                        Data[i - 1, j] == 'M' &&
                        Data[i - 2, j] == 'A' &&
                        Data[i - 3, j] == 'S')
                    {
                        sum++;
                        Used[i, j] = true;
                        Used[i - 1, j] = true;
                        Used[i - 2, j] = true;
                        Used[i - 3, j] = true;
                    }
                }
            }
            Console.WriteLine("BottomToTop: {0}", sum);
            return sum;
        }

        private int TopToBottom()
        {
            var sum = 0;
            for (int i = 0; i < rows-3; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (Data[i, j] == 'X' &&
                        Data[i+1, j] == 'M' &&
                        Data[i+2, j] == 'A' &&
                        Data[i+3, j] == 'S')
                    {
                        sum++;
                        Used[i, j] = true;
                        Used[i+1, j] = true;
                        Used[i+2, j] = true;
                        Used[i+3, j] = true;
                    }
                }
            }
            Console.WriteLine("TopToBottom: {0}", sum);
            return sum;
        }

        private int RightToLeft()
        {
            var sum = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = columns-1; j >= 3; j--)
                {
                    if (Data[i, j] == 'X' &&
                        Data[i, j - 1] == 'M' &&
                        Data[i, j - 2] == 'A' &&
                        Data[i, j - 3] == 'S')
                    {
                        sum++;
                        Used[i, j] = true;
                        Used[i, j - 1] = true;
                        Used[i, j - 2] = true;
                        Used[i, j - 3] = true;
                    }
                }
            }
            Console.WriteLine("RightToLeft: {0}", sum);
            return sum;
        }

        private int LeftToRight()
        {
            var sum = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns-3; j++)
                {
                    if (Data[i,j]=='X' &&
                        Data[i, j+1] == 'M' &&
                        Data[i, j+2] == 'A' &&
                        Data[i, j+3] == 'S' ){
                        sum++;
                        Used[i, j] = true;
                        Used[i, j+1] = true;
                        Used[i, j+2] = true;
                        Used[i, j+3] = true;
                    }
                }
            }
            Console.WriteLine("LeftToRight: {0}",sum);
            return sum;
        }
       

        

        private void LoadData()
        {
            string[] Rawdata = File.ReadAllLines(Constants.DATA_PATH + "T04Data.txt");
            
            foreach(var s in Rawdata)
            {
                rows++;
                if (s.Length > columns)
                {
                    columns = s.Length;
                }
            }

            //Console.WriteLine("rows: {0}, columns: {1}",rows,columns);

            Data = new char[rows, columns];

            rows = 0;
            int i;
            foreach (var s in Rawdata)
            {
                for (i=0;i < s.Length; i++){
                    Data[rows, i] = s[i];
                }
                rows++;
                
            }

            Used = new bool[rows, columns];

        }

        private void PrintFirstPart()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(Used[i,j] ? Data[i,j] : '.');
                }
                Console.WriteLine();
            }
        }
    }
}

