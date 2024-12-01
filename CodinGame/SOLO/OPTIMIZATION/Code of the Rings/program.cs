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
class Player
{
    static void Main(string[] args)
    {
        //その場で文字変更して文字列作成→Test24で4000字超過
        string magicPhrase = Console.ReadLine();

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        var asciiDictionary=new Dictionary<string, int>() {
            {" ",0 },
            {"A",1 },
            {"B",2},
            {"C",3},
            {"D",4},
            {"E",5},
            {"F",6},
            {"G",7},
            {"H",8},
            {"I",9},
            {"J",10 },
            {"K",11},
            {"L",12},
            {"M",13},
            {"N",14},
            {"O",15},
            {"P",16},
            {"Q",17},
            {"R",18},
            {"S",19},
            {"T",20},
            {"U",21},
            {"V",22},
            {"W",23},
            {"X",24},
            {"Y",25},
            {"Z",26},
        };

        var totalAsciiChara = 27;
        var currentChara = 0;

        var resultText = "";

        foreach(var ascii in magicPhrase)
        {
            var targetCount = asciiDictionary[ascii.ToString()];

            if( targetCount - currentChara >= 0)
            {
                var count=targetCount-currentChara;
                resultText += new string('+', count);

                
            }
            else
            {
                var count = totalAsciiChara+ targetCount - currentChara;
                resultText += new string('+', count);
            }
            currentChara = targetCount;

            resultText += ".";
        }


        Console.WriteLine(resultText);
    }
}