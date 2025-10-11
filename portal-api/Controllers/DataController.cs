using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalApi.Models;
using PortalApi.Services;

namespace PortalApi.Controllers
{
    [Authorize]
    public class DataController : BaseController
    {
        private readonly IDataService _dataService;

        public DataController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("tablea")]
        public async Task<ActionResult<IEnumerable<TableARow>>> GetTableA()
        {
            try
            {
                var result = await _dataService.GetTableAAsync();
                return HandleResult(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpGet("tableb")]
        public async Task<ActionResult<IEnumerable<TableBRow>>> GetTableB()
        {
            try
            {
                var result = await _dataService.GetTableBAsync();
                return HandleResult(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpGet("tablec")]
        public async Task<ActionResult<IEnumerable<TableCRow>>> GetTableC()
        {
            try
            {
                var result = await _dataService.GetTableCAsync();
                return HandleResult(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpGet("columnsums")]
        public async Task<ActionResult<ColumnSums>> GetColumnSums()
        {
            try
            {
                var result = await _dataService.GetColumnSumsAsync();
                return HandleResult(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpGet("animalcounts")]
        public async Task<ActionResult<IEnumerable<AnimalCount>>> GetAnimalCounts()
        {
            try
            {
                var result = await _dataService.GetAnimalCountsAsync();
                return HandleResult(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}