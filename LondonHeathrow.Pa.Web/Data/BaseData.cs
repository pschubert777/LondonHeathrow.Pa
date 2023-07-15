using System.ComponentModel.DataAnnotations;

namespace LondonHeathrow.Pa.Web.Data;

public class BaseData : BaseAudit
{
    [Key]
    public Guid Id { get; set; }
}