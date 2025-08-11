using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.User.Application.Contracts.ContractCommon
{
    /// <summary>
    /// 分页查询基类
    /// </summary>
    public class PagerSearchDto
    {
        /// <summary>
        /// 页码（从1开始）
        /// </summary>
        public int PageIndex { get; set; } = 1;
        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { get; set; } = 10;
        /// <summary>
        /// 跳过条数
        /// </summary>
        public int PageSkip
        {
            get
            {
                if (PageIndex <= 0)
                    return 0;
                return (PageIndex - 1) * PageSize;
            }
        }
    }
}
