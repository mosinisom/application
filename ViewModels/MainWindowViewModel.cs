using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reactive;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ReactiveUI;

namespace application.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public event PropertyChangedEventHandler PropertyChanged;

    public string Greeting => "Добро пожаловать!";
    private List<Employee> _emloyeeitems;
    private List<Department> _departmentitems;
    private Employee _selectedEmployee;
    private string _selectedEmail = "alexmosin@inbox.ru";
    public string email { get; set; } = "alexmosin@inbox.ru";
    private readonly Data _data;
    private Employee _newEmployee = new Employee();
    private Department _newDepartment = new Department();
    private Position _newPosition = new Position();
    private Project _newProject = new Project();
    private ProjectParticipation _newProjectParticipation = new ProjectParticipation();


    public MainWindowViewModel(Data data)
    {
        _data = data;
        EmployeeItems = _data.GetEmployees();
        DepartmentItems = _data.GetDepartments();

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

    public List<string> Departments
    {
        get
        {
            List<string> departments = new List<string>();
            foreach (var item in DepartmentItems)
            {
                departments.Add(item.departmentid + item.departmentname);
            }
            return departments;
        }
    }


    public List<Employee> EmployeeItems
    {
        get => _emloyeeitems;
        set
        {
            _emloyeeitems = value;
            OnPropertyChanged(nameof(EmployeeItems));
            OnPropertyChanged(nameof(emails));
        }
    }

    public List<Department> DepartmentItems
    {
        get => _departmentitems;
        set
        {
            _departmentitems = value;
            OnPropertyChanged(nameof(DepartmentItems));
            OnPropertyChanged(nameof(Departments));
        }
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

    // добавить нового сотрудника --------------------------------------------
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

    // добавить новый отдел -------------------------------------------------
    public Department NewDepartment
    {
        get => _newDepartment;
        set 
        {
            this.RaiseAndSetIfChanged(ref _newDepartment, value);
            OnPropertyChanged(nameof(Departments));
        }    
    }

    public void AddDepartment()
    {
        if (!CanAddDepartment())
            return;

        _data.AddDepartment(NewDepartment);
        DepartmentItems = _data.GetDepartments();

        NewDepartment = new Department();
    }

    private bool CanAddDepartment()
    {
        if (NewDepartment.departmentname.Length == 0)
            return false;
        return true;
    }


















}
