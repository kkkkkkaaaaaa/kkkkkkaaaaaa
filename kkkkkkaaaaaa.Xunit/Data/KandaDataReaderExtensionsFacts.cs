using System.Data;
using kkkkkkaaaaaa.Data;
using kkkkkkaaaaaa.Xunit.Aggregates.Entities;
using Microsoft.CSharp.RuntimeBinder;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class KandaDataReaderExtensionsFacts : KandaXunitFacts
    {
        /// <summary></summary>
        [Fact()]
        public void AsObjectFact()
        {
            using (var connection = this.Provider.CreateConnection())
            using (var reader = this.Provider.CreateDataReader(connection))
            {
                reader.CommandType = CommandType.Text;
                reader.CommandText = @"SELECT TOP(1) * FROM Person.Person";

                connection.Open();

                var person = reader.ExecuteReader()
                    .AsObject<PersonEntity>();

                Assert.NotNull(person);

            } // reader.Dispose(); connection.Dispose();
        }
        
        /// <summary></summary>
        [Fact()]
        public void AsObjectEnumerableFact()
        {
            using (var connection = this.Provider.CreateConnection())
            using (var reader = this.Provider.CreateDataReader(connection))
            {
                reader.CommandType = CommandType.Text;
                reader.CommandText = @"SELECT TOP(10) * FROM Person.Person";

                connection.Open();

                var people = reader
                    .ExecuteReader()
                    .AsObjectEnumerable<PersonEntity>();
        
                Assert.NotNull(people);
                Assert.True(0 < people.Count());
            }
        }
        
        /// <summary></summary>
        [Fact()]
        public void AsDynamicFact()
        {
            using (var connection = this.Provider.CreateConnection())
            using (var reader = this.Provider.CreateDataReader(connection))
            {
                reader.CommandType = CommandType.Text;
                reader.CommandText = @"SELECT TOP(1) * FROM Person.Person";

                connection.Open();

                var person = reader.ExecuteReader()
                    .AsDynamic();

                Assert.NotNull(person);
                Assert.NotNull(person.BusinessEntityID);
            }
        }
        
        /// <summary></summary>
        [Fact()]
        public void AsDynamicEnumerableFact()
        {
            using (var connection = this.Provider.CreateConnection())
            using (var reader = this.Provider.CreateDataReader(connection))
            {
                reader.CommandType = CommandType.Text;
                reader.CommandText = @"SELECT TOP(10) * FROM Person.Person";

                connection.Open();

                var people = reader.ExecuteReader()
                    .AsDynamicEnumerable();

                Assert.NotNull(people);
                Assert.True(0 < people.Count());
                var _ = people
                    .Select(p =>
                    {
                        Assert.NotNull(p.BusinessEntityID);
                        Assert.Throws<RuntimeBinderException>(() => p.NotContansProperty);

                        return p;
                    })
                    .ToArray();
            }
        }

        /// <summary></summary>
        [Fact()]
        public void AsDataTableFact()
        {
            using (var connection = this.Provider.CreateConnection())
            using (var reader = this.Provider.CreateDataReader(connection))
            {
                reader.CommandType = CommandType.Text;
                reader.CommandText = @"SELECT TOP(10) * FROM Person.Person";

                connection.Open();

                var people = reader.ExecuteReader()
                    .AsDataTable();

                Assert.NotNull(people);
                Assert.NotNull(0 < people.Columns.Count);
            }
        }
    }
}
