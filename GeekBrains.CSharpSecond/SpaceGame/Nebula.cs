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
  /// Класс Туманности
  /// </summary>
  class Nebula : BaseObject
  {
    Point[] Dots;
    /// <summary>
    /// Конструктор класса Туманности
    /// </summary>
    /// <param name="pos">Расположение</param>
    /// <param name="dir">Направление</param>
    /// <param name="size">Размер</param>
    public Nebula(Point pos, Point dir, Size size) : base(pos, dir, size)
    {

      Dots = new Point[50];
      Random rnd = new Random();
      for (int i = 0; i < Dots.Length; i++)
      {
        Dots[i] = new Point(rnd.Next() % 100, rnd.Next() % 100);
      }
    }

    public override void Draw()
    {
      //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
      //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);

      // Pos.X Pos.Y - центр звезды
      Game.Buffer.Graphics.FillEllipse(Brushes.DarkViolet, new Rectangle(Pos.X - Size.Width / 2, Pos.Y - Size.Height / 2, Size.Width, Size.Height));
      int[] a = { 5, 4, 3, 0 };
      int k = 4;
      for (int i = 0; i < a.Length; i++)
      {
        Game.Buffer.Graphics.FillEllipse(Brushes.DarkViolet, new Rectangle(Pos.X - a[i] * Size.Width / 3 / k - Size.Width / 8,
          Pos.Y - a[a.Length - i - 1] * Size.Height / 3 / k - Size.Height / 4, Size.Width / 4, Size.Height / 2));
        Game.Buffer.Graphics.FillEllipse(Brushes.DarkViolet, new Rectangle(Pos.X - a[i] * Size.Width / 3 / k - Size.Width / 8,
          Pos.Y + a[a.Length - i - 1] * Size.Height / 3 / k - Size.Height / 4, Size.Width / 4, Size.Height / 2));
        Game.Buffer.Graphics.FillEllipse(Brushes.DarkViolet, new Rectangle(Pos.X + a[i] * Size.Width / 3 / k - Size.Width / 8,
          Pos.Y - a[a.Length - i - 1] * Size.Height / 3 / k - Size.Height / 4, Size.Width / 4, Size.Height / 2));
        Game.Buffer.Graphics.FillEllipse(Brushes.DarkViolet, new Rectangle(Pos.X + a[i] * Size.Width / 3 / k - Size.Width / 8,
          Pos.Y + a[a.Length - i - 1] * Size.Height / 3 / k - Size.Height / 4, Size.Width / 4, Size.Height / 2));
      }
      int kw = 70;
      int kh = 35;
      for (int i = 0; i < Dots.Length; i++)
      {
        float x = Pos.X - Size.Width / 3f, 
          y = Pos.Y - Size.Height / 3f,
          dx = kw * Dots[i].X / 100f, 
          dy = kh * Dots[i].Y / 100f;

        Game.Buffer.Graphics.DrawLine(Pens.White, x + dx - 1, y + dy - 1, x + dx + 1, y + dy + 1);
        Game.Buffer.Graphics.DrawLine(Pens.White, x + dx - 1, y + dy + 1, x + dx + 1, y + dy - 1);
      }

      //for (int i = -1; i <= 1; i++)
      //{
      //  for (int j = -1; j <= 1; j++)
      //  {
      //    Game.Buffer.Graphics.FillEllipse(Brushes.Red, new Rectangle(Pos.X - i * Size.Width / 3 - Size.Width / 8, Pos.Y - j * Size.Height / 3 - Size.Height / 4, Size.Width / 4, Size.Height / 2));
      //  }
      //  Game.Buffer.Graphics.FillEllipse(Brushes.White, new Rectangle(Pos.X - Size.Width / 8, Pos.Y - Size.Height / 4, Size.Width / 4, Size.Height / 2));
      //}
    }
    public override void Update()
    {
      Random rnd = new Random();
      Pos.X += Dir.X;
      if (Pos.X < -Size.Width)
      {
        Pos.X = Game.Width + Size.Width;
        Pos.Y = (rnd.Next() % (Game.Height - 120)) + 60;
        for (int i = 0; i < Dots.Length; i++)
        {
          Dots[i].X = rnd.Next() % 100;
          Dots[i].Y = rnd.Next() % 100;
        }
      }
    }

  }
}
