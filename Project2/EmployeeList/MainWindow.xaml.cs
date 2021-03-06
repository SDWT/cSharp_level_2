﻿using System;
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
      Model.LoadData();
      
      InitializeComponent();

      cbDepartments.ItemsSource = Model.Departments;
      cbDepartmentsAddDept.ItemsSource = Model.Departments;
      cbDepartmentsAddEmp.ItemsSource = Model.Departments;

      lvEmployee.ItemsSource = Model.Employees;

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
      var answer = MessageBox.Show("Если вы хотите перезагрузить данные работников, чтобы отобразить изменения Департаментов, то нажмите Ок.", "Перезагрузка данных", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Cancel);
      if (answer.HasFlag(MessageBoxResult.OK))
      {
        lvEmployee.ItemsSource = null;
        lvEmployee.ItemsSource = Model.Employees;
      }

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
