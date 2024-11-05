using OfficeManagement.Data;
using OfficeManagement.Repositories;

namespace OfficeManagement.Services
{
    public interface ITouristPlaceService
    {
        Task<List<TouristPlace>> GetTouristPlaces();
        Task<TouristPlace> GetTouristPlace(int id);
        Task SaveTouristPlace(TouristPlace touristPlace);
        Task DeleteTouristPlace(TouristPlace touristPlace);
    }

    public class TouristPlaceService : ITouristPlaceService
    {
        private readonly ITouristPlaceRepository _repository;

        public TouristPlaceService(ITouristPlaceRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TouristPlace>> GetTouristPlaces()
        {
            return (List<TouristPlace>) await _repository.GetAll();
        }

        public async Task<TouristPlace> GetTouristPlace(int id)
        {
            return await _repository.Get(id);
        }

        public async Task SaveTouristPlace(TouristPlace touristPlace)
        {
            await _repository.Update(touristPlace);
        }

        public async Task DeleteTouristPlace(TouristPlace touristPlace)
        {
            await _repository.Delete(touristPlace);
        }

    }

}
