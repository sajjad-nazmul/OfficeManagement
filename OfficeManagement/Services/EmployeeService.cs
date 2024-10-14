using OfficeManagement.Data;
using OfficeManagement.Repositories;

namespace OfficeManagement.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();
        Employee GetEmployee(int id);
        Task SaveEmployee(Employee employee);
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return (List<Employee>) await _repository.GetAll();
        }

        public Employee GetEmployee(int id)
        {
            return _repository.Get(id);
        }

        public async Task SaveEmployee(Employee employee)
        {
            await _repository.Update(employee);
        }

    }

}
