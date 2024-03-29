﻿using Your.Melody.Library.DbAccess;
using Your.Melody.Library.Models;

namespace Your.Melody.Library.Data
{
    public class SongData : ISongData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public SongData(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public async Task AddSongToPlaylist(Song song, Guid playlistId)
        {
            await _sqlDataAccess.SaveDataAsync<object>("spSong_Add",
                new
                {
                    Id = song.Id,
                    Title = song.Title,
                    Artist = song.Artist,
                    VideoUrl = song.VideoUrl,
                    AudioUrl = song.AudioUrl,
                    PlaylistId = playlistId,
                    SecToStart = song.SecToStart
                });
        }
        public async Task SetSongAsPlayed(Guid songId)
        {
            await _sqlDataAccess.SaveDataAsync<object>("[dbo].[spSong_SetAsPlayed]",
                new
                {
                    songId = songId
                });
        }
    }
}
