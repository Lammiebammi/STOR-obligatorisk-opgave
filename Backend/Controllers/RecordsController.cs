using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Repository;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private RecordsRepository _repo;

        public RecordsController(RecordsRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Record> Get()
        {
            return _repo.GetAll();
        }
    }
}
