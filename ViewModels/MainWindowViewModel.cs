using System.Collections.Generic;
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





    public MainWindowViewModel(Data data)
    {
        _data = data;
        EmployeeItems = _data.GetEmployees();
    }

    public string MyData
    {
        get => _data.MyData;
        set => _data.MyData = value;
    }

    public List<string> emails
    {
        get
        {
            List<string> emails = new List<string>();
            foreach (var item in EmployeeItems)
            {
                emails.Add(item.Email);
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
        set {
            this.RaiseAndSetIfChanged(ref _selectedEmail, value);
            UpdateSelectedEmployee();
        }
    }


    private void UpdateSelectedEmployee()
    {
        SelectedEmployee = EmployeeItems.Find(x => x.Email == SelectedEmail);
        _data.attendWork(SelectedEmployee.EmployeeID);
    }
     
    


    public Employee SelectedEmployee
    {
        get => _selectedEmployee;
        set => this.RaiseAndSetIfChanged(ref _selectedEmployee, value);
    }
}
