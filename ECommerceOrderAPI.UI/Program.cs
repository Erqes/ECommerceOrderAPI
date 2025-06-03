using ECommerceOrderAPI.Application;
using ECommerceOrderAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration)
    .AddApplication();
builder.Services.ConfigureSwaggerGen(options =>
{
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ECommerceOrderAPI V1");
});


app.UseRouting();
app.UseAuthorization();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();

app.Run();
