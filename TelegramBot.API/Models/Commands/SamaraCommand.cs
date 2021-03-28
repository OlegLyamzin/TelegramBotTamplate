using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.DAL;

namespace TelegramBot.API.Models.Commands
{
    public class SamaraCommand : Command
    {
        private SongRepository _songRepository;

        public SamaraCommand(SongRepository songRepository)
        {
            _songRepository = songRepository;
        }
        public override string Name { get; set; } = "samara";

        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            var number = 1;
            try
            {
                number = Convert.ToInt32( message.Text.Split(" "));
            }
            catch { }

            await client.SendTextMessageAsync(chatId, _songRepository.GetSongByCollectionAndNumber(1,number).Text);
        }
    }
}
