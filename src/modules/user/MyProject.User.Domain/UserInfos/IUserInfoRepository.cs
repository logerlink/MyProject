using MyProject.User.Domain.UserInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MyProject.User.Domain.Users
{
    /// <summary>
    /// 自定义仓储层，大多数情况下是不需要自定义的
    /// </summary>
    public interface IUserInfoRepository:IRepository<UserInfo>
    {
        void MyAdd(UserInfo user);
    }
}
