using System;
using System.Collections.Generic;
using System.Diagnostics;
using Science_Wars_Server;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Runner r = new Runner("127.0.0.1", 12122);
            r.run(33);
        }
    }
}
        