using System;
using System.Web.Security;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.Web.Security
{
    public class KandaMembershipUser : MembershipUser
    {
        public KandaMembershipUser(MembershipEntity membership)
            : base(Membership.Provider.Name, membership.Name, membership.ID, @"", @"", @"", membership.Enabled, false, membership.CreatedOn, default(DateTime), default(DateTime), default(DateTime), default(DateTime))
        {
            this.doNothing();
        }

        #region Private members...

        /// <summary>
        /// �������Ȃ��B
        /// </summary>
        private void doNothing()
        {
            // �������܂���
        }

        #endregion
    }
}