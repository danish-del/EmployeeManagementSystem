using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repository
{
        public class EmployeeRepository : IEmployeeRepository
        {
            private readonly AppDbContext _context;

            public EmployeeRepository(AppDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Employee>> GetAll()
                => await _context.Employees.ToListAsync();

        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task Add(Employee employee)
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
            }

            public async Task Update(Employee employee)
            {
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
            }

            public async Task Delete(int id)
            {
                var emp = await _context.Employees.FindAsync(id);
                _context.Employees.Remove(emp);
                await _context.SaveChangesAsync();
            }
        }
    }

