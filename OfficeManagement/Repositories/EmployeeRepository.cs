using OfficeManagement.Data;

namespace OfficeManagement.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {

    }

    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

}
