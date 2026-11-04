using Backend.Interface;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IRecordsRepository _repo;

        public RecordsController(IRecordsRepository recordsRepository)
        {
            _repo = recordsRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetRecords([FromQuery] int? id = null)
        {
            if (id is not null)
            {
                Record? record = await _repo.GetRecordAsync(id.Value);

                return record is null ? NoContent() : Ok(record);
            }


            List<Record> records = (await _repo.GetRecordsAsync()).ToList();

            return records.Count == 0 ? NoContent() : Ok(records);
        }

        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //public async Task<IActionResult> GetRecord([FromQuery] int id)
        //{

        //}

    }
}
