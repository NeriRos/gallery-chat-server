namespace GalleryChatServer;

public class Chat
{
    public Chat(string Id)
    {
        this.Id = Id;
    }
    public string Id { get; set; }
    private List<Message> _Messages = new List<Message>();

    public void AddMessage(Message Message)
    {
        this._Messages.Add(Message);
    }

    public Message[] Messages
    {
        get { return _Messages.ToArray(); }
    }
}


public class Message
{
    public Message(string ChatId, User Sender, string Text)
    {
        this.ChatId = ChatId;
        this.Sender = Sender;
        this.Text = Text;
    }

    public Guid Id { get; } = Guid.NewGuid();
    public string ChatId { get; }
    public User Sender { get; }
    public string Text { get; set; }
    public DateTime Date { get; } = DateTime.Now;
}