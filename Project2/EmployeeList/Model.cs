﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

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

      //LoadData();

      //foreach (var item in Employees)
      //{
      //  var sqlInto = string.Format(@"INSERT INTO Employee (Name, DepartmentId, Salary)
      //                              VALUES (N'{0}', '{1}', '{2}')", item.Name, item.DepartmentId, item.Salary);

      //  using (SqlConnection connection = new SqlConnection(strConnection))
      //  {
      //    connection.Open();
      //    SqlCommand command = new SqlCommand(sqlInto, connection);
      //    command.ExecuteNonQuery();
      //  }
      //}

      //foreach (var item in Departments)
      //{
      //  var sqlInto = string.Format(@"INSERT INTO Department (Name)
      //                              VALUES (N'{0}')", item.Name);

      //  using (SqlConnection connection = new SqlConnection(strConnection))
      //  {
      //    connection.Open();
      //    SqlCommand command = new SqlCommand(sqlInto, connection);
      //    command.ExecuteNonQuery();
      //  }
      //}


      //Employees.Clear();
      //Departments.Clear();
      //Departments.Add(new Department("Undefined", Departments.Count));
    }

    /// <summary>
    /// Метод загрузки данных
    /// </summary>
    public static void LoadData()
    {
      #region old data
      //string[] Departs =
      //{
      //  "Probation",
      //  "Menegment",
      //  "Bookkeeping",
      //  "Design",
      //  "Programming",
      //  "Testing",
      //  "Economic"
      //};
      //foreach (var dep in Departs)
      //{
      //  Model.AddDepartment(dep);
      //}
      //Model.AddEmployee("Dima", "Probation", 10);
      //Model.AddEmployee("Kid", "Menegment", 200);
      //Model.AddEmployee("Vs", "Bookkeeping", 500);
      //Model.AddEmployee("Cat", "Design", 1000);
      #endregion


      string strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

      SqlConnection connection = new SqlConnection(strConnection);
      SqlDataAdapter adapter = new SqlDataAdapter();

      connection.Open();
      SqlCommand command = new SqlCommand("SELECT Name FROM Department", connection);
      SqlDataReader dataReader = command.ExecuteReader();

      while (dataReader.Read())
      {
        AddDepartment((string)dataReader["Name"]);
      }
      dataReader.Close();

      command = new SqlCommand("SELECT * FROM Employee", connection);
      dataReader = command.ExecuteReader();

      while (dataReader.Read())
      {
        AddEmployee((string)dataReader["Name"], (int)dataReader["DepartmentId"], (int)dataReader["Salary"]);
      }

      return;
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


    void UpdateDepartment(Department Dept)
    {
      if (Dept.Id < 1)
        return;
      // Тут должен быть код для изменеия департамента в БД

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

    void UpdateEmployee(Employee Emp)
    {
      if (Emp.Id < 1)
        return;
      // Тут должен быть код для изменеия сотрудника в БД

    }
  }
}
