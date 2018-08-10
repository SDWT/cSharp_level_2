using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Task1
{
	class MonthWorker : Worker
	{
		/// <summary>
		/// Конструктор от месячной зарплаты
		/// </summary>
		/// <param name="payment">Рублей в месяц</param>
		public MonthWorker(int payment = 11000) : base(payment)
		{ }

		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		//public MonthWorker() : this(11000)
		//{ }

		/// <summary>
		/// Конструктор от имени и зарплаты
		/// </summary>
		/// <param name="fullName">Полное имя</param>
		/// <param name="payment">>Рублей в месяц</param>
		public MonthWorker(string fullName, int payment) : base(fullName, payment)
		{ }

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override double MonthSalary()
		{
			return Payment;
		}
	}
}
