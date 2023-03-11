using Microsoft.AspNetCore.Mvc;
using InterviewTask.WebApi.Interfaces;
using InterviewTask.Common.Models.Responses;
using InterviewTask.Common.Models.DTOs;

namespace InterviewTask.WebApi.Controllers
{
    [Route("api/store/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _service;

        public StatisticsController(IStatisticsService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatisticsResponse>> GetStatistics(int id, DateTime startDate, DateTime endDate)
        {
            var result = await _service.GetStatistics(id, startDate, endDate);
            if (!result.Status)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
