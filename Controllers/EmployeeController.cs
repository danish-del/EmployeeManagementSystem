using EmployeeManagementSystem.Entities;
using EmployeeManagementSystem.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
        [ApiController]
        [Route("api/employees")]
        public class EmployeesController : ControllerBase
        {
            private readonly IEmployeeRepository _repo;

            public EmployeesController(IEmployeeRepository repo)
            {
                _repo = repo;
            }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.GetAll());
        }


        [HttpPost]
            public async Task<IActionResult> Create(Employee emp)
            {
                await _repo.Add(emp);
                return Ok(emp);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, Employee emp)
            {
                emp.Id = id;
                await _repo.Update(emp);
                return Ok(emp);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                await _repo.Delete(id);
                return Ok();
            }
        }

    }