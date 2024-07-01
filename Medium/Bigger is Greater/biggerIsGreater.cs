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
     * Complete the 'biggerIsGreater' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING w as parameter.
     */

    public static string biggerIsGreater(string w)
    {
        char[] charArray = w.ToCharArray();
        int changeIdx = 0;
        
        for (int i = 1; i < charArray.Length - 1; i++)
        {
            if (charArray[i] > charArray[i - 1]) 
            {
                changeIdx = i;
            }
        }

        if (changeIdx == 0)
            return "no answer";
        
        string res = string.Empty;
        //swap
        for (int i = charArray.Length - 1; i > changeIdx; i--)
        {
            if (charArray[i] > charArray[changeIdx]) 
            {
                char temp = charArray[i];
                charArray[i] = charArray[changeIdx];
                charArray[changeIdx] = temp;
                break;
            }
        }

        Array.Sort(charArray, changeIdx+1, charArray.Length- changeIdx);


        res = new string(charArray);
        return w == res ? "no answer" : res;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int T = Convert.ToInt32(Console.ReadLine().Trim());

        for (int TItr = 0; TItr < T; TItr++)
        {
            string w = Console.ReadLine();

            string result = Result.biggerIsGreater(w);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
