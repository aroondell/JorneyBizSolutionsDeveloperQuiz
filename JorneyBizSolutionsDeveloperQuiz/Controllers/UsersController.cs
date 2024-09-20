using JourneyBizDatabase;
using JourneyBizDatabase.Entities;
using JourneyBizDatabase.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace JorneyBizSolutionsDeveloperQuiz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly ILogger<UsersController> _logger;
        private JourneyBizDatabaseProvider _databaseProvider;

        public UsersController(ILogger<UsersController> logger, JourneyBizContext journeyBizContext)
        {
            _logger = logger;
            _databaseProvider = new JourneyBizDatabaseProvider(journeyBizContext);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int? id)
        {
            if (id == null) return NotFound();
            return await _databaseProvider.GetById<User>((int)id);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return await _databaseProvider.GetAll<User>();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int? id)
        {
            if (id == null) return NotFound();
            return _databaseProvider.DeleteById<User>((int)id).Result ? Ok() : NotFound();
        }

        [HttpPut(Name = "UpdateUser")]
        public async Task<ActionResult<User>> UpdateUser(User user)
        {
            if (user == null) return NotFound();
            return await _databaseProvider.UpdateRecord<User>(user);
        }

        [HttpPost(Name = "AddUser")]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            if (user == null) return NotFound();
            return await _databaseProvider.UpdateRecord<User>(user);
        }
    }
}