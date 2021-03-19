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
        [Route("update")]
        public async Task<ActionResult> Update([FromBody]Update update)
        {
            var commands = Bot.Commands;
            var message = update.Message;
            var client = await Bot.Get();

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
