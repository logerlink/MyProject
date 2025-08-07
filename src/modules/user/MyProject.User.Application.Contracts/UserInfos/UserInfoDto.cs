namespace MyProject.User.Application.Contracts.UserInfos;

public class UserInfoDto
{
    public string Name { get; set; }

    public string Password { get; set; }

    public int Type { get; set; }
    public string? PhoneNumber { get; set; }    // 表示字段可空
    public DateTime CreateTime { get; set; }
}


