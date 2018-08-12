using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace SpaceGame
{
  public class Win32
  {
    /// <summary>
    /// Allocates a new console for current process.
    /// </summary>
    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool AllocConsole();

    /// <summary>
    /// Frees the console.
    /// </summary>
    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool FreeConsole();

    public Win32()
    {
      Task.Factory.StartNew(Console);
    }

    private void Console()
    {

      if (AllocConsole())
      {
        System.Console.WriteLine("Введите текст");
        string a = System.Console.ReadLine();
        System.Console.WriteLine("Вы ввели: " + a);

        System.Console.ReadLine();



        FreeConsole();
      }
    }

  }
}
