using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Diagnostics;
using System.Threading.Tasks;

namespace kkkkkkaaaaaa.Data.Common
{
    public partial class KandaDbDataMapper
    {
        public static async Task<ICollection<T>> MapToCollectionAsync<T>(DbDataReader reader) where T : new()
        {
            var collection = new Collection<T>();

            while (await reader.ReadAsync())
            {
                var obj = KandaDbDataMapper.MapToObject<T>(reader);
                collection.Add(obj);
            }

            return collection;
        }

        [DebuggerStepThrough()]
        public static async Task<IEnumerable<T>> MapToEnumerableAsync<T>(DbDataReader reader) where T : new()
        {
            return await KandaDbDataMapper.MapToCollectionAsync<T>(reader);
        }

    }
}