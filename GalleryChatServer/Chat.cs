namespace GalleryChatServer;

public class Chat
{
    public int ImageId { get; set; }
    private List<Message> _Messages = new List<Message>();

    public void AddMessage(Message Message)
    {
        this._Messages.Append(Message);
    }

    public Message[] Messages
    {
        get { return _Messages.ToArray(); }
    }
}


public class Message
{
    Message(User Sender, String Text)
    {
        this.Sender = Sender;
        this.Text = Text;
    }

    public User Sender { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}

public class User
{
    public int Id { get; set; }
    public int UserName { get; set; }
}

