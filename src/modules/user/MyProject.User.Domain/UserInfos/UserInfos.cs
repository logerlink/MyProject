using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace MyProject.User.Domain.UserInfos;


/**
 * abp自带的审计实体：
 * FullAuditedEntity：包含完整审计字段（创建时间、创建人、最后修改时间、修改人、软删除标记、删除人/时间）
 * AuditedEntity：仅包含创建和修改审计字段（无软删除相关字段）
 * Entity：仅包含Id
 * CreationAuditedEntity：仅包含创建时间和创建人
*/

/// <summary>
/// 自定义指定表名
/// </summary>
[Table("UserInfo")]
public class UserInfo : Entity<int>
{
    /// <summary>
    /// 自定义指定列名
    /// </summary>
    [Column("Username")]
    public required string Name { get; set; }   // required 表示不可空

    public required string Password { get; set; }

    public int Type { get; set; }
    public string? PhoneNumber { get; set; }    // 表示字段可空
    public DateTime CreateTime { get; set; }
}
