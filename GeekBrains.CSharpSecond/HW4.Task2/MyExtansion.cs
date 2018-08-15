// Samsonov

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Task2
{
  /// <summary>
  /// Мой класс расширяемых методов
  /// </summary>
  public static class MyExtansion
  {
    /// <summary>
    /// Метод для подсчёта количества каждого элемента коллекции
    /// </summary>
    /// <param name="Col">Коллекция</param>
    /// <returns>Словарь: значение - количество</returns>
    public static Dictionary<int, int> CountExsampes(this IEnumerable<int> Col)
    {
      Dictionary<int, int> dict = new Dictionary<int, int>();
      foreach (int item in Col)
      {
        if (dict.ContainsKey(item))
          dict[item]++;
        else
          dict[item] = 1;
      }
      return dict;
    }

    /// <summary>
    /// Метод для подсчёта количества каждого элемента коллекции
    /// </summary>
    /// <typeparam name="T">Тип элементов в коллекции</typeparam>
    /// <param name="Col">Коллекция</param>
    /// <returns>Словарь: значение - количество</returns>
    public static Dictionary<T, int> CountExsampes<T>(this IEnumerable<T> Col)
    {
      Dictionary<T, int> dict = new Dictionary<T, int>();
      foreach (T item in Col)
      {
        if (dict.ContainsKey(item))
          dict[item]++;
        else
          dict[item] = 1;
      }
      return dict;
    }

    /// <summary>
    /// Метод для подсчёта количества каждого элемента коллекции с помощью LINQ в консоль
    /// </summary>
    /// <typeparam name="TSource">Тип элементов в коллекции</typeparam>
    /// <param name="Col">Коллекция</param>
    public static void CountExsampesLinqConsole<TSource>(this IEnumerable<TSource> Col)
    {
      var dict5 = (Col.GroupBy(e => e).Select(i => new { Value = i.First(), Count = i.Count()}));
      

      foreach (var item in dict5)
      {
        Console.WriteLine(item);
      }
      Console.WriteLine();
    }

    /// <summary>
    /// Метод для подсчёта количества каждого элемента коллекции с помощью LINQ
    /// </summary>
    /// <typeparam name="TSource">Тип элементов в коллекции</typeparam>
    /// <param name="Col">Коллекция</param>
    /// <returns>Коллекцию с типом элементов пара, где ключ - элементы из Col, а значение - количество</returns>
    public static IEnumerable<KeyValuePair<TSource, int>> CountExsampesLinq<TSource>(this IEnumerable<TSource> Col)
    {
      return (Col.GroupBy(e => e).Select(i => new KeyValuePair<TSource, int>(i.First(), i.Count())));
    }
  }
}
