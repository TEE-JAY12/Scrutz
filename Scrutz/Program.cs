using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;
using Scrutz.Data;
using Scrutz.Repository;
using Scrutz.Repository.Interface;
using Scrutz.Service;
using Scrutz.Service.Interface;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//        .AddMicrosoftIdentityWebApi(options =>
//        {
//            builder.Configuration.Bind("AzureAd", options);
//            options.TokenValidationParameters.NameClaimType = "name";
//        }, options => { builder.Configuration.Bind("AzureAd", options); });
builder.Services.AddAuthorization();

builder.Services.AddDbContext<ScrutzContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ScrutzContext")));
builder.Services.AddTransient<ICampaignRepo, CampaignRepo>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ICampaignService, CampaignService>();
builder.Services.AddTransient<IAccountSettingRepo, AccountSettingRepo>();
builder.Services.AddTransient<IAccountSettingService, AccountSettingService>();
builder.Services.AddTransient<ITweetRepo, TweetRepo>();
builder.Services.AddTransient<ITweetService, TweetService>();
builder.Services.AddTransient<IInfluencerRepo, InfluencerRepo>();
builder.Services.AddTransient<IInfluencerService, InfluencerService>();




builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers()
                .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(
    c =>
    {   c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Scrutz API",
        Description = "An ASP.NET Core Web API for managing the Scrutz project",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

        c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
         {
             Type = SecuritySchemeType.OAuth2,
             Flows = new OpenApiOAuthFlows
             {
                 Implicit = new OpenApiOAuthFlow()
                 {
                     AuthorizationUrl = new Uri(builder.Configuration["SwaggerAzureAD:AuthorizationUrl"]),
                     TokenUrl = new Uri(builder.Configuration["SwaggerAzureAD:TokenUrl"]),
                     Scopes = new Dictionary<string, string>
                     {
                         {builder.Configuration["SwaggerAzureAd:Scope"],"Access API as User"}
                     }
                 }
             }
         });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement() 
        { 
            {
                new OpenApiSecurityScheme 
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme,Id = "oauth2" }
                    
                },
                new[]{ builder.Configuration["SwaggerAzureAd:Scope"] }
            },
        
            
       });
        // using System.Reflection;
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    }
    );


var app = builder.Build();

IdentityModelEventSource.ShowPII = true;

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c=>
//    {
//        c.OAuthClientId(builder.Configuration["SwaggerAzureAd:ClientId"]);
//        c.OAuthUsePkce();
//        c.OAuthScopeSeparator("");
//    });
//}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.OAuthClientId(builder.Configuration["SwaggerAzureAd:ClientId"]);
    c.OAuthUsePkce();
    c.OAuthScopeSeparator("");
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
