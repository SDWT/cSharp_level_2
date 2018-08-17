using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeList
{
  /// <summary>
  /// Класс подразделеления
  /// </summary>
  public class Department
  {
    #region Static Properties
    /// <summary>
    /// Список отделов
    /// </summary>
    public static List<Department> Departments { get; } = new List<Department>();

    /// <summary>
    /// Отдел по умолчанию
    /// </summary>
    public static Department DefaultDepartment { get => Departments[0]; }

    #endregion

    #region Static Methods
    /// <summary>
    /// Статический конструктор
    /// </summary>
    static Department()
    {
      Departments.Add(new Department("Undefined"));
    }

    /// <summary>
    /// Метод добавления отдела
    /// </summary>
    /// <param name="Name">Название отдела</param>
    public static void AddDepartment(string Name)
    {
      if (Find(Name) == Department.DefaultDepartment)
        Departments.Add(new Department(Name));
    }

    /// <summary>
    /// Метод поиска отдела по названию
    /// </summary>
    /// <param name="Name">Название</param>
    /// <returns>Отдел</returns>
    public static Department Find(string Name)
    {
      var dept = Departments.Find((a) => { return a.Name == Name; });
      return (dept == null) ? Department.DefaultDepartment : dept;
    }

    /// <summary>
    /// Метод поиска отдела по номеру
    /// </summary>
    /// <param name="index">Номер</param>
    /// <returns>Отдел</returns>
    public static Department Find(int index)
    {
      return (index >= Departments.Count) ? Department.DefaultDepartment : Departments[index];
    }

    //public static void LoadDepartment(string data)
    //{
    //  new Department(data);
    //}
    #endregion

    #region Properties
    /// <summary>
    /// Номер отдела
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Имя отдела
    /// </summary>
    public string Name { get; }

    #endregion

    #region Methods
    /// <summary>
    /// Конструктор отдела
    /// </summary>
    /// <param name="Name">Имя отдела</param>
    private Department(string Name)
    {
      this.Name = Name;
      this.Id = Departments.Count;
    }

    /// <summary>
    /// Переопределение метода преобразования отдела в строку
    /// </summary>
    /// <returns>Строка</returns>
    public override string ToString()
    {
      return $"{Name}";
    }
    #endregion

  }
}
