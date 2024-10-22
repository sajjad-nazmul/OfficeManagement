using OfficeManagement.Data;
using OfficeManagement.Repositories;

namespace OfficeManagement.Services
{
    public interface IRoleService
    {
        Task<List<ApplicationUserRole>> GetRoles();
        Task<ApplicationUserRole> GetRole(string id);
        Task SaveRole(ApplicationUserRole role);
        Task DeleteRole(ApplicationUserRole role);
    }

    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ApplicationUserRole>> GetRoles()
        {
            return (List<ApplicationUserRole>) await _repository.GetAll();
        }

        public async Task<ApplicationUserRole> GetRole(string id)
        {
            return await _repository.Get(id);
        }

        public async Task SaveRole(ApplicationUserRole role)
        {
            await _repository.Update(role);
        }

        public async Task DeleteRole(ApplicationUserRole role)
        {
            await _repository.Delete(role);
        }
    }

}
