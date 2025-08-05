using MyProject.User.Application;
using MyProject.User.EntityFrameworkCore;   // 引用用户模块的EF层
using Volo.Abp;
using Volo.Abp.AspNetCore;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;

// 必须继承 AbpModule
[DependsOn(
    typeof(AbpAspNetCoreModule),       // 依赖ABP核心Web模块
    typeof(AbpSwashbuckleModule),      // 依赖Swagger模块
    typeof(UserModuleApplicationModule),      // 依赖用户应用模块
    typeof(UserModuleEntityFrameworkCoreModule)
)]
public class MyProjectHostModule : AbpModule
{
    // 配置服务
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        ConfigureAutoApiControllers(context.Services, configuration);

        // 配置Swagger
        // swagger：必须
        context.Services.AddAbpSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new() { Title = "MyProject API", Version = "v1" });

            // swagger：必须，关键：确保所有API都被Swagger包含（默认可能过滤动态生成的接口）
            options.DocInclusionPredicate((docName, description) => true);

            // swagger：非必须，包含动态 API 的程序集 XML 注释文件
            var xmlPath = Path.Combine(AppContext.BaseDirectory, "MyProject.User.Application.xml");     // 需要指定DepensOn(typeof(UserModuleApplicationModule))才会把这个xml文件加载到Host项目中
            options.IncludeXmlComments(xmlPath, true);
        });

        // swagger：非必须，添加控制器支持
        context.Services.AddControllers();
    }

    /// <summary>
    /// 自动API
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <remarks>
    /// HTTP Method
    /// ABP在确定服务方法的HTTP Method时使用命名约定:
    /// Get: 如果方法名称以GetList,GetAll或Get开头.
    /// Put: 如果方法名称以Put或Update开头.
    /// Delete: 如果方法名称以Delete或Remove开头.
    /// Post: 如果方法名称以Create,Add,Insert或Post开头.
    /// Patch: 如果方法名称以Patch开头.
    /// 其他情况, Post 为 默认方式.https://docs.abp.io/zh-Hans/abp/latest/API/Auto-API-Controllers
    /// </remarks>
    private void ConfigureAutoApiControllers(IServiceCollection services, IConfiguration configuration)
    {
        // swagger: 必须
        services.Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(UserModuleApplicationModule).Assembly, op => op.RootPath = "user");   // 自动controller，指定api基路由。/api/user/...
        });
        // swagger：非必须 配置 MVC 选项，添加自定义 请求头
        services.AddControllers(options =>
        {
            // 可以再此配置表头
        });
    }

    // 配置中间件
    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            // swagger：必须
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
