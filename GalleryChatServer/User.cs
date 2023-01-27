namespace GalleryChatServer;

public class User
{
    public User(string Username)
    {
        this.Username = Username;
    }

    public Guid Id { get; } = Guid.NewGuid();
    public string Username { get; set; }
}

