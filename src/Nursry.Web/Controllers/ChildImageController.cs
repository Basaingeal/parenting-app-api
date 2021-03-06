﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Nursry.Core.Entities.Storage;
using Nursry.Core.Interfaces;
using Nursry.Web.Util;
using System;
using System.IO;
using System.Linq;
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
        [ResponseCache(Duration = 604800, VaryByHeader = HeaderNames.Accept)]
        public async Task<ActionResult> Index(Guid id)
        {
            ChildImage image = await childImageRepo.GetByIdAsync(id);
            if (RequestAcceptsWebP())
            {
                return File(image.Stream, "image/webp");
            }
            ImageConverter imageConverter = new ImageConverter();
            Stream pngStream = imageConverter.ToPNG(image.Stream);
            pngStream.Position = 0;
            return File(pngStream, "image/png");
        }

        // GET: ChildImage/5.png
        [Route("{id:guid}.png")]
        [ResponseCache(Duration = 604800)]
        public async Task<ActionResult> Png(Guid id)
        {
            ImageConverter imageConverter = new ImageConverter();
            ChildImage image = await childImageRepo.GetByIdAsync(id);
            Stream pngStream = imageConverter.ToPNG(image.Stream);
            pngStream.Position = 0;
            return File(pngStream, "image/png");
        }

        // GET: ChildImage/5.webp
        [Route("{id:guid}.webp")]
        [ResponseCache(Duration = 604800)]
        public async Task<ActionResult> WebP(Guid id)
        {
            ChildImage image = await childImageRepo.GetByIdAsync(id);
            image.Stream.Position = 0;
            return File(image.Stream, "image/webp");
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
                Console.Error.WriteLine(e);
                return new BadRequestResult();
            }
        }

        private bool RequestAcceptsWebP()
        {
            var listOfAcceptHeaders = Request.Headers[HeaderNames.Accept].ToList();
            if(listOfAcceptHeaders.Count == 0)
            {
                return false;
            }
            return listOfAcceptHeaders[0].Contains("image/webp");
        }
    }
}