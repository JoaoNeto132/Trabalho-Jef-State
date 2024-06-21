using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrabalhoJef.ModelTask;


namespace TrabalhoJef.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerTask : Controller
    {
        private readonly BancoTask.DbContextTask _context;
        public ControllerTask(BancoTask.DbContextTask context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<TasksModel>> PostTask(TasksModel tasksmodel)
        {
            tasksmodel.State = Enum.TaskState.Created;
            _context.TasksModel.Add(tasksmodel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = tasksmodel.Id }, tasksmodel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TasksModel>> GetTask(int id)
        {
            var tasks = await _context.TasksModel.FindAsync(id);

            if (tasks == null)
            {
                return NotFound();
            }

            return tasks;
        }

        [HttpPut("{id}/start")]
        public async Task<IActionResult> StartTask(int id)
        {
            var tasks = await _context.TasksModel.FindAsync(id);

            if (tasks == null)
            {
                return NotFound();
            }

            // sempre que tiver alguma tarefa criada ele altera
            if (tasks.State == Enum.TaskState.Created)
            {
                tasks.State = Enum.TaskState.InProgress;
                _context.Entry(tasks).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest("A tarefa nao foi iniciada");
            }

            return NoContent();
        }

        [HttpPut("{id}/complete")]
        public async Task<IActionResult> CompleteTask(int id)
        {
            var tasks = await _context.TasksModel.FindAsync(id);

            if (tasks == null)
            {
                return NotFound();
            }

			// sempre que tiver alguma tarefa em progresso ele altera
			if (tasks.State == Enum.TaskState.InProgress)
            {
                tasks.State = Enum.TaskState.Completed;
                _context.Entry(tasks).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest("A tarefa nao pode ser completada");
            }

            return NoContent();
        }

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelTask(int id)
        {
            var tasks = await _context.TasksModel.FindAsync(id);
            if (tasks == null)
            {
                return NotFound();
            }
            // cancela a tarefa caso estiver em progresso ou criada
            if (tasks.State == Enum.TaskState.Created || tasks.State == Enum.TaskState.InProgress)
            {
                tasks.State = Enum.TaskState.Canceled;
                _context.Entry(tasks).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest("A tarefa nao foi cancelada");
            }

            return NoContent();
        }
    }
}
