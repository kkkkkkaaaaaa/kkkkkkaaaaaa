using kkkkkkaaaaaa.Data;
using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.Xunit.Repositories
{
    /// <summary>
    /// Kanda.Xunit.Repositories �̊��N���X�ł��B
    /// </summary>
    public abstract class KandaXunitRepositoryFacts
    {
        /// <summary>
        /// ���̃A�v���P�[�V�����̃f�[�^�v���o�C�_�[�̃N���X�̃C���X�^���X�𐶐����ĕԂ��AFactory Mathod ��񋟂��܂��B
        /// </summary>
        protected KandaDbProviderFactory _factory = KandaProviderFactory.Instance;
    }
}