using Logging_service;
using RabbitMQ_Messenger_Lib.Types;
using Microsoft.EntityFrameworkCore;
using DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<LogContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("LoggingDatabase"), b =>
    {
        b.MigrationsAssembly("Logging-service");
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS Configuration
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Auth0 Services
// ToDo: Implement

MessengerConfig messengerConfig = new MessengerConfig { HostName = builder.Configuration["MessageBus:Host"], Exchange = builder.Configuration["MessageBus:Exchange"] };
builder.Services.AddSingleton(messengerConfig);
builder.Services.AddSingleton(new LogConsumer(messengerConfig, builder.Services.BuildServiceProvider().GetService<LogContext>()));

var app = builder.Build();

// EF migration
try
{
    using (IServiceScope serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
    {
        DbContext context = serviceScope.ServiceProvider.GetRequiredService<LogContext>();
        context.Database.Migrate();
    }
}
catch (Exception e)
{
    Console.WriteLine("An error occured during EF Migration, migration aborted");
    Console.WriteLine(e.Message);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();