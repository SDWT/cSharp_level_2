// Samsonov
// HW4 Task: 2.c

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Task2
{
  /// <summary>
  /// Класс приложения
  /// </summary>
  class Program
  {
    /// <summary>
    /// Точка входа в программу
    /// </summary>
    /// <param name="args">Параметры запуска</param>
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

      Console.WriteLine("Linq");

      #region Linq v1

      //var dict4 = (from cnt in (from n in L
      //            group n by n)
      //            select (cnt => new { cnt.First(), cnt.Count()}));

      //var dict4 = (L.GroupBy(e => e).Select(i => new { Value = i.First(), Count = i.Count() }));

      //foreach (var item in dict4)
      //{
      //  foreach (var obj in item)
      //  {
      //    Console.WriteLine(obj);
      //  }
      //}

      //Console.WriteLine(dict4.GetType());
      //Console.WriteLine(dict4);

      //foreach (var item in dict4)
      //{
      //  Console.WriteLine(item);
      //}
      //Console.WriteLine();

      //var dict5 = (Q.GroupBy(e => e).Select(i => new { Value = i.First(), Count = i.Count() }));

      //foreach (var item in dict5)
      //{
      //  Console.WriteLine(item);
      //}
      //Console.WriteLine();

      #endregion

      #region Linq v2
      //L.CountExsampesLinqConsole();

      //Q.CountExsampesLinqConsole();
      #endregion

      #region Linq v3

      #endregion


      var dict6 = L.CountExsampesLinq();
      foreach (var item in dict6)
      {
        Console.WriteLine(item);
      }

      var res = Q.CountExsampesLinq();

      Console.WriteLine("\nTest: add element \"cat\" after method before foreach");
      foreach (var item in res)
      {
        Console.WriteLine(item);
      }
      Console.WriteLine();
      Q.Enqueue("cat");
      foreach (var item in res)
      {
        Console.WriteLine(item);
      }
      Console.WriteLine();

      #endregion

      return;
    }
  }
}
