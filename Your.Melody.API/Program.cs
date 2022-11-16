using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Your.Melody.API.Models;
using Your.Melody.Library.Helpers;
using Your.Melody.Library.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(config =>
{
    config.CreateMap<PlaylistYtModel, Your.Melody.Library.Models.PlaylistModel>()
            .ForMember(x => x.Songs, opt => opt.MapFrom(u => u.items));
    config.CreateMap<Your.Melody.Library.Models.SongModel, Your.Melody.Library.Models.SongDataModel>()
            .ForMember(x => x.VideoId, opt => opt.MapFrom(u => u.contentDetails.videoId))
            .ForMember(x => x.Title, opt => opt.MapFrom(u => u.snippet.title));
    //.ForMember(x => x.ChannelTitle, opt => opt.MapFrom(u => u.snippet.channelTitle));
    config.CreateMap<Your.Melody.Library.Models.PlaylistModel, Playlist>();
    config.CreateMap<SongDataModel, Song>();
    config.CreateMap<Your.Melody.Library.Models.PlaylistModel, Your.Melody.API.Models.PlaylistModel>();
    config.CreateMap<SongDataModel, Your.Melody.API.Models.SongModel>();
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

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json",
        "Your.Melody.API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
