using TVarApplication.Mappings;
using Arctic.NHibernateExtensions;
using Autofac;

namespace TVarApplication
{
    /// <summary>
    /// 用于向容器注册类型的扩展方法。在 Startup.ConfigureContainer 方法中调用。
    /// </summary>
    public static class ModuleProjectContainerBuilderExtensions
    {
        public static void AddModuleProject(this ContainerBuilder builder)
        {
            builder.AddModelMapper<ModuleProjectModelMapper>();
        }
    }
}
