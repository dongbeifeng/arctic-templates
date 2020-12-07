using System.Collections.Generic;

namespace Application.Web.Controllers
{
    /// <summary>
    /// 列表页结果
    /// </summary>
    public class ClazzList : OperationResult
    {
        /// <summary>
        /// 当前分页的数据
        /// </summary>
        public IEnumerable<ClazzListItem>? Data { get; init; }

        /// <summary>
        /// 总共有多少个数据
        /// </summary>
        public int Total { get; init; }
    }


}
