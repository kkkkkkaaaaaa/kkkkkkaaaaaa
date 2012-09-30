using System;
using System.Web.Security;

namespace kkkkkkaaaaaa.Web.DataTransferObjects
{
    public class KandaMembershipUser : MembershipUser
    {
        public KandaMembershipUser(MembershipEntity membership)
            : base(Membership.Provider.GetType().FullName, membership.Name, membership.ID, @"", @"", @"", true, false, membership.CreatedOn, default(DateTime), default(DateTime), default(DateTime), default(DateTime))
        {
            this.doNothing();
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