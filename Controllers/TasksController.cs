using ManagementDesTaches.Models;
using ManagementDesTaches.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManagementDesTaches.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly MTaskContext _context;
        private readonly ILogger<TasksController> _logger;
        public TasksController(MTaskContext context, ILogger<TasksController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/MTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mtask>>> GetTasks()
        {
            _logger.LogInformation($" return all task for database :{ _context.Tasks.ToList()}");
            return await  _context.Tasks.ToListAsync();
        }

        // GET: api/MTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mtask>> GetTask(int id)
        {
            var mTask = await _context.Tasks.FindAsync(id);

            if (mTask == null)
            {
                return NotFound();
            }
            _logger.LogInformation($"return task:{mTask}");

            return mTask;
        }

        // PUT: api/MTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMTask(int id, Mtask mTask)
        {
            if (id != mTask.Id)
            {
                _logger.LogError($"error: task with {id} don't exsit");
                return BadRequest();
            }

            _context.Entry(mTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MTaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mtask>> PostMTask(Mtask mTask)
        {
            _context.Tasks.Add(mTask);
            _logger.LogInformation($" A new user  add :{mTask}");
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMTask", new { id = mTask.Id }, mTask);
        }

        // DELETE: api/MTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMTask(int id)
        {
            var mTask = await _context.Tasks.FindAsync(id);
            if (mTask == null)
            {
                _logger.LogWarning($"you try to delete a task which don't exist in the database:{id}");
                return NotFound();
            }

            _context.Tasks.Remove(mTask);
            _logger.LogInformation($"Delete {mTask.Id} properly");
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MTaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}

