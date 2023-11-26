using Dapr.Workflow;
using Dapr.Workflow.Starter.API.Activities;
using Dapr.Workflow.Starter.API.DataAccess;
using Dapr.Workflow.Starter.API.Workflows;
using Google.Api;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>
    (
        options => options.UseSqlite("Data Source=MyDB1.db")
    );
builder.Services.AddDaprWorkflow(options =>
{
    // Note that it's also possible to register a lambda function as the workflow
    // or activity implementation instead of a class.
    options.RegisterWorkflow<CreateOrderFlow>();

    // These are the activities that get invoked by the workflow(s).
    options.RegisterActivity<CheckInventoryActivity>();
    options.RegisterActivity<CreateOrderActivity>();
    options.RegisterActivity<HoldInventoryActivity>();
    options.RegisterActivity<ProcessPayment>();
    options.RegisterActivity<ReleaseInventoryActivity>();
    options.RegisterActivity<SendNotificationActivity>();
    options.RegisterActivity<UpdateOrderActivity>();
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
