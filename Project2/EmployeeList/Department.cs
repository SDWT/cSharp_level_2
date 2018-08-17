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
  class Department
  {
    public static List<Department> Departments { get; } = new List<Department>();

    public static Department DefaultDepartment { get => Departments[0]; }

    static Department()
    {
      Departments.Add(new Department("Undefined"));
    }

    public static void AddDepartment(string Name)
    {
      if (Find(Name) == Department.DefaultDepartment)
        Departments.Add(new Department(Name));
    }

    public static Department Find(string Name)
    {
      var dept = Departments.Find((a) => { return a.Name == Name; });
      return (dept == null) ? Department.DefaultDepartment : dept;

    }

    public int Id { get; }

    public string Name { get; }

    private Department(string Name)
    {
      this.Name = Name;
      this.Id = Departments.Count;
    }

    //public static void LoadDepartment(string data)
    //{
    //  new Department(data);
    //}

    
    public override string ToString()
    {
      return $"{Name}";
    }



  }
}
