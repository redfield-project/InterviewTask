namespace InterviewTask.WebApi.Controllers;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InterviewTask.Common.Models;
using InterviewTask.Common.Models.DTOs;
using InterviewTask.WebApi.Interfaces;
using InterviewTask.Common.Models.Responses;

[Route("api/store/[controller]")]
[ApiController]
public class EntryController : ControllerBase
{
    private readonly IEntriesService _service;

    public EntryController(IEntriesService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<BaseResponse>> AddEntry(EntryDTO entry)
    {
        var result = await _service.AddEntry(entry);
        if (!result.Status)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}
