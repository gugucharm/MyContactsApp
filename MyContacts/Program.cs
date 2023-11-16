using Microsoft.EntityFrameworkCore;
using MyContactsApp.DAL.DatabaseContext;
using MyContactsApp.DAL.Commands.Contacts;
using MyContactsApp.DAL.Repositories.Interfaces;
using MyContactsApp.DAL.Repositories;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Defining connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connecting to Postgres
builder.Services.AddDbContext<MyContext>(options =>
    options.UseNpgsql(connectionString));

// Adding repositories for our use
builder.Services.AddScoped<IContactsRepository, ContactsRepository>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

// Adding MediatR to project
builder.Services.AddMediatR(typeof(CreateContactCommand));

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
