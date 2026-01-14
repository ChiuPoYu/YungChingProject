using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using YungChingWebApi.Data;
using YungChingWebApi.Repositories;
using YungChingWebApi.Repositories.Interfaces;
using YungChingWebApi.Resources.Filters;
using YungChingWebApi.Services;
using YungChingWebApi.Services.Interfaces;

namespace YungChingWebApi
{
    /// <summary>
    /// 應用程式入口類別
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 應用程式主要進入點
        /// </summary>
        /// <param name="args">命令列參數</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // 註冊 DbContext（使用 SQL Server）
            builder.Services.AddDbContext<SqlDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // 註冊 Repository（Scoped 生命週期）
            builder.Services.AddScoped<IHouseRepository, HouseRepository>();

            // 註冊 Service（Scoped 生命週期）
            builder.Services.AddScoped<IHouseService, HouseService>();

            // 註冊 Controllers 並加入全域過濾器
            builder.Services.AddControllers(options =>
            {
                // 註冊全域 HttpExceptionFilter
                options.Filters.Add<HttpExceptionFilter>();
            });
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            // 建立 Swagger API 文件配置
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "YungChing Web API",
                    Version = "v1",
                    Description = "YungChing 專案的 Web API"
                });

                // 讀取 XML 註解檔案
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });


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
        }
    }
}
