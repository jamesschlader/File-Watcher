using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace ConsoleApp1
{
    public class Status
    {

        public static string[] GetInputs()
        {

            Console.WriteLine("\n\t\tNo worries. Try again.\n\t\tEnter a directory:");
            var inputDirectory = Console.ReadLine();

            Console.WriteLine("\n\t\tEnter a file name or file pattern:");
            var inputFile = Console.ReadLine();

            var inputs = string.Join(",", inputDirectory, inputFile);

            Console.WriteLine($"\n\t\tInputs are: {inputs}");

            return inputs.Split(',');

        }

        public static void ReportInitialStatus(string[] args, string guessPath)
        {
            var files = new DirectoryInfo(guessPath).GetFiles(args[1]);

            var output1 = new StringBuilder();
            output1
                .Append($"\n\t\tDirectory {guessPath} \n\t\tEXISTS.")
                .Append($"\n\t\tThe file type to search for is: {args[1]}")
                .Append($"\n\t\tWatching all {Path.GetExtension(args[1])} files on the path {guessPath}")
                .Append($"\n\t\tThere are {files.Length} {Path.GetExtension(args[1])} files at {guessPath}:");

            Console.WriteLine(output1);

            foreach (var file in files)
            {
                var output2 = new StringBuilder();
                output2.Append($"\n\t\t{file.Name} is an {file.Attributes} file")
                    .Append($" and its length is: {file.Length} bytes.")
                    .Append($"\n\t\tThe full path for {file.Name} is {Path.GetDirectoryName($"{guessPath}")}\\{file.Name}")
                    .Append($"\n\t\tThe last access time of {file.Name} is: {file.LastAccessTime}")
                    .Append($" but was last modified {file.LastWriteTime}.");

                Console.WriteLine(output2);
            }
        }
    }
}