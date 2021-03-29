using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
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
        private Task<TelegramBotClient> _bot;
        private SongRepository _songRepository;

        public CheckController(IOptions<AppSettings> options, Bot bot, SongRepository songRepository)
        {
            var appsetings = options.Value;
            _bot = bot.Get();
            _songRepository = songRepository;
        }
       
        [HttpGet]
        public async Task<ActionResult<SongDto>> Check()
        {
            return Ok("working");
        }

        [HttpGet("start")]
        public async Task<ActionResult<SongDto>> Start()
        {
            return Ok(_songRepository.GetSongByCollectionAndNumber(1, 1).Text);
        }
    }
}
