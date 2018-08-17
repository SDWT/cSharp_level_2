using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeList
{
  /// <summary>
  /// Класс сотрудника
  /// </summary>
  public class Employee
  {
    #region Static Properties
    /// <summary>
    /// Список сотрудников
    /// </summary>
    public static ObservableCollection<Employee> Employees { get; } = new ObservableCollection<Employee>();
    #endregion

    #region Static Methods
    /// <summary>
    /// Метод добавления сотрудника
    /// </summary>
    /// <param name="Name">Имя</param>
    /// <param name="Department">Отдел</param>
    public static void AddEmployee(string Name, Department Department)
    {
      Employees.Add(new Employee(Name, Department));
    }
    #endregion

    #region Properties
    /// <summary>
    /// Номер сотрудника
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Имя сотрудника
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Номер отдела
    /// </summary>
    public int DepartmentId { get; set; }
    #endregion

    #region Methods
    /// <summary>
    /// Конструктор сотрудника
    /// </summary>
    /// <param name="Name">Имя</param>
    /// <param name="Department">Отдел</param>
    private Employee(string Name, Department Department) 
    {
      this.Name = Name;
      this.Id = Employees.Count;
      this.DepartmentId = Department.Id;
    }

    /// <summary>
    /// Переопределение метода преобразования сотрудника в строку
    /// </summary>
    /// <returns>Строка</returns>
    public override string ToString()
    {
      return $"{Name} - {Department.Find(DepartmentId)}";
    }
    #endregion
  }
}
