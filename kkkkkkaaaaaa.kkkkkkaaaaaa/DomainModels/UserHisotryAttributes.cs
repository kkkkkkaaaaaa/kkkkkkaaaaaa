using System.Collections.Generic;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.DomainModels
{
    public class UserHisotryAttributes
    {
        private UserHistoryEntity _entity;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public UserHisotryAttributes(UserHistoryEntity entity)
        {
            this._entity = entity;
        }

        public long UserID { get; private set; }

        public int Revision { get; private set; }

        public ICollection<UserHistoryAttributeEntity> Attributes { get; private set; }

        public UserHisotryAttributes Get()
        {
            return this;
        }

        public UserHisotryAttributes Create()
        {
            return this;
        }
    }
}