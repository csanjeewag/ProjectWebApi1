using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI4.Models
{
    public class Emp
    {
        [Key]
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpContact { get; set; }
        public string EmpAddress { get; set; }
        public string EmpEmail { get; set; }
        public string EmpPassword { get; set; }

        [ForeignKey("Position")]
        public string PositionPId { get; set; } 

        [ForeignKey("Department")]
        public string DepartmentDprtId { get; set; } 
          

    }
}
 