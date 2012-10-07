using System.Web.Security;

namespace kkkkkkaaaaaa.Web.Security
{
    public class KandaRoleProvider : RoleProvider
    {
        /// <summary>
        /// 指定されたユーザーが、構成済みの applicationName の指定されたロールに存在するかどうかを示す値を取得します。
        /// </summary>
        /// <returns>
        /// 指定されたユーザーが構成済みの applicationName の指定されたロールにある場合は true。それ以外の場合は false。
        /// </returns>
        /// <param name="username">検索するユーザー名。</param><param name="roleName">検索範囲とするロール。</param>
        public override bool IsUserInRole(string username, string roleName)
        {
            throw new System.NotImplementedException();
        }

        #region Not implementd members...

        /// <summary>
        /// 構成済みの applicationName で指定されたユーザーに割り当てられたロールのリストを取得します。
        /// </summary>
        /// <returns>
        /// 構成済みの applicationName で指定されたユーザーに割り当てられているすべてのロールの名前を格納している文字列配列。
        /// </returns>
        /// <param name="username">ロールの一覧を取得するユーザー。</param>
        public override string[] GetRolesForUser(string username)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 新しいロールを構成済みの applicationName のデータ ソースに追加します。
        /// </summary>
        /// <param name="roleName">作成するロールの名前。</param>
        public override void CreateRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 構成済みの applicationName のデータ ソースからロールを削除します。
        /// </summary>
        /// <returns>
        /// ロールが正常に削除された場合は true。それ以外の場合は false。
        /// </returns>
        /// <param name="roleName">削除するロールの名前。</param><param name="throwOnPopulatedRole">true の場合、<paramref name="roleName"/> に 1 つ以上のメンバーがあれば例外をスローし、<paramref name="roleName"/> を削除しません。</param>
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 指定されたロール名が、構成済みの applicationName のロール データ ソースに既に存在するかどうかを示す値を取得します。
        /// </summary>
        /// <returns>
        /// ロール名が構成済みの applicationName のデータ ソースに既に存在する場合は true。それ以外の場合は false。
        /// </returns>
        /// <param name="roleName">データ ソースで検索するロールの名前。</param>
        public override bool RoleExists(string roleName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 指定されたユーザー名を、構成済みの applicationName の指定されたロールに追加します。
        /// </summary>
        /// <param name="usernames">指定されたロールに追加するユーザー名の文字列配列。</param><param name="roleNames">指定されたユーザー名の割り当て先となるロール名の文字列配列。</param>
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 指定したユーザー名を構成済みの applicationName の指定したロールから削除します。
        /// </summary>
        /// <param name="usernames">指定されたロールから削除するユーザー名の文字列配列。</param><param name="roleNames">指定されたユーザー名を削除するロール名の文字列配列。</param>
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 構成済みの applicationName の指定されたロールに属するユーザーのリストを取得します。
        /// </summary>
        /// <returns>
        /// 構成済みの applicationName の指定されたロールのメンバーであるすべてのユーザーの名前を格納している文字列配列。
        /// </returns>
        /// <param name="roleName">ユーザーについて一覧を取得するロールの名前。</param>
        public override string[] GetUsersInRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 構成済みの applicationName のすべてのロールのリストを取得します。
        /// </summary>
        /// <returns>
        /// 構成済みの applicationName のデータ ソースに保存されているすべてのロール名を格納している文字列配列。
        /// </returns>
        public override string[] GetAllRoles()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 指定されたロールで、ユーザー名が指定内容と一致するユーザーの配列を取得します。
        /// </summary>
        /// <returns>
        /// <paramref name="usernameToMatch"/> に一致するユーザー名を持ち、指定されたロールのメンバーであるすべてのユーザーの名前を格納している文字列配列。
        /// </returns>
        /// <param name="roleName">検索範囲とするロール。</param><param name="usernameToMatch">検索するユーザー名。</param>
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// ロール情報を保管および取得するアプリケーションの名前を取得または設定します。
        /// </summary>
        /// <returns>
        /// ロール情報を保管および取得するアプリケーションの名前。
        /// </returns>
        public override string ApplicationName
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        #endregion
    }
}