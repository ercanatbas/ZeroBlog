using DapperExtensions.Mapper;
using System.Collections.Generic;
using System.Linq;

namespace ZBlog.Core.Entity.Map
{
    public static class MapperExtensions
    {
        public static void ConfigureIdentity(this IList<IPropertyMap> list, string columnName = "Id")
        {
            var obj = list.FirstOrDefault(x => x.Name.Equals(columnName));
            obj?.GetType().GetProperty("KeyType")?.SetValue(obj, KeyType.Identity);
        }
    }
}
