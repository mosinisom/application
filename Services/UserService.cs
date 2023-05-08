using System.Collections.Generic;
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

    public void AddEmployee(Dictionary<string, object> user) =>
        _queryProxy.Create().Query()
            .From("employees")
            .Insert(user);

}