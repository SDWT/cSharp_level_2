﻿// Samsonov

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpaceGame
{
  static class Log
  {
    public static void FileOut(string msg)
    {
      File.AppendAllText("log.txt", msg);
    }
  }
}