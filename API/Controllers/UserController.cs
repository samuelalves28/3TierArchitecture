using Business.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/adm/cad-usuarios")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAllAsync(CancellationToken cancellationToken)
    {
        return Ok(await userService.GetAllAsync(cancellationToken));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserByIdAsync(int id, CancellationToken cancellationToken)
    {
        return Ok(await userService.GetUserByIdAsync(id, cancellationToken));
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateAsync(User user, CancellationToken cancellationToken)
    {
        return Ok(await userService.CreateAsync(user, cancellationToken));
    }

    [HttpPut]
    public async Task<ActionResult<User>> UpdateAsync(User user, CancellationToken cancellationToken)
    {
        return Ok(await userService.UpdateAsync(user, cancellationToken));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<User>> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        return Ok(await userService.DeleteAsync(id, cancellationToken));
    }
}
