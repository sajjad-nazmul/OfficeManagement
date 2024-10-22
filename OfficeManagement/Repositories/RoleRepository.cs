using OfficeManagement.Data;

namespace OfficeManagement.Repositories
{
    public interface IRoleRepository : IGenericRepository<ApplicationUserRole>
    {

    }

    public class RoleRepository : GenericRepository<ApplicationUserRole>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

}
