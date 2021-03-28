using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramBot.API.Models;
using TelegramBot.Core;
using TelegramBot.DAL;
using TelegramBot.DAL.Models;

namespace TelegramBot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckController : ControllerBase
    {
        public CheckController(IOptions<AppSettings> options)
        {
            var appsetings = options.Value;
            Bot.Init(appsetings.API_KEY, appsetings.URL);
        }
       
        [HttpGet]
        public async Task<ActionResult<SongDto>> Check()
        {
            return Ok("working");
        }

        [HttpGet("start")]
        public async Task<ActionResult<SongDto>> Start()
        {
            return Ok();
        }
    }
}
