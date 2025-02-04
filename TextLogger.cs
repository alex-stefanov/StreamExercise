namespace Stefko;

public class TextLogger(
    params string[] logs)
    : ILog
{
    private readonly List<string> logs
        = [.. logs];

    public IReadOnlyList<string> Logs
        => logs.AsReadOnly();

    public void Log(
        string message)
        => logs.Add($"{DateTime.Now}: {message}");

    public void SaveLog(
        string path)
        => File.WriteAllLines(path, this.Logs);
}