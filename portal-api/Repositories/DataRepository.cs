using PortalApi.Data;
using PortalApi.Models;

namespace PortalApi.Repositories
{
    public interface IDataRepository
    {
        Task<IEnumerable<TableARow>> GetTableAAsync();
        Task<IEnumerable<TableBRow>> GetTableBAsync();
        Task<IEnumerable<TableCRow>> GetTableCAsync();
        Task<ColumnSums> GetColumnSumsAsync();
        Task<IEnumerable<AnimalCount>> GetAnimalCountsAsync();
    }

    public class DataRepository : BaseRepository<object>, IDataRepository
    {
        public DataRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TableARow>> GetTableAAsync()
        {
            return await Task.FromResult(_context.TableA.ToList());
        }

        public async Task<IEnumerable<TableBRow>> GetTableBAsync()
        {
            return await Task.FromResult(_context.TableB.ToList());
        }

        public async Task<IEnumerable<TableCRow>> GetTableCAsync()
        {
            return await Task.FromResult(_context.TableC.ToList());
        }

        public async Task<ColumnSums> GetColumnSumsAsync()
        {
            var data = _context.TableA.ToList();
            return await Task.FromResult(new ColumnSums
            {
                ColumnA = data.Sum(x => x.ColumnA),
                ColumnB = data.Sum(x => x.ColumnB),
                ColumnC = data.Sum(x => x.ColumnC),
                ColumnD = data.Sum(x => x.ColumnD),
                ColumnE = data.Sum(x => x.ColumnE)
            });
        }

        public async Task<IEnumerable<AnimalCount>> GetAnimalCountsAsync()
        {
            var data = _context.TableB.ToList();
            var allAnimals = new List<string>();
            
            foreach (var row in data)
            {
                allAnimals.AddRange(new[] { row.ColumnA, row.ColumnB, row.ColumnC, row.ColumnD, row.ColumnE });
            }

            var animalCounts = allAnimals
                .GroupBy(animal => animal)
                .Select(g => new AnimalCount { Animal = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count);

            return await Task.FromResult(animalCounts);
        }
    }
}