using PurpleCow.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connString = System.Configuration.ConfigurationManager.ConnectionStrings["pcConnectionString"].ConnectionString;

// have to abandon this, wasting way too much time troubleshooting
// The NHibernate library supports .Net Core, but it looks like the SQL driver does not
// was so excited that the new Nhibernate library was .Net Core compatible
// solution:  https://stackoverflow.com/questions/63856236/could-not-create-the-driver-from-nhibernate-driver-sqlserverdriver
NHibernateExtensions.StartNHibernate(builder.Services, connString);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


public class Startup
{
    public void Configure(IApplicationBuilder app)
    { 

    }

    public void ConfigureServices(IServiceCollection services)
    {
        var connString = System.Configuration.ConfigurationManager.ConnectionStrings["pcConnectionString"].ConnectionString;
        NHibernateExtensions.StartNHibernate(services, connString);
        services.AddControllersWithViews();
    }
}


