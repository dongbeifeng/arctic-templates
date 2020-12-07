using Arctic.NHibernateExtensions;
using System.Reflection;

namespace TVarApplication.Mappings
{
    internal class ModuleProjectModelMapper : XModelMapper
    {
        public ModuleProjectModelMapper()
        {
            // 添加映射类
            this.AddMappings(Assembly.GetExecutingAssembly().GetTypes());
        }
    }
}
