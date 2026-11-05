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
        public async Task<IActionResult> GetRecords([FromQuery] string? title = null, string? artist = null, int? duration = null,
            string? publicationYear = null, string? genre = null, bool singleSearch = false, bool caseSensitive = false)
        {
            if(title is not null || artist is not null || duration is not null || publicationYear is not null || genre is not null)
            {
                List<Record> searchList = _repo.Search(title: title, artist: artist, duration: duration, publicationYear: publicationYear, genre: genre, singleSearch: singleSearch, caseSensitive: caseSensitive).ToList();
                return Ok(searchList);
            }
            List<Record> records = (await _repo.GetRecordsAsync()).ToList();

            return records.Count == 0 ? NoContent() : Ok(records);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetRecordById(int id)
        {
            Record? record = await _repo.GetRecordAsync(id);

            return record is null ? NoContent() : Ok(record);
        }

        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //public async Task<IActionResult> GetRecord([FromQuery] int id)
        //{

        //}

    }
}
