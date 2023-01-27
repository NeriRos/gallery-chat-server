namespace GalleryChatServer;

public class Image
{
    public Image(String Path)
    {
        this.Id = Path;
        this.Path = Path;
    }

    public string Id { get; }
    public string Path { get; set; }
}