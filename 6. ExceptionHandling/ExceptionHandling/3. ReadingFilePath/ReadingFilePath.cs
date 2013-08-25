// Write a program that enters file name along with its full file path 
// (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console. 
// Find in MSDN how to use System.IO.File.ReadAllText(…). Be sure to catch 
// all possible exceptions and print user-friendly error messages

using System;
// this is mandatory:
using System.IO;
using System.Security;

namespace _3.ReadingFilePath
{
    class ReadingFilePath
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter the full path of the file you want to read: ");
            string filePath = Console.ReadLine();
            ReadFile(filePath);
        }

        static void ReadFile(string filePath)
        {
            try
            {
                string fileContent = File.ReadAllText(filePath);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nThe content of the file is: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(fileContent);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (DirectoryNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The path contains a directory that cannot be found!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (FileNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The file '{0}' was not found!", filePath);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (ArgumentNullException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No file path given!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (ArgumentException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The entered file path is not correct!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (PathTooLongException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The entered file path is too long - 248 characters are the maximum allowed!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (UnauthorizedAccessException uoae)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(uoae.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (SecurityException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You don't have the required permission to access this file!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (NotSupportedException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid file path format!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (IOException ioe)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ioe.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
