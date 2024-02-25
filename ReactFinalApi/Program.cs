using Microsoft.EntityFrameworkCore;
using ReactFinalApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connection = builder.Configuration.GetConnectionString("myconn");
builder.Services.AddDbContext<BookDbContext>(opt =>
{
    opt.UseSqlServer(connection);
});

void ConfigureServices(IServiceCollection services)


{
    services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", builder =>
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader());
    });
}

void Configure(IApplicationBuilder app)
{
    app.UseCors("AllowAll");
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(builder => builder.AllowAnyOrigin()); // Allow requests from any origin
app.UseCors(builder => builder.WithOrigins("http://domain.com")); // Allow requests only from domain.com
app.UseCors(builder => builder.AllowAnyHeader()); // Allow any header in the request
app.UseCors(builder => builder.AllowAnyMethod()); // Allow any HTTP method in the request
//app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
