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
            //var images = new List<Image> { new Image { Id = , Name = "Work Food Bank Warehouse" }, 
            //    new Image { Id = 2, Name = "Rescue Mission Food Service" },
            //    new Image { Id = 3, Name = "Mulch Cameron Peak Burn Scars" }};

            try
            {
                var images = _mapperSession.GetImages();

                return images;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return new List<Image>();
        }

        [HttpPost]
        public string Post(Image image)
        {
            try
            {
                _mapperSession.SaveImage(image);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return "success";
        }

        [HttpDelete]
        public string Delete()
        {
            try
            {
                var images = _mapperSession.GetImages();
                foreach (var image in images)
                {
                    _mapperSession.Delete(image);
                }
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return "success";
        }

    }
}