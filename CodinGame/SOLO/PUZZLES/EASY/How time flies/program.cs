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

        var beginDate=DateTime.Parse(BEGIN);
        var endDate=DateTime.Parse(END);

        DateTime period=endDate-beginDate

        var returnText = "";
        if (period.Year == 1)
        {
            returnText += "1 year,";
        }
        if (period.Year > 1)
        {
            returnText += $"{period.Year} years, ";
        }

        if (period.Month == 1)
        {
            returnText += "1 month,";
        }
        if (period.Month > 1)
        {
            returnText += $"{period.Month} months, ";
        }

        var days=(endDate-beginDate).TotalDays;
        var daysText = (days == 0) ? "" : (days == 1) ? "day" : "days";
        returnText += $"total {days} day{daysText}";

        Console.WriteLine("YY year[s], MM month[s], total NN days");
    }
}