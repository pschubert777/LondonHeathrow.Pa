using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LondonHeathrow.Pa.Web.Data
{
    [Table("User")]
    public class UserData : BaseData
    {
        [MaxLength(50)]
        public string DisplayName { get; set; }
        [MaxLength(25)]
        public string FirstName { get; set; }
        [MaxLength(25)]
        public string LastName { get; set; }
    }
}