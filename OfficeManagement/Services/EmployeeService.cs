using OfficeManagement.Data;
using OfficeManagement.Repositories;

namespace OfficeManagement.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
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

        public async Task<Employee> GetEmployee(int id)
        {
            return await _repository.Get(id);
        }

        public async Task SaveEmployee(Employee employee)
        {
            await _repository.Update(employee);
        }

    }

}
