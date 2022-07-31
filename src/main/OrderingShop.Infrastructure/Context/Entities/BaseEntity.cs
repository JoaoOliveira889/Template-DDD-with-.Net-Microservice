using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderingShop.Infrastructure.Context.Entities
{
    public class BaseEntity
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
    }
}

