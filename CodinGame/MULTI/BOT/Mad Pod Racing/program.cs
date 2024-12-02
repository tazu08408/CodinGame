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
        string[] inputs;

        bool isUseBoost = false;
        bool useBoost = false;

        var targetStepDictionary=new Dictionary<string, int>();
        var targetPositionDictionary = new Dictionary<int,string>();

        var currentTargetPositionX = 0;

        var isUseNextPosition = false;

        var isUseNestPositionCheck = false;

        var nextTargetFullLength = 0;
        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int x = int.Parse(inputs[0]);
            int y = int.Parse(inputs[1]);
            int nextCheckpointX = int.Parse(inputs[2]); // x position of the next check point
            int nextCheckpointY = int.Parse(inputs[3]); // y position of the next check point
            int nextCheckpointDist = int.Parse(inputs[4]); // distance to the next checkpoint
            int nextCheckpointAngle = int.Parse(inputs[5]); // angle between your pod orientation and the direction of the next checkpoint
            inputs = Console.ReadLine().Split(' ');
            int opponentX = int.Parse(inputs[0]);
            int opponentY = int.Parse(inputs[1]);

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");


            // You have to output the target position
            // followed by the power (0 <= thrust <= 100) or "BOOST"
            // i.e.: "x y thrust"


            Console.Error.WriteLine($"{x} {y} {nextCheckpointX} {nextCheckpointY} {nextCheckpointAngle} {nextCheckpointDist}");

            if (currentTargetPositionX != nextCheckpointX)
            {
                nextTargetFullLength = nextCheckpointDist;
                if (nextCheckpointDist > 3000)
                {
                    isUseNestPositionCheck = true;
                }
                else
                {
                    isUseNestPositionCheck = false;
                }


                if (!targetStepDictionary.ContainsKey($"{nextCheckpointX}-{nextCheckpointY}"))
                {
                    targetStepDictionary.Add($"{nextCheckpointX}-{nextCheckpointY}", targetStepDictionary.Count);
                    targetPositionDictionary.Add(targetPositionDictionary.Count, $"{nextCheckpointX}-{nextCheckpointY}");
                }
                else
                {
                    isUseNextPosition = true;
                }

                currentTargetPositionX = nextCheckpointX;
            }



            var targetX = nextCheckpointX;
            var targetY = nextCheckpointY;

            var power = 100;

            if (nextCheckpointDist < 2000)
            {
                power = 40;

                if (isUseNextPosition)
                {
                    power = 100;
                }
            }
            
            if (Math.Abs(nextCheckpointAngle) > 90)
            {
                power = 0;
            }
            else if (Math.Abs(nextCheckpointAngle) > 45)
            {
                power = 50;
            }

            if (isUseNextPosition)
            {
                if (isUseNestPositionCheck)
                {
                    if (targetStepDictionary.ContainsKey($"{nextCheckpointX}-{nextCheckpointY}"))
                    {
                        if (nextTargetFullLength > 5000)
                        {
                            if (nextCheckpointDist < 2500)
                            {
                                var nextnextCheckPointNo = targetStepDictionary[$"{nextCheckpointX}-{nextCheckpointY}"] + 1;

                                if (!targetPositionDictionary.ContainsKey(nextnextCheckPointNo))
                                {
                                    nextnextCheckPointNo = 0;
                                }

                                var nextnextPosition = targetPositionDictionary[nextnextCheckPointNo].Split('-');
                                targetX = Convert.ToInt32(nextnextPosition[0]);
                                targetY = Convert.ToInt32(nextnextPosition[1]);

                                power = 100;
                            }
                        }
                        else
                        {
                            if (nextCheckpointDist < 1500)
                            {
                                var nextnextCheckPointNo = targetStepDictionary[$"{nextCheckpointX}-{nextCheckpointY}"] + 1;

                                if (!targetPositionDictionary.ContainsKey(nextnextCheckPointNo))
                                {
                                    nextnextCheckPointNo = 0;
                                }

                                var nextnextPosition = targetPositionDictionary[nextnextCheckPointNo].Split('-');
                                targetX = Convert.ToInt32(nextnextPosition[0]);
                                targetY = Convert.ToInt32(nextnextPosition[1]);

                                power = 100;
                            }
                        }
                    }
                }


                if (isUseBoost == false)
                {
                    if (nextCheckpointDist > 6500)
                    {
                        if (Math.Abs(nextCheckpointAngle) < 10)
                        {
                            useBoost = true;
                            isUseBoost = true;
                        }
                    }
                }
            }

            if (useBoost == false)
            {
                Console.WriteLine(targetX + " " + targetY + $" {power}");
            }
            else
            {
                Console.WriteLine(targetX + " " + targetY + $" BOOST");

                useBoost = false;
            }
        }
    }
}