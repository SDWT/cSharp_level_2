// Samsonov

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
	class GameObjectException : Exception
	{
		public GameObjectException(string message) : base(message)
		{
		}
	}
}
