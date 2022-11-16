﻿using AutoMapper;
using HotChocolate.Types;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Your.Melody.API.Models;
using Your.Melody.Library.Helpers;

namespace Your.Melody.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongsDataHelper _songsDataHelper;
        private readonly IMapper _mapper;

        public SongsController(ISongsDataHelper songsDataHelper, IMapper mapper)
        {
            _songsDataHelper = songsDataHelper;
            _mapper = mapper;
        }
        /// <summary>
        /// Extracting songs from a playlist
        /// </summary>
        /// <param name="playlistUrl">Link to the playlist from youtube</param>
        /// <returns>List of songs</returns>
        [HttpGet("GetSongs")]
        public async Task<PlaylistModel> GetSongs([FromQuery] string playlistUrl)
        {
            var data = Regex.Match(playlistUrl, "(?<=list=)([a-zA-Z0-9])\\w+").Value;
            return _mapper.Map<PlaylistModel>(await _songsDataHelper.GetPlaylist(data));
        }
        /// <summary>
        /// Editing Title, Artist, SecToStart values for playlist
        /// </summary>
        /// <param name="playlist">Playlist model</param>
        /// <returns>Edited list of songs</returns>
        [HttpPost("EditPlaylist")]
        public async Task<PlaylistModel> EditPlaylist(PlaylistModel playlist)
        {
            return new PlaylistModel();
        }
    }
}
