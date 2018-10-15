using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.DataLayer.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using WebAPI4.Models;

namespace EMS.Service
{
    // [Produces("application/json")]
   // [Route("api/Employee")]
    public class EmployeeServices
    {
        // private readonly DataContext _context;
        private readonly EMSContext _context; 
        public EmployeeServices(EMSContext context)
        {
            _context = context;
        }

       
        public IEnumerable<Emp> GetAll() 
        {

            var corses = _context.emps
                //.Where(c => c.Name.Contains("s"))
                //.OrderByDescending(c => c.Name)
                //.ThenBy(c => c.BlogId)
                .ToList();
            //var employees = _context.Blogs.ToList();

            return corses;

        }

        public Emp GetEmp(string id)
        {

            var corses = _context.emps
                .Where(c => c.EmpId == id).FirstOrDefault();
                //.OrderByDescending(c => c.Name)
                //.ThenBy(c => c.BlogId)
                
            //var employees = _context.Blogs.ToList();

            return corses;

        }

        public Boolean AddEmployee(Emp emp)
        {
            try
            {
                _context.emps.Add(emp);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }


        public Boolean UpdateEmployee(Emp emp)
        {
            try
            {
                _context.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean Login(Login log)
        {
          var data =  _context.emps
                .Where(c => c.EmpId == log.EmpId && c.EmpPassword == log.EmpPassword)
                .Select(c => c.EmpId)
                .FirstOrDefault();
            if (string.IsNullOrEmpty(data))
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }


    }
}