using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    class WatcherThread
    {
        public static void ThreadAction(object obj)
        {
            var myParams = new DelegateObject();
            myParams = (DelegateObject)obj;

            try
            {
                var nextNames = new List<string>();
                var nextLengths = new List<long>();
                var nextTimes = new List<DateTime>();
                var trips = 0;

                while (true)
                {
                    var files = new DirectoryInfo(myParams.guessPath).GetFiles(myParams.arguments[1]);

                    var names = new List<string>();
                    var lengths = new List<long>();
                    var times = new List<DateTime>();

                    foreach (var file in files)
                    {
                        names.Add(file.Name);
                        lengths.Add(file.Length);
                        times.Add(file.LastWriteTime);
                    }

                    if (trips > 0)
                    {
                        if (names.Count < nextNames.Count)
                        {
                            // Something was deleted. Find it.
                            Console.WriteLine($"\nWhoa! Something was deleted!");
                           
                            var deletedFile = new List<string>();

                            foreach (var name in nextNames)
                            {
                                if (!names.Contains(name))
                                {
                                    deletedFile.Add(name);
                                }
                            }

                            Console.WriteLine($"\nSome files were deleted. They are:\n");
                            foreach (var file in deletedFile)
                            {
                                Console.WriteLine($"{file}");
                            }
                            Console.WriteLine("\nType 'quit' to stop the program.");

                        } else if (names.Count > nextNames.Count)
                        {
                            // A file was added. Find it.
                            Console.WriteLine($"\nWhoa! Something was added!");

                            var addedFiles = new List<string>();
                          
                          foreach (var name in names)
                            {
                                if (!nextNames.Contains(name))
                                {
                                    addedFiles.Add(name);
                                }
                                
                            }

                            Console.WriteLine("\nThese files were added:\n");
                            foreach (var file in addedFiles)
                            {
                                Console.WriteLine($"{file} has {file.Length} bytes.");

                            }
                            Console.WriteLine("\nType 'quit' to stop the program.");
                        }
                        else
                        {
                            for (int i = 0; i < times.Count; i++)
                            {
                                if (!times[i].Equals(nextTimes[i]))
                                {
                                    if (lengths[i] - nextLengths[i] != 0)
                                    {
                                        // Some file was modified
                                        Console.WriteLine($"\nWhoa! A file was accessed!");
                                        Console.WriteLine($"File {files[i].Name} was changed. \nIt's old length was {nextLengths[i]} and its new length is {lengths[i]}. \nA difference of {lengths[i] - nextLengths[i]} bytes.");
                                        Console.WriteLine("\nType 'quit' to stop the program.");
                                    }
                                    else
                                    {
                                        // Some file was accessed but not modified.
                                        Console.WriteLine($"\nWhoa! A file was accessed!\nFile {files[i].Name} was accessed but no changes were made.");
                                        Console.WriteLine("\nType 'quit' to stop the program.");
                                    }
                                   
                                }
                            }
                        }
                    }

                    nextNames = names;
                    nextLengths = lengths;
                    nextTimes = times;
                    trips++;
                  
                    // Yield the rest of the time slice.
                    Thread.Sleep(10000);
                }

            }
            catch (ThreadAbortException abortException)
            {
                Console.WriteLine((string)abortException.ExceptionState);
            }
        }
    }
}
