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

public int GetLastDepartmentId() =>
    _queryProxy.Create().Query()
        .From("departments")
        .Max<int>("departmentid");

public void AddNewDepartment(Department department)
{
    department.departmentid = GetLastDepartmentId() + 1;
    _queryProxy.Create().Query()
        .From("departments")
        .Insert(department);
}

public int GetLastPositionId() =>
    _queryProxy.Create().Query()
        .From("positions")
        .Max<int>("positionid");

public void AddNewPosition(Position position)
{
    position.positionid = GetLastPositionId() + 1;
    _queryProxy.Create().Query()
        .From("positions")
        .Insert(position);
}

public int GetLastProjectId() =>
    _queryProxy.Create().Query()
        .From("projects")
        .Max<int>("projectid");

public void AddNewProject(Project project)
{
    project.projectid = GetLastProjectId() + 1;
    _queryProxy.Create().Query()
        .From("projects")
        .Insert(project);
}

public int GetLastProjectParticipationId() =>
    _queryProxy.Create().Query()
        .From("projectparticipations")
        .Max<int>("projectparticipationid");

public void AddNewProjectParticipation(ProjectParticipation projectParticipation)
{
    projectParticipation.participationid = GetLastProjectParticipationId() + 1;
    _queryProxy.Create().Query()
        .From("projectparticipations")
        .Insert(projectParticipation);
}

    public void UpdateDepartment(Department department) =>
        _queryProxy.Create().Query()
            .From("departments")
            .Where("departmentid", department.departmentid)
            .Update(department);

    public void UpdatePosition(Position position) =>
        _queryProxy.Create().Query()
            .From("positions")
            .Where("positionid", position.positionid)
            .Update(position);

    public void UpdateProject(Project project) =>
        _queryProxy.Create().Query()
            .From("projects")
            .Where("projectid", project.projectid)
            .Update(project);

    public void UpdateProjectParticipation(ProjectParticipation projectParticipation) =>
        _queryProxy.Create().Query()
            .From("projectparticipations")
            .Where("projectid", projectParticipation.projectid)
            .Where("employeeid", projectParticipation.employeeid)
            .Update(projectParticipation);

            

















}