using System;

namespace ConsoleApp1
{
    public class TestArgs
    {
        public static bool TestValid(string[] args)
        {
            if (args.Length > 0)
            {
                switch (args.Length)
                {
                    case 1:
                        Console.WriteLine(
                            "\nToo few arguments,\nTo watch files inside of a folder of your choice, execute the program using this format:\nFileWatcher.exe [folder path] [file to watch] ");
                        return false;

                    case 2:
                        Console.WriteLine($"\nYour arguments are:\n{args[0]} and {args[1]}");
                        return true;

                    default:
                        Console.WriteLine(
                            "\nToo many arguments.\nTo watch files inside of a folder of your choice, execute the program using this format:\nFileWatcher.exe [folder path] [file to watch] ");
                        return false;

                }
            }
            else
            {
                Console.WriteLine("\nTo watch files inside of a folder of your choice, execute the program using this format:\nFileWatcher.exe [folder path] [file to watch] ");
                return false;
            }

        }
    }
}