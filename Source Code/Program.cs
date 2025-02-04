using Stefko;

HashSet<Team> teams = [];
HashSet<Player> players = [];

string? input = Console.ReadLine();

while (input != "exit")
{
    if (string.IsNullOrEmpty(input)
        || string.IsNullOrWhiteSpace(input))
    {
        continue;
    }

    string[] parts = input
        .Split(' ');

    if (parts.Length == 0)
    {
        continue;
    }

    switch (parts[0])
    {
        case "create_team":
            {
                if (parts.Length == 2)
                {
                    var newTeam = new Team(parts[1]);

                    teams.Add(newTeam);
                }

                break;
            }
        case "create_player":
            {
                if (parts.Length == 3)
                {
                    var newPlayer = new Player(parts[1], parts[2]);

                    players
                        .Add(newPlayer);
                }

                break;
            }
        case "add_player":
            {
                if (parts.Length == 4)
                {
                    Team foundTeam = teams.FirstOrDefault(x => x.Name == parts[1])
                        ?? throw new ArgumentException($"Team with name {parts[1]} not found.");

                    Player foundPlayer = players.FirstOrDefault(x => x.Name == parts[2])
                        ?? throw new ArgumentException($"Player with name {parts[2]} not found");

                    foundTeam
                         .AddPlayer(foundPlayer, parts[3]);
                }
                break;
            }
        case "remove_player":
            {
                if (parts.Length == 3)
                {
                    Team foundTeam = teams.FirstOrDefault(x => x.Name == parts[1])
                         ?? throw new ArgumentException($"Team with name {parts[1]} not found.");

                    Player foundPlayer = players.FirstOrDefault(x => x.Name == parts[2])
                        ?? throw new ArgumentException($"Player with name {parts[2]} not found");

                    foundTeam
                        .RemovePlayer(foundPlayer);
                }
                break;
            }
        case "print_team":
            {
                if (parts.Length == 4)
                {
                    Team foundTeam = teams.FirstOrDefault(x => x.Name == parts[1])
                         ?? throw new ArgumentException($"Team with name {parts[1]} not found.");

                    switch (parts[3].ToLower())
                    {
                        case "txt":
                            {
                                var textLogger = new TextLogger();

                                foundTeam.LogTeam(textLogger);

                                break;
                            }
                        case "xlsx":
                            {
                                var excelLogger = new ExcelLogger();

                                foundTeam.LogTeam(excelLogger);

                                break;
                            }
                        default:
                            {
                                throw new ArgumentException("Not a valid type of log!");
                            }
                    }
                }

                break;
            }
        case "print_log_txt":
            {
                if (parts.Length == 3)
                {

                    Team foundTeam = teams.FirstOrDefault(x => x.Name == parts[1])
                         ?? throw new ArgumentException($"Team with name {parts[1]} not found.");

                    var textLogger = new TextLogger();

                    foundTeam.SaveLog(textLogger, parts[2]);
                }

                break;
            }
        case "print_log_excel":
            {
                if (parts.Length == 3)
                {
                    Team foundTeam = teams.FirstOrDefault(x => x.Name == parts[1])
                         ?? throw new ArgumentException($"Team with name {parts[1]} not found.");

                    var excelLogger = new ExcelLogger();

                    foundTeam.SaveLog(excelLogger, parts[2]);
                }

                break;
            }
        default:
            {
                throw new ArgumentException("Not a valid comand!");
            }
    }
}