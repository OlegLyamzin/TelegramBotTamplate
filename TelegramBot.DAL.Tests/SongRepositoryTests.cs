using NUnit.Framework;

namespace TelegramBot.DAL.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var repo = new SongRepository();
            var actual = repo.GetSongByCollectionAndNumber(1, 1);
            Assert.Pass();
        }
    }
}