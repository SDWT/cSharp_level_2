using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeList
{
  class Model
  {
    #region Model

    /// <summary>
    /// Статический конструктор
    /// </summary>
    static Model()
    {
      Departments.Add(new Department("Undefined", Departments.Count));
    }

    #endregion

    #region Department Properties
    /// <summary>
    /// Список отделов
    /// </summary>
    public static List<Department> Departments { get; } = new List<Department>();

    /// <summary>
    /// Отдел по умолчанию
    /// </summary>
    public static Department DefaultDepartment { get => Departments[0]; }

    #endregion

    #region Department Methods
    
    /// <summary>
    /// Метод добавления отдела
    /// </summary>
    /// <param name="Name">Название отдела</param>
    public static void AddDepartment(string Name)
    {
      if (FindDepartment(Name) == DefaultDepartment)
        Departments.Add(new Department(Name, Departments.Count));
    }

    /// <summary>
    /// Метод поиска отдела по названию
    /// </summary>
    /// <param name="Name">Название</param>
    /// <returns>Отдел</returns>
    public static Department FindDepartment(string Name)
    {
      var dept = Departments.Find((a) => { return a.Name == Name; });
      return (dept == null) ? DefaultDepartment : dept;
    }

    /// <summary>
    /// Метод поиска отдела по номеру
    /// </summary>
    /// <param name="index">Номер</param>
    /// <returns>Отдел</returns>
    public static Department FindDepartment(int index)
    {
      return (index >= Departments.Count || index < 0) ? DefaultDepartment : Departments[index];
    }

    /// <summary>
    /// Изменить название отдела
    /// </summary>
    /// <param name="index">Номер отдела</param>
    /// <param name="NewName">Новое имя отдела</param>
    /// <returns></returns>
    public static bool EditDepartment(int index, string NewName)
    {
      if (FindDepartment(NewName) == DefaultDepartment)
      {
        FindDepartment(index).Name = NewName;
        return true;
      }
      return false;
    }

    //public static void LoadDepartment(string data)
    //{
    //  new Department(data);
    //}
    #endregion

    #region Employee Properties
    /// <summary>
    /// Список сотрудников
    /// </summary>
    public static ObservableCollection<Employee> Employees { get; } = new ObservableCollection<Employee>();
    #endregion

    #region Employee Methods
    /// <summary>
    /// Метод добавления сотрудника
    /// </summary>
    /// <param name="Name">Имя</param>
    /// <param name="Department">Отдел</param>
    public static void AddEmployee(string Name, string Department, int Salary)
    {
      Employees.Add(new Employee(Name, Employees.Count, FindDepartment(Department), Salary));
    }

    /// <summary>
    /// Метод добавления сотрудника
    /// </summary>
    /// <param name="Name">Имя</param>
    /// <param name="Department">Отдел</param>
    public static void AddEmployee(string Name, int Department, int Salary)
    {
      Employees.Add(new Employee(Name, Employees.Count, FindDepartment(Department), Salary));
    }
    #endregion

  }
}
