using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyProject.User.Domain;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace MyProject.User.EntityFrameworkCore;

[DependsOn(
    typeof(UserModuleDomainModule), // 依赖领域层
    typeof(AbpEntityFrameworkCoreSqlServerModule) // 依赖 SQL Server 集成
)]
public class UserModuleEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // 注册模块专属 DbContext
        context.Services.AddAbpDbContext<UserModuleDbContext>(options =>
        {
            // 自动发现领域层实体并映射（无需手动添加 DbSet）
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        // 配置数据库连接（从配置文件读取连接字符串）
        Configure<AbpDbContextOptions>(options =>
        {
            options.Configure<UserModuleDbContext>(dbContextOptions =>
            {
                dbContextOptions.UseSqlServer();
            });
        });
    }
}
