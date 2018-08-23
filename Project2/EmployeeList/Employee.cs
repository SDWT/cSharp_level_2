using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeList
{
  /// <summary>
  /// Класс сотрудника
  /// </summary>
  public class Employee : INotifyPropertyChanged
  {
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
    /// Зарплата
    /// </summary>
    public int Salary { get; }

    private int did;

    /// <summary>
    /// Номер отдела
    /// </summary>
    public int DepartmentId
    {
      get => did;
      set
      {
        if (this.did != value)
        {
          this.did = value;
          this.NotifyPropertyChanged(nameof(DepartmentId));
        }
      }
    }

    /// <summary>
    /// Номер отдела
    /// </summary>
    public string Department { get => Model.FindDepartment(DepartmentId).Name; } // Change to converter
    #endregion

    #region Methods
    /// <summary>
    /// Конструктор сотрудника
    /// </summary>
    /// <param name="Name">Имя</param>
    /// <param name="Department">Отдел</param>
    public Employee(string Name, int Id, Department Department, int Salary) 
    {
      this.Name = Name;
      this.Id = Id;
      this.DepartmentId = Department.Id;
      this.Salary = Salary;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void NotifyPropertyChanged(string propName)
    {
      this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
    /// <summary>
    /// Переопределение метода преобразования сотрудника в строку
    /// </summary>
    /// <returns>Строка</returns>
    //public override string ToString()
    //{
    //  return $"{Name} - {Department.Find(DepartmentId)}";
    //}
    #endregion
  }
}
