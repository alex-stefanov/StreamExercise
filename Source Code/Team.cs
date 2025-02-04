using System.Text;

namespace Stefko;

public class Team
{
    public Team(
        string name)
    {
        this.Name = name;
        this.teamLogs = new StringBuilder();

        teamLogs.AppendLine($"Отбор {this.Name} е създаден на {DateTime.Now}.");
    }

    private StringBuilder teamLogs;

    private string name;

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrEmpty(value)
                || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Name not specified.");
            }

            this.name = value;
        }
    }

    private readonly List<Player> players = [];

    public IReadOnlyList<Player> Players
        => this.players.AsReadOnly();

    public void AddPlayer(
        Player player,
        string position)
    {
        player.AssignPosition(position);

        this.players.Add(player);

        teamLogs.AppendLine($"Играч {player.Name} ({player.Position}) се присъедени към отбор {this.Name} на {DateTime.Now}.");
    }

    public void RemovePlayer(
        Player player)
    {
        if (!players.Remove(player))
        {
            teamLogs.AppendLine($"Играч {player.Name} ({player.Position}) не успя да бъде премахнат от отбор {this.Name} на {DateTime.Now}.");

            throw new ArgumentException($"Играч {player.Name} ({player.Position}) не успя да бъде премахнат от отбор {this.Name}.");
        }

        teamLogs.AppendLine($"Играч {player.Name} ({player.Position}) беше премахнат от отбор {this.Name} на {DateTime.Now}.");
    }

    public void LogTeam(
        ILog logger)
    {
        var sb = new StringBuilder();

        sb.AppendLine($"Отбор {this.Name}: ");

        foreach (Player player in this.Players)
        {
            sb.AppendLine($"-- {player.Name} ({player.Position})");
        }

        sb.AppendLine($"Играчи общо: {this.Players.Count}.");

        sb.AppendLine($"Пълен разчет: ");

        sb.Append(this.teamLogs.ToString());

        sb.AppendLine($"Край на разчета.");

        logger.Log(sb.ToString().Trim());
    }

    public void SaveLog(
        ILog logger,
        string path)
        => logger.SaveLog(path);
}