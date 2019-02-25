using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    public class RunWatcher
    {
        public static void Watcher(string[] args)
        {
            if (TestArgs.TestValid(args))
            {
                var guessPath = Path.GetFullPath($"{args[0]}\\");
              
                Console.WriteLine($"\tThe current directory is: {Environment.CurrentDirectory} ");
                Console.WriteLine($"\tThe directory you entered = {guessPath}");

                if (Directory.Exists(guessPath))
                {
                    DelegateObject MyParams = new DelegateObject
                    {
                        arguments = args,
                        guessPath = guessPath
                    };


                    // Start watching the files for changes.
                    Console.WriteLine("About to start the Watcher Thread...");
                    Thread watcher = new Thread(new ParameterizedThreadStart(WatcherThread.ThreadAction));
                    
                    Status.ReportInitialStatus(args, guessPath);

                   watcher.Start(MyParams);
                   watcher.IsBackground = true;
              
                  var input = "";
                    do
                    {
                        Console.WriteLine("Type 'quit' to stop the program.");
                        input = Console.ReadLine();

                    } while (input != "quit" );
                  watcher.Abort();
                }
                else
                {
                    Console.WriteLine($"\nDirectory {guessPath} \nDOES NOT EXIST.");

                    // Ask for the arguments again.
                    
                    Watcher(Status.GetInputs());
                }
            }
            else
            {
                // Ask for the arguments again.
                Watcher(Status.GetInputs());

            }

        }
    }
}
