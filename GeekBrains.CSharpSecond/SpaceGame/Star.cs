// Samsonov

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceGame
{
  /// <summary>
  /// Класс Звёзд
  /// </summary>
  class Star : BaseObject
  {

    /// <summary>
    /// Конструктор класса звезды
    /// </summary>
    /// <param name="pos">Расположение</param>
    /// <param name="dir">Направление</param>
    /// <param name="size">Размер</param>
    public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
    { }

    public override void Draw()
    {
      //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + size.Width, Pos.Y + size.Height);
      //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + size.Width, Pos.Y, Pos.X, Pos.Y + size.Height);

      // Pos.X Pos.Y - центр звезды
      Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X - Size.Width / 2, Pos.Y - Size.Height / 2, Pos.X + Size.Width / 2, Pos.Y + Size.Height / 2);
      Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width / 2, Pos.Y - Size.Height / 2, Pos.X - Size.Width / 2, Pos.Y + Size.Height / 2);
    }
    public override void Update()
    {
      Pos.X += Dir.X;
      if (Pos.X < -Size.Width)
      {
        Random rnd = new Random(Pos.Y);
        Pos.X = Game.Width + Size.Width;
        Pos.Y = (rnd.Next() % (Game.Height - 120)) + 60;
        Dir.X = -5 * ((rnd.Next() % 10) + 5);
      }
    }

  }
}
