using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeList
{
  /// <summary>
  /// Класс работника
  /// </summary>
  class Employee
  {
    public static List<Employee> Employees { get; } = new List<Employee>();
    private static int _count = 0;

    public int Id { get; }

    public string Name { get; }

    public int DepartmentId { get; set; }

    private Employee(string Name, Department Department) 
    {
      this.Name = Name;
      this.Id = _count++;
      this.DepartmentId = Department.Id;
    }

    public static void AddEmployee(string Name, Department Department)
    {
      Employees.Add(new Employee(Name, Department));
    }

    public override string ToString()
    {
      return $"{Name} - {Department.Departments[DepartmentId]}";
    }
  }
}
