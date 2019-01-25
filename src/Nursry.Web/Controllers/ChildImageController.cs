using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nursry.Core.Entities.Storage;
using Nursry.Core.Interfaces;
using Nursry.Web.Util;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Nursry.Web.Controllers
{
    [Route("[controller]")]
    public class ChildImageController : Controller
    {
        private IChildImageRepository childImageRepo;

        public ChildImageController(IChildImageRepository childImageRepo)
        {
            this.childImageRepo = childImageRepo;
        }

        // GET: ChildImage/5
        [Route("{id:guid}")]
        [ResponseCache(Duration = 604800)]
        public async Task<ActionResult> Index(Guid id)
        {
            ChildImage image = await childImageRepo.GetByIdAsync(id);
            return File(image.Stream, "image/webp");
        }

        // GET: ChildImage/Png/5
        [Route("png/{id:guid}")]
        [ResponseCache(Duration = 604800)]
        public async Task<ActionResult> Png(Guid id)
        {
            ImageConverter imageConverter = new ImageConverter();
            ChildImage image = await childImageRepo.GetByIdAsync(id);
            Stream pngStream = imageConverter.ToPNG(image.Stream);
            pngStream.Position = 0;
            return File(pngStream, "image/png");
        }

        // POST: ChildImage/
        [HttpPost]
        [Authorize]
        [Route("{id:guid}")]
        public async Task<ActionResult> Index(Guid id, IFormFile file)
        {
            ImageConverter imageConverter = new ImageConverter();
            try
            {
                using (Stream uploadStream = new MemoryStream())
                {
                    await file.CopyToAsync(uploadStream);
                    uploadStream.Position = 0;
                    using (Stream webpStream = imageConverter.ToWebP(uploadStream))
                    {
                        webpStream.Position = 0;
                        await childImageRepo.AddOrUpdateAsync(new ChildImage(id, webpStream));
                    }
                }
                return new OkResult();
            }
            catch (Exception e)
            {
                return new BadRequestResult();
            }
        }
    }
}