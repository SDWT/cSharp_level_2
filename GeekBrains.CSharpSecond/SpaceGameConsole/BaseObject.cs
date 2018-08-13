// Samsonov

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceGameConsole
{
  /// <summary>
  /// Класс базового объекта
  /// </summary>
  public abstract class BaseObject : ICollision
  {
    #region properties
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
    #endregion

    #region delegates

    public delegate void Message();

    #endregion

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


      if (Size.Width < 0 || Size.Height < 0)
      {
        throw new GameObjectException($"Размеры {this.GetType()} меньше нуля");
      }
      if (Size.Width > Game.Width / 4 || Size.Height > Game.Height / 4)
      {
        throw new GameObjectException($"Размеры {this.GetType()} Слишком большие нуля");
      }
      if (Math.Abs(Dir.X) > 50)
      {
        throw new GameObjectException($"Скорость {this.GetType()} слишком большая");
      }
      //if (Dir.Y != 0)
      //{
      //  throw new GameObjectException($"{this.GetType()} двигается по оси Y");
      //}
      if (Pos.X <= -Size.Width || Pos.Y < 0 || Pos.Y > Game.Height)
      {
        throw new GameObjectException($"{this.GetType()} расположен неправильного");
      }

    }

    #region collision
    /// <summary>
    /// Прямоугольник расположения объекта
    /// </summary>
    public Rectangle Rect => new Rectangle(Pos, Size);

    public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);
    #endregion


    /// <summary>
    /// Абстрактный метод отрисовки
    /// </summary>
    public abstract void Draw();

    /// <summary>
    /// Абстрактный метод обновления состояния
    /// </summary>
    public abstract void Update();
  }
}
