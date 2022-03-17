using Microsoft.AspNetCore.Mvc;
using PurpleCow.Web.Models;

namespace PurpleCow.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {

        public ImageController()
        {
        }

        [HttpGet]
        public List<Image> Get()
        {
            var images = new List<Image> { new Image { Id = 1, Name = "Kraken Logo" }, new Image { Id = 2, Name = "Canucks Logo" } };
            return images;
        }

        [HttpPost]
        public string Post(Image image)
        {
            return "success";
        }
    }
}