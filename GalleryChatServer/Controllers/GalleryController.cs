
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
    public Image[] Get()
    {
        List<Image> Images = new List<Image>();

        for (int i = 1; i < 8; i++)
        {
            Images.Add(new Image($"/image{i}.png"));
        }

        return Images.ToArray();
    }
}

