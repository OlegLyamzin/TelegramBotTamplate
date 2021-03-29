using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TelegramBot.API.Models;
using TelegramBot.Core;

namespace TelegramBot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private AppSettings _settings;
        private Bot _bot;

        public MessageController(IOptions<AppSettings> options, Bot bot)
        {
            _settings = options.Value;
            _bot = bot;
        }

        [Route("update")]
        public async Task<ActionResult> Update([FromBody] Update update)
        {
            var commands = _bot.Commands;
            var message = update.Message;
            var client = await _bot.Get();

            foreach (var command in commands)
            {
                if (command.Contains(message.Text))
                {
                    command.Execute(message, client);
                    break;
                }
            }
            return Ok();
        }

        [HttpGet("forcepush")]
        public async Task<ActionResult> ForcePush()
        {
            var commands = _bot.Commands;
            var client = await _bot.Get();

            client.DeleteWebhookAsync();
            var updates = client.GetUpdatesAsync().Result;
            await client.SetWebhookAsync(_settings.URL);
            
            foreach(var update in updates)
            {
                Update(update);
            }
            return Ok();
        }
    }
}
