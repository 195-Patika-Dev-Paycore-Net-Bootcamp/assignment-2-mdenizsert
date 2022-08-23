using System.Text.Json;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Odev2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private List<Staff> _staffs;
        private IValidator <Staff> _validator;

        public StaffController( IValidator<Staff> validator)
        {
            _staffs = new List<Staff>();
            _validator = validator;

            Staff staff1 = new Staff()
            {
                Id = 1,
                Name = "Mustafa",
                Lastname = "Sert",
                Email = "sertmustafadeniz@gmail.com",
                DateOfBirth = new DateTime(1998, 03, 10),
                PhoneNumber = "+905385028964",
                Salary = 10000
            };
            _staffs.Add(staff1);
        }

        [HttpGet("get")]
        public List<Staff> Get()
        {


            return _staffs;
        }

        [HttpGet("getbyid")]
        public Staff GetById(int id)
        {
            var result = _staffs.FirstOrDefault(x => x.Id == id);

            return result;
        }

        
        [HttpPost("add")]
        public IActionResult Add([FromBody] Staff staff)
        {
            ValidationResult result = _validator.Validate(staff);

            if (result.IsValid)
            {
                _staffs.Add(staff);

                return Ok();
            }
           
            return BadRequest();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromBody] Staff staff)
        {
            var result = _staffs.FirstOrDefault(x => x.Id == staff.Id);
            _staffs.Remove(result);

            return Ok();
        }

        [HttpPut("put")]
        public IActionResult Put([FromBody] Staff staff)
        {
            var result = _staffs.FirstOrDefault(x => x.Id == staff.Id);
            result.Name = staff.Name;
            result.Lastname = staff.Lastname;
            result.DateOfBirth = staff.DateOfBirth;
            result.Email = staff.Email;
            result.PhoneNumber = staff.PhoneNumber;
            result.Salary = staff.Salary;

            return Ok();
        }
    }
}
