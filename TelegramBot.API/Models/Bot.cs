using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot.API.Models.Commands;
using TelegramBot.Core;
using TelegramBot.DAL;

namespace TelegramBot.API.Models
{
    public class Bot
    {
        private TelegramBotClient client;
        private List<Command> commandList;
        private SamaraCommand _samaraCommand;

        public IReadOnlyList<Command> Commands { get => commandList.AsReadOnly(); }

        public Bot (IOptions<AppSettings> option, SamaraCommand samaraCommand)
        {
            _samaraCommand = samaraCommand;
            Init(option.Value.API_KEY, option.Value.URL);
        }

        public async Task<TelegramBotClient> Get()
        {
            return client;
        }

        public async Task<TelegramBotClient> Init(string apiKey, string url)
        {
            commandList = new List<Command>();
            commandList.Add(new HelloCommand());
            commandList.Add(_samaraCommand);

            client = new TelegramBotClient(apiKey);
            await client.SetWebhookAsync(url);

            return client;
        }
    }
}
