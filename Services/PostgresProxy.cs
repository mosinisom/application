using SqlKata.Compilers;
using SqlKata.Execution;
using Npgsql;
using Microsoft.Extensions.Options;

class PostgresProxy : IDBQueryProxy
{
    private readonly IOptionsMonitor<UserServiceSettings> _userServiceMonitor;
    private UserServiceSettings _userServiceSettings => _userServiceMonitor.CurrentValue;
    private PostgresCompiler compiler;
    
    public PostgresProxy(IOptionsMonitor<UserServiceSettings> userServiceMonitor)
    {
        _userServiceMonitor = userServiceMonitor;
        compiler = new PostgresCompiler();
    }

    public QueryFactory Create() =>
        new QueryFactory(
            new NpgsqlConnection(_userServiceSettings.ConnectionString),
            compiler
        );
}