using Microsoft.EntityFrameworkCore;
using MyContactsApp.DAL.DatabaseContext;
using MyContactsApp.DAL.Commands.Contacts;
using MyContactsApp.DAL.Repositories.Interfaces;
using MyContactsApp.DAL.Repositories;
using MyContactsApp.DAL.Mapping;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

#region Port Configuration
// Explicitly set the port
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenLocalhost(8000);
});
#endregion

#region Database Connection
// Defining connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
#endregion

#region JWT Configuration
// Configuring JWT
var secretKey = builder.Configuration.GetValue<string>("JwtConfig:Secret");
if (string.IsNullOrWhiteSpace(secretKey))
{
    throw new InvalidOperationException("JWT secret key is not set in the configuration.");
}

var key = Encoding.ASCII.GetBytes(secretKey);

// Setting up authentication
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.FromMinutes(Convert.ToDouble(builder.Configuration["JwtConfig:AccessTokenExpirationMinutes"]))
    };
});
#endregion

#region Basic Service Configuration
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
#endregion

#region Swagger Configuration
// Configuring Swagger to understand and use JWT tokens
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Define the Bearer Authentication scheme
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});
#endregion

#region CORS Configuration
// Configuring CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // Ensure this matches your React app's URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
#endregion

#region Database Service Configuration
// Connecting to Postgres
builder.Services.AddDbContext<MyContext>(options =>
    options.UseNpgsql(connectionString));

// Adding repositories for our use
builder.Services.AddScoped<IContactsRepository, ContactsRepository>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<ISubcategoriesRepository, SubcategoriesRepository>();
#endregion

#region MediatR and AutoMapper Configuration
// Adding MediatR to project
builder.Services.AddMediatR(typeof(CreateContactCommand));

// Adding AutoMapper to project
builder.Services.AddAutoMapper(typeof(Mapping));
#endregion

var app = builder.Build();

#region Application Configuration
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion
