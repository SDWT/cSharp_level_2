using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        "Economic",
        "Economic"
      };


      foreach (var dep in Departs)
      {
        Department.AddDepartment(dep);
      }
      Employee.AddEmployee("Dima", Department.Find("Probation"));
      Employee.AddEmployee("Kid", Department.Departments[2]);
      Employee.AddEmployee("Vs", Department.Departments[3]);
      Employee.AddEmployee("Cat", Department.Departments[4]);
      
      InitializeComponent();
      if (lbEmployee.SelectedIndex == -1)
      {
        cbDepartments.IsEnabled = false;
        tbEditName.IsEnabled = false;
      }
      lbEmployee.DataContext = Employee.Employees;
      cbDepartments.ItemsSource = Department.Departments;
      cbDepartments.SelectionChanged += CbDepartments_SelectionChanged;
    }

    private void CbDepartments_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      Employee.Employees[lbEmployee.SelectedIndex].DepartmentId = cbDepartments.SelectedIndex;
    }

    private void lbEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (lbEmployee.SelectedIndex == -1)
      {
        cbDepartments.IsEnabled = false;
        tbEditName.IsEnabled = false;
        return;
      }

      cbDepartments.IsEnabled = true;
      cbDepartments.SelectedIndex = Employee.Employees[lbEmployee.SelectedIndex].DepartmentId;
      tbEditName.IsEnabled = true;
      tbEditName.Text = Employee.Employees[lbEmployee.SelectedIndex].Name;

    }
  }
}
