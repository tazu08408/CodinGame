using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        string BEGIN = Console.ReadLine();
        string END = Console.ReadLine();

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.Error.WriteLine($"{BEGIN}   {END}");

        var beginDate=DateTime.ParseExact(BEGIN,"dd.MM.yyyy",null);
        var endDate=DateTime.ParseExact(END, "dd.MM.yyyy", null);

        var totalMonth=(endDate.Year*12+endDate.Month)-(beginDate.Year*12+beginDate.Month);
        if (beginDate.Day > endDate.Day)
        {
            totalMonth -= 1;
        }

        var year = totalMonth / 12;
        var month = totalMonth % 12;



        var returnText = "";
        if (year == 1)
        {
            returnText += "1 year, ";
        }
        if (year > 1)
        {
            returnText += $"{year} years, ";
        }

        if (month == 1)
        {
            returnText += "1 month, ";
        }
        if (month > 1)
        {
            returnText += $"{month} months, ";
        }

        var days=(endDate-beginDate).TotalDays;
        var daysText = (days == 0) ? "days" : (days == 1) ? "day" : "days";
        returnText += $"total {days} {daysText}";

        Console.WriteLine(returnText);
    }
}