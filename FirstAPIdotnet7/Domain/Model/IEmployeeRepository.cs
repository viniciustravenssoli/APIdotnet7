using FirstAPIdotnet7.Domain.DTOs;

namespace FirstAPIdotnet7.Domain.Model
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);

        List<EmployeeDTO> Get(int pageNumber, int pageQuantity);

        Employee? Get(int id);
    }
}
