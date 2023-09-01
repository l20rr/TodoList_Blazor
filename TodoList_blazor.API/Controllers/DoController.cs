using Microsoft.AspNetCore.Mvc;
using TodoList_blazor.API.Model;
using TodoList_blazor.Shared;

namespace TodoList_blazor.API.Controllers
{
    [Route("api/dos")]
    [ApiController]
    public class DoController : Controller
    {
        private readonly IDoModel _doModel;
        public DoController(IDoModel doModel)
        {
            _doModel = doModel;
        }
        [HttpGet]
        public IActionResult GetAlldo()
        {
            try
            {
                return Ok(_doModel.GetDos());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching users: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetDoById(int id)
        {
            try
            {
                return Ok(_doModel.GetDo(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching the user: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddDo([FromBody] Do dos)
        {
            var newDo = await _doModel.AddDo(dos);
            return CreatedAtAction(nameof(GetDoById), new { id = newDo.DoId }, newDo);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDo(int id)
        {
            if (id == 0)
                return BadRequest();

            var doToDelete = _doModel.GetDo(id);
            if (doToDelete == null)
                return NotFound();

            _doModel.DeleteDo(id);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            await _doModel.DeleteAll();
            return Ok(); 
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDo(int id, [FromBody] Do dos)
        {
            if (dos == null)
                return BadRequest();



            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var doToUpdate = _doModel.GetDo(dos.DoId);

            if (doToUpdate == null)
                return NotFound();

            _doModel.UpdateDo(dos);

            return NoContent(); 
        }
    }
}
