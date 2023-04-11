using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Books.BackendServer.Data.Entities
{
    [Table("Books")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        [Required]
        public string Title { get; set; } = string.Empty;

        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string? Topic { get; set; }


        [Required]
        public int AuthorId { get; set; }
        public int PublishYear { get; set; }

        [MaxLength(50)]
        private decimal _Price;
        public decimal Price
        {
            get
            {  return Math.Round(_Price, 2); }
            set
            {
                _Price = value;
            } 
        }
        [Column(TypeName = "tinyint")]
        [MaxLength(5)]
        public int Rating { get; set; }
        
        
    }
}
