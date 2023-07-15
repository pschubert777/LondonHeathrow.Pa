using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LondonHeathrow.Pa.Web.Data
{
    [Table("Device")]
    public class DeviceData : BaseAudit
    {
        [Key]
        [Required]
        [MaxLength(25)]
        public string Id { get; set; }
        [MaxLength(25)]
        public string Name { get; set; }
        [MaxLength(25)]
        public string ConnectionId { get; set; }
    }
}

