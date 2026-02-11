using SeminarASPDemo;

var builder = WebApplication.CreateBuilder(args);


// from microsoft docs, this is how to set the logger to log to the console
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
// Add services to the container. From Microsoft docs
builder.Services.AddSingleton<IProfessorDataBase, ProfessorDataBase>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication("FakeScheme")
    .AddCookie("FakeScheme"); // cookie scheme is simplest

var app = builder.Build();

//proof of concept authorization, inline custom middleware example
app.Use(async (context, next) =>
{ // context is an HTTPContext object, next is a delagate for the next middleware in the pipeline

    
    var claims = new[]
    {
        new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, "DemoUser"),
        new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, "User"),
        new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, "Admin"),
    };
    //create an identity and associate it with the claims created above
    var identity = new System.Security.Claims.ClaimsIdentity(claims, "FakeScheme");
    context.User = new System.Security.Claims.ClaimsPrincipal(identity);

    //calls the next middleware in the pipeline
    await next();
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
