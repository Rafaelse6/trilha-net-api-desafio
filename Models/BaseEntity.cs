using System.ComponentModel.DataAnnotations.Schema;

namespace TrilhaApiDesafio.Models
{
    public class BaseEntity
    {

        [Column("id")]
        public int Id { get; set; }
    }
}
