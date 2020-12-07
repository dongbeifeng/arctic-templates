using Arctic.Auditing;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application
{
    /// <summary>
    /// 实体类。所有公共属性和方法必须为 virtual。
    /// </summary>
    public class Clazz : IHasCuser, IHasCtime, IHasMuser, IHasMtime
    {
        /// <summary>
        /// 主键。使用 int 类型，使用 ClazzId 的形式命名。
        /// </summary>
        public virtual int ClazzId { get; set; }

        /// <summary>
        /// <see cref="RequiredAttribute"/> 指示属性不可为 null，<see cref="MaxLengthAttribute"/> 指示字段的最大长度。
        /// </summary>
        [Required]
        [MaxLength(50)]
        public virtual string Prop1 { get; set; }


        public virtual int Prop2 { get; set; }

        #region auditing properties

        public virtual string cuser { get; set; }
        public virtual string muser { get; set; }
        public virtual DateTime mtime { get; set; }
        public virtual DateTime ctime { get; set; }

        #endregion

    }
}
