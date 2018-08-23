using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeList
{
  /// <summary>
  /// Класс подразделеления
  /// </summary>
  public class Department : INotifyPropertyChanged
  {
    #region Properties

    /// <summary>
    /// Номер отдела
    /// </summary>
    public int Id { get; }

    private string name;

    /// <summary>
    /// Имя отдела
    /// </summary>
    public string Name
    {
      get => name;
      set
      {
        if (this.name != value)
        {
          this.name = value;
          this.NotifyPropertyChanged("Name");
        }
      }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Конструктор отдела
    /// </summary>
    /// <param name="Name">Имя отдела</param>
    public Department(string Name, int id)
    {
      this.name = Name;
      this.Id = id;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void NotifyPropertyChanged(string propName)
    {
      this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
    /// <summary>
    /// Переопределение метода преобразования отдела в строку
    /// </summary>
    /// <returns>Строка</returns>
    //public override string ToString()
    //{
    //  return $"{Name}";
    //}
    #endregion

  }
}
