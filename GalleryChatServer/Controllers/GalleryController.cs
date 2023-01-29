
using Microsoft.AspNetCore.Mvc;
namespace GalleryChatServer.Controllers;


[ApiController]
[Route("[controller]")]
public class GalleryController : ControllerBase
{
    private readonly ILogger<GalleryController> _logger;

    public GalleryController(ILogger<GalleryController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("/images")]
    public GalleryItem[] GetImages()
    {
        List<GalleryItem> Items = new List<GalleryItem>();

        for (int i = 1; i <= 8; i++)
        {
            Image image = new Image($"http://localhost:5251/images/{i}.jpg", i.ToString());

            Items.Add(new GalleryItem
            {
                Id = i.ToString(),
                Author = GalleryChatServer.User.getTestUser(i),
                Description = i % 2 == 0 ? "Test description" : "Very odd image",
                Title = i % 2 == 0 ? "Test title" : "Odd title",
                Image = image
            });
        }

        return Items.ToArray();
    }

    [HttpGet]
    [Route("/image/{id}")]
    public GalleryItem? GetById(string id)
    {
        if (int.TryParse(id, out int Id))
        {
            Image image = new Image($"http://localhost:5251/images/{Id}.jpg", Id.ToString());

            return new GalleryItem
            {
                Id = Id.ToString(),
                Author = GalleryChatServer.User.getTestUser(Id),
                Description = "Test description",
                Title = Id % 2 == 0 ? "Test title" : "Odd title",
                Image = image
            };
        }

        return null;
    }
}

