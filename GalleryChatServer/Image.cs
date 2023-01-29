namespace GalleryChatServer;

public class Image
{
    public Image(string Path, string Id)
    {
        this.Id = Id;
        this.Path = Path;
    }

    public string Id { get; }
    public string Path { get; set; }
}


public class GalleryItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required Image Image { get; set; }
    public User Author { get; set; } = User.getTestUser();
    public required string Description { get; set; }
    public required string Title { get; set; }
}