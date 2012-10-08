using System.Web.Security;
using kkkkkkaaaaaa.DataTransferObjects;
using kkkkkkaaaaaa.DomainModels;
using kkkkkkaaaaaa.Repositories;

namespace kkkkkkaaaaaa.Web.Security
{
    /// <summary>
    /// 
    /// </summary>
    public class KandaMembershipProvider : MembershipProvider
    {
        /// <summary>
        /// 新しいメンバーシップユーザーをデータソースに追加します。
        /// </summary>
        /// <returns>
        /// 新しく作成されたユーザーの情報が格納された <see cref="T:System.Web.Security.MembershipUser"/> オブジェクト。
        /// </returns>
        /// <param name="username">新しいユーザーのユーザー名。</param>
        /// <param name="password">新しいユーザーのパスワード。</param>
        /// <param name="email">新しいユーザーの電子メール アドレス。</param>
        /// <param name="passwordQuestion">新しいユーザーのパスワードの質問。</param>
        /// <param name="passwordAnswer">新しいユーザーのパスワードの解答。</param>
        /// <param name="isApproved">新しいユーザーを承認するかどうか。</param>
        /// <param name="providerUserKey">メンバーシップ データ ソースでのユーザーの一意の識別子。</param>
        /// <param name="status">ユーザーが正常に作成されたかどうかを示す <see cref="T:System.Web.Security.MembershipCreateStatus"/> 列挙値。</param>
        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            status = MembershipCreateStatus.InvalidQuestion;
            return null;
        }

        /// <summary>
        /// 指定のユーザー名とパスワードがデータソースに存在しているかどうかを検証します。
        /// </summary>
        /// <returns>
        /// 指定したユーザー名とパスワードが有効な場合は true。それ以外の場合は false。
        /// </returns>
        /// <param name="username">検証対象のユーザー名。</param>
        /// <param name="password">指定したユーザーのパスワード。</param>
        public override bool ValidateUser(string username, string password)
        {
            //throw new System.NotImplementedException();
            return Memberships.Validate(username, password);
        }

