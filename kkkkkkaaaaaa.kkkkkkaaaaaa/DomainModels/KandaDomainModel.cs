using System;
using System.Threading;
using kkkkkkaaaaaa.Data;
using kkkkkkaaaaaa.Repositories;

namespace kkkkkkaaaaaa.DomainModels
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class KandaDomainModel
    {
        #region Protected members...

        /// <summary>
        /// もしません。
        /// </summary>
        protected void DoNothing()
        {
            // もしない
        }

        /// <summary></summary>
        protected readonly KandaProviderFactory _factory = KandaProviderFactory.Instance;

        #endregion
    }
}