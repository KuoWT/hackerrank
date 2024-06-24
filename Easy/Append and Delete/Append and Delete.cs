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
     * Complete the 'appendAndDelete' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. STRING t
     *  3. INTEGER k
     */

    public static string appendAndDelete(string s, string t, int k)
    {
         int sameStringCnt = 0;
        if(s.Length + t.Length <= k)
        {
            return "Yes";
        }
        if (s.Length < t.Length)
        {
            sameStringCnt = findSameString(s, t).Length;
        }
        else
        {
            sameStringCnt = findSameString(t, s).Length;
        }
        int delete= s.Length - sameStringCnt;
        int add = t.Length - sameStringCnt;
        int opsNum = delete + add;
        int extra = k - opsNum;
        if (extra < 0 || extra % 2 != 0) 
        {
            return "No";
        }else
            return "Yes";
    }
    
     private static string findSameString(string t, string s) 
    {
        string sameString = string.Empty;
        for (int i = 0; i < t.Length; i++)
        {
            if (s[i] == t[i])
                sameString = sameString + s[i];
            else
                break;
        }
        return sameString;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string t = Console.ReadLine();

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.appendAndDelete(s, t, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
