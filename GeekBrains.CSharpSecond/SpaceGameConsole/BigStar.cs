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
  /// Класс Звёзд
  /// </summary>
  class BigStar : BaseImageObject
  {
    private const int _speedMax = 7;

    /// <summary>
    /// Конструктор класса большой звезды по умолчанию
    /// </summary>
    public BigStar() : base(new Point(0, 0), new Point(0, 0), new Size(250, 250), Properties.Resources.bigStar)
    {
      Dir = new Point((_speedMax - (Size.Width) / 50) * -2, 0);
    }

    /// <summary>
    /// Конструктор класса звезды
    /// </summary>
    /// <param name="pos">Расположение</param>
    /// <param name="size">Длина диаметра большорй звезды больше или равен 50, меньше или равен 250</param>
    public BigStar(Point pos, int size) : base(pos, new Point(0, 0), new Size(0, 0), Properties.Resources.bigStar)
    {
      if (size < 50)
        size = 50;
      else if (size > 250)
        size = 250;
      else
        size = (size / 50) * 50;

      this.Size = new Size(size, size);
      Dir = new Point((_speedMax - (size) / 50) * -2, 0);

    }

    /// <summary>
    /// Метод рисования
    /// </summary>
    public override void Draw()
    {
      // Pos.X Pos.Y
      Rectangle rect = new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height);
      Game.Buffer.Graphics.DrawImage(Img, rect);
    }

    /// <summary>
    /// Метод обновления
    /// </summary>
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
        Dir.X = -2 * (_speedMax - Size.Width / 50);
      }
    }

  }
}

