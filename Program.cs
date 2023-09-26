using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;



var builder = WebApplication.CreateBuilder(args);



// Add services to the container.



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true, //validates the server that generates the token
            ValidateAudience = true, //validae the recipient of the token is authorized to recieve
            ValidateLifetime = true, //this check if the token is not expired at the signing key of the issue is valid or not 
            ValidIssuer = builder.Configuration["Jwt:Issuer"], //appsettings.json
            ValidAudience = builder.Configuration["Jwt:Audience"], //appsettings.json
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])) //validates the signature of the token
        };
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



app.UseAuthentication();



app.UseAuthorization();



app.MapControllers();



app.Run();