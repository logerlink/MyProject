using AutoMapper;
using MyProject.User.Application.Contracts.UserInfos;
using MyProject.User.Domain.UserInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.User.Application
{
    internal class UserModuleApplicationAutoMapperProfile:Profile
    {
        public UserModuleApplicationAutoMapperProfile()
        {
            CreateMap<UserInfo, UserInfoDto>();
        }
    }
}
