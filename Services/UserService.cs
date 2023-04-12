using SqlKata.Execution;

class UserService
{
    private readonly IDBQueryProxy _queryProxy;

    public UserService(IDBQueryProxy queryProxy)
    {
        _queryProxy = queryProxy;
    }

    public bool CheckExistance(string email) =>
        _queryProxy.Create().Query()
            .From("users")
            .Where("email", email)
            .Exists();

}