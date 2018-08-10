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
  class BaseImageObject : BaseObject
  {
    /// <summary>
    /// Расположение
    /// </summary>
    protected Image Img;

    /// <summary>
    /// Конструктор базового объекта с изображением
    /// </summary>
    /// <param name="pos">Расположение</param>
    /// <param name="dir">Направление</param>
    /// <param name="size">Размер</param>
    /// <param name="img">Изображение</param>
    public BaseImageObject(Point pos, Point dir, Size size, Image img) : base(pos, dir, size)
    {
      Img = img;
    }

    /// <summary>
    /// Отрисовка базового объекта
    /// </summary>
    public override void Draw()
    {
      //Game.Buffer.Graphics.DrawImage(Img, Pos);

      //Rectangle rect = new Rectangle(Pos, size);
      Rectangle rect = new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height);
      Game.Buffer.Graphics.DrawImage(Img, rect);

    }

    /// <summary>
    /// Обновление состояния базового объекта
    /// </summary>
    public override void Update()
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
