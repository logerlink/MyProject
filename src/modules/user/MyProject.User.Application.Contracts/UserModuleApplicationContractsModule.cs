using MyProject.User.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace MyProject.User.Application.Contracts
{
    [DependsOn(
        typeof(UserModuleSharedModule)
    )]
    public class UserModuleApplicationContractsModule: AbpModule
    {
    }
}
