using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApiGP.Services.Interface;
using WebApiGP.Services.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");
var secretkey = builder.Configuration.GetSection("settings").GetSection("secretkey").ToString();
var keyBytes = Encoding.UTF8.GetBytes(secretkey);

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});
// Add services to the container.
builder.Services.Add(new ServiceDescriptor(typeof(IProduct), new ProductRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IUser), new UserRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IBrand), new BrandRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(ICategory), new CategoryRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(ICoupon), new CouponRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IShopcart), new ShopcartRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IOrder), new OrderRepository()));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var reglasCors = "ReglasCors";
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: reglasCors, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseAuthentication();

app.UseCors(reglasCors);

app.UseAuthorization();

app.MapControllers();

app.Run();
