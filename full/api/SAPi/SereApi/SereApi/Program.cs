var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
string MyCors = "MyCors";

// Add services to the container.

builder.Services.AddCors(options =>
{
    //options.AddPolicy(name: "MyPolicy",
    //    policy =>
    //    {
    //        //policy.WithOrigins("http://example.com",
    //        //                    "http://www.contoso.com")
    //        //        .WithMethods("PUT", "DELETE", "GET");
    //    });
    options.AddPolicy(name: MyCors, builder =>
    {
        builder.WithOrigins("*");
    });
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseCors(x => x
//      .AllowAnyHeader()
//      .AllowAnyMethod()
//      .AllowAnyOrigin());

app.UseCors(MyCors);

app.UseAuthorization();

app.MapControllers();

app.Run();
