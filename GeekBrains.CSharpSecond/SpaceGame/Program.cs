// Samsonov

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Text;



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
    //[STAThread]
    static void Main()
    {
      Form mainForm = new Form
      {
        Width = Screen.PrimaryScreen.Bounds.Width,
        Height = Screen.PrimaryScreen.Bounds.Height
      };
      Game.Init(mainForm);
      mainForm.Show();
      Game.Load();
      Game.Draw();

      Application.Run(mainForm);
    }
  }
}
