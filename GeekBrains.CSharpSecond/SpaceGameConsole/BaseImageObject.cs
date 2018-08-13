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
  public abstract class BaseImageObject : BaseObject
  {
    /// <summary>
    /// Расположение
    /// </summary>
    protected Image Img;

    /// <summary>
    /// Конструктор базового объекта с изображением по умолчанию
    /// </summary>
    public BaseImageObject() : base()
    {
      Img = Properties.Resources.bigStar;
    }

    /// <summary>
    /// Конструктор базового объекта с изображением от изображения
    /// </summary>
    /// <param name="img">Изображение</param>
    public BaseImageObject(Image img) : base()
    {
      Img = img;
    }

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
      Rectangle rect = new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height);
      Game.Buffer.Graphics.DrawImage(Img, rect);

    }
  }
}
