using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Task2
{
  public static class MyExtansion
  {
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
  }
}
