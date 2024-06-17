using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'formingMagicSquare' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY s as parameter.
     */

    public static int formingMagicSquare(List<List<int>> s)
    {
        int abs = int.MaxValue;
          int diff = 0;
          List<List<int>> magic = new List<List<int>>
          {
               new List<int> {8,3,4,1,5,9,6,7,2},
               new List<int> {6,7,2,1,5,9,8,3,4},
               new List<int> {4,9,2,3,5,7,8,1,6},
               new List<int> {8,1,6,3,5,7,4,9,2},
               new List<int> {2,7,6,9,5,1,4,3,8},
               new List<int> {4,3,8,9,5,1,2,7,6},
               new List<int> {6,1,8,7,5,3,2,9,4},
               new List<int> {2,9,4,7,5,3,6,1,8}
          };
          
          List<int> array = s.SelectMany(row => row).ToList();

          for(int i = 0;i<magic.Count;i++)
          {
               diff = 0;
               for(int j = 0;j<array.Count;j++)
               {
                     diff = Math.Abs(array[j] - magic[i][j]) + diff;
               }
               //abs
               if(diff < abs)
               abs = diff;
          }
          return abs;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        List<List<int>> s = new List<List<int>>();

        for (int i = 0; i < 3; i++)
        {
            s.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList());
        }

        int result = Result.formingMagicSquare(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
