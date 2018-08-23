using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeList
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    /// <summary>
    /// Конструктор главного окна
    /// </summary>
    public MainWindow()
    {
      string[] Departs =
      {
        "Probation",
        "Menegment",
        "Bookkeeping",
        "Design",
        "Programming",
        "Testing",
        "Economic"
      };


      foreach (var dep in Departs)
      {
        Model.AddDepartment(dep);
      }
      Model.AddEmployee("Dima", "Probation", 10);
      Model.AddEmployee("Kid", "Menegment", 200);
      Model.AddEmployee("Vs", "Bookkeeping", 500);
      Model.AddEmployee("Cat", "Design", 1000);
      
      InitializeComponent();

      //cbDepartments.DataContext = Model.Departments;
      //cbDepartmentsAddDept.DataContext = Model.Departments;
      //cbDepartmentsAddEmp.DataContext = Model.Departments;

      cbDepartments.ItemsSource = Model.Departments;
      cbDepartmentsAddDept.ItemsSource = Model.Departments;
      cbDepartmentsAddEmp.ItemsSource = Model.Departments;

      //cbDepartments.SetBinding()

      //if (lvEmployee.SelectedIndex == -1)
      //{
      //  cbDepartments.IsEnabled = true;
      //}

      //cbDepartments.IsEditable = true;

      lvEmployee.ItemsSource = Model.Employees;
      //lbEmployee.ItemsSource = Model.Employees;
      //lbEmployee.SelectionChanged += lbEmployee_SelectionChanged;
      //cbDepartments.ItemsSource = Model.Departments;
      //cbDepartmentsAddEmp.ItemsSource = Model.Departments;
      //cbDepartmentsAddEmp.SelectedIndex = -1;
      //cbDepartmentsAddDept.ItemsSource = Model.Departments;
      //cbDepartmentsAddDept.SelectedIndex = -1;

      // Employee Editor
      saveEditEmp.Click += SaveEditEmpButton_Click;
      resetEditEmp.Click += ResetEditEmpButton_Click;

      // Employee Adding
      saveAddEmp.Click += SaveAddEmpButton_Click;
      resetAddEmp.Click += ResetAddEmpButton_Click;

      // Department Adding
      saveAddDept.Click += SaveAddDeptButton_Click;
      resetAddDept.Click += ResetAddDeptButton_Click;
    }

    /// <summary>
    /// Обработчик нажатия на кнопку отменить в добавлении департамента
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ResetAddDeptButton_Click(object sender, RoutedEventArgs e)
    {
      tbAddDept.Text = string.Empty;
      cbDepartmentsAddDept.SelectedIndex = -1;
    }

    /// <summary>
    /// Обработчик нажатия на кнопку добавить в добавлении департамента
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SaveAddDeptButton_Click(object sender, RoutedEventArgs e)
    {
      int index = cbDepartmentsAddDept.SelectedIndex;
      if (index > 0)
      {
        Model.EditDepartment(index, tbAddDept.Text);

      }
      else
        Model.AddDepartment(tbAddDept.Text);

      // Костыль
      //cbDepartments.ItemsSource = new List<int>();
      //cbDepartmentsAddDept.ItemsSource = new List<int>();
      //cbDepartmentsAddEmp.ItemsSource = new List<int>();

      //cbDepartments.ItemsSource = Model.Departments;
      //cbDepartmentsAddDept.ItemsSource = Model.Departments;
      //cbDepartmentsAddEmp.ItemsSource = Model.Departments;

      //lvEmployee.ItemsSource = new List<int>();
      //lvEmployee.ItemsSource = Model.Employees;

      cbDepartmentsAddDept.SelectedIndex = -1;
    }

    /// <summary>
    /// Обработчик нажатия на кнопку отменить в добавлении сотрудника
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ResetAddEmpButton_Click(object sender, RoutedEventArgs e)
    {
      tbAddEmp.Text = string.Empty;
      cbDepartmentsAddEmp.SelectedIndex = -1;
    }

    /// <summary>
    /// Обработчик нажатия на кнопку добавить в добавлении сотрудника
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SaveAddEmpButton_Click(object sender, RoutedEventArgs e)
    {
      int index = cbDepartmentsAddEmp.SelectedIndex;
      if (index > -1)
      {
        Model.AddEmployee(tbAddEmp.Text, index, -1); // Change Salary

        // Костыль
        //lvEmployee.ItemsSource = new List<int>();
        //lvEmployee.ItemsSource = Model.Employees;
        cbDepartmentsAddEmp.SelectedIndex = -1;
      }
      
    }

    /// <summary>
    /// Обработчик смены выбранного элемента в списке сотрудников
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void lvEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      int id = lvEmployee.SelectedIndex;
      if (id > -1)
      {
        cbDepartments.SelectedIndex = Model.Employees[id].DepartmentId;
        lEditName.Content = Model.Employees[id].Name;

        cbDepartments.IsEnabled = true;
        // Костыль
        lvEmployee.SelectedIndex = id;
      }
    }

    //private void lbEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //{
    //  int id = lbEmployee.SelectedIndex;
    //  if (id > -1)
    //  {
    //    cbDepartments.SelectedIndex = Model.Employees[id].DepartmentId;
    //    lEditName.Content = Model.Employees[id].Name;

    //    cbDepartments.IsEnabled = true;
    //    // Костыль
    //    lbEmployee.SelectedIndex = id;
    //  }
    //}

    /// <summary>
    /// Обработчик нажатия на кнопку сохранить в редактировании сотрудника
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SaveEditEmpButton_Click(object sender, RoutedEventArgs e)
    {
      int id = lvEmployee.SelectedIndex;
      if (id > -1)
      {
        Model.Employees[id].DepartmentId = cbDepartments.SelectedIndex;
        
        // Костыль
        //lvEmployee.ItemsSource = new List<int>();
        //lvEmployee.ItemsSource = Model.Employees;
        // Костыль
        lvEmployee.SelectedIndex = id;
      }
      
    }

    /// <summary>
    /// Обработчик нажатия на кнопку отменить в редактировании сотрудника
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ResetEditEmpButton_Click(object sender, RoutedEventArgs e)
    {
      int id = lvEmployee.SelectedIndex;
      if (id > -1)
      {
        cbDepartments.SelectedIndex = Model.Employees[lvEmployee.SelectedIndex].DepartmentId;
        lEditName.Content = Model.Employees[lvEmployee.SelectedIndex].Name;
        // Костыль
        lvEmployee.SelectedIndex = id;
      }
    }

    /// <summary>
    /// Обработчик нажатия на клавиши клавиатуры
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Escape)
      {
        MainWindowApplication.Close();
      }
    }
  }
}
