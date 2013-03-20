using System;
using System.Web.Security;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.Web.Security
{
    public class KandaMembershipUser : MembershipUser
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="membership"></param>
        public KandaMembershipUser(MembershipEntity membership)
            : base(Membership.Provider.Name, membership.Name, membership.ID, @"", @"", @"", membership.Enabled, false, membership.CreatedOn, default(DateTime), default(DateTime), default(DateTime), default(DateTime))
        {
            this.doNothing();
        }

        /// <summary>
        /// 
        /// </summary>
        public long MembershipID
        {
            get { return (long) this.ProviderUserKey; }
        }

        #region Private members...

        /// <summary>
        /// 何もしない。
        /// </summary>
        private void doNothing()
        {
            // 何もしません
        }

        #endregion
    }
}