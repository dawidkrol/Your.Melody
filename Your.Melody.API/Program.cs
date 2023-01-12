using System.Reflection;
using Your.Melody.API.Models;
using Your.Melody.Library.Data;
using Your.Melody.Library.DbAccess;
using Your.Melody.Library.Helpers;
using Your.Melody.Library.Models;
using YoutubeExplode;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(config =>
{

    config.CreateMap<Your.Melody.Library.Models.PlaylistModel, Your.Melody.API.Models.Playlist>();
    config.CreateMap<Your.Melody.API.Models.PlaylistModel, Your.Melody.API.Models.Playlist>();
    config.CreateMap<SongDataModel, Your.Melody.API.Models.Song>();
    config.CreateMap<Your.Melody.API.Models.Song, Your.Melody.API.Models.SongModel>();
    config.CreateMap<Your.Melody.API.Models.SongModel, Your.Melody.API.Models.Song>();
    config.CreateMap<Your.Melody.API.Models.Playlist, Your.Melody.API.Models.PlaylistModel>();
    config.CreateMap<Your.Melody.API.Models.PlaylistModel, Your.Melody.Library.Models.Playlist>();
    config.CreateMap<Your.Melody.Library.Models.PlaylistModel, Your.Melody.API.Models.PlaylistModel>();
    config.CreateMap<SongDataModel, Your.Melody.API.Models.SongModel>();
    config.CreateMap<Your.Melody.Library.Models.ApprovedPlaylist, Your.Melody.API.Models.ApprovedPlaylist>();
    config.CreateMap<Your.Melody.API.Models.ApprovedPlaylist, Your.Melody.Library.Models.ApprovedPlaylist>();
    config.CreateMap<Your.Melody.API.Models.SongModel, Your.Melody.Library.Models.Song>();
    config.CreateMap<Your.Melody.Library.Models.ApprovedPlaylist, Your.Melody.API.Models.Playlist>();

    // GameModel -> Game
    config.CreateMap<GameModel, Game>();
    config.CreateMap<Your.Melody.Library.Models.GameModes, Your.Melody.API.Models.GameModes>();
    config.CreateMap<Your.Melody.Library.Models.Playlist, Your.Melody.API.Models.Playlist>();
    config.CreateMap<PlayerModel, Player>();
    config.CreateMap<UserModel, User>();
    config.CreateMap<Your.Melody.Library.Models.Song, Your.Melody.API.Models.Song>();

    //Game -> GameModel
    config.CreateMap<Game, GameModel>();
    config.CreateMap<Your.Melody.API.Models.GameModes, Your.Melody.Library.Models.GameModes>();
    config.CreateMap<Your.Melody.API.Models.Playlist, Your.Melody.Library.Models.Playlist>();
    config.CreateMap<Player, PlayerModel>();
    config.CreateMap<User, UserModel>();
    config.CreateMap<Your.Melody.API.Models.Song, Your.Melody.Library.Models.Song>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddScoped<IPointsCounter, PointsCounter>();
builder.Services.AddScoped<YoutubeClient>();
//Helpers
builder.Services.AddScoped<IApprovedPlaylistHelper, ApprovedPlaylistHelper>();
builder.Services.AddScoped<IGameHelper, GameHelper>();
builder.Services.AddScoped<IGameManagerHelper, GameManagerHelper>();
builder.Services.AddScoped<ISongsDataHelper, SongsDataHelperYouTubeExplode>();
builder.Services.AddScoped<IPlayerHelper, PlayerHelper>();
//Data
builder.Services.AddScoped<IGameData, GameData>();
builder.Services.AddScoped<IPlayerData, PlayerData>();
builder.Services.AddScoped<IPlaylistData, PlaylistData>();
builder.Services.AddScoped<ISongData, SongData>();
builder.Services.AddScoped<IAnswerData, AnswerData>();
builder.Services.AddScoped<ISqlDataAccess, SqlDataAccess>();

var app = builder.Build();

app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json",
    "Your.Melody.API v1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
