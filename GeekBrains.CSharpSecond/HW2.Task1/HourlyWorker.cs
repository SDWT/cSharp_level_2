using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Task1
{
	class HourlyWorker : Worker
	{
		private const double dayPaymentMultiplier = 20.8;
		private const double hourPaymentMultiplier = 8;

		/// <summary>
		/// Конструктор от часовой оплаты для работника с почасовой оплатой
		/// </summary>
		/// <param name="payment">Рублей в час</param>
		public HourlyWorker(int payment) : base(payment)
		{ }

		/// <summary>
		/// Конструктор по умолчанию для работника с почасовой оплатой
		/// </summary>
		public HourlyWorker() : this(500)
		{ }

		/// <summary>
		/// Конструктор от имени и зарплаты
		/// </summary>
		/// <param name="fullName">Полное имя</param>
		/// <param name="payment">Рублей в час</param>
		public HourlyWorker(string fullName, int payment) : base(fullName, payment)
		{ }

		/// <summary>
		/// Метода подсчёта месячной зарплаты для работника с почасовой оплатой
		/// </summary>
		/// <returns>Количество рублей в месяц</returns>
		public override double MonthSalary()
		{
			return dayPaymentMultiplier * hourPaymentMultiplier * Payment;
		}
	}
}
