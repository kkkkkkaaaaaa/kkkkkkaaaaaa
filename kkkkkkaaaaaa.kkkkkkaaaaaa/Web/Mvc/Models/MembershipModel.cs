using System.ComponentModel.DataAnnotations;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.Web.Mvc.Models
{
    public class MembershipModel : MembershipEntity
    {
        [Required]
        public override string Name { get; set; }
    }
}