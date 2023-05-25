using System.Collections.Generic;
using ReactiveUI;

namespace application.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting => "Добро пожаловать!";

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

    public bool CheckExistance() {
        return _data.CheckExistance("alexmosin@inbox.ru");
    }

    public string str //= CheckExistance().ToString();
    {
        get => _data.CheckExistance("alexmosin@inbox.ru").ToString();
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

    private string _selectedEmail = "alexmosin@inbox.ru";

    public string SelectedEmail
    {
        get => _selectedEmail;
        set => this.RaiseAndSetIfChanged(ref _selectedEmail, value);
    }

    private List<Employee> _emloyeeitems;
    public List<Employee> EmployeeItems
    {
        get => _emloyeeitems;
        set => this.RaiseAndSetIfChanged(ref _emloyeeitems, value);
    }

    // Свойство, которое будет хранить выбранный элемент
    private Employee _selectedEmployee;
    public Employee SelectedEmployee
    {
        get => _selectedEmployee;
        set => this.RaiseAndSetIfChanged(ref _selectedEmployee, value);
    }
}
