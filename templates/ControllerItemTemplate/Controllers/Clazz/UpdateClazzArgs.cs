using System.ComponentModel.DataAnnotations;

namespace Application.Web.Controllers
{
    /// <summary>
    /// 更新操作的参数
    /// </summary>
    public class UpdateClazzArgs
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string? Prop1 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int Prop2 { get; set; }

    }
}
