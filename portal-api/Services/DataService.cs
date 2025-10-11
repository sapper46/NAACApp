using PortalApi.Models;
using PortalApi.Repositories;

namespace PortalApi.Services
{
    public interface IDataService
    {
        Task<IEnumerable<TableARow>> GetTableAAsync();
        Task<IEnumerable<TableBRow>> GetTableBAsync();
        Task<IEnumerable<TableCRow>> GetTableCAsync();
        Task<ColumnSums> GetColumnSumsAsync();
        Task<IEnumerable<AnimalCount>> GetAnimalCountsAsync();
    }

    public class DataService : BaseService, IDataService
    {
        private readonly IDataRepository _dataRepository;

        public DataService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<IEnumerable<TableARow>> GetTableAAsync()
        {
            try
            {
                return await _dataRepository.GetTableAAsync();
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetTableA");
                return new List<TableARow>();
            }
        }

        public async Task<IEnumerable<TableBRow>> GetTableBAsync()
        {
            try
            {
                return await _dataRepository.GetTableBAsync();
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetTableB");
                return new List<TableBRow>();
            }
        }

        public async Task<IEnumerable<TableCRow>> GetTableCAsync()
        {
            try
            {
                return await _dataRepository.GetTableCAsync();
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetTableC");
                return new List<TableCRow>();
            }
        }

        public async Task<ColumnSums> GetColumnSumsAsync()
        {
            try
            {
                return await _dataRepository.GetColumnSumsAsync();
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetColumnSums");
                return new ColumnSums();
            }
        }

        public async Task<IEnumerable<AnimalCount>> GetAnimalCountsAsync()
        {
            try
            {
                return await _dataRepository.GetAnimalCountsAsync();
            }
            catch (Exception ex)
            {
                HandleException(ex, "GetAnimalCounts");
                return new List<AnimalCount>();
            }
        }
    }
}