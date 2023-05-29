using System;
using System.Collections.Generic;
using System.Reactive;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ReactiveUI;

namespace application.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting => "Добро пожаловать!";
    private List<Employee> _emloyeeitems;
    private Employee _selectedEmployee;
    private string _selectedEmail = "alexmosin@inbox.ru";
    public string email { get; set; } = "alexmosin@inbox.ru";
    private readonly Data _data;
    public Employee _newEmployee = new Employee();


    public MainWindowViewModel(Data data)
    {
        _data = data;
        EmployeeItems = _data.GetEmployees();

        // NewEmployee.dateofbirth = DateTime.Now - TimeSpan.FromDays(365 * 18);
        // NewEmployee.hiredate = DateTime.Now;
    }

    public List<string> emails
    {
        get
        {
            List<string> emails = new List<string>();
            foreach (var item in EmployeeItems)
            {
                emails.Add(item.email);
            }
            return emails;
        }
    }


    public List<Employee> EmployeeItems
    {
        get => _emloyeeitems;
        set => this.RaiseAndSetIfChanged(ref _emloyeeitems, value);
    }

    public string SelectedEmail
    {
        get => _selectedEmail;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedEmail, value);
            UpdateSelectedEmployee();
        }
    }

    private void UpdateSelectedEmployee()
    {
        SelectedEmployee = EmployeeItems.Find(x => x.email == SelectedEmail);
        _data.attendWork(SelectedEmployee.employeeid);
    }


    public Employee SelectedEmployee
    {
        get => _selectedEmployee;
        set => this.RaiseAndSetIfChanged(ref _selectedEmployee, value);
    }

    // добавить нового сотрудника
    public Employee NewEmployee
    {
        get => _newEmployee;
        set => this.RaiseAndSetIfChanged(ref _newEmployee, value);
    }


    public void AddEmployee()
    {
        if (!CanAddEmployee())
            return;

        _data.AddEmployee(NewEmployee);
        EmployeeItems = _data.GetEmployees();
        NewEmployee = new Employee();
    }

    private bool CanAddEmployee()
    {
        if (NewEmployee.email.Length == 0)
            return false;
        return true;
    }


















}
