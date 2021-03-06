﻿// Samsonov

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceGameConsole
{
  class Asteroid : BaseImageObject, ICloneable, IComparable<Asteroid>
  {
    /// <summary>
    /// Сила Астероида
    /// </summary>
    public int Power { get; set; } = 3;

    public Asteroid() : base()
    {
      Dir.Y = 0;
      Img = Properties.Resources.asteroid;
      Power = 1;
    }

    /// <summary>
    /// Конструктор класса астероида
    /// </summary>
    /// <param name="pos">Расположение</param>
    /// <param name="dir">Направление</param>
    /// <param name="size">Размер</param>
    public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size, Properties.Resources.asteroid)
    {
      Dir.Y = 0;
      Power = 1;
    }

    /// <summary>
    /// 
    /// </summary>
    public override void Draw()
    {
      //Game.Buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y, Size.Width, Size.Height);
      Rectangle rect = new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height);
      Game.Buffer.Graphics.DrawImage(Img, rect);
    }

    public override void Update()
    {
      Pos.X += Dir.X;
      if (Pos.X < -Size.Width)
      {
        Death();
      }
    }

    public object Clone()
    {
      Asteroid asteroid = new Asteroid(Pos, Dir, Size);
      asteroid.Power = Power;
      return asteroid;
    }

    public void Death()
    {
      Random rnd = new Random(Pos.Y);
      Pos.X = Game.Width + Size.Width;
      Pos.Y = (rnd.Next() % (Game.Height - 120)) + 60;
      Dir.X = -4 * ((rnd.Next() % 10) + 5);
    }

    int IComparable<Asteroid>.CompareTo(Asteroid other)
    {
      return (Power > other.Power) ? 1 : ((Power < other.Power) ? -1 : 0);
    }
  }
}
