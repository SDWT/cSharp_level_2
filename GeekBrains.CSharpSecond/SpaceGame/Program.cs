// Samsonov

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace SpaceGame
{
  /// <summary>
  /// Главный класс
  /// </summary>
  static class Program
  {
    /// <summary>
    /// Главная точка входа для приложения.
    /// </summary>
    [STAThread]
    static void Main()
    {
      //Application.EnableVisualStyles();
      //Application.SetCompatibleTextRenderingDefault(false);
      Form mainForm = new Form();
      mainForm.Width = 800;
      mainForm.Height = 600;

      Game.Init(mainForm);
      mainForm.Show();
      Game.Draw();

      Application.Run(mainForm);
    }
  }
}
