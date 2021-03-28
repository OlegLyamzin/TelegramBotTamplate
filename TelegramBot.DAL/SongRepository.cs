using System;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Options;
using TelegramBot.Core;
using TelegramBot.DAL.Models;

namespace TelegramBot.DAL
{
    public class SongRepository
    {
        private SqlConnection _connection;

        public SongRepository(IOptions<AppSettings> options)
        {
            _connection = new SqlConnection(options.Value.CONNECTION_STRING);
        }

        public SongDto GetSongByCollectionAndNumber(int collectionId, int number)
        {
            var result = _connection
                .Query<SongDto, CollectionDto, SongDto>(
                "dbo.Song_SelectByCollectionAndNumber",
                (song, collection) =>
                {
                    if (song != null && collection != null)
                    {
                        song.Collection = collection;
                    }
                    return song;
                },
                new { collectionId, number },
                splitOn: "Id",
                commandType: System.Data.CommandType.StoredProcedure)
                .FirstOrDefault();
            return result;
        }
    }
}
