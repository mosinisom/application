using System.Collections.Generic;
using System.Linq;
using SqlKata.Execution;

public class UserService
{
    private readonly IDBQueryProxy _queryProxy;

    public UserService(IDBQueryProxy queryProxy)
    {
        _queryProxy = queryProxy;
    }

    public bool CheckExistance(string email) =>
        _queryProxy.Create().Query()
            .From("employees")
            .Where("email", email)
            .Exists();

    public int GetLastId() =>
        _queryProxy.Create().Query()
            .From("employees")
            .Max<int>("employeeid");

    public void AddEmployee(Employee user) {
            if (CheckExistance(user.email))
            {
                return;
            }
            
            user.employeeid = GetLastId() + 1;
            _queryProxy.Create().Query()
                .From("employees")
                .Insert(user);
    }

    public List<Employee> GetEmployees() =>
        _queryProxy.Create().Query()
            .From("employees")
            .Get<Employee>().ToList();


    public void UpdateEmployee(Employee employee) =>
        _queryProxy.Create().Query()
            .From("employees")
            .Where("employeeid", employee.employeeid)
            .Update(employee);

    public void DeleteEmployee(Employee employee) =>
        _queryProxy.Create().Query()
            .From("employees")
            .Where("employeeid", employee.employeeid)
            .Delete();
    

    public Employee GetEmployeeById(int id) =>
        _queryProxy.Create().Query()
            .From("employees")
            .Where("employeeid", id)
            .FirstOrDefault<Employee>();

    public Employee GetEmployeeByEmail(string email) =>
        _queryProxy.Create().Query()
            .From("employees")
            .Where("email", email)
            .FirstOrDefault<Employee>();

    public List<Employee> GetEmployeesByDepartmentId(int departmentId) =>
        _queryProxy.Create().Query()
            .From("employees")
            .Where("departmentid", departmentId)
            .Get<Employee>().ToList();

    public List<Employee> GetEmployeesByPositionId(int positionId) =>
        _queryProxy.Create().Query()
            .From("employees")
            .Where("positionid", positionId)
            .Get<Employee>().ToList();

    public List<Employee> GetEmployeesByProjectId(int projectId) =>
        _queryProxy.Create().Query()
            .From("projectparticipation")
            .Where("projectid", projectId)
            .Join("employees", "projectparticipation.employeeid", "employees.employeeid")
            .Get<Employee>().ToList();

    public void attendWork(int employee) =>
        _queryProxy.Create().Query()
            .From("employeeattendance")
            .Insert(new EmployeeAttendance
            {
                employeeid = employee,
                attendancedate = System.DateTime.Now
            });

    public int GetAllAttendancesByEmployeeId(int employeeId) =>
        _queryProxy.Create().Query()
            .From("employeeattendance")
            .Where("employeeid", employeeId)
            .Count<int>();




}