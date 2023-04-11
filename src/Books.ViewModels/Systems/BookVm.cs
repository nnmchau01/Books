using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.ViewModels.Systems
{
    public class BookVm
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public string ?Topic { get; set; }

        public int AuthorId { get; set; }

        public int PublishYear { get; set; }

        public decimal Price { get; set; }

        public int Rating { get; set; }
    }
}
