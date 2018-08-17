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

      if (lbEmployee.SelectedIndex == -1)
      {
        cbDepartments.IsEnabled = false;
        tbEditName.IsEnabled = false;
      }
      lbEmployee.ItemsSource = Employee.Employees;
      cbDepartments.ItemsSource = Department.Departments;
      cbDepartments.SelectionChanged += CbDepartments_SelectionChanged;
    }

    /// <summary>
    /// Обработчик смены выбранного элемента в списке отделов
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CbDepartments_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      Employee.Employees[lbEmployee.SelectedIndex].DepartmentId = cbDepartments.SelectedIndex;
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
        cbDepartments.IsEnabled = false;
        tbEditName.IsEnabled = false;
        return;
      }
      cbDepartments.SelectedIndex = Employee.Employees[lbEmployee.SelectedIndex].DepartmentId;
      tbEditName.Text = Employee.Employees[lbEmployee.SelectedIndex].Name;

      cbDepartments.IsEnabled = true;
      tbEditName.IsEnabled = true;
    }
  }
}
