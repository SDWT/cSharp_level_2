// Samsonov

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
  class Bullet : BaseObject
  {

    /// <summary>
    /// Конструктор класса звезды
    /// </summary>
    /// <param name="pos">Расположение</param>
    /// <param name="dir">Направление</param>
    /// <param name="size">Размер</param>
    public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
    {}

    /// <summary>
    /// 
    /// </summary>
    public Bullet() : base()
    {
    }

    public override void Draw()
    {
      Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
    }

    public override void Update()
    {
      Pos.X = Pos.X + 3;
      if (Pos.X > Game.Width)
      {
        Death();
      }
    }

    public void Death()
    {
      //Random rnd = new Random(Pos.Y);
      Pos.X = 0;
      Pos.Y = 210;
    }
  }
}
