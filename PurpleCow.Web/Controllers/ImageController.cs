using Microsoft.AspNetCore.Mvc;
using PurpleCow.Common.Models;
using PurpleCow.Data;
using System.Diagnostics;

namespace PurpleCow.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IMapperSession _mapperSession;
        public ImageController(IMapperSession mapperSession)
        {
            _mapperSession = mapperSession;
        }

        [HttpGet]
        public List<Image> Get()
        {
            var images = new List<Image> { new Image { Id = 1, Name = "Work Food Bank Warehouse" }, 
                new Image { Id = 2, Name = "Rescue Mission Food Service" },
                new Image { Id = 3, Name = "Mulch Cameron Peak Burn Scars" }};

            try
            {
                var items = _mapperSession.GetImages();

                var newimage = new Image { Id = 4, Name = "Support Ukrainian Orphanages" };
                _mapperSession.Save(newimage);
            }
            catch (Exception ex)
            { 
                Debug.WriteLine(ex.Message);
            }
            return images;
        }

        [HttpPost]
        public string Post(Image image)
        {
            try
            {
                _mapperSession.Save(image);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return "success";
        }
    }
}