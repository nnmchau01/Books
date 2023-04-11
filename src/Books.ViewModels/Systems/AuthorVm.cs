using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.ViewModels.Systems
{
    public class AuthorVm
    {
        public int Id { get; set; }

        public string ?Name { get; set; }

        
        public bool Female { get; set; }

        
        public int Born { get; set; }

        public int Died { get; set; }
    }
}
