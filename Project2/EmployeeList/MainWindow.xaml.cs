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
        Department.AddDepartment(dep);
      }
      Employee.AddEmployee("Dima", Department.Find("Probation"));
      Employee.AddEmployee("Kid", Department.Find("Menegment"));
      Employee.AddEmployee("Vs", Department.Find("Bookkeeping"));
      Employee.AddEmployee("Cat", Department.Find("Design"));
      
      InitializeComponent();

      //if (lbEmployee.SelectedIndex == -1)
      //{
      //  cbDepartments.IsEnabled = true;
      //}

      //cbDepartments.IsEditable = true;
      lbEmployee.ItemsSource = Employee.Employees;
      cbDepartments.ItemsSource = Department.Departments;
      cbDepartmentsAddEmp.ItemsSource = Department.Departments;
      cbDepartmentsAddEmp.SelectedIndex = -1;
      cbDepartmentsAddDept.ItemsSource = Department.Departments;
      cbDepartmentsAddDept.SelectedIndex = -1;

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
        Department.EditDepartment(index, tbAddDept.Text);

      }
      else
        Department.AddDepartment(tbAddDept.Text);

      // Костыль
      cbDepartments.ItemsSource = new List<int>();
      cbDepartmentsAddDept.ItemsSource = new List<int>();
      cbDepartmentsAddEmp.ItemsSource = new List<int>();

      cbDepartments.ItemsSource = Department.Departments;
      cbDepartmentsAddDept.ItemsSource = Department.Departments;
      cbDepartmentsAddEmp.ItemsSource = Department.Departments;

      lbEmployee.ItemsSource = new List<int>();
      lbEmployee.ItemsSource = Employee.Employees;

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
        Employee.AddEmployee(tbAddEmp.Text, Department.Find(index));

        // Костыль
        lbEmployee.ItemsSource = new List<int>();
        lbEmployee.ItemsSource = Employee.Employees;
        cbDepartmentsAddEmp.SelectedIndex = -1;
      }
      
    }

    /// <summary>
    /// Обработчик смены выбранного элемента в списке сотрудников
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void lbEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (lbEmployee.SelectedIndex > -1)
      {

        cbDepartments.SelectedIndex = Employee.Employees[lbEmployee.SelectedIndex].DepartmentId;
        lEditName.Content = Employee.Employees[lbEmployee.SelectedIndex].Name;

        cbDepartments.IsEnabled = true;
      }
    }

    /// <summary>
    /// Обработчик нажатия на кнопку сохранить в редактировании сотрудника
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SaveEditEmpButton_Click(object sender, RoutedEventArgs e)
    {
      if (lbEmployee.SelectedIndex > -1)
      {
        Employee.Employees[lbEmployee.SelectedIndex].DepartmentId = cbDepartments.SelectedIndex;

        // Костыль
        lbEmployee.ItemsSource = new List<int>();
        lbEmployee.ItemsSource = Employee.Employees;
      }
      
    }

    /// <summary>
    /// Обработчик нажатия на кнопку отменить в редактировании сотрудника
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ResetEditEmpButton_Click(object sender, RoutedEventArgs e)
    {
      cbDepartments.SelectedIndex = Employee.Employees[lbEmployee.SelectedIndex].DepartmentId;
      lEditName.Content = Employee.Employees[lbEmployee.SelectedIndex].Name;
    }
  }
}
