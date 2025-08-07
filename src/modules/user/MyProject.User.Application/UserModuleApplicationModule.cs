using Volo.Abp.Modularity;
using Volo.Abp.AutoMapper;
using Volo.Abp.Application;
using MyProject.User.Domain;

namespace MyProject.User.Application;

[DependsOn(
    typeof(AbpAutoMapperModule),    // 依赖automapper模块，否则automapper不生效
    typeof(UserModuleDomainModule),
    typeof(AbpDddApplicationModule)
)]
public class UserModuleApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // 配置对象映射
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<UserModuleApplicationModule>();
        });
    }
}
