// Samsonov

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpaceGameConsole
{
  static class Log
  {
    static Log()
    {
      File.WriteAllText("log.txt", string.Empty);
    }

    public static void FileOut(string msg)
    {      
      File.AppendAllText("log.txt", msg);
    }

    public static void ConsoleOut(string msg)
    {
      Console.Write(msg);
    }
  }
}