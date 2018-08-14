using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Task2
{
  class Program
  {
    static void Main(string[] args)
    {

      #region int count
      List<int> L = new List<int>();
      Random rnd = new Random(30);

      for (int i = 0; i < 100; i++)
      {
        int x = rnd.Next(0, 10);
        L.Add(x);
        //Console.WriteLine(x);
      }
      Console.WriteLine();
      
      Console.WriteLine("Collection<int>");
      var dict1 = L.CountExsampes();

      foreach (var item in dict1)
      {
        Console.WriteLine(item);
      }
      Console.WriteLine();
      #endregion
      #region T count

      Console.WriteLine("Collection<T>");
      var dict2 = L.CountExsampes<int>();

      foreach (var item in dict2)
      {
        Console.WriteLine(item);
      }
      Console.WriteLine();

      Queue<string> Q = new Queue<string>();


      for (int i = 0; i < 3; i++)
      {
        Q.Enqueue("Abra");
        Q.Enqueue("Cod");
        Q.Enqueue("Cod");
        Q.Enqueue("CodAbra");
        Q.Enqueue("CodAbra");
        Q.Enqueue("CodAbra");
      }
      Console.WriteLine();

      var dict3 = Q.CountExsampes<string>();

      foreach (var item in dict3)
      {
        Console.WriteLine(item);
      }
      Console.WriteLine();
      #endregion
      #region Linq count

      
      //Console.WriteLine("Collection<T>");
      //var dict4 = L.CountExsampes<int>();

      //foreach (var item in dict4)
      //{
      //  Console.WriteLine(item);
      //}
      //Console.WriteLine();
      
      //var dict5 = Q.CountExsampes<string>();

      //foreach (var item in dict5)
      //{
      //  Console.WriteLine(item);
      //}
      //Console.WriteLine();
      #endregion

      return;
    }
  }
}
