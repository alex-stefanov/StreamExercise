using OfficeOpenXml;

namespace Stefko;

class ExcelLogger(
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
    {
        using var package = new ExcelPackage();

        var sheet = package.Workbook.Worksheets
            .Add("Log");

        for (int i = 0; i < logs.Count; i++)
        {
            sheet.Cells[i + 1, 1].Value = logs[i];
        }

        File.WriteAllBytes(path, package.GetAsByteArray());
    }
}
