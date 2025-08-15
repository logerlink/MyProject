using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using MyProject.User.Domain.UserInfos;

namespace MyProject.User.EntityframeworkCore.EntityFrameworkCore;

[ConnectionStringName("UserModule")] // 指定连接字符串名称（与配置文件对应）
public class UserModuleDbContext : AbpDbContext<UserModuleDbContext>
{
    // 无需手动定义 DbSet，ABP 会通过 AddDefaultRepositories 自动处理
    // public DbSet<UserInfo> Users { get; set; }
    // 注意：这里有个问题，如果这里不显示定义DBSet且没有任何的自定义IxxxRepository，那么就会报错，不知道是什么原因
    // 正常指定 options.AddDefaultRepositories(includeAllEntities: true); 就可以不用显示定义DbSet，并且可以自动识别注入的
    // 若这里不想显示定义DbSet，可以加一个IUserRepository、UserRepository

    public UserModuleDbContext(DbContextOptions<UserModuleDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // 配置实体映射（仅需配置领域层实体）
        modelBuilder.Entity<UserInfo>();
    }
}
