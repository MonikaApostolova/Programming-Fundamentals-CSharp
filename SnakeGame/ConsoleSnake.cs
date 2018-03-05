using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class ConsoleSnake
{
    private static int points;
    private static int applesCount;
    private static double speed;
    private static int bigApplesCount;

    static void Main()
    {
        Console.BufferHeight = Console.WindowHeight;
        Console.CursorVisible = false;
        

        //start timer
        int timer = 0;
        int smallAppDissTime = 8000;
        int bigAppDissTime = 5000;

        Random generator = new Random();
        Random obstacleGenerator = new Random();
        
        Coordinate right = new Coordinate(0, 1);
        Coordinate left = new Coordinate(0, -1);
        Coordinate up = new Coordinate(-1, 0);
        Coordinate down = new Coordinate(1, 0);

        //get samll apple coordinates
        Coordinate smallAppPos = new Coordinate(generator.Next(0, Console.WindowHeight), generator.Next(0, Console.WindowWidth));

        //get big apple coordinates
        Coordinate bigAppPos = new Coordinate(generator.Next(0, Console.WindowHeight), generator.Next(0, Console.WindowWidth));

        Coordinate direction = right;

        Queue<Coordinate> snake = new Queue<Coordinate>();

        //set snake size
        for (int i = 0; i < 5; i++)
        {
            snake.Enqueue(new Coordinate(0, i));
        }

        //draw snake start
        foreach (var coordinate in snake)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(">");
        }        

        //generate obstacles
        List<Coordinate> obstacles = new List<Coordinate>();

        for (int i = 0; i < 40; i++)
        {
            Coordinate currObstacle = new Coordinate(obstacleGenerator.Next(0, Console.WindowHeight)
                , obstacleGenerator.Next(0, Console.WindowWidth));

            while (obstacles.Contains(currObstacle) || snake.Contains(currObstacle) || smallAppPos.Equals(currObstacle) 
                   || bigAppPos.Equals(currObstacle))
            {
                currObstacle = new Coordinate(obstacleGenerator.Next(0, Console.WindowHeight)
                    , obstacleGenerator.Next(0, Console.WindowWidth));
            }

            obstacles.Add(currObstacle); 
            Console.SetCursorPosition(currObstacle.Y, currObstacle.X);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|");
        }

        //sleep
        Thread.Sleep(2000);


        while (true)
        {

            // read key
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.UpArrow && !direction.Equals(down))
                {
                    direction = up;
                }

                if (keyPressed.Key == ConsoleKey.DownArrow && !direction.Equals(up))
                {
                    direction = down;
                }

                if (keyPressed.Key == ConsoleKey.LeftArrow && !direction.Equals(right))
                {
                    direction = left;
                }

                if (keyPressed.Key == ConsoleKey.RightArrow && !direction.Equals(left))
                {
                    direction = right;
                }
            }

            

            //move snake
            Coordinate prevPoss = snake.Dequeue();
            Console.SetCursorPosition(prevPoss.Y, prevPoss.X);
            Console.Write(" ");

            Coordinate currHeadPoss = snake.Last();
            Coordinate newHeadPoss = new Coordinate(currHeadPoss.X + direction.X, currHeadPoss.Y + direction.Y);

            // goes off board
            if (newHeadPoss.X < 0)
            {
                newHeadPoss.X = Console.WindowHeight - 1;
            }

            if (newHeadPoss.X >= Console.WindowHeight)
            {
                newHeadPoss.X = 0;
            }

            if (newHeadPoss.Y < 0)
            {
                newHeadPoss.Y = Console.WindowWidth - 1;
            }

            if (newHeadPoss.Y >= Console.WindowWidth)
            {
                newHeadPoss.Y = 0;
            }

            //snake dies
            if (snake.Contains(newHeadPoss))
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("GAME OVER!");
                Console.WriteLine($"Your points are: {points}");
                Console.WriteLine($"Small apples eaten: {applesCount}");
                Console.WriteLine($"Big apples eaten: {bigApplesCount}");
                return;
            }

            if (obstacles.Contains(newHeadPoss))
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("GAME OVER!");
                Console.WriteLine($"Your points are: {points}");
                Console.WriteLine($"Small apples eaten: {applesCount}");
                Console.WriteLine($"Big apples eaten: {bigApplesCount}");
                return;
            }

            snake.Enqueue(newHeadPoss);

            
            Console.SetCursorPosition(newHeadPoss.Y, newHeadPoss.X);
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            if (direction.Equals(left))
            {
                Console.Write("<");
            }

            if (direction.Equals(right))
            {
                Console.Write(">");
            }

            if (direction.Equals(up))
            {
                Console.Write("^");
            }

            if (direction.Equals(down))
            {
                Console.Write("v");
            }

            //draw small apple           
            Console.SetCursorPosition(smallAppPos.Y, smallAppPos.X);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("a");

            //draw big apple
            if (Environment.TickCount - timer >= bigAppDissTime)
            {
                while (obstacles.Contains(bigAppPos))
                {
                    bigAppPos = new Coordinate(generator.Next(0, Console.WindowHeight), generator.Next(0, Console.WindowWidth));
                }
                Console.SetCursorPosition(bigAppPos.Y, bigAppPos.X);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("A");
            }
            
            //eat samll apple
            if (snake.Contains(smallAppPos))
            {
                //update time
                timer = Environment.TickCount;

                points += 100;
                Console.SetCursorPosition(smallAppPos.Y, smallAppPos.X);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("O");

                smallAppPos = new Coordinate(generator.Next(0, Console.WindowHeight), generator.Next(0, Console.WindowWidth));

                while (obstacles.Contains(smallAppPos))
                {
                    smallAppPos = new Coordinate(generator.Next(0, Console.WindowHeight), generator.Next(0, Console.WindowWidth));
                }
                
                snake.Enqueue(newHeadPoss);
                applesCount++;
                speed += 0.5;
            }

            //eat big apple
            if (snake.Contains(bigAppPos))
            {
                //update time
                timer = Environment.TickCount;

                points += 200;
                Console.SetCursorPosition(bigAppPos.Y, bigAppPos.X);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("O");

                bigAppPos = new Coordinate(generator.Next(0, Console.WindowHeight), generator.Next(0, Console.WindowWidth));

                while (obstacles.Contains(smallAppPos))
                {
                    bigAppPos = new Coordinate(generator.Next(0, Console.WindowHeight), generator.Next(0, Console.WindowWidth));
                }

                snake.Enqueue(newHeadPoss);
                bigApplesCount++;
                speed += 0.5;
            }

            speed += 0.01;

            Thread.Sleep((int)(100 - speed));
        }
    }
}

struct Coordinate
{
    public int X;

    public int Y;

    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool Equals(Coordinate other)
    {
        if (other.Y == Y && other.X == X)
        {
            return true;
        }

        return false;
    }
}
