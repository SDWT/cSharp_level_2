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
  /// Класс базового объекта
  /// </summary>
  class BaseObject
  {
    /// <summary>
    /// Расположение
    /// </summary>
    protected Point Pos;

    /// <summary>
    /// Направление
    /// </summary>
    protected Point Dir;

    /// <summary>
    /// Размер
    /// </summary>
    protected Size Size;

    /// <summary>
    /// Конструктор базового объекта по умолчанию
    /// </summary>
    public BaseObject()
    {
      Point p = new Point(0, 0);
      Pos = p;
      Dir = p;
      this.Size = new Size(p);
    }

    /// <summary>
    /// Конструктор базового объекта
    /// </summary>
    /// <param name="pos">Расположение</param>
    /// <param name="dir">Направление</param>
    /// <param name="size">Размер</param>
    public BaseObject(Point pos, Point dir, Size size)
    {
      Pos = pos;
      Dir = dir;
      this.Size = size;
    }

    /// <summary>
    /// Отрисовка базового объекта
    /// </summary>
    public virtual void Draw()
    {
      Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
    }

    /// <summary>
    /// Обновление состояния базового объекта
    /// </summary>
    public virtual void Update()
    {
      Pos.X = Pos.X + Dir.X;
      Pos.Y = Pos.Y + Dir.Y;
      if (Pos.X < 0)
        Dir.X = -Dir.X;
      if (Pos.X > Game.Width)
        Dir.X = -Dir.X;
      if (Pos.Y < 0)
        Dir.Y = -Dir.Y;
      if (Pos.Y > Game.Height)
        Dir.Y = -Dir.Y;
    }
  }
}
