using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Task1
{
	abstract class Worker : IComparable
	{
		private static int cnt = 0;
		/// <summary>
		/// 
		/// </summary>
		protected int Payment;

		/// <summary>
		/// Полное имя работника
		/// </summary>
		protected string FullName;

		/// <summary>
		/// Конструктор анонимного рабочего
		/// </summary>
		/// <param name="payment">Оплата за период</param>
		protected Worker(int payment)
		{
			FullName = $"Anonim {++cnt}";
			Payment = payment;
		}


		/// <summary>
		/// Конструктор рабочего с именем
		/// </summary>
		/// <param name="fullName">Полное имя</param>
		/// <param name="payment">Оплата за период</param>
		protected Worker(string fullName, int payment)
		{
			FullName = fullName;
			Payment = payment;
		}

		public int CompareTo(object obj)
		{
			if (!(obj is Worker))
			{
				throw new ArgumentException("Argument not supported this function", "obj");
			}

			Worker obj2 = obj as Worker;
			if (obj2.Payment == Payment)
			{
				return FullName.CompareTo(obj2.FullName);
			}
			else
				return MonthSalary().CompareTo(obj2.MonthSalary());
			
		}

		/// <summary>
		/// Макет метода подсчёта месячной зарплаты
		/// </summary>
		/// <returns></returns>
		public abstract double MonthSalary();


		public override string ToString()
		{
			return $"{FullName}: {Payment}";
		}


	}
}
