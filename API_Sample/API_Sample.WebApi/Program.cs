using API_Sample.Application.Mapper;
using API_Sample.Application.Services;
using API_Sample.Application.Ultilities;
using API_Sample.Data.EF;
using API_Sample.Data.Model;
using API_Sample.WebApi.Middlewares;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

static void InitUtilitiesService(IServiceCollection services)
{
    services.AddSingleton<IJwtHelper, JwtHelper>();
    services.AddScoped<ISendMailSMTP, SendMailSMTP>();
}

static void InitDaoService(IServiceCollection services)
{
    //services.AddScoped<IS_Image, S_Image>();
    //services.AddScoped<IS_Product, S_Product>();
    services.AddScoped<IS_Subject, S_Subject>();
    services.AddScoped<IS_Grade, S_Grade>();
    services.AddScoped<IS_Class, S_Class>();
    services.AddScoped<IS_Attendance, S_Attendance>();
    services.AddScoped<IS_Employee, S_Employee>();
    services.AddScoped<IS_Role, S_Role>();
    services.AddScoped<IS_Student, S_Student>();
    services.AddScoped<IS_Student, S_Student>();
    services.AddScoped<IS_StudentMapsClass, S_StudentMapsClass>();
    services.AddScoped<IS_EmployeeMapsClass, S_EmployeeMapsClass>();
    services.AddScoped<IS_Tuition, S_Tuition>();
    services.AddScoped<IS_TuitionTransaction, S_TuitionTransaction>();
    services.AddScoped<IS_StudentMapsTuition, S_StudentMapsTuition>();
}

// Add services to the container.

builder.Services.AddDbContext<MainDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MainConnectString")));

builder.Services.AddDbContext<DemoDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MainConnectString")));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

InitUtilitiesService(builder.Services);
InitDaoService(builder.Services);

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressInferBindingSourcesForParameters = true; //Disable inference rules
    options.SuppressModelStateInvalidFilter = true;
    //options.SuppressMapClientErrors = true; //Disable ProblemDetails
    //options.ClientErrorMapping[StatusCodes.Status404NotFound].Link = "https://httpstatuses.com/404";
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    //c.OperationFilter<API.H2ADBSite.Portal.Variables.AddAuthorizationHeaderOperationHeader>();
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API_Sample.WebApi", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                In = ParameterLocation.Header,
            },
            new string[]{}
        }
    });
});

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    option.RequireHttpsMetadata = true;
    option.SaveToken = true;
    option.IncludeErrorDetails = true;
    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration.GetValue<string>("Jwt:Issuer"),
        ValidateAudience = true,
        ValidAudience = builder.Configuration.GetValue<string>("Jwt:Audience"),
        ValidateLifetime = true,
        RequireExpirationTime = true, //Expired or not 
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("Jwt:Key"))),
        ClockSkew = TimeSpan.Zero, //TimeSpan.Zero // new System.TimeSpan(0,0,30);
    };
    option.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                context.Response.Headers.Add("Token-Expired", "true");
            return Task.CompletedTask;
        }
    };
});

//Config IpRateLimit https://github.com/stefanprodan/AspNetCoreRateLimit/wiki/IpRateLimitMiddleware
builder.Services.AddMemoryCache();
//builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

var path = Directory.GetCurrentDirectory();
builder.Logging.AddFile($"{path}\\Logs\\Logs.txt");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwaggerUI(c =>
    {
        c.DefaultModelExpandDepth(2);
        c.DefaultModelRendering(ModelRendering.Model);
        c.DefaultModelsExpandDepth(-1);
        c.DisplayOperationId();
        c.DisplayRequestDuration();
        c.DocExpansion(DocExpansion.None);
        c.EnableDeepLinking();
        c.EnableFilter();
        //c.MaxDisplayedTags(5);
        c.ShowExtensions();
        c.ShowCommonExtensions();
        c.EnableValidator();
        //c.SupportedSubmitMethods(SubmitMethod.Get, SubmitMethod.Head);
        c.UseRequestInterceptor("(request) => { return request; }");
    });
}
else
{
    app.UseHsts();
    if (builder.Configuration.GetValue<bool>("Swagger:Active"))
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.DefaultModelExpandDepth(2);
            c.DefaultModelRendering(ModelRendering.Model);
            c.DefaultModelsExpandDepth(-1);
            c.DisplayOperationId();
            c.DisplayRequestDuration();
            c.DocExpansion(DocExpansion.None);
            c.EnableDeepLinking();
            c.EnableFilter();
            //c.MaxDisplayedTags(5);
            c.ShowExtensions();
            c.ShowCommonExtensions();
            c.EnableValidator();
            //c.SupportedSubmitMethods(SubmitMethod.Get, SubmitMethod.Head);
            c.UseRequestInterceptor("(request) => { return request; }");
        });
    }
}

app.UseIpRateLimiting(); //Apply IpRateLimit in middleware

app.UseMiddleware<SecurityHeadersMiddleware>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
