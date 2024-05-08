using OneClick.Utility;
using OneClick.Utility.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCustomServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDBServices(builder.Configuration);
builder.Services.AddLogging();
builder.Services.AddSwaggerGen();
builder.Services.AddOptions();
builder.Services.AddCustomCors();
var app = builder.Build();
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

Helper.SetFolder(builder.Configuration.GetValue<string>("Folder:Path"));
Helper.SetFolderPdf(builder.Configuration.GetValue<string>("FolderPdf:Path"));
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowOrigin");
app.MapControllers();
app.Run();
