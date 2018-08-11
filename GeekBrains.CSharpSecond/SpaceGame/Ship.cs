// Samsonov

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceGame
{
  class Ship : BaseObject
  {
    private int _energy = 100;
    public int Energy { get => _energy; }

    public static event Message MessageDie;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="n"></param>
    public void EnergyLow(int n)
    {
      _energy -= n;
      if (_energy > 100)
        _energy = 100;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="dir"></param>
    /// <param name="size"></param>
    public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
    {

    }

    /// <summary>
    /// Метод отрисовки корабля
    /// </summary>
    public override void Draw()
    {
      Game.Buffer.Graphics.FillEllipse(Brushes.Wheat, Pos.X, Pos.Y, Size.Width, Size.Height);
    }

    /// <summary>
    /// Метод обновления состояния корабля
    /// </summary>
    public override void Update()
    {

    }

    public void Up()
    {
      if (Pos.Y - Dir.Y >= 0)
        Pos.Y -= Dir.Y;
    }

    public void Down()
    {
      if (Pos.Y + Dir.Y <= Game.Height)
        Pos.Y += Dir.Y;
    }

    public void Die()
    {
      MessageDie?.Invoke();
    }


  }
}
