using OfficeManagement.Data;

namespace OfficeManagement.Repositories
{
    public interface ITouristPlaceRepository : IGenericRepository<TouristPlace>
    {

    }

    public class TouristPlaceRepository : GenericRepository<TouristPlace>, ITouristPlaceRepository
    {
        public TouristPlaceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

}
