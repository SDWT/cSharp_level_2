// Samsonov

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceGameConsole
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
    //private static Bullet _bullet;
    private static int _maxBullets = 25;
    private static List<Bullet> _bullets = new List<Bullet>();

    private static int _maxAsteroids = 10;
    private static List<Asteroid> _asteroids = new List<Asteroid>();

    //private static Asteroid[] _asteroid;

    #endregion

    private static Timer _timer = new Timer();
    /// <summary>
    /// 
    /// </summary>
    public static Random rnd = new Random();

    private static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10));

    private static int _score = 0;

    public static Action<string> _log;
    public static Action _close;

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
      _close = form.Close;

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
      //Load();

      // Обработчики нажатий на клавиши
      form.KeyDown += Form_KeyDown;

      Ship.MessageDie += Finish;
      _log += Log.FileOut;
      _log += Log.ConsoleOut;

      // Создаём таймер
      //Timer timer = new Timer();
      _timer.Interval = 100;
      _timer.Start();
      _timer.Tick += Timer_Tick;
    }

    private static void Form_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.ControlKey && _bullets.Count < _maxBullets)
        _bullets.Add(new Bullet(new Point(_ship.Rect.X + _ship.Rect.Width / 2, _ship.Rect.Y + _ship.Rect.Height / 2), new Point(4, 0), new Size(4, 1)));
      if (e.KeyCode == Keys.Up)
        _ship.Up();
      if (e.KeyCode == Keys.Down)
        _ship.Down();
      if (e.KeyCode == Keys.Escape)
        _close();
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
      foreach (Asteroid astr in _asteroids)
        astr?.Draw();
      foreach (Bullet b in _bullets)
        b.Draw();

      _ship?.Draw();

      if (_ship is null)
        Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
      Buffer.Graphics.DrawString(string.Format("Score: {0:D5}", _score), new Font(FontFamily.GenericMonospace, 20, FontStyle.Regular), Brushes.White, 10, 10);
      Buffer.Graphics.DrawString(string.Format("HP: {0:D3}", _ship.Energy), new Font(FontFamily.GenericMonospace, 20, FontStyle.Regular), Brushes.White, 10, 40);
      Buffer.Render();
    }

    /// <summary>
    /// Обновление всех входящих элементов
    /// </summary>
    public static void Update()
    {
      foreach (BaseObject obj in _objs)
        obj.Update();
      foreach (Bullet b in _bullets)
        b.Update();

      for (int i = 0; i < _asteroids.Count; i++)
      {
        if (_asteroids[i] == null || (_asteroids[i] is Aid_kit && _asteroids[i].Rect.X < 0))
        {
          _asteroids.RemoveAt(i--);
          continue;
        }
        _asteroids[i].Update();

        for (int j = 0; j < _bullets.Count; j++)
        {
          if (_bullets[j].Rect.X > Game.Width)
          {
            //_log($"Было: {_bullets.Count} Стало: {_bullets.Count - 1}.\n");
            _bullets.RemoveAt(j--);
            continue;
          }

          if (_bullets[j].Collision(_asteroids[i]))
          {
            System.Media.SystemSounds.Hand.Play();
            if (!(_asteroids[i] is Aid_kit))
            {
              _score += _asteroids[i].Power;
              _log($"Получено {_asteroids[i].Power} очков за сбитый астероид.\n");
            }
            _asteroids.RemoveAt(i--);
            _bullets.RemoveAt(j--);
            break;
            //_asteroid[i] = null;
            //_bullet = null;
          }
        }

        if (i < 0 || !_ship.Collision(_asteroids[i]))
          continue;
        var rnd = new Random();
        _ship?.EnergyLow(_asteroids[i].Power * rnd.Next(1, 10));

        if (_asteroids[i] is Aid_kit)
          _log($"Очки здоровья востановлены.\n");
        else if (_asteroids[i] is Asteroid)
          _log($"Получен урон {_asteroids[i].Power} от астероида.\n");

        System.Media.SystemSounds.Asterisk.Play();
        if (_ship.Energy <= 0)
        {
          _ship?.Die();

          _log($"Ваш корабль уничтожен.\nВы проиграли.\n");
        }
      }

      if (_asteroids.Count <= 0)
      {
        AddAsteroids();
      }

      #region Old Asteroids
      //foreach (Asteroid astr in _asteroid)
      //{
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
      //}
      #endregion
    }

    /// <summary>
    /// Метод загрузки объектов для инициализации
    /// </summary>
    public static void Load()
    {
      int i = 0;
      Random rnd = new Random();

      _objs = new BaseObject[50];
      #region Old Asteroids
      //_asteroid = new Asteroid[10];

      //for (int j = 0; j < _asteroid.Length; j++)
      //{
      //  int r = rnd.Next(5, 50);
      //  _asteroid[j] = new Asteroid(new Point(Game.Width, rnd.Next(0, Game.Height)), new Point(-r / 5, 0), new Size(r, r));
      //  if (j % 4 == 0)
      //  {
      //    _asteroid[j] = new Aid_kit(new Point(Game.Width, rnd.Next(0, Game.Height)), new Point(-r / 5, 0), new Size(r, r));
      //  }
      //}

      #endregion
      AddAsteroids();

      _objs[i++] = new Nebula(new Point(300, 300), new Point(-5, 0), new Size(100, 50));
      _objs[i++] = new BigStar(new Point(100, 100), 250);

      for (; i < _objs.Length; i++)
        _objs[i] = new Star(new Point(10, i * 20), new Point(-i, 0), new Size(3, 3));
    }

    /// <summary>
    /// Метод окончания игры
    /// </summary>
    public static void Finish()
    {
      _timer.Stop();
      Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
      Buffer.Render();
    }

    /// <summary>
    /// Метод добавления астероидов по максимальному числу
    /// </summary>
    private static void AddAsteroids()
    {
      AddAsteroids(_maxAsteroids++);
    }

    /// <summary>
    /// Метод добавления астероидов по количеству
    /// </summary>
    /// <param name="count">Количество</param>
    private static void AddAsteroids(int count)
    {
      for (int j = 0; j < count; j++)
      {
        int r = rnd.Next(5, 50);

        if (j % 5 == 0)
          _asteroids.Add(new Aid_kit(new Point((int)(Game.Width * (1 + r / 100.0)), rnd.Next(0, Game.Height)), new Point(-r / 5, 0), new Size(r, r)));
        else
          _asteroids.Add(new Asteroid(new Point((int)(Game.Width * (1 + r / 100.0)), rnd.Next(0, Game.Height)), new Point(-r / 5, 0), new Size(r, r)));
      }
    }
  }
}
