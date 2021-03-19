using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.API.Models.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; set; }
        public abstract void Execute(Message message, TelegramBotClient client);
        public bool Contains(string command)
        {
            return command.Contains(this.Name);
        }

    }
}
