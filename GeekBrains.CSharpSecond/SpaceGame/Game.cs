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
    /// <summary>
    /// 
    /// </summary>
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

    public static Rectangle RectArea { get; set; }

    /// <summary>
    /// Конструктор по умалчанию
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
      RectArea = form.ClientRectangle;
      //Width = form.ClientSize.Width;
      //Height = form.ClientSize.Height;

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

    /// <summary>
    /// Обработчик таймера
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
      // Проверяем вывод графики
      //Buffer.Graphics.Clear(Color.Black);
      //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
      //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
      //Buffer.Render();

      Buffer.Graphics.Clear(Color.Black);
      foreach (BaseObject obj in _objs)
        obj.Draw();
      Buffer.Render();
    }

    /// <summary>
    /// Обновление всех входящих элементов
    /// </summary>
    public static void Update()
    {
      foreach (BaseObject obj in _objs)
        obj.Update();
    }
    /// <summary>
    /// Массив хранения объектов
    /// </summary>
    public static BaseObject[] _objs;

    /// <summary>
    /// Метод загрузки объектов для инициализации
    /// </summary>
    public static void Load()
    {
      int i = 0;
      _objs = new BaseObject[30];
      _objs[i++] = new Nebula(new Point(300, 300), new Point(-5, 0), new Size(100, 50));
      //_objs[i++] = new Star(new Point(100, 100), new Point(-5, 0), new Size(100, 100));
      //_objs[i++] = new BaseImageObject(new Point(100, 100), new Point(0, 0), new Size(100, 100), Properties.Resources.BigStar);
      _objs[i++] = new BigStar(new Point(100, 100), 100);

      /*
      for (; i < 10; i++)
        _objs[i] = new BaseObject(new Point(600, i * 20), new Point(-i, -i), new Size(10, 10));
      */
      for (; i < _objs.Length; i++)
        _objs[i] = new Star(new Point(10 /*- i * 20*/, i * 20), new Point(-i, 0), new Size(3, 3));
      //_objs[i] = new Star(new Point(600, i * 20), new Point(-i, 0), new Size(5, 5));

    }
  }
}
