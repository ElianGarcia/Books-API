using Books_API.Context;
using Books_API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BooksContext>(x => x.UseSqlServer("workstation id=service-report-db.mssql.somee.com;packet size=4096;user id=eliangarciarguez_SQLLogin_1;pwd=\t3lqlyxvsao;data source=service-report-db.mssql.somee.com;persist security info=False;initial catalog=service-report-db;Integrated Security=false; Encrypt=false"));
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*")
                          .WithHeaders("*")
                          .WithMethods("*");
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
