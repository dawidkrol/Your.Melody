using AutoMapper;
using HotChocolate.Types;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<Playlist> GetSongs([FromQuery] string playlistUrl)
        {
            var data = Regex.Match(playlistUrl, "(?<=list=)([a-zA-Z0-9])\\w+").Value;
            return _mapper.Map<Playlist>(await _songsDataHelper.GetPlaylist(data));
        }
    }
}
