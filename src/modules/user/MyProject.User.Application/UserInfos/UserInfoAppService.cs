using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using MyProject.User.Domain.UserInfos;
using MyProject.User.Application.Contracts.UserInfos;
using MyProject.User.Application.Contracts.Users;
using MyProject.User.Domain.Users;
using Volo.Abp.Auditing;
using Volo.Abp.Validation;
using Volo.Abp;

namespace MyProject.User.Application.UserInfos;

/// <summary>
/// 禁用日志审计和自动校验
/// </summary>
[DisableAuditing,DisableValidation]
// swagger：非必须，默认值为true，如果设为false，则不会展示该service
[RemoteService(IsEnabled = true)]
// swagger：必须
public class UserInfoAppService : ApplicationService, IUserInfoAppService   // 不强制实现IUserInfoAppService，不过一般都会实现
{
    private readonly IRepository<UserInfo, int> _userInfoRepository;
    /// <summary>
    /// 自定义User仓储接口
    /// </summary>
    private readonly IUserInfoRepository _myUserInfoRepository;

    public UserInfoAppService(IRepository<UserInfo, int> userInfoRepository, IUserInfoRepository myUserInfoRepository)
    {
        _userInfoRepository = userInfoRepository;
        _myUserInfoRepository = myUserInfoRepository;
    }

    /// <summary>
    /// 获取集合
    /// </summary>
    /// <returns></returns>
    // swagger：必须，类或方法使用 public 公开访问
    public async Task<List<UserInfoDto>> GetListAsync()
    {
        //_myUserInfoRepository.MyAdd(null);
        var models = await _userInfoRepository.GetListAsync();
        return ObjectMapper.Map<List<UserInfo>, List<UserInfoDto>>(models);
    }
    /// <summary>
    /// 根据Id获取实体
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<UserInfoDto> GetByIdAsync(int id)
    {
        var model = await _userInfoRepository.GetAsync(id);
        return ObjectMapper.Map<UserInfo, UserInfoDto>(model);
    }
    public async Task<UserInfoDto> CreateAsync(CreateUserInfoDto inputDto)
    {
        var model = ObjectMapper.Map<CreateUserInfoDto, UserInfo>(inputDto);
        model.CreateTime = DateTime.Now;
        model = await _userInfoRepository.InsertAsync(model);
        return ObjectMapper.Map<UserInfo, UserInfoDto>(model);
    }
}
