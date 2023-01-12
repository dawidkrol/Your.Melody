using Your.Melody.Library.Helpers;
using Your.Melody.Library.Models;

namespace Your.Melody.UTests.Library.Helpers
{
    public class PointsCounterTest
    {
        IPointsCounter _gameHelper;

        public PointsCounterTest()
        {
            _gameHelper = new PointsCounter();
        }
        public static IEnumerable<object[]> DataCountingPointsSecoundsAsyncTest =>
        new List<object[]>
        {
            new object[] { new Song() { Artist = "Artist", Title = "Title" }, "Title", "Artist", 1 , 93 },
            new object[] { new Song() { Artist = "Artist", Title = "Title" }, "Title", "Artist", 2 , 88 },
            new object[] { new Song() { Artist = "Artist", Title = "Title" }, "Title", "Artist", 3 , 83 },
            new object[] { new Song() { Artist = "Artist", Title = "Title" }, "Title", "Artist", 4 , 78 },
        };
        public static IEnumerable<object[]> DataCountingPointsTitleAsyncTest =>
        new List<object[]>
        {
            new object[] { new Song() { Artist = "Artist", Title = "Title" }, "Title", "Artist", 1 , 93 },
            new object[] { new Song() { Artist = "Artist", Title = "Title" }, "title", "Artist", 1 , 93 },
            new object[] { new Song() { Artist = "Artist", Title = "Title" }, "ttle", "Artist", 1 , 56 },
            new object[] { new Song() { Artist = "Artist", Title = "Title" }, "", "Artist", 1 , 46 },
        };
        public static IEnumerable<object[]> DataCountingPointsArtistAsyncTest =>
        new List<object[]>
        {
            new object[] { new Song() { Artist = "Artist", Title = "Title" }, "Title", "Artist", 1 , 93 },
            new object[] { new Song() { Artist = "Artist", Title = "Title" }, "Title", "artist", 1 , 93 },
            new object[] { new Song() { Artist = "Artist", Title = "Title" }, "Title", "Atist", 1 , 54 },
            new object[] { new Song() { Artist = "Artist", Title = "Title" }, "Title", "Arrst", 1 , 62 },
            new object[] { new Song() { Artist = "Artist", Title = "Title" }, "Title", "", 1 , 46 },
        };

        [Theory]
        [MemberData(nameof(DataCountingPointsSecoundsAsyncTest))]
        public async void CountingPointsSecoundsAsyncTest(Song song, string titleByUser, string artistByUser, float secWhenUserResponce, double expected)
        {
            var actual = await _gameHelper.CountingPointsAsync(song, titleByUser, artistByUser, secWhenUserResponce);

            Assert.Equal(expected, actual, 1f);
        }
        [Theory]
        [MemberData(nameof(DataCountingPointsTitleAsyncTest))]
        public async void CountingPointsTitleAsyncTest(Song song, string titleByUser, string artistByUser, float secWhenUserResponce, double expected)
        {
            var actual = await _gameHelper.CountingPointsAsync(song, titleByUser, artistByUser, secWhenUserResponce);

            Assert.Equal(expected, actual, 1f);
        }
        [Theory]
        [MemberData(nameof(DataCountingPointsArtistAsyncTest))]
        public async void CountingPointsArtistAsyncTest(Song song, string titleByUser, string artistByUser, float secWhenUserResponce, double expected)
        {
            var actual = await _gameHelper.CountingPointsAsync(song, titleByUser, artistByUser, secWhenUserResponce);

            Assert.Equal(expected, actual, 1f);
        }
    }
}
