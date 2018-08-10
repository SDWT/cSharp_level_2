using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Task1
{
	class Program
	{
		static void Main(string[] args)
		{
			// Test Worker, HourlyWorker, MonthWorker

			Worker[] workers = new Worker[10];
			int k = 0;

			workers[k++] = new MonthWorker("Kid", 30000);
			workers[k++] = new HourlyWorker("Cat", 3000);

			for (; k < workers.Length / 2; k++)
			{
				workers[k] = new HourlyWorker(101 * k);
			}
			for (; k < workers.Length; k++)
			{
				workers[k] = new MonthWorker(11000 * k);
			}

			for (int i = 0; i < workers.Length; i++)
			{
				Console.WriteLine(string.Format("{0} {1}", workers[i], workers[i].MonthSalary()));
			}

			Console.Write("\nArray sort test:\n");
			Array.Sort(workers);
			for (int i = 0; i < workers.Length; i++)
			{
				Console.WriteLine(string.Format("{0} {1}", workers[i], workers[i].MonthSalary()));
			}

			ArrayWorker aw = new ArrayWorker(10);


			Console.Write("\nForeach test:\n");
			foreach (Worker item in aw)
			{
				Console.WriteLine(string.Format("{0} {1}", item.ToString(), item.MonthSalary()));
			}
			
			//Console.Write(aw);

			return;
		}
	}
}
