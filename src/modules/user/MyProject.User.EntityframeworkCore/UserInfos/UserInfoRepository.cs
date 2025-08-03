using Microsoft.EntityFrameworkCore;
using MyProject.User.Domain.UserInfos;
using MyProject.User.Domain.Users;
using MyProject.User.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MyProject.User.EntityframeworkCore.Users
{
    /// <summary>
    /// User仓储实现 实现自定义仓储
    /// </summary>
    public class UserInfoRepository : EfCoreRepository<UserModuleDbContext, UserInfo, int>, IUserInfoRepository
    {
        public UserInfoRepository(IDbContextProvider<UserModuleDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public void MyAdd(UserInfo user)
        {
            throw new NotImplementedException();
        }
    }
}
