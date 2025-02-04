# 🏆 StreamsTask

## 📌 Description
StreamsTask is a C# console application that manages teams and players. It allows creating teams, adding and removing players, and logging actions into TXT and Excel files.

## 🎮 Features

### 📌 Main Commands:
- `create_team <team_name>` – Creates a new team.
- `create_player <name> <position>` – Creates a new player without adding them to a team.
- `add_player <team_name> <player_name> <position>` – Adds a player to a team.
- `remove_player <team_name> <player_name>` – Removes a player from a team.

### 📝 Logging and Output:
- `print_team <team_name> <file_path> <log_type (txt/xlsx)>` – Saves the team to a file.
- `print_log_txt <team_name> <file_path>` – Saves the team's history to a text file.
- `print_log_excel <team_name> <file_path>` – Saves the team's history to an Excel file.

### 📜 The team history includes:
- 📅 When the team was created.
- 🔄 When a player joined.
- ❌ When a player left.

## 🚀 How to Run
The program runs continuously until the user enters `exit`. To start:
1. Compile the project.
2. Run the executable file.
3. Enter commands in the console.

🎉 Enjoy managing your teams! 🏆

## 🤝 Contributing

Found a bug? Want to improve something?  
🔧 Feel free to open an issue or submit a PR!  

Made with ❤️ by [Alex Stefanov]  
🚀 Powered by C# | ⚡ Built with .NET | ✨ Inspired by team management
