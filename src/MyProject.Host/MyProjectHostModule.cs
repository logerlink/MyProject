using MyProject.User.EntityFrameworkCore;   // 引用用户模块的EF层
using Volo.Abp;
using Volo.Abp.AspNetCore;  
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;

// 必须继承 AbpModule
[DependsOn(
    typeof(AbpAspNetCoreModule),       // 依赖ABP核心Web模块
    typeof(AbpSwashbuckleModule),      // 依赖Swagger模块
    typeof(UserModuleEntityFrameworkCoreModule) // 依赖用户模块
)]
public class MyProjectHostModule : AbpModule
{
    // 配置服务
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        // 配置Swagger
        context.Services.AddAbpSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new() { Title = "MyProject API", Version = "v1" });

            // 必须包含动态 API 的程序集 XML 注释文件
            //var xmlPath = Path.Combine(AppContext.BaseDirectory, "MyProject.xml");
            //options.IncludeXmlComments(xmlPath, true);

            //options.DocInclusionPredicate((docName, description) => true);
            //options.CustomSchemaIds(type => type.FullName);

        });
    }

    // 配置中间件
    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "MyProject API v1");
            });
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
