using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Save the Planet.
 * Use less Fossil Fuel.
 **/
class Player
{
    static void Main(string[] args)
    {
        int flatAreaXStart = 0;
        int flatAreaXEnd = 0;
        int flatAreaY = 0;

        int xbefore = -1;
        int xafter = -1;
        int ybefore = -1;
        int yafter = -1;

        string[] inputs;
        int N = int.Parse(Console.ReadLine()); // the number of points used to draw the surface of Mars.
        for (int i = 0; i < N; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int landX = int.Parse(inputs[0]); // X coordinate of a surface point. (0 to 6999)
            int landY = int.Parse(inputs[1]); // Y coordinate of a surface point. By linking all the points together in a sequential fashion, you form the surface of Mars.

            xbefore = xafter;
            ybefore = yafter;
            xafter = landX;
            yafter = landY;

            if (ybefore == yafter)
            {
                if (xafter - xbefore >= 1000)
                {
                    flatAreaXStart = xbefore;
                    flatAreaXEnd = xafter;
                    flatAreaY = yafter;
                }

            }

        }

        var loopCount = 0;
        var startPositionX = 0;
        var halfPositionX = 0;

        var landingSpaceX = flatAreaXEnd - flatAreaXStart;

        var breakePositionY = 0;

        var processCount = 0;
        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int X = int.Parse(inputs[0]);
            int Y = int.Parse(inputs[1]);
            int HS = int.Parse(inputs[2]); // the horizontal speed (in m/s), can be negative.
            int VS = int.Parse(inputs[3]); // the vertical speed (in m/s), can be negative.
            int F = int.Parse(inputs[4]); // the quantity of remaining fuel in liters.
            int R = int.Parse(inputs[5]); // the rotation angle in degrees (-90 to 90).
            int P = int.Parse(inputs[6]); // the thrust power (0 to 4).

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            int xRemain = (flatAreaXEnd + flatAreaXStart) / 2 - X;
            int yRemain = flatAreaY - Y;

            Console.Error.WriteLine(flatAreaXStart + " " + flatAreaXEnd + " " + flatAreaY + " " + xRemain + " " + yRemain);

            loopCount += 1;
            if (loopCount == 1)
            {
                startPositionX = X;
                halfPositionX = (xRemain / 2) + X;

                if (Math.Abs(HS) >= 45)
                {
                    processCount = 1;
                }
            }

            Console.Error.WriteLine($"{loopCount}    {processCount}");

            var power = 4;



            if (processCount == 0) //kasoku
            {
                if (X < halfPositionX)
                {
                    R = SubtractSpeed(R);
                    if (HS > 30)
                    {
                        processCount += 1;
                    }
                }
                else if (halfPositionX < X)
                {
                    R = AddSpeed(R);
                    if (HS < -30)
                    {
                        processCount += 1;
                    }
                }
            }
            else if (processCount == 1) //suihei ikou
            {
                R = ZeroSpeed(R);
                if (R == 0)
                {
                    processCount += 1;
                }
            }
            else if (processCount == 2) //suihei idou + breake
            {
                if ((VS > 0)&&(Y+150>flatAreaY))
                {
                    power = 0;
                }
                if (Math.Abs(xRemain) < (HS * HS) / 2 / 2)
                {
                    if (HS > 0)
                    {
                        R = AddSpeed(R);
                    }
                    else
                    {
                        R = SubtractSpeed(R);
                    }
                }
                if (Math.Abs(HS) < 3)
                {
                    processCount += 1;

                    if (X <= flatAreaXStart || flatAreaXEnd <= X)
                    {
                        processCount = 0;
                    }
                }
            }
            else if (processCount == 3) //suihei ikou
            {
                R = ZeroSpeed(R);
                power = 0;

                if (R == 0)
                {
                    processCount += 1;

                    breakePositionY = (Y - flatAreaY) * 9 / 10 + flatAreaY;
                }
            }
            else if (processCount == 4)
            {
                if (Y < breakePositionY)
                {

                }
                else
                {
                    power = 0;
                }
            }

            // R P. R is the desired rotation angle. P is the desired thrust power.
            Console.WriteLine(R + " " + power);
        }
    }

    public static int AddSpeed(int current)
    {
        var R = current + 15;
        if (R > 30)
        {
            R = 30;
        }
        return R;
    }

    public static int SubtractSpeed(int current)
    {
        var R = current - 15;
        if (R < -30)
        {
            R = -30;
        }
        return R;
    }

    public static int ZeroSpeed(int current)
    {
        var R = (current < -15) ? (current + 15)
            : (current > 15) ? (current - 15)
            : 0;

        return R;
    }

}