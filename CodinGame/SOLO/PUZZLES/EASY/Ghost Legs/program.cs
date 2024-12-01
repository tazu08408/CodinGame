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
        string[] inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]);
        int H = int.Parse(inputs[1]);

        var startPosition=new Dictionary<string, int>();
        var currentPosition=new Dictionary<int,string>();
        var endPosition = new Dictionary<int ,string>();

        var lastPosition= new Dictionary<string, int>();

        var itemCount = 0;
        for (int i = 0; i < H; i++)
        {
            string line = Console.ReadLine();

            if (i == 0)
            {
                var datas = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                itemCount=datas.Length;

                foreach(var item in datas.Select((x,i)=>new { x, i }))
                {
                    startPosition.Add(item.x, item.i);
                    currentPosition.Add(item.i, item.x);
                }
            }
            else if (i == (H-1))
            {
                var datas = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in datas.Select((x, i) => new { x, i }))
                {
                    endPosition.Add(item.i, item.x);
                }

                foreach (var item in currentPosition)
                {
                    lastPosition.Add(item.Value,item.Key);
                }
            }
            else
            {
                for (var count = 0; count < itemCount-1; count++) {
                    var data = line.Substring(3 * count, 4);
                    if (data == "|--|")
                    {
                        var temp = currentPosition[count];
                        currentPosition[count] = currentPosition[count+1];
                        currentPosition[count+1]=temp;
                    }
                }
            }
        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        foreach(var start in startPosition)
        {
            Console.WriteLine($"{start.Key}{endPosition[lastPosition[start.Key]]}");
        }
    }
}