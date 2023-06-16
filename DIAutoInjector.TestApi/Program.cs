using DIAutoInjector.InstallerModules;
using DIAutoInjector.TestApi.Middlewares;
using DIAutoInjector.TestApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterDIAutoInjector();
builder.Services.AddScoped<IManualHelper, ManualHelper>((provider) => new ManualHelper("connetionString"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseMiddleware<IdentityLoggingMiddleware>();

app.MapControllers();

app.Run();
