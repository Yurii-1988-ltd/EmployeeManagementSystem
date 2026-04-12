

namespace EmployeeManagementSystem.Contracts;

public interface ILoggerManager
{
    void LogInfo(string message);
    void LogWarn(string message);
    void LogDebug(string Message);
    void LogError(string message);
}
