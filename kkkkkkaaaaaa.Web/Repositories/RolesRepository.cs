using System;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Web.DataTransferObjects;
using kkkkkkaaaaaa.Web.TableDataGateways;

namespace kkkkkkaaaaaa.Web.Repositories
{
    /// <summary>
    /// Roles の Repository。
    /// </summary>
    public class RolesRepository : KandaRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        public RoleEntity Find(long id, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(DbDataReader);

            try
            {
                reader = RolesGateway.Select(new RoleEntity() { ID = id, }, connection, transaction);
                //reader = RolesGateway.Select(new RoleEntity() { ID = id, Name = @"", Description = @"", Enabled = true, }, connection, transaction);

                var entity = KandaDbDataMapper.MapToObject<RoleEntity>(reader);
                if (reader.Read()) { throw new Exception(string.Format(@"RolesRepository.Find({0})", id)); }

                return entity;
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Create(RoleEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var created = RolesGateway.Insert(entity, connection, transaction);

            return (created == 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Update(RoleEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var updated = RolesGateway.Update(entity, connection, transaction);

            return (updated == 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Truncate(DbConnection connection, DbTransaction transaction)
        {
            var error = RolesGateway.Truncate(connection, transaction);

            return (error == 0);
        }


        /// <summary>
        /// コンストラクタ―。
        /// </summary>
        internal RolesRepository()
        {
            this.DoNothing();
        }
    }
}