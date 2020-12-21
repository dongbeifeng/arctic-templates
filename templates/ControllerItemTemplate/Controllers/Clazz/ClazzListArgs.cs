using System;
using System.Collections.Specialized;

namespace Application.Web.Controllers
{
    /// <summary>
    /// 列表查询参数
    /// </summary>
    public class ClazzListArgs
    {
        /// <summary>
        /// 使用 SearchArg 表示属性是查询参数。SearchMode.Like 表示支持模糊查找，
        /// 使用 ? 表示一个字符，使用 * 表示任意个字符。
        /// </summary>
        [SearchArg(SearchMode.Like)]
        public string? Prop1 { get; set; }

        /// <summary>
        /// 当源属性名称和参数不同时，SourceProperty 指示在数据源的哪个属性上查找。
        /// </summary>
        [SourceProperty(nameof(Clazz.Prop2))]
        [SearchArg(SearchMode.GreaterOrEqual)]
        public int? Prop2From { get; set; }


        /// <summary>
        /// 当 SearchMode 为 Expression 时，则使用具有约定名称的的属性来确定查询条件。
        /// 约定的属性名为此属性名后跟 Expr 后缀。
        /// </summary>
        [SearchArg(SearchMode.Expression)]
        public int? Prop2To { get; set; }

        /// <summary>
        /// 为 Prop2To 属性提供查询表达式。
        /// 应使用 internal 修饰符，否则 swagger 提供的接口文档会出现 System.Reflection 命名空间中的类型。
        /// </summary>
        internal Expression<Func<Clazz, bool>>? Prop2ToExpr
        {
            get
            {
                if (Prop2To == null)
                {
                    return null;
                }

                return (x => x.Prop2 < Prop2To.Value);
            }
        }

        /// <summary>
        /// 名为 Filter 的公共实例方法会先被调用。参数和返回值应为 IQueryable{Clazz}。
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public IQueryable<Clazz> Filter(IQueryable<Clazz> q)
        {
            return q;
        }
        
        /// <summary>
        /// 排序字段
        /// </summary>
        public OrderedDictionary? Sort { get; set; }

        /// <summary>
        /// 基于 1 的当前页面。
        /// </summary>
        public int? Current { get; set; }

        /// <summary>
        /// 每页大小
        /// </summary>
        public int? PageSize { get; set; }

    }
}
