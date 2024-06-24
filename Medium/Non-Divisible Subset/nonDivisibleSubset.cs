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
using System.Runtime.Intrinsics.Arm;

class Result
{

    /*
     * Complete the 'nonDivisibleSubset' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY s
     */

    public static int nonDivisibleSubset(int k, List<int> s)
    {
        //remainder list
        List<int> remainder = new List<int>();

        if (k == 1)
            return 1;
        for (int i = 0; i < k; i++)
        {
            remainder.Add(0);
        }

        for (int j = 0; j < s.Count; j++)
        {
            int rem = s[j] % k;
            remainder[rem] = remainder[rem] + 1;
        }

        //整除只有一種+其他餘數
        int count = remainder[0] > 0 ? 1 : 0;
        for (int l = 1; l <= k / 2; l++)
        {
            if (l == k - l)
                count++;
            else
                count = count + Math.Max(remainder[l], remainder[k - l]);

        }


        return count;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

        int result = Result.nonDivisibleSubset(k, s);

        //textWriter.WriteLine(result);

        //textWriter.Flush();
        ////textWriter.Close();
    }
}