        /// <summary>
        /// メンバーシップ ユーザーの一意の識別子に基づいて、データ ソースからユーザー情報を取得します。ユーザーの最終利用日時スタンプを更新するオプションも提供されます。
        /// </summary>
        /// <returns>
        /// データ ソースから取得された指定のユーザーの情報が格納された <see cref="T:System.Web.Security.MembershipUser"/> オブジェクト。
        /// </returns>
        /// <param name="providerUserKey">情報を取得するメンバーシップ ユーザーの一意の識別子。</param><param name="userIsOnline">ユーザーの最終利用日時スタンプを更新する場合は true。ユーザーの最終利用日時スタンプを更新しないでユーザー情報を返す場合は false。</param>
        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new System.NotImplementedException();
        }


        #region Not implemented members...

        /// <summary>
        /// メンバーシップ ユーザーに対するパスワードの質問と解答の更新要求を処理します。
        /// </summary>
        /// <returns>
        /// パスワードの質問と解答が正常に更新された場合は true。それ以外の場合は false。
        /// </returns>
        /// <param name="username">パスワードの質問と解答を変更するユーザー。</param><param name="password">指定したユーザーのパスワード。</param><param name="newPasswordQuestion">指定したユーザーの新しいパスワード。</param><param name="newPasswordAnswer">指定したユーザーの新しいパスワードの解答。</param>
        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 指定したメンバーシップ ユーザーのパスワードをデータ ソースから取得します。
        /// </summary>
        /// <returns>
        /// 指定したユーザー名のパスワード。
        /// </returns>
        /// <param name="username">パスワードを取得するユーザー。</param><param name="answer">ユーザーのパスワードの解答。</param>
        public override string GetPassword(string username, string answer)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// メンバーシップ ユーザーに対するパスワードの更新要求を処理します。
        /// </summary>
        /// <returns>
        /// パスワードが正常に更新された場合は true。それ以外の場合は false。
        /// </returns>
        /// <param name="username">パスワードを更新するユーザー。</param><param name="oldPassword">指定したユーザーの現在のパスワード。</param><param name="newPassword">指定したユーザーの新しいパスワード。</param>
        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// ユーザーのパスワードを、自動的に生成された新しいパスワードにリセットします。
        /// </summary>
        /// <returns>
        /// 指定したユーザーの新しいパスワード。
        /// </returns>
        /// <param name="username">パスワードをリセットするユーザー。</param><param name="answer">指定したユーザーのパスワードの解答。</param>
        public override string ResetPassword(string username, string answer)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// データ ソース内のユーザー情報を更新します。
        /// </summary>
        /// <param name="user">更新するユーザーとそのユーザーの更新情報を表す <see cref="T:System.Web.Security.MembershipUser"/> オブジェクト。</param>
        public override void UpdateUser(MembershipUser user)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// ロックを解除して、メンバーシップ ユーザーの検証を可能にします。
        /// </summary>
        /// <returns>
        /// メンバーシップ ユーザーのロックが正常に解除された場合は true。それ以外の場合は false。
        /// </returns>
        /// <param name="userName">ロック ステータスを解除するメンバーシップ ユーザー。</param>
        public override bool UnlockUser(string userName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// データ ソースからユーザーの情報を取得します。ユーザーの最終利用日時スタンプを更新するオプションも提供されます。
        /// </summary>
        /// <returns>
        /// データ ソースから取得された指定のユーザーの情報が格納された <see cref="T:System.Web.Security.MembershipUser"/> オブジェクト。
        /// </returns>
        /// <param name="username">ユーザー情報を取得するユーザーの名前。</param><param name="userIsOnline">ユーザーの最終利用日時スタンプを更新する場合は true。ユーザーの最終利用日時スタンプを更新しないでユーザー情報を返す場合は false。</param>
        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 指定した電子メール アドレスに関連付けられているユーザー名を取得します。
        /// </summary>
        /// <returns>
        /// 指定した電子メール アドレスに関連付けられているユーザー名。一致する電子メール アドレスが見つからない場合、このメソッドは null を返します。
        /// </returns>
        /// <param name="email">検索対象の電子メール アドレス。</param>
        public override string GetUserNameByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// メンバーシップ データ ソースからユーザーを削除します。
        /// </summary>
        /// <returns>
        /// ユーザーが正常に削除された場合は true。それ以外の場合は false。
        /// </returns>
        /// <param name="username">削除するユーザーの名前。</param><param name="deleteAllRelatedData">データベースからそのユーザーに関連するデータを削除する場合は true。データベース内のそのユーザーに関連するデータをそのままにしておく場合は false。</param>
        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// データ ソース内のすべてのユーザーのページのコレクションを取得します。
        /// </summary>
        /// <returns>
        /// <paramref name="pageIndex"/> で指定されたページから始まる <paramref name="pageSize"/><see cref="T:System.Web.Security.MembershipUser"/> オブジェクトのページを格納している <see cref="T:System.Web.Security.MembershipUserCollection"/>。
        /// </returns>
        /// <param name="pageIndex">取得する結果のページのインデックス。<paramref name="pageIndex"/> が 0 から始まっています。</param><param name="pageSize">取得する結果のページのサイズ。</param><param name="totalRecords">一致したユーザーの総数。</param>
        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// アプリケーションに現在アクセスしているユーザーの数を取得します。
        /// </summary>
        /// <returns>
        /// アプリケーションに現在アクセスしているユーザーの数。
        /// </returns>
        public override int GetNumberOfUsersOnline()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// ユーザー名が指定内容と一致するメンバーシップ ユーザーのコレクションを取得します。
        /// </summary>
        /// <returns>
        /// <paramref name="pageIndex"/> で指定されたページから始まる <paramref name="pageSize"/><see cref="T:System.Web.Security.MembershipUser"/> オブジェクトのページを格納している <see cref="T:System.Web.Security.MembershipUserCollection"/>。
        /// </returns>
        /// <param name="usernameToMatch">検索するユーザー名。</param><param name="pageIndex">取得する結果のページのインデックス。<paramref name="pageIndex"/> が 0 から始まっています。</param><param name="pageSize">取得する結果のページのサイズ。</param><param name="totalRecords">一致したユーザーの総数。</param>
        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 電子メール アドレスが指定内容と一致するメンバーシップ ユーザーのコレクションを取得します。
        /// </summary>
        /// <returns>
        /// <paramref name="pageIndex"/> で指定されたページから始まる <paramref name="pageSize"/><see cref="T:System.Web.Security.MembershipUser"/> オブジェクトのページを格納している <see cref="T:System.Web.Security.MembershipUserCollection"/>。
        /// </returns>
        /// <param name="emailToMatch">検索対象の電子メール アドレス。</param><param name="pageIndex">取得する結果のページのインデックス。<paramref name="pageIndex"/> が 0 から始まっています。</param><param name="pageSize">取得する結果のページのサイズ。</param><param name="totalRecords">一致したユーザーの総数。</param>
        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// ユーザーがパスワードを取得できるように、メンバーシップ プロバイダーが構成されているかどうかを示します。
        /// </summary>
        /// <returns>
        /// メンバーシップ プロバイダーがパスワードの取得をサポートしている場合は true。それ以外の場合は false。既定値は false です。
        /// </returns>
        public override bool EnablePasswordRetrieval
        {
            get { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// ユーザーがパスワードをリセットできるように、メンバーシップ プロバイダーが構成されているかどうかを示します。
        /// </summary>
        /// <returns>
        /// メンバーシップ プロバイダーがパスワードのリセットをサポートしている場合は true。それ以外の場合は false。既定値は true です。
        /// </returns>
        public override bool EnablePasswordReset
        {
            get { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// ユーザーがパスワードをリセットおよび取得する際にパスワードの質問に答えなければならないように、メンバーシップ プロバイダーが構成されているかどうかを示す値を取得します。
        /// </summary>
        /// <returns>
        /// パスワードをリセットまたは取得する際にパスワードの解答を要求する場合は true。それ以外の場合は false。既定値は true です。
        /// </returns>
        public override bool RequiresQuestionAndAnswer
        {
            get { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// カスタム メンバーシップ プロバイダーを使用するアプリケーションの名前。
        /// </summary>
        /// <returns>
        /// カスタム メンバーシップ プロバイダーを使用するアプリケーションの名前。
        /// </returns>
        public override string ApplicationName
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// メンバーシップ ユーザーがロックされるまでの無効なパスワードまたはパスワード解答の指定回数を取得します。
        /// </summary>
        /// <returns>
        /// メンバーシップ ユーザーがロックされるまでの無効なパスワードまたはパスワード解答の指定回数。
        /// </returns>
        public override int MaxInvalidPasswordAttempts
        {
            get { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// 無効なパスワードまたはパスワードの解答を最大回数まで指定できる、メンバーシップ ユーザーがロックされるまでの期間を示す分数を取得します。
        /// </summary>
        /// <returns>
        /// 無効なパスワードまたはパスワードの解答を最大回数まで指定できる、メンバーシップ ユーザーがロックされるまでの期間を示す分数。
        /// </returns>
        public override int PasswordAttemptWindow
        {
            get { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// メンバーシップ プロバイダーが各ユーザー名に対して一意の電子メール アドレスを要求するかどうかを示す値を取得します。
        /// </summary>
        /// <returns>
        /// メンバーシップ プロバイダーが一意の電子メール アドレスを必要とする場合は true。それ以外の場合は false。既定値は true です。
        /// </returns>
        public override bool RequiresUniqueEmail
        {
            get { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// メンバーシップ データ ソースにパスワードを格納する形式を示す値を取得します。
        /// </summary>
        /// <returns>
        /// データ ソースにパスワードを格納する形式を示す <see cref="T:System.Web.Security.MembershipPasswordFormat"/> 値の 1 つ。
        /// </returns>
        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// パスワードに最低限必要な長さを取得します。
        /// </summary>
        /// <returns>
        /// パスワードに最低限必要な長さ。
        /// </returns>
        public override int MinRequiredPasswordLength
        {
            get { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// 有効なパスワードに最低限含むことが必要な特殊文字の数を取得します。
        /// </summary>
        /// <returns>
        /// 有効なパスワードに最低限含むことが必要な特殊文字の数。
        /// </returns>
        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// パスワードの評価に使用される正規表現を取得します。
        /// </summary>
        /// <returns>
        /// パスワードの評価に使用される正規表現。
        /// </returns>
        public override string PasswordStrengthRegularExpression
        {
            get { throw new System.NotImplementedException(); }
        }

        #endregion
    }
}