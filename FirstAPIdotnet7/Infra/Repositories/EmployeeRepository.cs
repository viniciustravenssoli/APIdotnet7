using FirstAPIdotnet7.Domain.DTOs;
using FirstAPIdotnet7.Domain.Model;

namespace FirstAPIdotnet7.Infra.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void Add(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
        }

        public List<EmployeeDTO> Get(int pageNumber, int pageQuantity)
        {
            return _context.Employees.Skip(pageNumber * pageQuantity).Take(pageQuantity)
                .Select( b => 
                new EmployeeDTO()
                {
                    Id = b.id,
                    NameEmployee = b.name,
                    Photo = b.photo
                })
                .ToList();
        }

        public Employee? Get(int id)
        {
            return _context.Employees.Find(id);
        }
    }
}
