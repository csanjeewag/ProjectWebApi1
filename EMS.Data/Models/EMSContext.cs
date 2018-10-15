using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAPI4.Models
{
    public class EMSContext : DbContext
    {
        //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-RUHANGI\SQLEXPRESS;Initial Catalog=DBApi5;Integrated Security=True");
        //}

        public EMSContext(DbContextOptions<EMSContext> options) : base(options)
        {

        }
       
        public DbSet<Emp> emps { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Position> positions { get; set; }
    }
}
