﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Internacionalización_y_versiones.Entities;

namespace Internacionalización_y_versiones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IStringLocalizer<PostsController> _stringLocalizer;
        private readonly IStringLocalizer<SharedResource> _sharedResourceLocalizer;

        public PostsController(IStringLocalizer<PostsController> stringLocalizer, IStringLocalizer<SharedResource> sharedResourceLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _sharedResourceLocalizer = sharedResourceLocalizer;
        }

        [HttpGet]
        [Route("PostControllerResource")]
        public IActionResult GetUsingPostControllerResource()
        {
            //Find text
            var article = _stringLocalizer["Article"]; //It its possible to access first the position and later add the value (PostType = article.Value).
            var postName = _stringLocalizer.GetString("Welcome").Value ?? String.Empty; //Or go directly to the value.
            
            return Ok(new
            {
                PostType = article.Value,
                PostName = postName
            });
        }

        [HttpGet]
        [Route("SharedResource")]

        public IActionResult GetUsingSharedResource()
        {
            var article = _stringLocalizer["Article"];
            var postName = _stringLocalizer.GetString("Welcome").Value ?? String.Empty;
            var todayIs = string.Format(_sharedResourceLocalizer.GetString("TodayIs"), DateTime.Now.ToLongDateString());

            return Ok(new
            {
                PostType = article.Value,
                PostName = postName,
                TodayIs = todayIs
            });
        }
    }
}
