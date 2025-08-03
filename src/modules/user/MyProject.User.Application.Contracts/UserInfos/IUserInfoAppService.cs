using MyProject.User.Application.Contracts.UserInfos;
using MyProject.User.Application.Contracts.Users;
using Volo.Abp.Application.Services;

namespace MyProject.User.Application.Contracts.UserInfos;

public interface IUserInfoAppService : IApplicationService
{
    Task<List<UserInfoDto>> GetListAsync();

    Task<UserInfoDto> GetByIdAsync(int id);

    Task<UserInfoDto> CreateAsync(CreateUserInfoDto input);
}
