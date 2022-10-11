using CrudAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CrudAngular.Controllers
{
    [RoutePrefix("Api/Employee")]
   
    public class EmployeeController : ApiController
    {
        CrudAngularEntities entity = new CrudAngularEntities();

        [HttpGet]
        [Route("AllEmployeeDetails")]
        public IQueryable<EmployeeAllDetail> GetEmployee()
        {
            try
            {
                return entity.EmployeeAllDetails;

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetEmployeeDetailsById/{employeeId})")]
        public IHttpActionResult GetEmployeeById(string employeeId)
        {
            EmployeeAllDetail emp = new EmployeeAllDetail();
            int ID = Convert.ToInt32(employeeId);
            try
            {
                emp = entity.EmployeeAllDetails.Find(ID);
                if (emp == null)
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {
                throw;
            }
            return Ok(emp);
        }

        [HttpPost]
        [Route("InsertEmployeeDetails")]
        public IHttpActionResult PostEmployee(EmployeeAllDetail data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                entity.EmployeeAllDetails.Add(data);
                entity.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
            return Ok(data);
        }

        [HttpPut]
        [Route("UpdateEmployeeDetails")]
        public IHttpActionResult PutEmployee(EmployeeAllDetail employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                EmployeeAllDetail emp = new EmployeeAllDetail();
                emp = entity.EmployeeAllDetails.Find(employee.EmpId);
                if (employee != null)
                {
                    emp.EmpName = employee.EmpName;
                    emp.DateOfBirth = employee.DateOfBirth;
                    emp.EmailId = employee.EmailId;
                    emp.Address = employee.Address;
                    emp.Gender = employee.Gender;
                    emp.Pincode = employee.Pincode;
                }
                int i = this.entity.SaveChanges();


            }
            catch (Exception)
            {
                throw;
            }
            return Ok(employee);
        }
        [HttpDelete]
        [Route("DeleteOfEmployee")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            EmployeeAllDetail emp = entity.EmployeeAllDetails.Find(id);
            if (emp == null)
            {
                return NotFound();
            }
            entity.EmployeeAllDetails.Remove(emp);
            entity.SaveChanges();
            return Ok(emp);
        }
    }
}
