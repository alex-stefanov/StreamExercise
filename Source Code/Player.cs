namespace Stefko;

public class Player(
    string name,
    string position)
{
    private string name = name;

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

    private string position = position;

    public string Position
    {
        get => this.position;
        private set
        {
            if (string.IsNullOrEmpty(value)
                || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Position not specified.");
            }

            this.position = value;
        }
    }

    public void AssignPosition(
        string position)
        => this.Position = position;
}