// For checking values - http://ostermiller.org/calc/triangle.html

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.TriangleSurface
{
    class TriangleSurface
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture; // The '.' is recognised as a mathematical character from the console
            Console.ForegroundColor = ConsoleColor.White;
            
            byte Choice = InputChoice();

            switch (Choice)
            {
                case 1:
                    PrintResult(CalculateBySideAltitude(InputSideAltitude())); // First to input the values, than calculate the result and print it
                    break;
                case 2:
                    PrintResult(CalculaeByThreeSides(InputSideAltitude()));  // First to input the values, than calculate the result and print it
                    break;
                case 3:
                    PrintResult(CalculaeByThreeSides(CalculateAltitudeBySideAngleSide())); // First to input the values, than calculate the third side and finally calculate the result and print it
                    break;
                default:
                    break;
            }
        }

        public static double[] CalculateAltitudeBySideAngleSide() // Clarification -  http://www.mathsisfun.com/algebra/trig-solving-sas-triangles.html
        {
            Console.WriteLine("Please, enter a value for the two sides and the angle: ");
            Console.Write("First side: ");
            double Side1 = double.Parse(Console.ReadLine());
            Console.Write("Second side: ");
            double Side2 = double.Parse(Console.ReadLine());
            Console.Write("Angle in degrees: ");
            double Angle = double.Parse(Console.ReadLine()) * Math.PI / 180; // Math.Cos calculates the angle in radians and convertion from degrees is needed - http://social.msdn.microsoft.com/Forums/vstudio/en-US/c14fd846-19b9-4e8a-ba6c-0b885b424439/is-c-working-with-degrees-or-radians
            double Side3 = Math.Sqrt(Side1 * Side1 + Side2 * Side2 - 2 * Side1 * Side2 * Math.Cos(Angle)); 
            double[] AllSides = { Side1, Side2, Side3 };
            return AllSides;
        }

        public static double CalculaeByThreeSides(double[] ThreeSides) // Clarification - http://www.mathopenref.com/heronsformula.html
        {

            double Side1 = ThreeSides[0];
            double Side2 = ThreeSides[1];
            double Side3 = ThreeSides[2];
            
            double HalfPerimeter = (Side1 + Side2 + Side3) / 2;
            double Surface = Math.Sqrt(HalfPerimeter * (HalfPerimeter - Side1) * (HalfPerimeter - Side2) * (HalfPerimeter - Side3));
            return Surface;
        }

        public static double[] InputThreeSides()
        {
            double[] ThreeSides = new double[2];
            Console.WriteLine("Please, enter a value for the three sides: ");
            Console.Write("First side: ");
            ThreeSides[0] = double.Parse(Console.ReadLine());
            Console.Write("Second side: ");
            ThreeSides[1] = double.Parse(Console.ReadLine());
            Console.Write("Third side: ");
            ThreeSides[2] = double.Parse(Console.ReadLine());
            return ThreeSides;
        }

        public static double CalculateBySideAltitude(double[] SideAltitude) 
        {
            double Side = SideAltitude[0];
            double Altitude = SideAltitude[1];
            double Surface = Side * Altitude / 2;
            return Surface;
        }

        private static double[] InputSideAltitude()
        {
            Console.Write("Please, enter a value for side: ");
            double[] SideAltitude = new double[1];
            SideAltitude[0] = double.Parse(Console.ReadLine());
            Console.Write("Please, enter a value for altitude: ");
            SideAltitude[1] = double.Parse(Console.ReadLine());
            return SideAltitude;
        }

        private static void PrintResult(double Surface)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe surface value is {0:0.00}\n", Surface);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static byte InputChoice()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Please, select how you would like to calculate the triangle's surface:");
            Console.WriteLine("1 for given side and an altitude");
            Console.WriteLine("2 for given three sides");
            Console.WriteLine("3 for given two sides and an angle between them.");
            Console.Write("\nYour choice is: ");
            byte Choice = byte.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            return Choice;
        }
    }
}
