using System;
using System.Collections.Generic;

public class Data
{
    UserService _userService;
    Employee userEmployee = new Employee();
    List<Department> departments = new List<Department>();
    List<Position> positions = new List<Position>();
    List<Project> projects = new List<Project>();
    List<ProjectParticipation> projectParticipations = new List<ProjectParticipation>();

    public Data (UserService userService)
    {
        _userService = userService;
    }

    // string email = "alexmosin@inbox.ru";

    Dictionary<string, object> user = new Dictionary<string, object>()
    {
        {"firstname", "Alex"},
        {"lastname", "Mosin"},
        {"email", "mosin@inbox.ru"},
        {"phonenumber", "1234567890"},
        {"dateofbirth", "1999-01-01"},
        {"hiredate", "2021-01-01"},
        {"departmentid", 1},
        {"positionid", 1}
    };

    public bool CheckExistance(string email) { return _userService.CheckExistance(email);}

    public void AddEmployee(Employee user) { _userService.AddEmployee(user);}

    public string MyData { get; set; } = "Hello World";

    public List<Employee> GetEmployees() { return _userService.GetEmployees();}

    public void UpdateEmployee(Employee employee) { _userService.UpdateEmployee(employee);}

    public void DeleteEmployee(Employee employee) { _userService.DeleteEmployee(employee);}

    public Employee GetEmployeeById(int id) { return _userService.GetEmployeeById(id);}

    public Employee GetEmployeeByEmail(string email) { return _userService.GetEmployeeByEmail(email);}

    public List<Employee> GetEmployeesByDepartmentId(int departmentId) { return _userService.GetEmployeesByDepartmentId(departmentId);}

    // public List<Department> GetDepartments() { return departments;}  

    public List<Employee> GetEmployeesByPositionId(int positionId) { return _userService.GetEmployeesByPositionId(positionId);}

    public List<Employee> GetEmployeesByProjectId(int projectId) { return _userService.GetEmployeesByProjectId(projectId);}

    public void attendWork(int employeeid) { _userService.attendWork(employeeid);}

}