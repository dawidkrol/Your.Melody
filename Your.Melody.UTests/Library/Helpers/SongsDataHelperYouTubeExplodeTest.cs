using Your.Melody.Library.Helpers;
using Your.Melody.Library.Models;
using YoutubeExplode;

namespace Your.Melody.UTests.Library.Helpers
{
    public class SongsDataHelperYouTubeExplodeTest
    {
        class Compare : IEqualityComparer<SongDataModel>
        {
            public bool Equals(SongDataModel a, SongDataModel b)
            {
                if (a.Title.Equals(b.Title) && a.Artist.Equals(b.Artist) && a.AudioUrl.Equals(b.AudioUrl) && a.VideoUrl.Equals(b.VideoUrl))
                    return true;
                return false;
            }
            public int GetHashCode(SongDataModel codeh)
            {
                return 0;
            }
        }
        ISongsDataHelper _songsDataHelper;
        public SongsDataHelperYouTubeExplodeTest()
        {
            YoutubeClient youtubeClient = new YoutubeClient();
            _songsDataHelper = new SongsDataHelperYouTubeExplode(youtubeClient);
        }
        public static IEnumerable<object[]> DataGettingPlaylistModelAsyncTest =>
        new List<object[]>
        {
            new object[] { @"https://www.youtube.com/playlist?list=PLs980T26JEs5huZMtzL_p7NvQa0j_bS_f", new PlaylistModel() 
            {
                Songs = new List<SongDataModel>()
                {
                    new SongDataModel()
                    {
                        Title= "I’M A STAR NOW",
                        Artist = "2115",
                        SecToStart = 0,
                    },
                    new SongDataModel()
                    {
                        Title= "Lágrimas",
                        Artist = "SENTINO",
                        SecToStart = 0,
                    }
                }
            } },
        };
        [Theory]
        [MemberData(nameof(DataGettingPlaylistModelAsyncTest))]
        [Obsolete]
        public async void GettingPlaylistModelAsyncTest(string uri, PlaylistModel expected)
        {
            var actual = await _songsDataHelper.GetPlaylist(uri);

            Assert.True(!expected.Songs.SequenceEqual(actual.Songs,new Compare()) && expected.Songs.Count == actual.Songs.Count);
        }
        public static IEnumerable<object[]> DataGettingTitleAndArtistAsyncTestAsyncTest =>
            new List<object[]>
            {
                        new object[] { "G-Eazy - But A Dream (Official Music Video)", ("But A Dream", "G-Eazy") },
                        new object[] { "Quebonafide - Szejk (prod. Teken)", ("Szejk", "Quebonafide") },
                        new object[] { "PRO8L3M - Bagaże", ("Bagaże", "PRO8L3M") },
                        new object[] { "SENTINO - Lágrimas prod. CrackHouse", ("Lágrimas", "SENTINO") }
            };
        [Theory]
        [MemberData(nameof(DataGettingTitleAndArtistAsyncTestAsyncTest))]
        public void GettingTitleAndArtistAsyncTest(string title, (string, string) expected)
        {
            var actual = _songsDataHelper.SeperatingTitleAndArtist(title);

            Assert.Equal(expected, actual);
        }
    }
}
