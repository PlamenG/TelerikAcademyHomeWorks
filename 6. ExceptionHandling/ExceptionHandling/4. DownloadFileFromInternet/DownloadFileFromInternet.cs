// Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) 
// and stores it the current directory. Find in Google how to download files in C#. Be sure to catch 
// all exceptions and to free any used resources in the finally block.


using System;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Threading;

class DownloadFileFromInternet
{
    
    
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Enter the full download url: "); //Ask for the url of the file to download
        string url = Console.ReadLine(); //Store it in the url string
        string fileName = Path.GetFileName(url); //extract the file name

        using (WebClient client = new WebClient())//Open a web client
        {
            try
            {
                string Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                
                client.DownloadFile(url, fileName);//Use the web client with our url and file name
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The file has been downloaded!");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Do you want to open the file (y/n): ");
                Console.ForegroundColor = ConsoleColor.White;
                string answer = Console.ReadLine();
                if (answer == "y")
                    Process.Start(fileName); // the file will be opened

            }
            catch (ArgumentNullException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please provide a url address!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (WebException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An error occurred while trying to download the file! Make sure the url is valid, the file you want to download exists and the internet connection is running!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (NotSupportedException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The DownloadFile method cannot be called simultaneously on multiple threads.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            
        }
    }
}