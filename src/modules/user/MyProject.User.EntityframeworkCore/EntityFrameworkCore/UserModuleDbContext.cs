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
