using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using MyProject.User.Domain.UserInfos; // 引用领域层实体

namespace MyProject.User.EntityFrameworkCore;

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
        modelBuilder.Entity<UserInfo>(entity =>
        {
            //entity.ToTable("Users"); // 映射到数据库表
            //entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
            //entity.Property(p => p.Price).HasColumnType("decimal(18,2)");
        });
    }
}
