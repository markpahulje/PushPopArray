using System;
using System.Diagnostics;
using System.Linq;

public static class Program 
{
 public static void PushStringCopyArray(ref string[] array, string pushvalue) {
  
        string[] temp = new string[array.Length];
        temp[0] = pushvalue;

        Array.Copy(array, 0, temp, 1, array.Length - 1);

        array = temp;
 }

 public static void PushStringArray(ref string[] array, string pushvalue) {
  
        int newLength = array.Length;
        string[] temp = new string[array.Length];

        temp[0] = pushvalue; //push new value on top of array

        for (int i = 0; i < array.Length - 1; i++)
        temp[i + 1] = array[i];

        array = temp;

 }
 /// <summary>
 /// Pop value from top of string[] ref array
 /// </summary>
 public static string PopStringArray(ref string[] array) {
  
        int newLength = array.Length;
        //string[] temp = new string[array.Length]; //default value is ""
        string[] temp = Enumerable.Repeat("#", array.Length).ToArray(); //set a default value

        string popvalue = array[0]; ////push new value on top of array

        for (int i = array.Length - 1; i >= 1; i--)
        temp[i - 1] = array[i];

        array = temp;

        return popvalue;
 }

 public static void PrintArray(ref string[] array) {
        for (int i = 0; i < array.Length; i++)
        Console.Write("a[" + i + "]=" + array[i] + ",");
        Console.WriteLine();
        Console.WriteLine();
 }

public static void Main() {
    Stopwatch sw = new Stopwatch();
    string[] test = new string[] {"z","a","b","c"};

    Console.WriteLine("Pop/Push Array Test");
    Console.WriteLine("Arr Len=" + test.Length);
    PrintArray(ref test);
    PushStringArray(ref test, "1st");
    PrintArray(ref test);
    PushStringArray(ref test, "2nd");
    PrintArray(ref test);
    PushStringArray(ref test, "3rd");
    PrintArray(ref test);

    sw.Start();
    PushStringArray(ref test, "4th");
    sw.Stop();
    Console.WriteLine(sw.ElapsedTicks + " ticks. WOW! For loop, but still O(n).");
    PrintArray(ref test);

    sw.Start();
    PushStringCopyArray(ref test, "5th");
    sw.Stop();
    Console.WriteLine(sw.ElapsedTicks + " ticks. Array.Copy:  I thought this would be better.");
    PrintArray(ref test);

    Console.WriteLine(PopStringArray(ref test));
    PrintArray(ref test);
    Console.WriteLine(PopStringArray(ref test));
    PrintArray(ref test);
    Console.WriteLine(PopStringArray(ref test));
    PrintArray(ref test);
    Console.WriteLine(PopStringArray(ref test));
    PrintArray(ref test);
    Console.WriteLine(PopStringArray(ref test));
    PrintArray(ref test);
}
}
