using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace FallingRocks
{
    struct Element
    {
        public int coordX;
        public int coordY;
        public char symbol;
        public ConsoleColor color;
    }

    
    class FallingRocks
    {
        static void PrintOnPosition(int coordX, int coordY, char symbol, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.CursorVisible = false; // stops cursor flickering
            
            Console.SetCursorPosition(coordX, coordY);
            Console.ForegroundColor = color;
            Console.Write(symbol);
        }


        static void PrintStringOnPosition(int coordX, int coordY, string str, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.CursorVisible = false; // stops cursor flickering
            
            
            Console.SetCursorPosition(coordX, coordY);
            Console.ForegroundColor = color;
            Console.Write(str);
        }

        

        private static void DrawInformation(int livesCount, int score, int speed)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            PrintStringOnPosition(39, 10, "Lives: " + livesCount, ConsoleColor.Blue);
            PrintStringOnPosition(39, 16, "Speed: " + speed / 20, ConsoleColor.Blue);
            PrintStringOnPosition(39, 20, "Score: " + score, ConsoleColor.Blue);
        }

        private static int GameSpeed(int speed)
        {
            if (speed < 100)
            {
                speed++;
            }
            Thread.Sleep(5);
            return speed;
        }

        private static List<Element> MoveRocks(ref int livesCount, ref int score, ref Element dwarf, List<Element> rocks, ref bool hitted)
        {
            Thread.Sleep(100);
            List<Element> newList = new List<Element>();

            for (int i = 0; i < rocks.Count; i++)
            {
                Element oldRock = rocks[i];
                Element newRock = new Element();
                newRock.coordX = oldRock.coordX;
                newRock.coordY = oldRock.coordY + 1;
                newRock.symbol = oldRock.symbol;
                newRock.color = oldRock.color;

                // Check if rocks are hitting dwarf
                if (((newRock.coordY == dwarf.coordY) && (newRock.coordX == (dwarf.coordX - 1))) || // left side
                    ((newRock.coordY == dwarf.coordY) && (newRock.coordX == dwarf.coordX)) ||       // right side
                    ((newRock.coordY == dwarf.coordY) && (newRock.coordX == (dwarf.coordX + 1)) ||  // body
                    ((newRock.coordY == dwarf.coordY - 1) && (newRock.coordX == (dwarf.coordX)))))  // nose
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    livesCount--;
                    hitted = true;
                    
                }

                if (newRock.coordY < Console.WindowHeight)
                {
                    newList.Add(newRock);
                }
                else
                {
                    score++;
                }

            }
            return newList;
        }

        private static Element MoveStarShip(int playfieldWidth, int playfieldHight, Element dwarf)
        {
            
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (dwarf.coordX == 3) // left most position considering the engine fire
                    {
                        dwarf.coordX = 3;
                    }
                    else if (dwarf.coordX - 1 >= 1)
                    {
                        dwarf.coordX = dwarf.coordX - 2; // Optimum movement speed is by this value
                    }
                    char RightEngineFire = Encoding.GetEncoding(437).GetChars(new byte[] { 61 })[0];
                    PrintOnPosition(dwarf.coordX + 4, dwarf.coordY, RightEngineFire, Console.ForegroundColor = ConsoleColor.Red);
                    Console.Beep(700, 50);
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (dwarf.coordX + 1 < playfieldWidth - 1) // right most position considering the engine fire
                    {
                        dwarf.coordX = dwarf.coordX + 2;
                    }
                    char LeftEngineFire = Encoding.GetEncoding(437).GetChars(new byte[] { 61 })[0];
                    PrintOnPosition(dwarf.coordX - 4, dwarf.coordY, LeftEngineFire, Console.ForegroundColor = ConsoleColor.Red);
                    Console.Beep(700, 50);
                }
                else if ((pressedKey.Key == ConsoleKey.UpArrow)) 
                {
                    if (dwarf.coordY + 1 < playfieldHight - 1)
                    {
                        dwarf.coordY = dwarf.coordY - 1;
                    }
                    if (dwarf.coordY == 1 || dwarf.coordY == 0) // up most position considering the engine fire
                    {
                        dwarf.coordY = 1;
                    }
                    
                    char BackEngineFire = Encoding.GetEncoding(437).GetChars(new byte[] { 210 })[0];
                    PrintOnPosition(dwarf.coordX - 1, dwarf.coordY + 2, BackEngineFire, Console.ForegroundColor = ConsoleColor.Red);
                    PrintOnPosition(dwarf.coordX + 1, dwarf.coordY + 2, BackEngineFire, Console.ForegroundColor = ConsoleColor.Red);
                    Console.Beep(700, 50);
                }
                if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    if (dwarf.coordY == 28) // down most position considering the engine fire
                    {
                        dwarf.coordY = 28;
                    }
                    else if (dwarf.coordY - 1 >= 1)
                    {
                        dwarf.coordY = dwarf.coordY + 1; // Optimum movement speed is by this value
                    }
                    char FrontEngineFire = Encoding.GetEncoding(437).GetChars(new byte[] { 248 })[0];
                    PrintOnPosition(dwarf.coordX - 1, dwarf.coordY - 2, FrontEngineFire, Console.ForegroundColor = ConsoleColor.Red);
                    PrintOnPosition(dwarf.coordX + 1, dwarf.coordY - 2, FrontEngineFire, Console.ForegroundColor = ConsoleColor.Red);
                    Console.Beep(700, 50);
                }
            }
            return dwarf;
        }

        private static void GeneratingRocks(int playfieldWidth, Random randomGenerator, List<Element> rocks)
        {
            Element newRock = new Element();
            char Rock1 = Encoding.GetEncoding(437).GetChars(new byte[] { 219 })[0];
            char Rock2 = Encoding.GetEncoding(437).GetChars(new byte[] { 249 })[0];
            char Rock3 = Encoding.GetEncoding(437).GetChars(new byte[] { 223 })[0];
            char Rock4 = Encoding.GetEncoding(437).GetChars(new byte[] { 004 })[0];
            char[] symbol = new char[] { Rock1, Rock2, Rock3, Rock4 };
            int i = randomGenerator.Next(0, symbol.Length);
            int assist = randomGenerator.Next(0, 100);
            int rockLength;
            if (assist < 70)
            {
                rockLength = 1;
            }
            else if (assist < 95)
            {
                rockLength = 2;
            }
            else
            {
                rockLength = 3;
            }

            newRock.coordX = randomGenerator.Next(0, playfieldWidth);
            newRock.color = (ConsoleColor)randomGenerator.Next(9, 15);
            newRock.coordY = 0;
            newRock.symbol = symbol[i];

            for (int j = 0; j < rockLength; j++)
            {
                newRock.coordX = newRock.coordX + 2;
                if (newRock.coordX < playfieldWidth)
                {
                    rocks.Add(newRock);
                }

            }
        }

        static void Main()
        {

            Console.CursorVisible = false; // stops cursor flickering
            int playfieldWidth = 35;
            int playfieldHight = 45;
            int livesCount = 3;             // adjust available lives
            int score = 0;
            int speed = 0;
            Console.BufferHeight = Console.WindowHeight = 30;
            Console.BufferWidth = Console.WindowWidth = 50;
            Element dwarf = new Element();
            dwarf.coordX = 13;
            dwarf.coordY = Console.WindowHeight - 2;
            char Body = Encoding.GetEncoding(437).GetChars(new byte[] { 223 })[0];
            dwarf.symbol = Body;
            dwarf.color = ConsoleColor.White;
            Random randomGenerator = new Random();
            List<Element> rocks = new List<Element>();
            DisplayIntroInfo();

            while (true)
            {
                bool hitted = false;


                GeneratingRocks(playfieldWidth, randomGenerator, rocks);


                dwarf = MoveStarShip(playfieldWidth, playfieldHight, dwarf);


                List<Element> newList = MoveRocks(ref livesCount, ref score, ref dwarf, rocks, ref hitted);

                rocks = newList;

                // Clear the console
                Console.Clear();


                
                foreach (Element rock in rocks)
                {
                    PrintOnPosition(rock.coordX, rock.coordY, rock.symbol, rock.color);
                }

                if (hitted)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    char Destroyed = Encoding.GetEncoding(437).GetChars(new byte[] { 176 })[0];
                    PrintOnPosition(dwarf.coordX, dwarf.coordY, Destroyed, ConsoleColor.Red);
                    PrintOnPosition(dwarf.coordX - 1, dwarf.coordY, Destroyed, ConsoleColor.Red);
                    PrintOnPosition(dwarf.coordX + 1, dwarf.coordY, Destroyed, ConsoleColor.Red);
                    rocks.Clear();
                    PrintStringOnPosition(36, 3, "Press [Enter]", ConsoleColor.Green);
                    PrintStringOnPosition(36, 5, "to continue", ConsoleColor.Green);
                    PrintStringOnPosition(36, 16, "Your current ", ConsoleColor.Green);
                    PrintStringOnPosition(36, 17, "score is : " + score, ConsoleColor.Green);
                    speed = 0;
                    Console.Beep(400, 1000);
                    Console.ReadLine();
                    dwarf.coordX = 13;
                    dwarf.coordY = Console.WindowHeight - 2;
                }
                else
                {
                    // drawing the starship
                    PrintOnPosition(dwarf.coordX, dwarf.coordY, dwarf.symbol, dwarf.color);
                    char topSide = Encoding.GetEncoding(437).GetChars(new byte[] { 30 })[0];
                    PrintOnPosition(dwarf.coordX, dwarf.coordY - 1, topSide, dwarf.color);
                    char leftSide = Encoding.GetEncoding(437).GetChars(new byte[] { 222 })[0];
                    PrintOnPosition(dwarf.coordX - 1, dwarf.coordY, leftSide, Console.ForegroundColor = ConsoleColor.Green);
                    char rightSide = Encoding.GetEncoding(437).GetChars(new byte[] { 221 })[0];
                    PrintOnPosition(dwarf.coordX + 1, dwarf.coordY, rightSide, Console.ForegroundColor = ConsoleColor.Green);
                }

                if (livesCount <= 0) // Draw Game Over
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;
                    PrintStringOnPosition(17, 8, "GAME OVER !!!", ConsoleColor.Red);
                    PrintStringOnPosition(15, 16, "Your score is : " + score, ConsoleColor.Red);
                    PrintStringOnPosition(14, 24, "Press any key to exit", ConsoleColor.Red);
                    Console.WriteLine();
                    return;

                }
                
                DrawInformation(livesCount, score, speed);

                speed = GameSpeed(speed);
            }
        }

        private static void DisplayIntroInfo() // + Bonus simple animation
        {

            PrintStringOnPosition(14, 9, "Wellcome to Falling Rocks!", ConsoleColor.White);
            PrintStringOnPosition(14, 10, "Please, use the arrow keys", ConsoleColor.White);
            PrintStringOnPosition(14, 11, "to navigate your star ship.", ConsoleColor.White);
            Console.WriteLine();
            PrintStringOnPosition(14, 13, "Press [ENTER] when you", ConsoleColor.White);
            PrintStringOnPosition(14, 14, "are ready to start.", ConsoleColor.White);

            Console.ReadLine();

            for (int i = 1; i < 30; i++)
            {
                Thread.Sleep(2);
                char BackGround = Encoding.GetEncoding(437).GetChars(new byte[] { 219 })[0];
                if (i == 2)
                {
                    Console.MoveBufferArea(0, 0, 50, 1, 0, i-1, BackGround, ConsoleColor.DarkBlue, ConsoleColor.DarkBlue);
                
                }
                Console.MoveBufferArea(0, 0, 50, 1, 0, i, BackGround, ConsoleColor.DarkBlue, ConsoleColor.DarkBlue);
                Console.Beep((i + 5) * 100, 100);

            }
        }
    }
}
