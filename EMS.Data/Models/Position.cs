using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI4.Models
{
    public class Position
    {
        [Key]
        public string PId { get; set; }
        public string PName { get; set; }
        public string Roles { get; set; }
        public ICollection<Emp> Emp { get; set; }
    }
}
