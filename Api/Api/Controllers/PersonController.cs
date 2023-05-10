using Api.ApplicationServices;
using Api.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly LiveServices _liveServices;

    public PersonController(LiveServices liveServices)
    {
        _liveServices = liveServices;
    }

    [HttpPost]
    public async Task<IActionResult> AddPerson(CreatePersonCommand createPersonCommand)
    {
        await _liveServices.HandleCommand(createPersonCommand);
        return Ok(createPersonCommand);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPerson(Guid id)
    {
        var response = await _liveServices.GetPerson(id);
        return Ok(response);
    }
}
