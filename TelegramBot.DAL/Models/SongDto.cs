using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBot.DAL.Models
{
    public class SongDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public CollectionDto Collection {get;set;}
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
