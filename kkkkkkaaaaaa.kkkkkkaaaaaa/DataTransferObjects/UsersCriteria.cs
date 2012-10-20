using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.DataTransferObjects
{
    public struct UsersCriteria
    {
        /*
        public UsersCriteria()
        {
            @id					BIGINT
            , @familyName		NVARCHAR(1024)
            , @givenName		NVARCHAR(1024)
            , @additionalName	NVARCHAR(1024)
            , @description		NVARCHAR(MAX)		
            , @enabled			BIT
            , @createdOn		DATETIME2
            , @updatedOn		DATETIME2
        }
         */

        [KandaDbParameterMapping("id")]
        public long ID { get; set; }
        
        [KandaDbParameterMapping("enabled")]
        public bool Enabled { get; set; }
    }
}