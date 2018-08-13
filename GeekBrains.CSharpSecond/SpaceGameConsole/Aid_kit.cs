// Samsonov

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceGameConsole
{
  class Aid_kit : Asteroid
  {

    /// <summary>
    /// Конструктор класса астероида
    /// </summary>
    /// <param name="pos">Расположение</param>
    /// <param name="dir">Направление</param>
    /// <param name="size">Размер</param>
    public Aid_kit(Point pos, Point dir, Size size) : base(pos, dir, size)
    {
      Dir.Y = 0;
      Power = -1 * Game.rnd.Next(2, 5);
      Img = Properties.Resources.aid_kit;
    }
  }
}
