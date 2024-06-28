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
using System.Numerics;

class Result
{

    /*
     * Complete the 'organizingContainers' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts 2D_INTEGER_ARRAY container as parameter.
     */

    public static string organizingContainers(List<List<int>> container)
    {
        List<int> ballType = new List<int>();
        List<int> containerType = new List<int>();

        for (int j = 0; j < container.Count; j++)
        {
            int ball = 0;
            int containers = 0;
            for (int k = 0; k < container.Count; k++)
            {
                containers += container[j][k];
                ball += container[k][j];
            }
            ballType.Add(ball);
            containerType.Add(containers);
        }
        ballType.Sort();
        containerType.Sort();
        if (containerType.SequenceEqual(ballType))
            return "Impossible";
        else
            return "Possible";
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> container = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                container.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(containerTemp => Convert.ToInt32(containerTemp)).ToList());
            }

            string result = Result.organizingContainers(container);


        }


    }
}
