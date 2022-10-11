using System.Data;
using kkkkkkaaaaaa.Data;
using kkkkkkaaaaaa.Xunit.Aggregates.Entities;
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
                reader.CommandText = @"SELECT TOP(100) * FROM Person.Person";

                connection.Open();

                var people = reader
                    .ExecuteReader()
                    .AsObjectEnumerable<PersonEntity>();
        
                Assert.NotNull(people);
                Assert.True(0 < people.Count());
            }
        }

        /*
        /// <summary></summary>
        [Fact()]
        public void AsDynamicEnumerableFact()
        {
            using (var connection = this.Provider.CreateConnection())
            using (var reader = this.Provider.CreateDataReader(connection))
            {
                reader.CommandType = CommandType.Text;
                reader.CommandText = @"SELECT TOP(1) * FROM Person.Person";

                connection.Open();

                var person = reader.ExecuteReader()
                    .AsDynamic<PersonEntity>();

                Assert.NotNull(person)
            }
        }
        */

        /*
        /// <summary></summary>
        [Fact()]
        public void AsDynamicEnumerableFact()
        {
            using (var connection = this.Provider.CreateConnection())
            using (var reader = this.Provider.CreateDataReader(connection))
            {
                reader.CommandType = CommandType.Text;
                reader.CommandText = @"SELECT TOP(100) * FROM Person.Person";

                connection.Open();

                var people = reader.ExecuteReader()
                    .AsDynamicEnumerable();

                Assert.NotNull(people);
                Assert.True(0 < people.Count);
            }
        }
        */
    }
}
