using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI4.Models;

namespace WebAPI4.Controllers
{
   // [Produces("application/json")]
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {
        private readonly DataContext _context;
        private readonly EmployeeService _service;
        public EmployeeController(DataContext context)
        {
            _context = context;
            _service = new EmployeeService(_context);
        }



        [Produces("application/json")]
        [HttpGet("test")]
        public ActionResult FindAl()
        {
            string id = "1";
            var test = _context.emps
                .Where(c => c.EmpId == id)
                .Join(_context.departments,
                e => e.DepartmentDprtId, d => d.DprtId, (e, d) =>
                   new { e, d})
                .Join(_context.positions,
                    e2=> e2.e.PositionPId,p=>p.PId,(e2,p)
                    => new {e2.e.EmpName,e2.d.DprtName ,p.PName})
                 
                   ; 
                //.Where(c => c.EmpId == id)
                //.Select(c => c.EmpId)
                //.FirstOrDefault(); 
            //if (String.IsNullOrEmpty(id))
           
            
                return Ok(test);
           

        }

        [Produces("application/json")]
        [HttpGet("")]
        public IEnumerable<Emp> FindAll()
        {
            return _service.GetAll();

        }

        [Produces("application/json")]
        [HttpGet("{id}")]
        public Emp FindAl(string id)
        {
            return _service.GetEmp(id); 

        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]
        public IActionResult Create([FromBody]Emp emp)
        {

            if (_service.AddEmployee(emp))
            {

                return Ok(emp);
            }
            else
            {
                return BadRequest("there error");
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("update")]
        public IActionResult Update([FromBody]Emp emp)
        {

            if (_service.UpdateEmployee(emp))
            {

                return Ok(emp);
            }
            else
            {
                return BadRequest("there error");
            }
        }

        [Produces("application/json")] 
        [Consumes("application/json")]
        [HttpPost("login")]
        public IActionResult login([FromBody]Login logins)  
        {

            if (_service.Login(logins))
            {
               var data= _service.GetEmp(logins.EmpId);
               var datas = data.PositionPId;
               var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJJZCI6IjEiLCJSb2xlIjoiQUQifQ.pxr1s84Ir1_6-0yglIfRYIfadYPPjhOg1UtmgCcuekQ";
                var token2 = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJJZCI6IjEiLCJSb2xlIjoiUkMifQ.cKKLvKDdoLWqkmNFuA_OYxnqnGlxWiUzVsFnA0YxusQ";
                return Ok(token2); 
            }
            else
            {
                return BadRequest("there error");
            }
        }

    }
}