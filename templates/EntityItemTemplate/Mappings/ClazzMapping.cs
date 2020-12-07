using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Application.Mappings
{
    internal class ClazzMapping : ClassMapping<Clazz>
    {
        public ClazzMapping()
        {
            Table(nameof(Clazz));
            DynamicUpdate(true);
            BatchSize(10);

            Id(cl => cl.ClazzId, id => id.Generator(Generators.Identity));

            Property(cl => cl.ctime, prop => prop.Update(false));
            Property(cl => cl.cuser, prop => prop.Update(false));
            Property(cl => cl.mtime);
            Property(cl => cl.muser);
            Property(cl => cl.Prop1);
            Property(cl => cl.Prop2);
        }
    }
}
