using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;


namespace ConsoleApp1
{
    public class FileWatcher
    {
        public static void Main(string[] args)
        {
            RunWatcher.Watcher(args);
        }
    }
}
