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
        /// �������Ȃ��B
        /// </summary>
        private void doNothing()
        {
            // �������܂���
        }

        #endregion
    }
}