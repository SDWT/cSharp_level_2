﻿// Samsonov

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
    public static int Width { get; set; } = 800;

    /// <summary>
    /// Свойство Высоты игрового поля
    /// </summary>
    public static int Height { get; set; } = 600;
    
    #region drawning objects

    private static BaseObject[] _objs;
    private static Bullet _bullet;
    private static Asteroid[] _asteroid;

    #endregion

    private static Timer _timer = new Timer();
    /// <summary>
    /// 
    /// </summary>
    public static Random rnd = new Random();

    private static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10));

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

      // Обработчики нажатий на клавиши
      form.KeyDown += Form_KeyDown;

      Ship.MessageDie += Finish;

      // Создаём таймер
      //Timer timer = new Timer();
      _timer.Interval = 100;
      _timer.Start();
      _timer.Tick += Timer_Tick;
    }

    private static void Form_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.ControlKey)
        _bullet =  new Bullet( new Point(_ship.Rect.X +  10 , _ship.Rect.Y +  4 ),  new Point( 4 ,  0 ),  new Size( 4 ,  1 ));
      if (e.KeyCode == Keys.Up)
        _ship.Up();
      if (e.KeyCode == Keys.Down)
        _ship.Down();
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
        astr?.Draw();
      _bullet?.Draw();
      _ship?.Draw();

      if (_ship is null)
        Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
      Buffer.Render();
    }

    /// <summary>
    /// Обновление всех входящих элементов
    /// </summary>
    public static void Update()
    {
      foreach (BaseObject obj in _objs)
        obj.Update();
      for (int i = 0; i < _asteroid.Length; i++)
      {
        if (_asteroid[i] == null)
          continue;
        _asteroid[i].Update();

        if (_asteroid[i].Collision(_bullet))
        {
          System.Media.SystemSounds.Hand.Play();
          //astr.Death();
          //_bullet.Death();
          _asteroid[i] = null;
          _bullet = null;
          continue;
        }
        if (!_ship.Collision(_asteroid[i]))
          continue;
        var rnd = new Random();
        _ship?.EnergyLow(rnd.Next(1, 10));
        System.Media.SystemSounds.Asterisk.Play();
        if (_ship.Energy <= 0)
          _ship?.Die();
      }

      foreach (Asteroid astr in _asteroid)
      {
        //if (astr == null)
        //  continue;
        //astr.Update();

        //if (astr.Collision(_bullet))
        //{
        //  System.Media.SystemSounds.Hand.Play();
        //  //astr.Death();
        //  //_bullet.Death();
        //  astr = null;

        //}
      }
      _bullet?.Update();
    }

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

    public static void Finish()
    {
      _timer.Stop();
      Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
      Buffer.Render();
    }
  }
}