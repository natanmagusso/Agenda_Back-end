using Agenda_API6.Domain.Interfaces;
using Agenda_API6.Repositories.Requests;
using Agenda_API6.Repositories.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Agenda_API6.Controllers
{
    /// <summary>
    /// Schedule data transaction methods control class.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        /// <summary>
        /// Variable declaration referring to the ILogger class.
        /// </summary>
        private readonly ILogger<SchedulesController> _logger;

        /// <summary>
        /// Variable declaration referring to the ISchedule class.
        /// </summary>
        private readonly ISchedule _scheduleInterface;

        /// <summary>
        /// Receives the instance of the ILogger and ISchedule classes.
        /// </summary>
        public SchedulesController(ILogger<SchedulesController> logger, ISchedule scheduleInterface)
        {
            _logger = logger;
            _scheduleInterface = scheduleInterface;
        }

        /// <summary>
        /// Method GetAll.
        /// </summary>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                List<ScheduleResponse>? schedules = await _scheduleInterface.GetAllAsync();
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possível consultar os registros: " + ex.Message);
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Method GetId.
        /// </summary>
        /// <param name="id">Field id.</param>
        [HttpGet("GetId/{id}")]
        public async Task<IActionResult> ConsultarAlunoIdAsync([FromRoute] int id)
        {
            try
            {
                ScheduleResponse? schedule = await _scheduleInterface.GetIdAsync(id);
                if (schedule == null) return NotFound();
                return Ok(schedule);
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possível consultar o registro: " + ex.Message);
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Method Insert.
        /// </summary>
        /// <param name="request">Class request.</param>
        [HttpPost("Insert")]
        public async Task<IActionResult> InsertAsync([FromBody] ScheduleRequest request)
        {
            try
            {
                await _scheduleInterface.InsertAsync(request);
                return Ok(request);
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possível inserir o registro: " + ex.Message);
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Method Update.
        /// </summary>
        /// <param name="request">Class request.</param>
        /// <param name="id">Field id.</param>
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] ScheduleRequest request, [FromRoute] int id)
        {
            try
            {
                await _scheduleInterface.UpdateAsync(request, id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possível atualizar o registro: " + ex.Message);
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Method Delete.
        /// </summary>
        /// <param name="id">Field id.</param>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                await _scheduleInterface.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possível excluir o registro: " + ex.Message);
                return new StatusCodeResult(500);
            }
        }
    }
}
