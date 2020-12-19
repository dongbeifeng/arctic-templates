using Arctic.AspNetCore;
using Arctic.NHibernateExtensions;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClazzController : ControllerBase
    {
        readonly ISession _session;
        readonly ILogger _logger;

        public ClazzController(ISession session, ILogger logger)
        {
            _session = session;
            _logger = logger;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="args">查询参数</param>
        /// <returns></returns>
        [HttpPost]
        [DebugShowArgs]
        [AutoTransaction]
        [Route("list")]
        public async Task<ClazzList> List(ClazzListArgs args)
        {
            var pagedList = await _session.Query<Clazz>().SearchAsync(args, args.Sort, args.Current, args.PageSize);
            return new ClazzList
            {
                Success = true,
                Message = "OK",                
                Data = pagedList.List.Select(x => new ClazzListItem
                {
                    ClazzId = x.ClazzId,
                    Prop1 = x.Prop1,
                    Prop2 = x.Prop2,
                }),
                Total = pagedList.Total
            };
        }

        /// <summary>
        /// 详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [AutoTransaction]
        public async Task<ClazzDetail> Detail(int id)
        {
            var clazz = await _session.GetAsync<Clazz>(id);
            return new ClazzDetail 
            {
                ClazzId = Clazz.ClazzId,
                Prop1 = Clazz.Prop1,
                Prop2 = Clazz.Prop2,
            };
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoTransaction]
        [Route("create")]
        public async Task<OperationResult> Create(CreateClazzArgs args)
        {
            Clazz clazz = new Clazz
            {
                Prop1 = args.Prop1,
                Prop2 = args.Prop2,
            };
            await _session.SaveAsync(clazz);
            return new OperationResult { Success = true, Message = "OK" };
        }


        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="args"></param>
        [HttpPut("update/{id}")]
        [AutoTransaction]
        public async Task<OperationResult> Update(int id, [FromBody] UpdateClazzArgs args)
        {
            Clazz? clazz = await _session.GetAsync<Clazz>(id);
            if (clazz == null)
            {
                throw new InvalidOperationException();
            }
            clazz.Prop1 = args.Prop1;
            clazz.Prop2 = args.Prop2;
            await _session.UpdateAsync(clazz);
            return new OperationResult { Success = true, Message = "OK" };
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AutoTransaction]
        [HttpDelete("{id}")]
        public async Task<OperationResult> Delete(int id)
        {
            Clazz? clazz = await _session.GetAsync<Clazz>(id);
            if (clazz == null)
            {
                throw new InvalidOperationException();
            }
            await _session.DeleteAsync(clazz);
            return new OperationResult { Success = true, Message = "OK" };

        }
    }
}
