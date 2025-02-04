namespace Stefko;

public interface ILog
{
    void Log(
        string message);

    void SaveLog(
        string path);
}