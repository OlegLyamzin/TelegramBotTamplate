using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TelegramBot.API.Models;

namespace TelegramBot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private Bot _bot;

        public MessageController(Bot bot)
        {
            _bot = bot;
        }

        [Route("update")]
        public async Task<ActionResult> Update([FromBody]Update update)
        {
            var commands = _bot.Commands;
            var message = update.Message;
            var client = await _bot.Get();

            foreach(var command in commands)
            {
                if (command.Contains(message.Text))
                {
                    command.Execute(message, client);
                    break;
                }
            }

            return Ok();
        }
    }
}
