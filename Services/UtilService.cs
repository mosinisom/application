using System.Collections.Generic;
using System.Linq;
using SqlKata.Execution;

public class UtilService
{
    private readonly IDBQueryProxy _queryProxy;

    public UtilService(IDBQueryProxy queryProxy)
    {
        _queryProxy = queryProxy;
    }

    public List<Department> GetDepartments() =>
        _queryProxy.Create().Query()
            .From("departments")
            .Get<Department>().ToList();

    public List<Position> GetPositions() =>
        _queryProxy.Create().Query()
            .From("positions")
            .Get<Position>().ToList();

    public List<Project> GetProjects() =>
        _queryProxy.Create().Query()
            .From("projects")
            .Get<Project>().ToList();

    public List<object> GetProjectParticipations() =>
        _queryProxy.Create().Query()
            .From("projectparticipations")
            .Join("employees", "projectparticipations.employeeid", "employees.employeeid")
            .Join("projects", "projectparticipations.projectid", "projects.projectid")
            .Select("projectparticipations.projectid", "projects.projectname", "projectparticipations.startdate", "projectparticipations.enddate", "employees.firstname", "employees.lastname")
            .Get<object>().ToList();

    public void AddNewDepartment(Department department) =>
        _queryProxy.Create().Query()
            .From("departments")
            .Insert(department);

    public void AddNewPosition(Position position) =>
        _queryProxy.Create().Query()
            .From("positions")
            .Insert(position);

    public void AddNewProject(Project project) =>
        _queryProxy.Create().Query()
            .From("projects")
            .Insert(project);

















}