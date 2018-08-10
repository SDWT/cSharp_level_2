using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Task1
{
	class ArrayWorker : IEnumerable, IEnumerator
	{
		private readonly Worker[] _a;

		public ArrayWorker(int n)
		{
			_a = new Worker[n];

			for (int i = 0; i < n / 2; i++)
			{
				_a[i] = new MonthWorker(i * 10100);
			}
			for (int i = n / 2; i < n; i++)
			{
				_a[i] = new HourlyWorker(i * 101);
			}
		}

		public ArrayWorker(Worker[] a)
		{
			_a = new Worker[a.Length];

			for (int i = 0; i < a.Length; i++)
			{
				_a[i] = a[i];
			}
		}

		public override string ToString()
		{
			StringBuilder Buf = new StringBuilder(_a.Length);
			for (int i = 0; i < _a.Length; i++)
			{
				Buf.AppendLine(_a[i].ToString());
			}

			return Buf.ToString();
		}

		private int _i = -1;

		public IEnumerator GetEnumerator()
		{
			return this;
		}

		public bool MoveNext()
		{
			if (_i == _a.Length - 1)
			{
				Reset();
				return false;
			}
			else
			{
				_i++;
				return true;
			}
		}

		public void Reset()
		{
			_i = -1;
		}

		public object Current => _a[_i];
	}
}
