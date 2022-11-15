using Microsoft.Extensions.Options;
using System.Reflection;
using Your.Melody.API.Models;
using Your.Melody.Library.Helpers;
using Your.Melody.Library.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(config =>
{
    config.CreateMap<PlaylistYtModel, PlaylistModel>()
            .ForMember(x => x.Songs, opt => opt.MapFrom(u => u.items));
    config.CreateMap<SongModel, Your.Melody.Library.Models.SongDataModel>()
            .ForMember(x => x.VideoId, opt => opt.MapFrom(u => u.contentDetails.videoId))
            .ForMember(x => x.Title, opt => opt.MapFrom(u => u.snippet.title));
    //.ForMember(x => x.ChannelTitle, opt => opt.MapFrom(u => u.snippet.channelTitle));
    config.CreateMap<PlaylistModel, Playlist>();
    config.CreateMap<SongDataModel, Song>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddScoped<ISongsDataHelper, SongsDataHelper>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
