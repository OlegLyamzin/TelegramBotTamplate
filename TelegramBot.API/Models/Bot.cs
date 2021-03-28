using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot.API.Models.Commands;
using TelegramBot.Core;

namespace TelegramBot.API.Models
{
    public static class Bot
    {
        private static TelegramBotClient client;
        private static List<Command> commandList;

        public static IReadOnlyList<Command> Commands { get => commandList.AsReadOnly(); }


        public static async Task<TelegramBotClient> Get()
        {
            return client;
        }

        public static async Task<TelegramBotClient> Init(string apiKey, string url)
        {
            commandList = new List<Command>();
            commandList.Add(new HelloCommand());
            commandList.Add(new SamaraCommand());

            client = new TelegramBotClient(apiKey);
            await client.SetWebhookAsync(url);

            return client;
        }
    }
}
