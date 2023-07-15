using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LondonHeathrow.Pa.Web.Data
{
	public class BaseAudit
	{
        public Guid CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public virtual UserData CreatedByUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid ModifiedBy { get; set; }
        [ForeignKey("ModifiedBy")]
        public virtual UserData ModifiedByUser { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}

