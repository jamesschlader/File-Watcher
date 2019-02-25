using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class DelegateObject
    {
        public DelegateObject() { }

        public DelegateObject(string[] args, string path)
        {
            arguments = args;
            guessPath = path;
        }

        public string[] arguments { get; set; }
        public string guessPath { get; set; }
    }
}
