using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Books.BackendServer.Data.Entities
{
    [Table("Authors")]
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)" )]
        [Required]
        public string ?Name { get; set; }

        [Required]
        public bool? Female { get; set; }

        [Required]
        public int Born { get; set; }

        public int Died { get; set; }

    }
}
