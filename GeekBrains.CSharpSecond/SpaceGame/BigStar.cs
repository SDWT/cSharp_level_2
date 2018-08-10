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
  class BigStar : BaseImageObject
  {
    const int speedMax = 7;
    /// <summary>
    /// Конструктор класса звезды
    /// </summary>
    /// <param name="pos">Расположение</param>
    /// <param name="dir">Направление</param>
    /// <param name="size">Длина диаметра большорй звезды больше или равен 50, меньше или равен 250</param>
    public BigStar(Point pos, int size) : base(pos, new Point(0, 0), new Size(0, 0), Properties.Resources.bigStar)
    {
      if (size < 50)
        size = 50;
      else if (size > 250)
        size = 250;
      else
        size = (size / 50) * 50;

      this.Size = new Size(size , size);
      Dir = new Point((speedMax - (size) / 50) * -2, 0);

    }

    public override void Draw()
    {
      //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + size.Width, Pos.Y + size.Height);
      //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + size.Width, Pos.Y, Pos.X, Pos.Y + size.Height);

      // Pos.X Pos.Y - центр звезды
      Rectangle rect = new Rectangle(Pos.X - Size.Width / 2, Pos.Y - Size.Height / 2, Size.Width, Size.Height);
      Game.Buffer.Graphics.DrawImage(Img, rect);
    }
    public override void Update()
    {
      Pos.X += Dir.X;
      if (Pos.X < -Size.Width)
      {
        Random rnd = new Random(Pos.Y);
        Pos.X = Game.Width + Size.Width;
        Pos.Y = (rnd.Next() % (Game.Height - 120)) + 60;
        int newsize = ((rnd.Next() % 3) + 1) * 50;
        Size = new Size(newsize, newsize);
        Dir.X = -2 * (speedMax - Size.Width / 50);
      }
    }

  }
}

