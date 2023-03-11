namespace InterviewTask.WebApi.Controllers;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InterviewTask.Common.Models;
using InterviewTask.Common.Models.DTOs;
using InterviewTask.WebApi.Interfaces;
using InterviewTask.Common.Models.Responses;

[Route("api/[controller]")]
[ApiController]
public class StoreController : ControllerBase
{
    private readonly IStoresService _service;

    public StoreController(IStoresService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<ExtendedResponse>> AddStore(StoreDTO store)
    {
        var result = await _service.AddStore(store);
        if (!result.Status)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StoreResponse>> GetStore(int id)
    {
        var result = await _service.GetStore(id);
        if (!result.Status)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpGet("list")]
    public async Task<ActionResult<int[]>> GetStoresList()
    {
        var result = await _service.GetStoresList();
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ExtendedResponse>> UpdateStore(Store store)
    {
        var result = await _service.UpdateStore(store);
        if (!result.Status)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BaseResponse>> DeleteStore(int id)
    {
        var result = await _service.DeleteStore(id);
        if (!result.Status)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}
