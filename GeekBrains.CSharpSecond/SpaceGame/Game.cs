// Samsonov

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceGame
{
  /// <summary>
  /// Класс игры для отрисовки и обработки
  /// </summary>
  static class Game
  {

    private static BufferedGraphicsContext _context;

    /// <summary>
    /// Поле буфера кадра
    /// </summary>
    public static BufferedGraphics Buffer;

    /// <summary>
    /// Свойство Ширины игрового поля
    /// </summary>
    public static int Width { get; set; }

    /// <summary>
    /// Свойство Высоты игрового поля
    /// </summary>
    public static int Height { get; set; }

    /// <summary>
    /// Конструктор по умолчанию
    /// </summary>
    static Game() { }

    /// <summary>
    /// Метод инициализации элементов игры
    /// </summary>
    /// <param name="form">Форма в которую будет идти отрисовка игры</param>
    public static void Init(Form form)
    {
      // Графическое устройство для вывода графики
      Graphics g;
      // Предоставляет доступ к главному буферу графического контекста для текущего приложения
      _context = BufferedGraphicsManager.Current;
      g = form.CreateGraphics();

      // Создаем объект (поверхность рисования) и связываем его с формой
      // Запоминаем размеры формы
      Width = form.Width;
      Height = form.Height;

      if (Width < 0)
      {
        throw new ArgumentOutOfRangeException("Width", Width, "Ширина не может быть меньше 0");
      }
      if (Height < 0)
      {
        throw new ArgumentOutOfRangeException("Height", Height, "Высота не может быть меньше 0");
      }
      if (Width > 2000)
      {
        throw new ArgumentOutOfRangeException("Width", Width, "Ширина не может быть больше 2000");
      }
      if (Height > 2000)
      {
        throw new ArgumentOutOfRangeException("Height", Height, "Высота не может быть больше 2000");
      }


      // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
      Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

      // Подгружаем объекты
      Load();

      // Создаём таймер
      Timer timer = new Timer();
      timer.Interval = 100;
      timer.Start();
      timer.Tick += Timer_Tick;
    }

    private static void Timer_Tick(object sender, EventArgs e)
    {
      Draw();
      Update();
    }

    /// <summary>
    /// Метод отрисовки игры
    /// </summary>
    public static void Draw()
    {
      Buffer.Graphics.Clear(Color.Black);
      foreach (BaseObject obj in _objs)
        obj.Draw();
      foreach (Asteroid astr in _asteroid)
        astr.Draw();
      _bullet.Draw();
      Buffer.Render();
    }

    /// <summary>
    /// Обновление всех входящих элементов
    /// </summary>
    public static void Update()
    {
      foreach (BaseObject obj in _objs)
        obj.Update();
      foreach (Asteroid astr in _asteroid)
      {
        astr.Update();
        if (astr.Collision(_bullet))
        {
          System.Media.SystemSounds.Hand.Play();
          astr.Death();
          _bullet.Death();
        }
      }
      _bullet.Update();
    }

    #region drawning objects

    private static BaseObject[] _objs;
    private static Bullet _bullet;
    private static Asteroid[] _asteroid;

    #endregion

    /// <summary>
    /// Метод загрузки объектов для инициализации
    /// </summary>
    public static void Load()
    {
      int i = 0;
      Random rnd = new Random();

      _objs = new BaseObject[30];
      _bullet = new Bullet(new Point(0, 210), new Point(5, 0), new Size(4, 1));
      _asteroid = new Asteroid[3];

      for (int j = 0; j < _asteroid.Length; j++)
      {
        int r = rnd.Next(5, 50);
        _asteroid[j] = new Asteroid(new Point(Game.Width, rnd.Next(0, Game.Height)), new Point(-r / 5, 0), new Size(r, r));
      }


      _objs[i++] = new Nebula(new Point(300, 300), new Point(-5, 0), new Size(100, 50));
      _objs[i++] = new BigStar(new Point(100, 100), 250);

      for (; i < _objs.Length; i++)
        _objs[i] = new Star(new Point(10, i * 20), new Point(-i, 0), new Size(3, 3));
    }
  }
}
