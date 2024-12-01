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
        string magicPhrase = Console.ReadLine();

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        var asciiDictionary = new Dictionary<string, int>() {
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

        var existDictionary = new Dictionary<string, int>();

        var totalStone = 30;
        var totalAsciiChara = 27;
        var currentChara = 0;

        var resultText = "";

        var asciiCountDictionary = new Dictionary<string, int>();

        foreach (var ascii in magicPhrase)
        {
            if (!asciiCountDictionary.ContainsKey(ascii.ToString()))
            {
                asciiCountDictionary.Add(ascii.ToString(), 0);
            }
            asciiCountDictionary[ascii.ToString()] += 1;
        }

        var asciiPositionDictyonary = new Dictionary<string, int>();


        var wordCountDictionary = new Dictionary<string, int>();

        foreach (var word in magicPhrase.Split(" "))
        {
            if (!wordCountDictionary.ContainsKey(word))
            {
                wordCountDictionary.Add(word, 0);
            }
            wordCountDictionary[word] += 1;
        }

        asciiPositionDictyonary.Add(" ", 0);
        foreach (var word in wordCountDictionary.OrderByDescending(x => x.Value))
        {
            Console.Error.WriteLine($"{word.Key} {word.Value}");
            foreach (var ascii in word.Key)
            {
                if (!asciiPositionDictyonary.ContainsKey(ascii.ToString()))
                {
                    asciiPositionDictyonary.Add(ascii.ToString(), asciiPositionDictyonary.Count());
                }
            }
        }





        existDictionary.Add(" ", 0);
        existDictionary.Add("A", 26);
        existDictionary.Add("B", 25);
        existDictionary.Add("C", 24);
        existDictionary.Add("D", 23);
        existDictionary.Add("E", 22);
        existDictionary.Add("F", 21);
        existDictionary.Add("G", 20);
        existDictionary.Add("H", 19);
        existDictionary.Add("I", 18);
        existDictionary.Add("J", 17);
        existDictionary.Add("K", 16);
        existDictionary.Add("L", 15);
        existDictionary.Add("M", 14);
        existDictionary.Add("N", 13);
        existDictionary.Add("O", 12);
        existDictionary.Add("P", 11);
        existDictionary.Add("Q", 10);
        existDictionary.Add("R", 9);
        existDictionary.Add("S", 8);
        existDictionary.Add("T", 7);
        existDictionary.Add("U", 6);
        existDictionary.Add("V", 5);
        existDictionary.Add("W", 4);
        existDictionary.Add("X", 3);
        existDictionary.Add("Y", 2);
        existDictionary.Add("Z", 1);
        resultText += "+[>[+>]+<[<]>+]";
        currentChara = 0;

        foreach (var ascii in magicPhrase)
        {
            var targetCount = 0;

            if (!existDictionary.ContainsKey(ascii.ToString()))
            {
                existDictionary.Add(ascii.ToString(), existDictionary.Count());
                //existDictionary.Add(ascii.ToString(), asciiPositionDictyonary[ascii.ToString()]);
                targetCount = existDictionary[ascii.ToString()];

                resultText += GetMoveCode(currentChara, targetCount, asciiPositionDictyonary.Count(), existDictionary.Count(),true);

                currentChara = targetCount;
                if (asciiDictionary[ascii.ToString()] <= 13)
                {
                    resultText += new string('+', asciiDictionary[ascii.ToString()]);
                }
                else
                {
                    resultText += new string('-', 27 - asciiDictionary[ascii.ToString()]);
                }
            }

            targetCount = existDictionary[ascii.ToString()];



            resultText += GetMoveCode(currentChara, targetCount, asciiPositionDictyonary.Count(), existDictionary.Count(),false);


            currentChara = targetCount;


            resultText += ".";

            if (currentChara == 0)
            {
                resultText += ">";
                currentChara = 1;
            }
        }


        Console.WriteLine(resultText);
    }

    public static string GetMoveCode(int current, int target, int allCharaCount, int existCharaCount, bool isNewChara)
    {
        var bbb = (target >= current) ? (target - current) : (current - target);

        var resultText = "";

        //if (allCharaCount == existCharaCount)
        if (isNewChara)
        {
            resultText += "[>]";
            return resultText;
        }

        if ((target <= 2) && (bbb > 6))
        {
            resultText += "[<]" + new string('>', target);
            return resultText;
        }

        if (bbb <= 15)
        {
            if (target > current)
            {
                var count = target - current;
                resultText += new string('>', bbb);
            }
            else
            {
                var count = -(target - current);
                resultText += new string('<', bbb);
            }


        }
        else
        {
            if (target > current)
            {
                var count = 30 - bbb;
                resultText += new string('<', count);
            }
            else
            {
                var count = 30 - bbb;
                resultText += new string('>', count);
            }
        }

        return resultText;
    }
}