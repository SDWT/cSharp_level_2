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

      cbDepartments.IsEditable = true;
      lbEmployee.ItemsSource = Employee.Employees;
      cbDepartments.ItemsSource = Department.Departments;
      saveEditEmp.Click += SaveEditEmpButton_Click;
      resetEditEmp.Click += ResetEditEmpButton_Click;
    }

    /// <summary>
    /// Обработчик смены выбранного элемента в списке сотрудников
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void lbEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (lbEmployee.SelectedIndex == -1)
      {
        return;
      }
      cbDepartments.SelectedIndex = Employee.Employees[lbEmployee.SelectedIndex].DepartmentId;
      lEditName.Content = Employee.Employees[lbEmployee.SelectedIndex].Name;

      cbDepartments.IsEnabled = true;
    }

    /// <summary>
    /// Обработчик нажатия на кнопку сохранить в редактировании сотрудника
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SaveEditEmpButton_Click(object sender, RoutedEventArgs e)
    {
      if (lbEmployee.SelectedIndex == -1)
      {
        return;
      }
      Employee.Employees[lbEmployee.SelectedIndex].DepartmentId = cbDepartments.SelectedIndex;

      // Костыль
      lbEmployee.ItemsSource = new List<int>();
      lbEmployee.ItemsSource = Employee.Employees;
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
