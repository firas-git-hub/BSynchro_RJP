using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using BSynchro_RJP.Models.Contexts;
using BSynchro_RJP.Services.DBIntermidiaryServices.UserAccounts;
using BSynchro_RJP.Services.Customers;
using BSynchro_RJP.Services.DBIntermidiaryServices.Users;
using BSynchro_RJP.Services.DBIntermidiaryServices.AccountTransactions;
using System.Text.Json.Serialization;
using BSynchro_RJP.Interface.Customers;
using BSynchro_RJP.Interface.DBIntermidiaryServices.AccountTransactions;
using BSynchro_RJP.Interface.DBIntermidiaryServices.UserAccounts;
using BSynchro_RJP.Interface.DBIntermidiaryServices.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CustomersContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CustomersDbConStr")));
builder.Services.AddScoped<ICustomersContextService, CustomersContextService>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IUserAccountsService, UserAccountsService>();
builder.Services.AddScoped<IAccountTransactionsService, AccountTransactionsService>();

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
