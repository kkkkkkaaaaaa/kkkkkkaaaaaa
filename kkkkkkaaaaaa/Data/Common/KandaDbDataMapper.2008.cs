using System.Collections.ObjectModel;
using System.Data;

namespace kkkkkkaaaaaa.Data.Common
{
    public partial class KandaDbDataMapper
    {
        /// <summary>
        /// 
        /// </summary>
        public static ObservableCollection<T> MapToObservableCollection<T>(IDataReader reader) where T : new()
        {
            var collection = new ObservableCollection<T>();

            while (reader.Read())
            {
                var item = KandaDbDataMapper.MapToObject<T>(reader);
                collection.Add(item);
            }

            return collection;
        }
    }
}